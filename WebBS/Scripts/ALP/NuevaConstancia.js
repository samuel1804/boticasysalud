$(document).ready(function () {

    $("#btnGuardar").on("click", GuardarConstancia);

    function GuardarConstancia() {
        var arrInsumos = new Array();

        var tmpCodInsumo = "";
        var isValid = true;

        $("#tbConstanciaInsumoContent tr").each(function (index, value) {
            var row = $(value);
            var tds = row.find("td");

            $input = row.find("input[type='number']").val();

            var cantidad = parseInt($input);

            var codInsumo = $.trim($(tds[0]).text());
            var cantOrden = $.trim($(tds[3]).text());
            var cantConstancia = cantidad;
            var cantDiferencia = $.trim($(tds[5]).text());

            if (cantConstancia < cantOrden) {
                tmpCodInsumo = codInsumo;
                isValid = false;
                return false;
            }

            arrInsumos.push(codInsumo + "|" + cantOrden + "|" + cantConstancia + "|" + cantDiferencia);
        });

        if (!isValid)
        {
            bootbox.alert("La cantidad real no puede ser menor a la cantidad solicitada del insumo : " + tmpCodInsumo);
            return;
        }

        var nroOrden = $("#txtNroOrden").val();

        var params = { nroOrden: nroOrden, insumos: arrInsumos };
        var data = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "/Constancia/Guardar",
            data: data,
            contentType: "application/json; charset=utf-8",
            DataType: "json",
            error: function (data) {
                console.log(data);
            },
            success: function (data) {

                console.log(data.Success);

                if (data.Success) {
                    bootbox.alert("Se registró satisfactoriamente la Constancia de Preparado : " + data.Object, function () {
                        window.location.replace("/Constancia/Index");
                    });
                }

            }
        });
    }

});

function calcularDiferencia(input) {

    var cantReal = parseInt($.trim($(input).val()));

    var $row = $(input).closest("tr"),
        $tds = $row.find("td");

    var row = {};

    $.each($tds, function (index, value) {

        var valor = $.trim($(value).text());

        switch (index) {
            case 0:
                row.codInsumo = valor;
                break;
            case 1:
                row.nomInsumo = valor;
                break;
            case 2:
                row.unidadMedida = valor;
                break;
            case 3:
                row.cantidad = parseInt(valor);
                break;
            case 4:
                row.cantidadReal = isNaN(cantReal) ? 0 : cantReal;
                break;
            case 5:
                row.diferencia = parseInt(valor);
                break;
        }
    });

    var diferencia = row.cantidadReal - row.cantidad;

    $($tds[$tds.length - 1]).text(diferencia.toString());

}