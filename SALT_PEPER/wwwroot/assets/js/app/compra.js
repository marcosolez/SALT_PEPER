let JSONListadoIngredientes = [];
const PK = Number($("#PK").val());
let subTotal = 0;

$(document).ready(function () {

 
    if (JSONProductos === null)
        JSONProductos = [];

    if (JSONProductos.length > 0) {


        JSONProductos.forEach(x => {
            const ingrediente = JSONIngrediente.find(y => y.pk === Number(x.fkingrediente));
            const unidadMedida = JSONUnidadMedida.find(y => y.pk === ingrediente.fkunidadmedida);

            var obj = {
                FKINGREDIENTE: ingrediente.pk,
                INGREDIENTE: ingrediente.nombre,
                FKUNIDADMEDIDA: unidadMedida.pk,
                UNIDADMEDIDA: x.nombre,
                CANTIDADUNIDAD: Number(x.cantidadunidad),
                PRECIO: Number(x.precio),
                SUBTOTAL: Number(x.cantidadunidad) * Number(x.precio),
            }
            JSONListadoIngredientes.push(obj);
        });
        CrearFilas(false);
    }
})

$("#btnAgregar").click(function () {
    AgregarIngrediente();
});


$("#txtPrecio").keyup(function (e) {
    subTotal = Number($(this).val()) * Number($("#txtCantidad").val());
    $("#txtSubTotal").val(subTotal);
});
$("#txtCantidad").keyup(function (e) {
    subTotal = Number($(this).val()) * Number($("#txtCantidad").val());
    $("#txtSubTotal").val(subTotal);
})

$("#btnGuardar").click(function (e) {
    e.preventDefault();

    if (!ValidaGuardarCompra())
        return;

    const obj = {
        PK: Number($("#PK").val()),
        NUMFACTURA: $("#NUMFACTURA").val(),
        FKPROVEEDOR: Number($("#FKPROVEEDOR").val()),
        USERNAME: $("#USERNAME").val(),
        ESTADO: true,
        DETALLECOMPRADTO: JSONListadoIngredientes
    };

    $.ajax({
        url: '/Compras/GuardaCompra',
        type: 'POST',
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(obj),
        success: function (resp) {
            if (resp.data) {
                Swal.fire(
                    'Registro guardado satisfactoriamente',
                    '',
                    'success'
                ).then(function (x) {
                    window.location = "/Compras";
                });

            }
        },
        error: function (jqXhr, textStatus, errorThrown) {
            Swal.fire(
                'Error al guardar el registro',
                '',
                'error'
            )
        },
        complete: function (e) {

        }
    });

});

function ValidaGuardarCompra() {


    if (!$("#formCompra").valid()) {
        return false;
    }

    console.log("VALOR")

    let isValid = true;
    if (JSONListadoIngredientes.length === 0) {
        toastr.warning("Debe de agregar al menos un producto", "Información faltante");
        isValid = false;
    }
    return isValid;
}



function AgregarIngrediente() {
    const valIngrediente = $("#FKINGREDIENTE").val();
    const valCantidad = $("#txtCantidad").val();
    const valPrecio = $("#txtPrecio").val();

    let IsValid = true;
    if (valIngrediente === "") {
        $("#valiIngrediente").text("Campo requerido");
        IsValid = false;
    } else {
        $("#valiIngrediente").text("");
    }
    if (valCantidad === "") {
        $("#valiCantidad").text("Campo requerido");
        IsValid = false;
    }
    else {
        $("#valiCantidad").text("");
    }
    if (Number(valCantidad) <= 0) {
        $("#valiCantidad").text("La cantidad debe ser mayor a  0");
        IsValid = false;
    }
    else {
        $("#valiCantidad").text("");
    }

    if (Number(valPrecio) <= 0) {
        $("#valPrecio").text("La cantidad debe ser mayor a  0");
        IsValid = false;
    }
    else {
        $("#valPrecio").text("");
    }

    if (valPrecio === "") {
        $("#valiPrecio").text("Campo requerido");
        IsValid = false;
    } else {
        $("#valiPrecio").text("");
    }

    if (!IsValid) {
        return;
    } else {
        $("#valiIngrediente").text("");
        $("#valiCantidad").text("");
        $("#valiCantidad").text("");
    }



    if (VerificaSiExisteIngrediente(Number(valIngrediente))) {
        toastr.warning("El producto ya existe", "Duplicado");
        return;
    }



    const ingrediente = JSONIngrediente.find(x => x.pk === Number(valIngrediente));
    const unidadMedida = JSONUnidadMedida.find(x => x.pk === ingrediente.fkunidadmedida);

    var obj = {
        FKINGREDIENTE: ingrediente.pk,
        INGREDIENTE: ingrediente.nombre,
        FKUNIDADMEDIDA: unidadMedida.pk,
        UNIDADMEDIDA: unidadMedida.nombre,
        CANTIDADUNIDAD: Number(valCantidad),
        PRECIO: Number(valPrecio),
        SUBTOTAL: Number(valCantidad) * Number(valPrecio),
    }
    $("#txtPrecio").val("");
    $("#txtCantidad").val("");
    JSONListadoIngredientes.push(obj);
    CrearFilas(true);
}


function CrearFilas(isEditable) {
    $("#bodyIngredientes").html("");
    let row = "";
    let cont = 0;
    let total = 0;

    var iconDelete = "";

    JSONListadoIngredientes.forEach(x => {
        cont++;

        if (isEditable) {
            iconDelete = `<td style="cursor:pointer" onClick="deleteIngrediente(${x.FKINGREDIENTE})" ><i class="bx bx-trash bx-sm"></i></td>`;
        } else {
            iconDelete = `<td><i class="bx bx-lock-alt bx-sm"></i></td>`;
        }

        row += `<tr >
                    <td>${cont}</td>
                    <td>${x.INGREDIENTE}</td>
                    <td>${x.UNIDADMEDIDA}</td>
                    <td>${x.CANTIDADUNIDAD}</td>
                    <td>C$ ${x.PRECIO.toFixed(2)}</td>
                    <td>C$ ${x.SUBTOTAL.toFixed(2)}</td>`;
                
        row += iconDelete;
        row += "</tr>";

        total += x.SUBTOTAL;
    });
    $("#bodyIngredientes").html(row);
    $("#txtTotal").html(`C$ ${total.toFixed(2)}`);


}

function deleteIngrediente(valor) {

    Swal.fire({
        title: "Eliminar registro",
        text: "¿Está seguro que desea eliminar este registro?",
        icon: "warning",
        showCancelButton: !0,
        confirmButtonColor: "#34c38f",
        cancelButtonColor: "#f46a6a",
        confirmButtonText: "Si, eliminar",
        cancelButtonText: "Cancelar"
    }).then(function (t) {
        if (t.isConfirmed) {
            const filtrado = JSONListadoIngredientes.filter(function (el) { return el.FKINGREDIENTE != valor; });
            JSONListadoIngredientes = filtrado;
            CrearFilas();
        }
    });

}

function VerificaSiExisteIngrediente(id) {

    const existe = JSONListadoIngredientes.find(x => x.FKINGREDIENTE === id);
    if (existe)
        return true;

    return false;
}

