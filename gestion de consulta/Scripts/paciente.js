function Add() {
    var res = validateRegistro();
    if (res == false) {
        return false;
    }
    $('#bregistro').attr("disabled", true);
    var empObj = {
        cedula: $('#Cedula').val(),
        nombres: $('#Nombres').val(),
        apellidos: $('#Apellidos').val(),
        clave: $('#Contraseña').val(),
        telefono: $('#Telefono').val(),
        id_rol: 1,
        correo: $('#Correo').val()
    };
    $.ajax({
        url: "/Paciente/Registro",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result == "Save") {
                swal({
                    title: "Registro",
                    text: "Exitoso",
                    icon: "success",
                    button: "Aceptar",
                }).then(function (isConfirm) {
                    if (isConfirm) {
                        window.location.href = "/Login/Login";
                    }
                })
            } else {
                swal("ERROR", "Usuario ya existe", "error");
                //clearTextBoxRegistro();
                $('#bregistro').attr("disabled", false);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function validateRegistro() {
    var email = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    var cedula = /^[0-9]{6,10}$/;
    var nombres = /^[a-zA-Z\s]+$/;

    var isValid = true;

    if (!cedula.test($('#Cedula').val())) {
        $('#Cedula').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Cedula').css('border-color', 'lightgrey');
    }

    if (!cedula.test($('#Telefono').val())) {
        $('#Telefono').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Telefono').css('border-color', 'lightgrey');
    }

    if ($('#Contraseña').val().trim() == "") {
        $('#Contraseña').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Contraseña').css('border-color', 'lightgrey');
    }
    if (!nombres.test($('#Nombres').val())) {
        $('#Nombres').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Nombres').css('border-color', 'lightgrey');
    }
    if (!nombres.test($('#Apellidos').val())) {
        $('#Apellidos').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Apellidos').css('border-color', 'lightgrey');
    }

    if (!email.test($('#Correo').val())) {
        $('#Correo').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Correo').css('border-color', 'lightgrey');
    }


    return isValid;
}