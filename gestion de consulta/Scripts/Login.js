function Login() {

    var res = validatelogin();
    if (res == false) {
        return false;
    }
    $('#blogin').attr("disabled", true);
    var Usuario = {
        cedula: $('#l_identificacion').val(),
        clave: $('#l_contraseña').val()
    };
    $.ajax({
        url: "/Login/Login",
        data: JSON.stringify(Usuario),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result == "no existe") {
                swal({
                    title: "Error",
                    text: "Usuario o Contraseña invalida",
                    icon: "error",
                    button: "Aceptar",
                }).then(function (isConfirm) {
                    if (isConfirm) {
                        clearTextBox();
                        $('#blogin').attr("disabled", false);
                    }
                })
            } else if (result == "1") {

                window.location.href = "/Paciente/Inicio";

            } else if (result == "2") {

                window.location.href = "/Medico/Inicio";

            } else if (result == "3") {

                window.location.href = "/Funcionario/Inicio";

            } else {

                window.location.href = "/Administrador/Inicio";
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function validatelogin() {
    var cedula = /^[0-9]{6,10}$/;

    var isValid = true;
    if (!cedula.test($('#l_identificacion').val())) {
        $('#l_identificacion').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#l_identificacion').css('border-color', 'lightgrey');
    }


    if ($('#l_contraseña').val().trim() == "") {
        $('#l_contraseña').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#l_contraseña').css('border-color', 'lightgrey');
    }

    return isValid;
}

function clearTextBox() {
    $('#l_identificacion').val("");
    $('#l_contraseña').val("");
}