$(document).ready(function () {
    CargarMedicamentos();  
    CargarExamenes();
});


function GuardarHistorial(id) {
    var empObj = {

        cedula_paciente:id,
        antecedentes_familiares: $('#AnteF').val(),
        antecedentes_personales: $('#AnteP').val(),
        cirugias: $('#Cirugias').val(),
        enfermedades_cronicas: $('#EnferC').val(),
        motivo_consulta: $('#MotivoC').val(),
        diagnostico: $('#Diag').val()
    };
    $.ajax({
        url: "/Medico/GuardarHistorial",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}


function GuardarMedicamentos() {  
    var empObj = {
        Codigo_Medicamento: $('select[name="selectmedic"]').val(),
        Cantidad: $('#CantMe').val()
    };
    $.ajax({
        url: "/Medico/GuardarMedicamentos",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
           
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    
}

function CargarMedicamentos() {
    $.ajax({
        url: "/Medico/CargarMedicamentos",
        data: JSON.stringify(),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#combomedicamento').html('');
            $(result).each(function () {
                var option = $(document.createElement('option'));
                option.text(this.Nombre);
                option.val(this.Codigo);
                $("#combomedicamento").append(option);
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



function CargarExamenes() {
    $.ajax({
        url: "/Medico/CargarExamenes",
        data: JSON.stringify(),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#comboexamenes').html('');
            $(result).each(function () {
                var option = $(document.createElement('option'));
                option.text(this.Nombre);
                option.val(this.Codigo);
                $("#comboexamenes").append(option);
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}





function CitasMedico(id) {
    $.ajax({
        url: "/Medico/ConsultarCitas/" + id ,
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

function Historiales() {
    $.ajax({
        url: "/Medico/ConsultarHistorial",
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

function HistorialClinico1(id) {
    $.ajax({
        url: "/Medico/HistorialClinico1/" + id,
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