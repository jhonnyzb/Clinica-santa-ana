
function agendar() {
 window.location.href = "/Paciente/Inicio";
}


$(function () {
    var b = 1;
    $("#datepicker").datepicker({
        minDate: 0,
        changeMonth: true,
        changeYear: true,
        dateFormat: "dd / mm / yy",
        onSelect: function (date) {
            $('#datepicker').css('border-color', 'lightgrey');
            if (b == 0) { $('#cboEjemplo').html('');}
            var empObj = {
                fecha_horario: date
            };
            $.ajax({
                url: "/Paciente/Agendar",
                data: JSON.stringify(empObj),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    if (result.length == 0) { alert("No hay citas para este dia") }
                    $(result).each(function () {
                        var option = $(document.createElement('option'));
                        option.text(this.Nombre);
                        option.val(this.Codigo);
                        $("#cboEjemplo").append(option);
                        b = 0;
                    });
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        },
    });
});

function actualizarUsuario(id) {
    $.ajax({
        url: "/Paciente/V_actualizarDatos/" + id,
        type: "GET",
        //contentType: "application/json;charset=utf-8",
        dataType: "html",
        success: function (result) {
            $(".tbod").html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function AgendarCita() {
    var res=validateFormCita()
    if (res == false) {
        return false;
    }
    var empObj = {
        fecha_horario: $('#datepicker').val(),
        horario: $('select[name="selectbasic"] option:selected').text() 
    };

    $.ajax({
        url: "/Paciente/Agendarcita",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            swal({
                title: "Cita agendada",
                text: result,
                icon: "success",
                button: "Aceptar",
            }).then(function (isConfirm) {
                $('#datepicker').val("");
                $('#cboEjemplo').html('');
            })
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}




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

function validateFormCita() {
    

    var isValid = true;
 
    if ($('#datepicker').val().trim() == "") {
        $('#datepicker').css('border-color', 'Red');
        isValid = false;
    }
    if ($('#cboEjemplo').val().trim() == "") {
        isValid = false;
    }
    return isValid;
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