

$(document).ready(function () {
    $(".select2").select2();
    $("#btnAgregarIngrediente").click(function (e) {
        AgregarIngrediente();
    });

});

let JSONListadoIngredientes = [];

function AgregarIngrediente() {
    const PKIngrediente = Number($("#FkIngrediente").val());
    if (VerificaSiExisteIngrediente(PKIngrediente)) {
        toastr.warning("Duplicado", "El ingrediente ya existe")
        return;
    }

    const objBuscado = selectIngrediente(PKIngrediente);
    var obj = {
        FkIngrediente: objBuscado.FkIngrediente,
        Ingrediente: objBuscado.Ingrediente,
        FkUnidadMedida: objBuscado.FkUnidadMedida,
        UnidadMedida: objBuscado.UnidadMedida,
        Cantidad: Number($("#txtCantidadPorUnidad").val())
    }
    JSONListadoIngredientes.push(obj);
    CrearFilas();
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

toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-top-center",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}


!function (t) {
    "use strict"; function e() { } e.prototype.init = function () {
        t("#sa-basic").on("click", function () {
            Swal.fire({ title: "Any fool can use a computer", confirmButtonColor: "#556ee6" })
        }),
            t("#sa-title").click(function () {
                Swal.fire({ title: "The Internet?", text: "That thing is still around?", icon: "question", confirmButtonColor: "#556ee6" })
            }), t("#sa-success").click(function () {
                Swal.fire({
                    title: "Good job!",
                    text: "You clicked the button!",
                    icon: "success", showCancelButton: !0,
                    confirmButtonColor: "#556ee6",
                    cancelButtonColor: "#f46a6a"
                })
            }),
            t("#sa-warning").click(function () {
                Swal.fire({
                    title: "Are you sure?",
                    text: "You won't be able to revert this!",
                    icon: "warning",
                    showCancelButton: !0,
                    confirmButtonColor: "#34c38f",
                    cancelButtonColor: "#f46a6a",
                    confirmButtonText: "Yes, delete it!"
                }).then(function (t) {
                    t.value && Swal.fire("Deleted!", "Your file has been deleted.", "success")
                })
            }), t("#sa-params").click(function () { Swal.fire({ title: "Are you sure?", text: "You won't be able to revert this!", icon: "warning", showCancelButton: !0, confirmButtonText: "Yes, delete it!", cancelButtonText: "No, cancel!", confirmButtonClass: "btn btn-success mt-2", cancelButtonClass: "btn btn-danger ms-2 mt-2", buttonsStyling: !1 }).then(function (t) { t.value ? Swal.fire({ title: "Deleted!", text: "Your file has been deleted.", icon: "success" }) : t.dismiss === Swal.DismissReason.cancel && Swal.fire({ title: "Cancelled", text: "Your imaginary file is safe :)", icon: "error" }) }) }), t("#sa-image").click(function () { Swal.fire({ title: "Sweet!", text: "Modal with a custom image.", imageUrl: "assets/images/logo-dark.png", imageHeight: 20, confirmButtonColor: "#556ee6", animation: !1 }) }), t("#sa-close").click(function () { var t; Swal.fire({ title: "Auto close alert!", html: "I will close in <strong></strong> seconds.", timer: 2e3, confirmButtonColor: "#556ee6", onBeforeOpen: function () { Swal.showLoading(), t = setInterval(function () { Swal.getContent().querySelector("strong").textContent = Swal.getTimerLeft() }, 100) }, onClose: function () { clearInterval(t) } }).then(function (t) { t.dismiss === Swal.DismissReason.timer && console.log("I was closed by the timer") }) }), t("#custom-html-alert").click(function () { Swal.fire({ title: "<i>HTML</i> <u>example</u>", icon: "info", html: 'You can use <b>bold text</b>, <a href="//Themesbrand.in/">links</a> and other HTML tags', showCloseButton: !0, showCancelButton: !0, confirmButtonClass: "btn btn-success", cancelButtonClass: "btn btn-danger ml-1", confirmButtonColor: "#47bd9a", cancelButtonColor: "#f46a6a", confirmButtonText: '<i class="fas fa-thumbs-up me-1"></i> Great!', cancelButtonText: '<i class="fas fa-thumbs-down"></i>' }) }), t("#sa-position").click(function () { Swal.fire({ position: "top-end", icon: "success", title: "Your work has been saved", showConfirmButton: !1, timer: 1500 }) }), t("#custom-padding-width-alert").click(function () { Swal.fire({ title: "Custom width, padding, background.", width: 600, padding: 100, confirmButtonColor: "#556ee6", background: "#fff url(//subtlepatterns2015.subtlepatterns.netdna-cdn.com/patterns/geometry.png)" }) }), t("#ajax-alert").click(function () { Swal.fire({ title: "Submit email to run ajax request", input: "email", showCancelButton: !0, confirmButtonText: "Submit", showLoaderOnConfirm: !0, confirmButtonColor: "#556ee6", cancelButtonColor: "#f46a6a", preConfirm: function (n) { return new Promise(function (t, e) { setTimeout(function () { "taken@example.com" === n ? e("This email is already taken.") : t() }, 2e3) }) }, allowOutsideClick: !1 }).then(function (t) { Swal.fire({ icon: "success", title: "Ajax request finished!", html: "Submitted email: " + t, confirmButtonColor: "#556ee6" }) }) }), t("#chaining-alert").click(function () {
                Swal.mixin({ input: "text", confirmButtonText: "Next &rarr;", showCancelButton: !0, confirmButtonColor: "#556ee6", cancelButtonColor: "#74788d", progressSteps: ["1", "2", "3"] }).queue([{ title: "Question 1", text: "Chaining swal2 modals is easy" },
                    "Question 2", "Question 3"]).then(function (t) {
                        t.value && Swal.fire({ title: "All done!", html: "Your answers: <pre><code>" + JSON.stringify(t.value) + "</code></pre>", confirmButtonText: "Lovely!", confirmButtonColor: "#556ee6" })
                    })
            }), t("#dynamic-alert").click(function () {
                swal.queue([{
                    title: "Your public IP", confirmButtonColor: "#556ee6", confirmButtonText: "Show my public IP", text: "Your public IP will be received via AJAX request", showLoaderOnConfirm: !0, preConfirm: function () {
                        return new Promise(function (e) {
                            t.get("https://api.ipify.org?format=json").done(function (t) {
                                swal.insertQueueStep(t.ip), e()
                            })
                        })
                    }
                }]).catch(swal.noop)
            })
    }, t.SweetAlert = new e, t.SweetAlert.Constructor = e
}(window.jQuery), function () { "use strict"; window.jQuery.SweetAlert.init() }();