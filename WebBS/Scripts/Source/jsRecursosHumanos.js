
var MantElaborarEvalTecnica = new function () {

    var lastcell = -1;

    listar = function () {

        $("#listaElabDesemTecnico").jqGrid({
            url: "/RecursosHumanos/ElaborarEvalTecnica/selectElaborarEvalTecnica",
            datatype: 'json',
            mtype: 'Get',
            colNames: ['ID', 'Perfil', 'Perfil_Id', 'Criterio', 'Criterio_Id', 'Pregunta', 'Alternativa', 'Alternativa_Id', '', ''],
            colModel: [
                { key: true, hidden: true, name: 'intCod_preg_eva_tec', index: 'intCod_preg_eva_tec' },
                { key: false, name: 'obePerfil.strDesc_perfil', index: 'obePerfil.strDesc_perfil', width: '20%', editable: false },
                { key: false, hidden: true, name: 'obePerfil.intCod_perfil', index: 'obePerfil.intCod_perfil' },
                { key: false, name: 'obeCriterio.strDesc_criterio', index: 'obeCriterio.strDesc_criterio', width: '20%', editable: false },
                { key: false, hidden: true, name: 'obeCriterio.intCod_criterio', index: 'obeCriterio.intCod_criterio' },
                { key: false, name: 'strPregunta', index: 'strPregunta', width: '40%', editable: false },
                { key: false, name: 'obeAlternativa.strDesc_Alternatica', index: 'obeAlternativa.strDesc_Alternatica', width: '10%', editable: false },
                { key: false, hidden: true, name: 'obeAlternativa.intCod_alternativa_evaluaciontec', index: 'obeAlternativa.intCod_alternativa_evaluaciontec' },
                { key: false, name: 'editRow', search: false, index: 'editRow', width: '4%', align: "center", sortable: false },
                { key: false, name: 'deleteRow', search: false, index: 'deleteRow', width: '4%', align: "center", sortable: false }],
            pager: jQuery('#pagerlistaElabDesemTecnico'),
            rowNum: 20,
            rowList: [20, 30, 40],
            scrollOffset: 0,
            rownumbers: true,
            viewrecords: true,
            grouping: true,
            groupingView: {
                groupField: ['obePerfil.strDesc_perfil'],
                groupColumnShow: [false],
                groupText: ['<b>{0} - {1} Registro(s)</b>']
            },
            reloadAfterEdit: true, //seems to have no effect
            reloadAfterSubmit: true, //seems to have no effect
            emptyrecords: 'No existen registros',
            jsonReader: {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: false,
                Id: "1"
            },
            autowidth: true,
            multiselect: false,
            onSelectRow: function (id) {
                if (id && id !== lastcell) {
                    jQuery('#grid').jqGrid('restoreRow', lastcell);
                    jQuery('#grid').jqGrid('editRow', id, true);
                    lastcell = id;
                }
            },
            subGrid: false,
            gridComplete: function () {
                var grid = jQuery("#listaElabDesemTecnico");
                var gridData = grid.jqGrid('getRowData');
                var ids = grid.jqGrid('getDataIDs');
                for (var i = 0; i < ids.length; i++) {

                    
                    var intCod_perfil = gridData[i]["obePerfil.intCod_perfil"];
                    var intCod_criterio = gridData[i]["obeCriterio.intCod_criterio"];
                    var strPregunta = gridData[i]["strPregunta"];
                    var intCod_alternativa = gridData[i]["obeAlternativa.intCod_alternativa_evaluaciontec"];



                    var ID = ids[i];
                    var tagEdit = "<img class='imgMenuButton' src='/Content/images/Editar.png' title='Editar Evaluación' " +
                                       "onclick=\"editar('" + ID + "', '" + intCod_perfil + "', '" + intCod_criterio + "', '" + strPregunta + "', '" + intCod_alternativa + "');\" Style='width: 20px; height: 16px; cursor: pointer;' />";
                    grid.jqGrid('setRowData', ID, { editRow: tagEdit });

                    var tagDelete = "<img class='imgMenuButton' src='/Content/images/Eliminar.gif' title='Eliminar Evaluación' " +
                                       "onclick=\"eliminar('" + ID + "');\" Style='width: 20px; height: 16px; cursor: pointer;' />";
                    grid.jqGrid('setRowData', ID, { deleteRow: tagDelete });
                }

            }
        }).navGrid('#pagerlistaElabDesemTecnico', { edit: false, add: false, del: false, search: false, refresh: false });

        $("#listaElabDesemTecnico").setGridHeight('auto');


    }

    grabar = function () {

        if (document.getElementById("cboPerfil").value == 0)
        {
            alert('Seleccione Perfil');
            return;
        }

        if (document.getElementById("cboCriterio").value == 0) {
            alert('Seleccione Criterio');
            return;
        }

        if ($('#txtPregunta').val().trim() == "") {
            alert('Ingrese Pregunta');
            return;
        }

        if (document.getElementById("cboAlternativa").value == 0) {
            alert('Seleccione Alternativa');
            return;
        }

        $.ajax({
            type: "POST",
            url: "/jsonService.asmx/mantElaborarEvalTecnica",
            data: "{ 'intCod_preg_eva_tec': " + $("#hd_Cod_preg_eva_tec").val() +
                  ", 'strPregunta': '" + $('#txtPregunta').val().trim() +
                  "', 'intCod_criterio': " + document.getElementById("cboCriterio").value +
                  ", 'intCod_alternativa': " + document.getElementById("cboAlternativa").value +
                  ", 'intCod_perfil': " + document.getElementById("cboPerfil").value + " }",

            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var dato = response.d;
                var recepcion = dato.split('|');
                var mensaje = recepcion[0];
                if (mensaje == "") {
                    var url = "/RecursosHumanos/ElaborarEvalTecnica/selectElaborarEvalTecnica";
                    $("#listaElabDesemTecnico").jqGrid('setGridParam', { page: 1, url: url }).trigger("reloadGrid");
                    if ($("#hd_Cod_preg_eva_tec").val() == "0")
                        alert("Se grabó con éxito.");
                    else
                        alert("Se actualizó con éxito.");
                    $("#hd_Cod_preg_eva_tec").val("0");
                    $("#cboPerfil").val("0");
                    $("#cboCriterio").val("0");
                    $("#txtPregunta").val("");
                    $("#cboAlternativa").val("0");
                }
                else {
                    alert(recepcion[1]);
                }
            }
        });


    }

    eliminar = function (ID) {
        $.ajax({
            type: "POST",
            url: "/jsonService.asmx/deleteElaborarEvalTecnica",
            data: "{ 'intCod_preg_eva_tec': " + ID + " }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var dato = response.d;
                var recepcion = dato.split('|');
                var mensaje = recepcion[0];
                if (mensaje == "") {
                    var url = "/RecursosHumanos/ElaborarEvalTecnica/selectElaborarEvalTecnica";
                    $("#listaElabDesemTecnico").jqGrid('setGridParam', { url: url }).trigger("reloadGrid");
                    alert("Se eliminó con éxito.");
                }
                else {
                    alert(recepcion[1]);
                }
            }
        });
        return true;
    }

    editar = function (ID, intCod_perfil, intCod_criterio, strPregunta, intCod_alternativa) {
        $("#hd_Cod_preg_eva_tec").val(ID);
        $("#cboPerfil").val(intCod_perfil);
        $("#cboCriterio").val(intCod_criterio);
        $("#txtPregunta").val(strPregunta);
        $("#cboAlternativa").val(intCod_alternativa);
        return true;
    }

    return {
        sel: listar,
        add: grabar,
        del: eliminar
    };
}();


var MantRegistrarEvalTecnica = new function () {

    grabar = function () {

        if ($('#txtObservacion').val().trim() == "") {
            alert('Ingrese Observación');
            return;
        }

        $.ajax({
            type: "POST",
            url: "/jsonService.asmx/mantElaborarEvalTecnica",
            data: "{ 'intCod_preg_eva_tec': " + $("#hd_Cod_preg_eva_tec").val() +
                  ", 'strPregunta': '" + $('#txtPregunta').val().trim() +
                  "', 'intCod_criterio': " + document.getElementById("cboCriterio").value +
                  ", 'intCod_alternativa': " + document.getElementById("cboAlternativa").value +
                  ", 'intCod_perfil': " + document.getElementById("cboPerfil").value + " }",

            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var dato = response.d;
                var recepcion = dato.split('|');
                var mensaje = recepcion[0];
                if (mensaje == "") {
                    var url = "/RecursosHumanos/ElaborarEvalTecnica/selectElaborarEvalTecnica";
                    $("#listaElabDesemTecnico").jqGrid('setGridParam', { page: 1, url: url }).trigger("reloadGrid");
                    if ($("#hd_Cod_preg_eva_tec").val() == "0")
                        alert("Se grabó con éxito.");
                    else
                        alert("Se actualizó con éxito.");
                    $("#hd_Cod_preg_eva_tec").val("0");
                    $("#cboPerfil").val("0");
                    $("#cboCriterio").val("0");
                    $("#txtPregunta").val("");
                    $("#cboAlternativa").val("0");
                }
                else {
                    alert(recepcion[1]);
                }
            }
        });


    }

    return {
        add: grabar
    };
}();

