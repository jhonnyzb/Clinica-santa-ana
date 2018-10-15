

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