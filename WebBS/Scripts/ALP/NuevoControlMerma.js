var modified = false;

$(document).ready(function () {

    $("#btnGuardar").on("click", ActualizarConstancia);

    function ActualizarConstancia() {

        var arrInsumos = new Array();

        var tmpCodInsumo = "";
        var isValid = true;

        $("#tbConstanciaInsumoContent tr").each(function (index, value) {
            var row = $(value);
            var tds = row.find("td");

            $input = row.find("input[type='text']").val();

            var motivo = $.trim($input);

            var codInsumo = $.trim($(tds[0]).text());
            var cantOrden = $.trim($(tds[3]).text());
            var cantConstancia = $.trim($(tds[4]).text());
            var cantDiferencia = $.trim($(tds[5]).text());

            arrInsumos.push(codInsumo + "|" + cantOrden + "|" + cantConstancia + "|" + cantDiferencia + "|" + motivo);
        });

        if (!isValid) {
            bootbox.alert("La cantidad real no puede ser menor a la cantidad solicitada del insumo : " + tmpCodInsumo);
            return;
        }

        var nroConstancia = $("#txtNroConstancia").val();

        var params = { nroConstancia: nroConstancia, insumos: arrInsumos };
        var data = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "/ControlMerma/Guardar",
            data: data,
            contentType: "application/json; charset=utf-8",
            DataType: "json",
            error: function (data) {
                console.log(data);
            },
            success: function (data) {

                console.log(data.Success);

                if (data.Success) {
                    bootbox.alert("Se registró satisfactoriamente el Control de Merma : " + data.Object, function () {
                        window.location.replace("/ControlMerma/Lista");
                    });
                }

            }
        });

    }

});