let JSONListadoIngredientes = [];
const PK = Number($("#PK").val());
let TIENEINGREDIENTE = $("#TIENEINGREDIENTE").is(':checked');// $("#ISBEBIDA").val();
let isIngredientes = Boolean($("#isIngredientes").val());

$(document).ready(function () {
    $(".select2").select2();
    $("#btnAgregarIngrediente").click(function (e) {
        AgregarIngrediente();
    });


    $("#TIENEINGREDIENTE").prop("checked", TIENEINGREDIENTE);


    if (JSONPlatillo === null)
        JSONPlatillo = [];

    if (!isIngredientes)
        $(".divIngredientes").fadeOut("slow");

    if (JSONPlatillo.length > 0) {


        JSONPlatillo.forEach(x => {

            const objBuscado = selectIngrediente(x.fkingrediente);

            JSONListadoIngredientes.push({
                Pk: x.pk,
                FkIngrediente: objBuscado.FkIngrediente,
                Ingrediente: objBuscado.Ingrediente,
                FkUnidadMedida: objBuscado.FkUnidadMedida,
                UnidadMedida: objBuscado.UnidadMedida,
                Cantidad: x.cantidadunidad
            });
        });
        CrearFilas();
    }

    $("#chkEsBebida").change(function (e) {
        const checked = $(this).is(':checked');
       

        if (JSONListadoIngredientes.length>0 && !checked) {            
            toastr.warning("Elimine primero los ingredientes en la lista", "Advertencia");
            $("#chkEsBebida").prop("checked", true);
            $("#TIENEINGREDIENTE").trigger();
            return;
        }

      
        if (checked) {
            $(".divIngredientes").fadeIn("slow");
            TIENEINGREDIENTE = checked;
        }

        else {
            $(".divIngredientes").fadeOut("slow");
            TIENEINGREDIENTE = checked;
        }

    });



});

$("#btnGuardar").click(function (e) {
    e.preventDefault();


    if (!ValidaGuardarPlatillo())
        return;


    const LISTADOINGREDIENTE = [];
    JSONListadoIngredientes.forEach(x => {
        LISTADOINGREDIENTE.push({
            PK: x.Pk,
            FKINGREDIENTE: Number(x.FkIngrediente),
            CANTIDADUNIDAD: Number(x.Cantidad),
            FKPLATILLO: PK
        })
    });

    const platillosDTO = {
        PK: Number($("#PK").val()),
        NOMBRE: $("#NOMBRE").val(),
        DESCRIPCION: $("#DESCRIPCION").val(),
        PRECIO: Number($("#PRECIO").val()),
        IMAGEN: $("#IMAGEN").val(),
        FKCATEGORIAPLATILLO: Number($("#FKCATEGORIAPLATILLO").val()),
        ESTADO: true,
        LISTADOINGREDIENTE: LISTADOINGREDIENTE
    }
    // const data = JSON.stringify(platillosDTO);

    ///Seccion par ala imagen



    var formData = new FormData();
    formData.append("PK", platillosDTO.PK);
    formData.append("NOMBRE", platillosDTO.NOMBRE);
    formData.append("DESCRIPCION", platillosDTO.DESCRIPCION);
    formData.append("PRECIO", platillosDTO.PRECIO);
    formData.append("FKCATEGORIAPLATILLO", platillosDTO.FKCATEGORIAPLATILLO);
    formData.append("IMAGEN", platillosDTO.IMAGEN);

    var fileUpload = $("#Files").get(0);
    var files = fileUpload.files;
    for (var i = 0; i < files.length; i++)
        formData.append('Files', files[i]);

    let cont = 0;
    LISTADOINGREDIENTE.forEach(x => {
        formData.append("LISTADOINGREDIENTE[" + cont + "].PK", x.PK);
        formData.append("LISTADOINGREDIENTE[" + cont + "].FKINGREDIENTE", x.FKINGREDIENTE);
        formData.append("LISTADOINGREDIENTE[" + cont + "].FKPLATILLO", x.FKPLATILLO);
        formData.append("LISTADOINGREDIENTE[" + cont + "].CANTIDADUNIDAD", x.CANTIDADUNIDAD);
        //
        cont++;
    });


    $.ajax({
        url: '/Platillo/GuardaActualizaPlatillo',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (resp) {
            if (resp.data) {
                Swal.fire(
                    'Registro guardado satisfactoriamente',
                    '',
                    'success'
                ).then(function (x) {
                    window.location = "/Platillo";
                });

                //  window.location = "Platillo/Index";
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

function ValidaGuardarPlatillo() {

    console.log("TIENEINGREDIENTE", TIENEINGREDIENTE);
    if (!$("#formPlatillo").valid()) {
        return false;
    }

    let isValid = true;
    if (JSONListadoIngredientes.length === 0 && TIENEINGREDIENTE) {
        toastr.warning("Debe de agregar al menos un ingrediente", "Información faltante");
        isValid = false;
    }
    return isValid;
}



function AgregarIngrediente() {
    const valIngrediente = $("#FkIngrediente").val();
    const valCantidad = $("#txtCantidadPorUnidad").val();

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
    if (!IsValid) {
        return;
    } else {
        $("#valiIngrediente").text("");
        $("#valiCantidad").text("");
        $("#valiCantidad").text("");
    }



    const PKIngrediente = Number($("#FkIngrediente").val());
    if (VerificaSiExisteIngrediente(PKIngrediente)) {
        toastr.warning("El ingrediente ya existe", "Duplicado");
        return;
    }

    const objBuscado = selectIngrediente(PKIngrediente);
    var obj = {
        PK: 0,
        FkIngrediente: objBuscado.FkIngrediente,
        Ingrediente: objBuscado.Ingrediente,
        FkUnidadMedida: objBuscado.FkUnidadMedida,
        UnidadMedida: objBuscado.UnidadMedida,
        Cantidad: Number($("#txtCantidadPorUnidad").val())
    }
    JSONListadoIngredientes.push(obj);
    CrearFilas();
    $("#FkIngrediente").val("");
    $("#txtCantidadPorUnidad").val("");
    $(".select2").select2();
}

function selectIngrediente(id) {

    const ingrediente = JSONIngrediente.find(x => x.pk === id);
    const unidadMedida = JSONUnidadMedida.find(x => x.pk === ingrediente.fkunidadmedida);
    return {
        FkIngrediente: ingrediente.pk,
        FkUnidadMedida: unidadMedida.pk,
        Ingrediente: ingrediente.nombre,
        UnidadMedida: unidadMedida.nombre
    }
}

function CrearFilas() {
    $("#bodyIngredientes").html("");
    let row = "";
    let cont = 0;
    JSONListadoIngredientes.forEach(x => {
        cont++;
        row += `<tr ><td>${cont}</td>
                <td>${x.Ingrediente}</td>
                <td>${x.UnidadMedida}</td>
                <td>${x.Cantidad}</td>
                <td style="cursor:pointer" onClick="deleteIngrediente(${x.FkIngrediente})" ><i class="fa fa-trash-alt"></i></td></tr>`;
    });
    $("#bodyIngredientes").html(row);
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
            const filtrado = JSONListadoIngredientes.filter(function (el) { return el.FkIngrediente != valor; });
            JSONListadoIngredientes = filtrado;
            CrearFilas();
        }
    });

}

function VerificaSiExisteIngrediente(id) {

    const existe = JSONListadoIngredientes.find(x => x.FkIngrediente === id);
    if (existe)
        return true;

    return false;
}



$('#Files').change(function () {
    const file = this.files[0];
    console.log(file);
    if (file) {
        let reader = new FileReader();
        reader.onload = function (event) {
            $('#imgPreview').attr('src', event.target.result);
        }
        reader.readAsDataURL(file);
    }
});