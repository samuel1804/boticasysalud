$(document).ready(function () {
    
    $("#btnGuardar").on("click", GuardarLibro);

    function GuardarLibro()
    {
        var nroConstancia = $("#txtNroConstancia").val();

        var params = { nroConstancia: nroConstancia };
        var data = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "/Libro/Guardar",
            data: data,
            contentType: "application/json; charset=utf-8",
            DataType: "json",
            error: function (data) {
                console.log(data);
            },
            success: function (data) {

                console.log(data.Success);

                if (data.Success) {
                    bootbox.alert("Se registró satisfactoriamente en el Libro de Receta : " + data.Object, function () {
                        window.location.replace("/Libro/Lista");
                    });
                }

            }
        });
    }

});