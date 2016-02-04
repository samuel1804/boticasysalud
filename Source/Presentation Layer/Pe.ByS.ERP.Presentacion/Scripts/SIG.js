SIG = {
   // verificar existencia de campo en un array, y SI este esta en estado actualizado 
    VarificarExistenciaActualizado: function (Lista, Campos, ValorCampo, Actualizacion, CampoOrden, IdOrdenGrilla) {
        var existe = false;
        var existecampo = true;
        $.each(Lista, function (i, v) {
            $.each(Campos, function (k, c) {
                if (v[c] == ValorCampo[k]) {
                    if (actualizacion) {
                        if (v[CampoOrden] != IdOrdenGrilla) {
                            if (existecampo) {
                                existe = true;
                            }
                        }
                        else {
                            //existecampo = false;
                        }
                    }
                    else {
                        if (existecampo) {
                            existe = true;
                        }
                    }
                }
                else {
                    existe = false;
                    existecampo = false;
                    return;
                }
            });
            if (existe) {
                return true;
            }
            else {
                existecampo = true;
            }
        });
        return existe;
    },
    GrillaVarificarExistencia: function (nombregrilla, Campos, ValorCampo, actualizacion, IdOrdenGrilla) {
        var existe = false;
        var existecampo = true;
        var rowkeys = jQuery("#" + nombregrilla).jqGrid('getGridParam', 'selarrrow');
        $.each(rowkeys, function (i, rowkey) {
            var row = jQuery("#" + nombregrilla).getRowData(rowkey);
            $.each(Campos, function (k, c) {
                if (row[c] == ValorCampo[k]) {
                    if (actualizacion) {
                        if (row[CampoOrden] != IdOrdenGrilla) {
                            if (existecampo) {
                                existe = true;
                            }
                        }
                        else {
                            //existecampo = false;
                        }
                    }
                    else {
                        if (existecampo) {
                            existe = true;
                        }
                    }
                }
                else {
                    existe = false;
                    existecampo = false;
                    return;
                }
            });
            if (existe) {
                return true;
            }
            else {
                existecampo = true;
            }
        });
        return existe;
    },
    //limpia toda la grilla
    ClearGrilla: function (grilla) {
        $("#" + grilla).jqGrid("clearGridData", true);
    },
    SelectRowMSG: function (rowSelect, varios) {
        var msg = "";
        if (rowSelect != null && rowSelect != undefined) {
            if (rowSelect.length == 0) {
                msg = 'Seleccione un item';
            }
            else if (rowSelect.length > 1 && !varios) {
                msg = 'Seleccione solo un item';
            }
        }
        else {
            msg = 'Genere una busqueda';
        }
        return msg;
    },
    ObtenerMax: function (array, IDCampo) {
        var max = 0;
        for (var i = 0; i < array.length; i++) {
            if (array[i][IDCampo] > 0) {
                if (array[i][IDCampo] >= max)
                    max = array[i][IDCampo];
            }
            else {
                if (array[i].ID >= max)
                    max = array[i].ID;
            }
        }
        return max;
    },
    Ajax: function (opciones, successCallback, failureCallback, errorCallback) {

        if (opciones.url == null)
            opciones.url = "";

        if (opciones.parametros == null)
            opciones.parametros = {};

        if (opciones.async == null)
            opciones.async = true;

        if (opciones.datatype == null)
            opciones.datatype = "json";

        if (opciones.contentType == null)
            opciones.contentType = "application/json; charset=utf-8";

        if (opciones.type == null)
            opciones.type = "POST";

        $.ajax({
            type: opciones.type,
            url: opciones.url,
            contentType: opciones.contentType,
            dataType: opciones.datatype,
            async: opciones.async,
            data: opciones.datatype == "json" ? JSON.stringify(opciones.parametros) : opciones.parametros,
            success: function (response) {
                if (successCallback != null && typeof (successCallback) == "function")
                    successCallback(response);
            },
            failure: function (msg) {
                alert(msg);
                if (failureCallback != null && typeof (failureCallback) == "function")
                    failureCallback(msg);
            },
            error: function (xhr, status, error) {
                alert(error);
                if (errorCallback != null && typeof (errorCallback) == "function")
                    errorCallback(xhr);
            }
        });
    },
    Ajax3: function (url, parameters, async) {
        var rsp;
        $.ajax({
            type: "POST",
            url: url,
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: async,
            data: JSON.stringify(parameters),
            success: function (response) {
                rsp = response;
            },
            failure: function (msg) {
                rsp = -1;
            }
        });
        return rsp;
    },
    ParseDate: function (date) {
        var parts = date.split("/");
        var fecha = new Date(parts[1] + "/" + parts[0] + "/" + parts[2]);
        return fecha.getTime();
    },
    ShowAlert: function (dialog, mensaje) {
        if (dialog == '') {
            dialog = 'dialog-alert';
        }

        $('#' + dialog).html("");
        $('#' + dialog).append("<br/>" + mensaje);
        $('#' + dialog).dialog("open");
    },

    CreateDialogs: function (arrayDialog) {

        for (var i = 0; i < arrayDialog.length; i++) {
            if (arrayDialog[i].resizable == null)
                arrayDialog[i].resizable = false;
            $("#" + arrayDialog[i].name).dialog({
                autoOpen: false,
                resizable: arrayDialog[i].resizable,
                closeOnEscape: true,
                height: arrayDialog[i].height,
                width: arrayDialog[i].width,
                title: arrayDialog[i].title,
                modal: true,
                open: function () {
                    //$(this).parent().appendTo($('#aspnetForm'));
                },
                close: function () {
                    
                    var name = $(this).attr('id');
                    var dialogMe = $(this);
                    $.each(arrayDialog, function (index, v) {
                        if (v.name == name) {
                            if (v.closePopUp != null && typeof (v.closePopUp) == "function") {
                                v.closePopUp(name);
                            }
                            else {
                                $("#"+ v.name).dialog("close");
                            }
                        }
                    });
                }
            });
        }
    },
    EditDialogs: function (arrayDialog) {

        for (var i = 0; i < arrayDialog.length; i++) {
            $("#" + arrayDialog[i].name).dialog('option', 'title', arrayDialog[i].title);
            $("#" + arrayDialog[i].name).dialog('option', 'height', arrayDialog[i].height);
            $("#" + arrayDialog[i].name).dialog('option', 'width', arrayDialog[i].width);
        }
    },
    CreateDialogsEjecutar: function (arrayDialog) {

        for (var i = 0; i < arrayDialog.length; i++) {
            $("<div id='" + arrayDialog[i].name + "'></div>").dialog({
                autoOpen: arrayDialog[i].autoOpen == null ? false : arrayDialog[i].autoOpen,
                resizable: false,
                closeOnEscape: true,
                height: arrayDialog[i].height,
                width: arrayDialog[i].width,
                title: arrayDialog[i].title,
                modal: true,
                open: function () {
                    $(this).parent().appendTo($('#aspnetForm'));
                },
                close: function () {
                    var name = $(this).attr('id');

                    $.each(arrayDialog, function (index, v) {

                        if (v.name == name) {
                            if (v.closePopUp != null && typeof (v.closePopUp) == "function") {
                                v.closePopUp();
                            }

                            if (v.destroy)
                                $("#" + name).remove();
                            else
                                $(this).dialog("close");
                            return false;
                        }
                    });
                }
            });
        }
    },
    CreateDialogEliminar: function (dialog, clickEliminarCommand) {
        $("#" + dialog.Name).dialog({
            autoOpen: false,
            resizable: false,
            height: 200,
            width: 280,
            title: dialog.Titulo,
            modal: true,
            open: function () {
                $(this).parent().appendTo($('#aspnetForm'));
                $(this).siblings('.ui-dialog-buttonpane').find('button:eq(1)').focus();
            },
            buttons: [
                {
                    text: dialog.TextoCancelar,
                    click: function () {
                        $(this).dialog("close");
                    }
                },
                {
                    text: dialog.TextoEliminar,
                    click: function () {
                        if (clickEliminarCommand != null && typeof (clickEliminarCommand) == "function")
                            clickEliminarCommand();
                        else
                            eliminar();
                    }
                }
            ]
        });
    },
    CreateDialogsConfirm: function (arrayDialog) {
        var indexButtonSelect = 1;
        for (var i = 0; i < arrayDialog.length; i++) {
            $("#" + arrayDialog[i].name).dialog({
                autoOpen: false,
                resizable: false,
                height: arrayDialog[i].height,
                width: arrayDialog[i].width,
                title: arrayDialog[i].title,
                modal: true,
                buttons: [
                        {
                            text: arrayDialog[i].titleBtn1,
                            click: function () {
                                var name = $(this).attr('id');
                                $.each(arrayDialog, function (index, v) {
                                    if (v.name == name) {
                                        var fun = window[v.strFun];
                                        fun();
                                        return;
                                    }
                                });
                            }
                        },
                        {
                            text: arrayDialog[i].titleBtn2,
                            click: function () {
                                $(this).dialog("close");
                            }
                        }
                ],
                open: function () {
                    $(this).parent().appendTo($('#aspnetForm'));
                    $(this).siblings('.ui-dialog-buttonpane').find('button:eq(0)').focus();
                },
            });
        }
    },
    ObtenerFormulario: function (url, parameters, contenedorInformacion) {
        $.ajax({
            url: url,
            data: parameters,
            cache: false,
            dataType: 'html',
            success: function (result) {
                $('#' + contenedorInformacion).show();
                $('#' + contenedorInformacion).html(result);
            },
            error: function (request, status, error) {
                $('#' + contenedorInformacion).hide();
                alert(request.responseText);
            }
        });
    },

    MostrarInformacion: function (url, parameters, contenedorListado, contenedorInformacion) {
        $.ajax({
            url: url,
            data: parameters,
            cache: false,
            dataType: 'html',
            success: function (result) {
                $('#' + contenedorListado).hide();
                $('#' + contenedorInformacion).show();
                $('#' + contenedorInformacion).html(result);
            },
            error: function (request, status, error) {
                $('#' + contenedorListado).show();
                $('#' + contenedorInformacion).hide();
                alert(request.responseText);
            }
        });
    },

    MostrarInformacionPopup: function (url, parameters, contenedorInformacion) {

        $.ajax({
            url: url,
            data: parameters,
            dataType: 'html',
            async: true,
            cache: false,
            success: function (result) {
                $('#' + contenedorInformacion).html(result);
                $('#' + contenedorInformacion).dialog("open");
            },
            error: function (request, status, error) {
                alert(request.responseText);
            }
        });
    },
    Grilla: function (grilla, pager, identificador, height, width, caption, urlListar, id, colsNames, colsModel, sortName, opciones) {
        debugger;
        var grid = jQuery('#' + grilla);
        var estadoSubGrid = false;

        if (opciones.noregistro == null) {
            opciones.noregistro = false;
        }
        if (opciones.sort == null) {
            opciones.sort = 'desc';
        }
        if (opciones.subGrid != null) {
            estadoSubGrid = true;
        }
        if (opciones.rowNumber == null) {
            opciones.rowNumber = 15;
        }
        if (opciones.rowNumbers == null) {
            opciones.rowNumbers = [opciones.rowNumber, 20, 50, 100, 150];
        }
        if (opciones.rules == null) {
            opciones.rules = false;
        }
        if (opciones.dialogDelete == null) {
            opciones.dialogDelete = 'dialog-delete';
        }
        if (opciones.dialogAlert == null) {
            opciones.dialogAlert = 'dialog-alert';
        }
        if (opciones.search == null) {
            opciones.search = false;
        }
        if (opciones.footerrow == null) {
            opciones.footerrow = false;
        }

        if (opciones.multiselect == null) {
            opciones.multiselect = false;
        }
        if (opciones.agregarBotones == null) {
            opciones.agregarBotones = false;
        }

        if (opciones.GridLocal == null) {
            opciones.GridLocal = false;

            if (opciones.CellEdit == null) {
                opciones.CellEdit = false;
            }
        }

        if (opciones.NuevoCaption == null)
            opciones.NuevoCaption = "Nuevo";

        if (opciones.EditarCaption == null)
            opciones.EditarCaption = "Editar";

        if (opciones.EliminarCaption == null)
            opciones.EliminarCaption = "Eliminar";

        if (opciones.Lenguaje == null)
            opciones.Lenguaje = "es";

        if (opciones.AlertTitle == null)
            opciones.AlertTitle = "Alterta";

        if (opciones.SinRegistro == null)
            opciones.SinRegistro = "Sin registros";

        if (opciones.CustomButtons == null)
            opciones.CustomButtons = {};

        if (opciones.canEventSameRow == null)
            opciones.canEventSameRow = true;

        if (opciones.pgbuttons == null)
            opciones.pgbuttons = true;

        if (opciones.pginput == null)
            opciones.pginput == true;

        if (opciones.refresh == null)
            opciones.refresh == false;

        if (opciones.treeGrid == null)
            opciones.treeGrid = false;

        if (opciones.grouping == null)
            opciones.grouping = false;

        if (opciones.groupingViewOptions == null)
            opciones.groupingViewOptions = new Object()


        langShort = opciones.Lenguaje.split('-')[0].toLowerCase();
        if ($.jgrid.hasOwnProperty("regional") && $.jgrid.regional.hasOwnProperty(opciones.Lenguaje)) {
            $.extend($.jgrid, $.jgrid.regional[opciones.Lenguaje]);
        } else if ($.jgrid.hasOwnProperty("regional") && $.jgrid.regional.hasOwnProperty(langShort)) {
            $.extend($.jgrid, $.jgrid.regional[langShort]);
        }

        //opciones.selectFunc = (opciones.selectFunc == null) ? false : opciones.OnSelect;

        var rowKey;
        var lastRowKey;
        if (!opciones.GridLocal) {
            
            var settingsGrid = {
                prmNames: {
                    search: 'isSearch',
                    nd: null,
                    rows: 'rows',
                    page: 'page',
                    sort: 'sortField',
                    order: 'sortOrder',
                    filters: 'filters'
                },

                postData: { searchString: '', searchField: '', searchOper: '', filters: '' },
                jsonReader: {
                    root: 'rows',
                    page: 'page',
                    total: 'total',
                    records: 'records',
                    cell: 'cell',
                    id: id, //index of the column with the PK in it
                    userdata: 'userdata',
                    repeatitems: true
                },
                pgbuttons: opciones.pgbuttons,
                pginput: opciones.pginput,
                rowNum: opciones.rowNumber,
                rowList: opciones.rowNumbers,
                pager: '#' + pager,
                sortname: sortName,
                viewrecords: true,
                shrinkToFit: opciones.shrinkToFit != null ? opciones.shrinkToFit : true,
                multiselect: opciones.multiselect,
                rownumbers: true,
                sortorder: opciones.sort,
                height: height,
                footerrow: opciones.footerrow,
                width: width,
                autowidth: false,
                colNames: colsNames,
                colModel: colsModel,
                caption: caption,
                subGrid: estadoSubGrid,
                grouping: opciones.grouping,
                groupingView: {
                    groupField: opciones.groupingViewOptions.groupField == null ? [] : opciones.groupingViewOptions.groupField,
                    groupColumnShow: opciones.groupingViewOptions.groupColumnShow == null ? [] : opciones.groupingViewOptions.groupColumnShow,
                    groupText: opciones.groupingViewOptions.groupText == null ? [] : opciones.groupingViewOptions.groupText,
                    groupCollapse: opciones.groupingViewOptions.groupCollapse == null ? false : opciones.groupingViewOptions.groupCollapse,
                    groupOrder: opciones.groupingViewOptions.groupOrder == null ? [] : opciones.groupingViewOptions.groupOrder,
                    groupSummary: opciones.groupingViewOptions.groupSummary == null ? [] : opciones.groupingViewOptions.groupSummary,
                    hideFirstGroupCol: opciones.groupingViewOptions.hideFirstGroupCol == null ? true : opciones.groupingViewOptions.hideFirstGroupCol,
                    groupSummaryPos: opciones.groupingViewOptions.groupSummaryPos == null ? [] : opciones.groupingViewOptions.groupSummaryPos,
                },
                editurl: opciones.EditingOptions ? opciones.EditingOptions.editUrl : '',
                ajaxSelectOptions: { type: "POST", contentType: 'application/json; charset=utf-8', dataType: 'json', },
                subGridRowColapsed: function (subgrid_id, row_id) {
                    var subgrid_table_id, pager_id;
                    subgrid_table_id = subgrid_id + "_t";
                    pager_id = "p_" + subgrid_table_id;
                    jQuery("#" + subgrid_table_id).remove();
                    jQuery("#" + pager_id).remove();
                },
                subGridRowExpanded: function (subgrid_id, row_id) {
                    var subGrid = opciones.subGrid;

                    var subgrid_table_id, pager_id;
                    subgrid_table_id = subgrid_id + "_t";
                    pager_id = "p_" + subgrid_table_id;

                    $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table><div id='" + pager_id + "' class='scroll'></div>");

                    var parameters = { cDocNro: row_id };
                    debugger;
                    $.ajax({
                        type: "POST",
                        url: subGrid.Url,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify(parameters),
                        success: function (rsp) {
                            debugger;
                            var data = (typeof rsp.d) == 'string' ? eval('(' + rsp.d + ')') : rsp.d;
                            $("#" + subgrid_table_id).jqGrid({
                                datatype: "local",
                                colNames: subGrid.ColNames,
                                colModel: subGrid.ColModels,
                                rowNum: 10,
                                rowList: [10, 20, 50, 100],
                                sortorder: "desc",
                                viewrecords: true,
                                rownumbers: true,
                                pager: "#" + pager_id,
                                loadonce: true,
                                sortable: true,
                                height: subGrid.Height,
                                width: subGrid.Width
                            });

                            for (var i = 0; i <= data.length; i++)
                                jQuery("#" + subgrid_table_id).jqGrid('addRowData', i + 1, data[i]);

                            $("#" + subgrid_table_id).trigger("reloadGrid");
                        },
                        failure: function (msg) {
                            debugger_;
                            $('#mensajeFalla').show().fadeOut(8000);
                        }
                    });
                },

                ondblClickRow: function (rowid) {
                    if (opciones.search) {
                        var ret = grid.getRowData(rowid);
                        SelectRow(ret);
                    }

                    if (opciones.EditingOptions != null && opciones.EditingOptions.canEditRowInline) {
                        if (opciones.BeforeEditHandler != null && typeof (opciones.BeforeEditHandler) == "function")
                            opciones.BeforeEditHandler(grid, rowKey);

                        var editparameters = {
                            "keys": true,
                            "oneditfunc": null,
                            "successfunc": opciones.SaveRowInline ? opciones.SaveRowInline : null,
                            "url": opciones.EditingOptions ? opciones.EditingOptions.editUrl : null,
                            "extraparam": {},
                            "aftersavefunc": null,
                            "errorfunc": null,
                            "afterrestorefunc": opciones.AfterSaveRowInline ? opciones.AfterSaveRowInline : null,
                            "restoreAfterError": true,
                            "mtype": "POST"
                        }

                        grid.jqGrid("editRow", rowKey, editparameters);

                        lastRowKey = rowKey;
                    }

                    if (opciones.DblClickHandler != null && typeof (opciones.DblClickHandler) == 'function') {
                        opciones.DblClickHandler(rowid);
                    }
                },
                onSelectRow: function (id) {
                    rowKey = grid.getGridParam('selrow');

                    if (rowKey != null) {
                        $("#" + identificador).val(rowKey);
                    }

                    if (opciones.EditingOptions != null && opciones.EditingOptions.canEditRowInline) {
                        if (lastRowKey !== rowKey) {
                            if (lastRowKey != "undefined") {
                                if ($("tr#" + lastRowKey).attr("editable") === "1") {
                                    grid.jqGrid('restoreRow', lastRowKey);
                                }
                            }
                        }
                    }

                    if (opciones.OnSelectRow != null && typeof (opciones.OnSelectRow) == 'function') {
                        if (opciones.canEventSameRow || (lastRowKey !== rowKey))
                            if (opciones.multiselect == false)
                                opciones.OnSelectRow(id);
                            else
                                opciones.OnSelectRow(id, opciones.nameArraySelected);
                    }
                    lastRowKey = rowKey;
                },
                onSelectAll: opciones.OnSelectAll,
                gridComplete: function () {
                    if ($('#' + grilla).getGridParam('records') == 0) {
                        if (opciones.noregistro == true) {
                            SIG.Alert(opciones.AlertTitle, opciones.SinRegistro, null);
                        }
                    }

                    rowKey = null;
                    if (opciones.agregarBotones == true) {
                        AgregarBotones();
                    }

                    if (opciones.GridCompleteHandler != null && typeof (opciones.GridCompleteHandler) == "function")
                        opciones.GridCompleteHandler(grid);
                },
                datatype : function (postdata) {
                    var migrilla = new Object();
                    migrilla.page = postdata.page;
                    migrilla.rows = postdata.rows;
                    migrilla.sidx = postdata.sortField;
                    migrilla.sord = postdata.sortOrder;
                    migrilla._search = postdata.isSearch;
                    migrilla.filters = postdata.filters;
                    
                    if (opciones.rules != false) {

                        if (opciones.GetRulesMethod == null)
                            opciones.GetRulesMethod = GetRules;
                        var parametroExtra = null;
                        var customRules = opciones.GetRulesMethod(grilla);

                        if (migrilla.filters != "") {

                            parametroExtra = JSON.parse(migrilla.filters);

                            if (customRules != null) {
                                parametroExtra.groups = new Array();

                                if (opciones.AdvancedSearch == true) {
                                    parametroExtra.groups.push(customRules);
                                }
                                else {
                                    var nuevoSubGrupo = { groupOp: 'AND', rules: {} };
                                    nuevoSubGrupo.rules = customRules;

                                    parametroExtra.groups.push(nuevoSubGrupo);
                                }
                            }
                        }
                        else {
                            if (opciones.AdvancedSearch == true && customRules != null)
                                parametroExtra = customRules;
                            else if (customRules != null && customRules.length > 0) {
                                parametroExtra = { groupOp: 'AND', rules: {} };
                                parametroExtra.rules = customRules;
                            }
                        }

                        migrilla.filters = parametroExtra == null ? "" : JSON.stringify(parametroExtra);
                    }

                    if (migrilla._search == true) {
                        migrilla.searchField = postdata.searchField;
                        migrilla.searchOper = postdata.searchOper;
                        migrilla.searchString = postdata.searchString;
                    }

                    var params = { grid: migrilla };

                    $.ajax({
                        url: urlListar,
                        type: 'post',
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify(params),
                        async: false,
                        success: function (data, st) {
                            
                            if (st == 'success') {
                                if (opciones.pivotGridOptions == null) {
                                    var jq = $('#' + grilla)[0];
                                    jq.addJSONData(data);
                                } else {
                                    
                                    if (opciones.pivotGridOptions.colTotals)
                                        settingsGrid.footerrow = true;

                                    grid.jqGrid('jqPivot', data, {
                                    //grid.jqGrid('jqPivot', opciones.pivotGridOptions.urlData+"2?grid=" + gridPivot, {
                                        xDimension: opciones.pivotGridOptions.xDimensionColumns,
                                        yDimension: opciones.pivotGridOptions.yDimensionColumns,
                                        aggregates: opciones.pivotGridOptions.aggregateColumns,
                                        groupSummaryPos: opciones.pivotGridOptions.groupSummaryPos == null ? 'header' : opciones.pivotGridOptions.groupSummaryPos,
                                        colTotals: opciones.pivotGridOptions.colTotals == null ? false : opciones.pivotGridOptions.colTotals,
                                        frozenStaticCols: opciones.pivotGridOptions.frozenStaticCols == null ? false : opciones.pivotGridOptions.frozenStaticCols,
                                        groupSummary: opciones.pivotGridOptions.groupSummary == null ? true : opciones.pivotGridOptions.groupSummary,
                                        rowTotals: opciones.pivotGridOptions.rowTotals == null ? false : opciones.pivotGridOptions.rowTotals,
                                        rowTotalsText: opciones.pivotGridOptions.rowTotalsText == null ? "Total" : opciones.pivotGridOptions.rowTotalsText
                                    }, settingsGrid, opciones.pivotGridOptions.ajaxOptions);
                                }
                            }
                        },
                        error: function (a, b, c) {

                            alert('Error with AJAX callback:' + a.responseText);
                        }
                    });
                }
            };

            grid.jqGrid(settingsGrid);
        }
        else if (opciones.GridLocal) {
            var settingsGrid = {
                colNames: colsNames,
                colModel: colsModel,
                sortorder: opciones.sort,
                pgbuttons: opciones.pgbuttons,
                pginput: opciones.pginput,
                rowNum: opciones.rowNumber,
                rowList: opciones.rowNumbers,
                rownumbers: true,
                cellEdit: opciones.CellEdit,
                cellsubmit: "clientArray",
                pager: '#' + pager,
                sortname: sortName,
                viewrecords: true,
                multiselect: opciones.multiselect,
                sortorder: opciones.sort,
                footerrow: opciones.footerrow,
                height: height,
                width: width,
                gridview: true,
                autowidth: false,
                caption: caption,
                subGrid: estadoSubGrid,
                editurl: opciones.editurl,
                grouping: opciones.grouping,
                groupingView: {
                    groupField: opciones.groupingViewOptions.groupField == null ? [] : opciones.groupingViewOptions.groupField,
                    groupColumnShow: opciones.groupingViewOptions.groupColumnShow == null ? [] : opciones.groupingViewOptions.groupColumnShow,
                    groupText: opciones.groupingViewOptions.groupText == null ? [] : opciones.groupingViewOptions.groupText,
                    groupCollapse: opciones.groupingViewOptions.groupCollapse == null ? false : opciones.groupingViewOptions.groupCollapse,
                    groupOrder: opciones.groupingViewOptions.groupOrder == null ? [] : opciones.groupingViewOptions.groupOrder,
                    groupSummary: opciones.groupingViewOptions.groupSummary == null ? [] : opciones.groupingViewOptions.groupSummary,
                    hideFirstGroupCol: opciones.groupingViewOptions.hideFirstGroupCol == null ? true : opciones.groupingViewOptions.hideFirstGroupCol,
                    groupSummaryPos: opciones.groupingViewOptions.groupSummaryPos == null ? [] : opciones.groupingViewOptions.groupSummaryPos,
                },
                treeGrid: opciones.treeGrid,
                gridComplete: function () {
                    if (opciones.GridCompleteHandler != null && typeof (opciones.GridCompleteHandler) == "function")
                        opciones.GridCompleteHandler();
                },
                loadComplete: function () {
                    if (opciones.LoadCompleteHandler != null && typeof (opciones.LoadCompleteHandler) == "function")
                        opciones.LoadCompleteHandler(this);
                },
                afterSaveCell: function (rowid, cellname, value, iRow, iCol) {
                    if (opciones.AfterSaveCellHandler != null)
                        opciones.AfterSaveCellHandler(rowid, cellname, value, iRow, iCol);
                },
                onSelectRow: function () {
                    rowKey = grid.getGridParam('selrow');

                    if (rowKey != null) {
                        $("#" + identificador).val(rowKey);
                    }
                    if (opciones.selectRowFunc != null) {
                        if (typeof (opciones.selectRowFunc) == 'function') {
                            opciones.selectRowFunc(rowKey)
                        }
                    }
                },
                ondblClickRow: function (rowid) {
                    if (opciones.search) {
                        var ret = grid.getRowData(rowid);
                        SelectRow(ret);
                    }

                    if (opciones.DblClickHandler != null && typeof (opciones.DblClickHandler) == 'function') {
                        opciones.DblClickHandler(rowid);
                    }
                },
                beforeEditCell: function (rowid, cellname, value, iRow, iCol) {
                    if (opciones.BeforeEditCellHandler != null)
                        opciones.BeforeEditCellHandler(rowid, cellname, value, iRow, iCol);
                },
                afterEditCell: function (rowid, cellname, value, iRow, iCol) {
                    if (opciones.AfterEditCellHandler != null)
                        opciones.AfterEditCellHandler(rowid, cellname, value, iRow, iCol);
                },
                rowattr: function (rowId) {
                    if (opciones.RowAttrHandler != null)
                        opciones.RowAttrHandler(rowId);
                }
            };

            if (opciones.pivotGridOptions == null) {
                settingsGrid.datatype = "local";

                grid.jqGrid(settingsGrid);
            } else {
                if (opciones.pivotGridOptions.colTotals)
                    settingsGrid.footerrow = true;

                grid.jqGrid('jqPivot', opciones.pivotGridOptions.urlData, {
                    xDimension: opciones.pivotGridOptions.xDimensionColumns,
                    yDimension: opciones.pivotGridOptions.yDimensionColumns,
                    aggregates: opciones.pivotGridOptions.aggregateColumns,
                    groupSummaryPos: opciones.pivotGridOptions.groupSummaryPos == null ? 'header' : opciones.pivotGridOptions.groupSummaryPos,
                    colTotals: opciones.pivotGridOptions.colTotals == null ? false : opciones.pivotGridOptions.colTotals,
                    frozenStaticCols: opciones.pivotGridOptions.frozenStaticCols == null ? false : opciones.pivotGridOptions.frozenStaticCols,
                    groupSummary: opciones.pivotGridOptions.groupSummary == null ? true : opciones.pivotGridOptions.groupSummary,
                    rowTotals: opciones.pivotGridOptions.rowTotals == null ? false : opciones.pivotGridOptions.rowTotals,
                    rowTotalsText: opciones.pivotGridOptions.rowTotalsText == null ? "Total" : opciones.pivotGridOptions.rowTotalsText
                }, settingsGrid, opciones.pivotGridOptions.ajaxOptions);
            }
        }
        
        grid.jqGrid('navGrid', "#" + pager, {
            edit: false,
            add: false,
            del: false,
            search: opciones.search,
            refresh: false,
        },
        {}, // use default settings for edit
        {}, // use default settings for add
        {}, // delete instead that del:false we need this
        {
            multipleSearch: true,
            beforeShowSearch: function () {
                return true;
            }
        });

        if (opciones.eliminar) {
            $('#' + grilla).navButtonAdd('#' + pager, {
                caption: opciones.EliminarCaption,
                title: opciones.EliminarCaption,
                buttonicon: 'ui-icon-trash',
                position: 'first',
                onClickButton: function () {
                    if (rowKey != null) {
                        $("#" + opciones.dialogDelete).dialog("open");
                    } else {
                        SIG.Alert(opciones.AlertTitle, opciones.Mensaje, null);
                    }
                }
            });
        }

        if (opciones.editar) {
            $('#' + grilla).navButtonAdd('#' + pager, {
                caption: opciones.EditarCaption,
                title: opciones.EditarCaption,
                buttonicon: 'ui-icon-pencil',
                position: 'first',
                onClickButton: function () {
                    if (rowKey != null) {
                        if (opciones.EditarCommand != null && typeof (opciones.EditarCommand) == "function")
                            opciones.EditarCommand(rowKey);
                        else
                            Editar(rowKey);
                    } else {
                        SIG.Alert(opciones.AlertTitle, opciones.Mensaje, null);
                    }
                }
            });
        }

        if (opciones.nuevo) {
            $('#' + grilla).navButtonAdd('#' + pager, {
                caption: opciones.NuevoCaption,
                title: opciones.NuevoCaption,
                buttonicon: 'ui-icon-plus',
                position: 'first',
                onClickButton: function () {
                    if (opciones.NuevoCommand != null && typeof (opciones.NuevoCommand) == "function")
                        opciones.NuevoCommand();
                    else
                        Nuevo();
                }
            });
        }

        if (opciones.CustomButtons) {
            $.each(opciones.CustomButtons, function (index, botonNuevo) {
                $('#' + grilla).navButtonAdd('#' + pager, {
                    caption: botonNuevo.Caption,
                    title: botonNuevo.Title,
                    buttonicon: botonNuevo.ButtonIcon ? botonNuevo.ButtonIcon : 'ui-icon-plus',
                    position: botonNuevo.Position ? botonNuevo.Position : 'first',
                    onClickButton: function () {
                        if (botonNuevo.ClickFunction != null && typeof (botonNuevo.ClickFunction) == "function")
                            botonNuevo.ClickFunction();
                    }
                });
            });
        }

        $('#' + grilla).jqGrid('gridResize', { minWidth: 450, minHeight: 150 });
    },

    GrillaUpgrade: function (opciones) {
        $.jgrid.nav = true;

        var grid = jQuery('#' + opciones.grilla);
        var estadoSubGrid = false;

        if (opciones.hidegrid == null)
            opciones.hidegrid = false;

        if (opciones.noregistro == null) {
            opciones.noregistro = false;
        }
        if (opciones.sort == null) {
            opciones.sort = 'desc';
        }
        if (opciones.subGrid != null) {
            estadoSubGrid = true;
        }
        if (opciones.rowNumber == null) {
            opciones.rowNumber = 15;
        }
        if (opciones.rowNumbers == null) {
            opciones.rowNumbers = [opciones.rowNumber, 20, 50, 100, 150];
        }

        if (opciones.showRowNumbers == null)
            opciones.showRowNumbers = true;

        if (opciones.rules == null) {
            opciones.rules = false;
        }
        if (opciones.dialogDelete == null) {
            opciones.dialogDelete = 'dialog-delete';
        }
        if (opciones.dialogAlert == null) {
            opciones.dialogAlert = 'dialog-alert';
        }
        if (opciones.search == null) {
            opciones.search = false;
        }
        if (opciones.footerrow == null) {
            opciones.footerrow = false;
        }

        if (opciones.multiselect == null) {
            opciones.multiselect = false;
        }
        if (opciones.agregarBotones == null) {
            opciones.agregarBotones = false;
        }
        if (opciones.gridLocal == null) {
            opciones.gridLocal = false;

            if (opciones.cellEdit == null) {
                opciones.cellEdit = false;
            }
        }

        if (opciones.mostrarCaption == null)
            opciones.mostrarCaption = true;

        if (opciones.nuevoCaption == null)
            opciones.nuevoCaption = "Nuevo";

        if (opciones.editarCaption == null)
            opciones.editarCaption = "Editar";

        if (opciones.eliminarCaption == null)
            opciones.eliminarCaption = "Eliminar";

        if (opciones.lenguaje == null)
            opciones.lenguaje = "es-pe";

        if (opciones.alertTitle == null)
            opciones.alertTitle = "Alterta";

        if (opciones.sinRegistro == null)
            opciones.sinRegistro = "Sin registros";

        if (opciones.emptyrecords == null)
            opciones.emptyrecords = 'Sin registros que mostrar';

        if (opciones.refreshtext == null)
            opciones.refreshtext = 'Actualizar';

        if (opciones.customButtons == null)
            opciones.customButtons = {};

        if (opciones.canEventSameRow == null)
            opciones.canEventSameRow = true;

        if (opciones.pgbuttons == null)
            opciones.pgbuttons = true;

        if (opciones.pginput == null)
            opciones.pginput = true;

        if (opciones.height == null)
            opciones.height = 'auto';

        if (opciones.width == null)
            opciones.width = 'auto';

        if (opciones.caption == null)
            opciones.caption = '';

        if (opciones.autowidth == null)
            opciones.autowidth = true;

        if (opciones.treeGrid == null)
            opciones.treeGrid = false;

        if (opciones.forceFit == null)
            opciones.forceFit = true;
        
        if (opciones.shrinkToFit == null)
            opciones.shrinkToFit = true;

        if (opciones.fixed == null)
            opciones.fixed = true;

        if (opciones.viewrecords == null)
            opciones.viewrecords = true;
        
        var rowKey;
        var lastRowKey;

        if (!opciones.gridLocal) {
            grid.jqGrid({
                prmNames: {
                    search: 'isSearch',
                    nd: null,
                    rows: 'rows',
                    page: 'page',
                    sort: 'sortField',
                    order: 'sortOrder',
                    filters: 'filters'
                },
                postData: { searchString: '', searchField: '', searchOper: '', filters: '' },
                jsonReader: {
                    root: 'rows',
                    page: 'page',
                    total: 'total',
                    records: 'records',
                    cell: 'cell',
                    id: opciones.id, //index of the column with the PK in it
                    userdata: 'userdata',
                    repeatitems: true
                },
                sortable: opciones.sortable != null ? opciones.sortable : true,
                emptyrecords: opciones.emptyrecords,
                pgbuttons: opciones.pgbuttons,
                pginput: opciones.pginput,
                rowNum: opciones.rowNumber,
                rowList: opciones.rowNumbers,
                pager: '#' + opciones.pager,
                sortname: opciones.sortName,
                viewrecords: true,
                multiselect: opciones.multiselect,
                rownumbers: true,
                hidegrid: opciones.hidegrid,
                sortorder: opciones.sort,
                height: opciones.height,
                footerrow: opciones.footerrow,
                width: opciones.width,
                autowidth: opciones.autowidth,
                colNames: opciones.colsNames,
                colModel: opciones.colsModel,
                caption: opciones.caption,
                subGrid: estadoSubGrid,
                forceFit: opciones.forceFit,
                shrinkToFit: opciones.shrinkToFit,
                fixed: opciones.fixed,
                editurl: opciones.EditingOptions ? opciones.EditingOptions.editUrl : '',
                ajaxSelectOptions: { type: "POST", contentType: 'application/json; charset=utf-8', dataType: 'json', },
                subGridRowColapsed: function(subgridId) {
                    var subgridTableId = subgridId + "_t";
                    var pagerId = "p_" + subgridTableId;
                    jQuery("#" + subgridTableId).remove();
                    jQuery("#" + pagerId).remove();
                },
                subGridRowExpanded: function(subgridId, rowId) {
                    var subGrid = opciones.subGrid;
                    var subgridTableId = subgridId + "_t";
                    var pagerId = "p_" + subgridTableId;

                    $("#" + subgridId).html("<table id='" + subgridTableId + "' class='scroll'></table><div id='" + pagerId + "' class='scroll'></div>");

                    var parameters = { cDocNro: rowId };
                    $.ajax({
                        type: "POST",
                        url: subGrid.Url,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify(parameters),
                        success: function(rsp) {
                            var data = (typeof rsp.d) == 'string' ? eval('(' + rsp.d + ')') : rsp.d;
                            $("#" + subgridTableId).jqGrid({
                                datatype: "local",
                                colNames: subGrid.ColNames,
                                colModel: subGrid.ColModels,
                                rowNum: 10,
                                rowList: [10, 20, 50, 100],
                                sortorder: "desc",
                                viewrecords: true,
                                rownumbers: true,
                                pager: "#" + pagerId,
                                loadonce: true,
                                sortable: true,
                                height: subGrid.Height,
                                width: subGrid.Width
                            });

                            for (var i = 0; i <= data.length; i++)
                                jQuery("#" + subgridTableId).jqGrid('addRowData', i + 1, data[i]);

                            $("#" + subgridTableId).trigger("reloadGrid");
                        }
                    });
                },
                ondblClickRow: function(rowid) {
                    if (opciones.search) {
                        var ret = grid.getRowData(rowid);
                        SelectRow(ret);
                    }

                    if (opciones.EditingOptions != null && opciones.EditingOptions.canEditRowInline) {
                        if (opciones.BeforeEditHandler != null && typeof(opciones.BeforeEditHandler) == "function")
                            opciones.BeforeEditHandler(rowKey);

                        var editparameters = {
                            "keys": true,
                            "oneditfunc": null,
                            "successfunc": opciones.EditingOptions.SaveRowInline != null ? opciones.EditingOptions.SaveRowInline : null,
                            "url": opciones.EditingOptions.editUrl != null ? opciones.EditingOptions.editUrl : null,
                            "extraparam": {},
                            "aftersavefunc": opciones.EditingOptions.AfterSaveFunc != null ? opciones.EditingOptions.AfterSaveFunc : null,
                            "errorfunc": null,
                            "afterrestorefunc": opciones.EditingOptions.AfterSaveRowInline != null ? opciones.EditingOptions.AfterSaveRowInline : null,
                            "restoreAfterError": true,
                            "mtype": "POST"
                        };
                        grid.jqGrid("editRow", rowKey, editparameters);
                    }

                    if (opciones.DblClickHandler != null && typeof(opciones.DblClickHandler) == 'function') {
                        opciones.DblClickHandler(rowid);
                    }
                    lastRowKey = rowKey;
                },
                beforeSelectRow: function(rowid, e) {
                    if (opciones.BeforeSelectRow != null && typeof(opciones.BeforeSelectRow) == 'function') {
                        opciones.BeforeSelectRow(rowid, e);
                    }
                    return true;
                },
                onSelectRow: function(id) {
                    rowKey = grid.getGridParam('selrow');

                    if (rowKey != null) {
                        $("#" + opciones.identificador).val(rowKey);
                    }

                    if (opciones.EditingOptions != null && opciones.EditingOptions.canEditRowInline) {
                        if (lastRowKey !== rowKey) {
                            if (lastRowKey != null) {
                                var ind = grid.jqGrid('getInd', lastRowKey, true);
                                if (ind != false) {
                                    if ($(ind).attr("editable") === "1") {
                                        grid.jqGrid('restoreRow', lastRowKey);
                                        grid.jqGrid('resetSelection');
                                        rowKey = null;
                                    }
                                }
                            }
                        }
                    }

                    if (opciones.OnSelectRow != null && typeof(opciones.OnSelectRow) == 'function') {
                        if (opciones.canEventSameRow || (lastRowKey !== rowKey))
                            if (opciones.multiselect == false)
                                opciones.OnSelectRow(id);
                            else
                                opciones.OnSelectRow(id, opciones.nameArraySelected);
                    }
                    lastRowKey = rowKey;
                },
                onSelectAll: opciones.OnSelectAll,
                gridComplete: function() {
                    if (grid.getGridParam('records') == 0) {
                        if (opciones.noregistro == true) {
                            SIG.Alert(opciones.alertTitle, opciones.sinRegistro, null);
                        }
                    }

                    rowKey = null;
                    if (opciones.agregarBotones == true) {
                        AgregarBotones();
                    }

                    if (opciones.GridCompleteHandler != null && typeof(opciones.GridCompleteHandler) == "function")
                        opciones.GridCompleteHandler(grid);
                },
                datatype: function (postdata) {
                    var migrilla = new Object();
                    migrilla.Page = postdata.page;
                    migrilla.Rows = postdata.rows;
                    migrilla.Sidx = postdata.sortField;
                    migrilla.Sord = postdata.sortOrder;
                    migrilla.Search = postdata.isSearch;
                    migrilla.Filters = postdata.filters;

                    if (opciones.rules != false) {

                        if (opciones.GetRulesMethod == null)
                            opciones.GetRulesMethod = GetRules;

                        var parametroExtra = null;
                        var customRules = opciones.GetRulesMethod(opciones.grilla, migrilla);

                        if (migrilla.Filters != "") {

                            parametroExtra = JSON.parse(migrilla.Filters);

                            if (customRules != null) {
                                parametroExtra.Groups = new Array();

                                if (opciones.AdvancedSearch == true) {
                                    parametroExtra.Groups.push(customRules);
                                } else {
                                    var nuevoSubGrupo = { GroupOp: 'AND', Rules: {} };
                                    nuevoSubGrupo.Rules = customRules;

                                    parametroExtra.Groups.push(nuevoSubGrupo);
                                }
                            }
                        } else {

                            if (opciones.AdvancedSearch == true && customRules != null)
                                parametroExtra = customRules;
                            else if (customRules != null && customRules.length > 0) {
                                parametroExtra = { groupOp: 'AND', rules: {} };
                                parametroExtra.rules = customRules;
                                
                                if (opciones.defaultRuleSearch != null)
                                    parametroExtra.rules = parametroExtra.rules.concat(opciones.defaultRuleSearch);
                            }
                            else if (opciones.defaultRuleSearch != null)
                                parametroExtra = { groupOp: 'AND', rules: opciones.defaultRuleSearch };
                        }

                        migrilla.Filters = parametroExtra == null ? "" : JSON.stringify(parametroExtra);
                    } else if (migrilla.Filters == "" && opciones.defaultRuleSearch != null) {
                        migrilla.Filters = JSON.stringify({ groupOp: 'AND', rules: opciones.defaultRuleSearch });
                    }

                    if (migrilla._search == true) {
                        migrilla.SearchField = postdata.searchField;
                        migrilla.SearchOper = postdata.searchOper;
                        migrilla.SearchString = postdata.searchString;
                    }

                    var params = { grid: migrilla };

                    $.ajax({
                        url: opciones.urlListar,
                        type: 'post',
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify(params),
                        async: false,
                        success: function(data, st) {
                            if (st == 'success') {
                                var jq = grid[0];
                                jq.addJSONData(data);
                            }
                        },
                        error: function(a, b, c) {

                            alert('Error with AJAX callback:' + a.responseText);
                        }
                    });
                }
            });
        }
        else if (opciones.gridLocal) {
            //opciones.pivotGrid
            var settingsGrid = {
                colNames: opciones.colsNames,
                colModel: opciones.colsModel,
                sortorder: opciones.sort,
                emptyrecords: opciones.emptyrecords,
                pgbuttons: opciones.pgbuttons,
                pginput: opciones.pginput,
                rowNum: opciones.rowNumber,
                rowList: opciones.rowNumbers,
                rownumbers: opciones.showRowNumbers,
                hidegrid: opciones.hidegrid,
                cellEdit: opciones.cellEdit,
                cellsubmit: "clientArray",
                pager: '#' + opciones.pager,
                sortname: opciones.sortName,
                viewrecords: opciones.viewrecords,
                multiselect: opciones.multiselect,
                footerrow: opciones.footerrow,
                height: opciones.height,
                width: opciones.width,
                gridview: true,
                forceFit: opciones.forceFit,
                shrinkToFit: opciones.shrinkToFit,
                fixed: opciones.fixed,
                autowidth: opciones.autowidth,
                caption: opciones.caption,
                subGrid: estadoSubGrid,
                editurl: opciones.editurl,
                treeGrid: opciones.treeGrid,
                gridComplete: function () {
                    if (opciones.GridCompleteHandler != null && typeof (opciones.GridCompleteHandler) == "function")
                        opciones.GridCompleteHandler();
                },
                loadComplete: function () {
                    if (opciones.LoadCompleteHandler != null && typeof (opciones.LoadCompleteHandler) == "function")
                        opciones.LoadCompleteHandler();
                },
                afterInsertRow: function (rowid) {
                    if (opciones.AfterInsertRow != null && typeof (opciones.AfterInsertRow) == "function")
                        opciones.AfterInsertRow(rowid);
                },
                afterSaveCell: function (rowid, cellname, value, iRow, iCol) {
                    if (opciones.AfterSaveCellHandler != null)
                        opciones.AfterSaveCellHandler(rowid, cellname, value, iRow, iCol);
                },
                ondblClickRow: function (rowid) {
                    if (opciones.search) {
                        var ret = grid.getRowData(rowid);
                        SelectRow(ret);
                    }

                    if (opciones.EditingOptions != null && opciones.EditingOptions.canEditRowInline) {
                        if (opciones.BeforeEditHandler != null && typeof (opciones.BeforeEditHandler) == "function")
                            opciones.BeforeEditHandler(rowKey);

                        var editparameters = {
                            "keys": true,
                            "oneditfunc": null,
                            "successfunc": opciones.EditingOptions.SaveRowInline != null ? opciones.EditingOptions.SaveRowInline : null,
                            "url": opciones.EditingOptions.editUrl != null ? opciones.EditingOptions.editUrl : null,
                            "extraparam": {},
                            "aftersavefunc": opciones.EditingOptions.AfterSaveFunc != null ? opciones.EditingOptions.AfterSaveFunc : null,
                            "errorfunc": null,
                            "afterrestorefunc": opciones.EditingOptions.AfterSaveRowInline != null ? opciones.EditingOptions.AfterSaveRowInline : null,
                            "restoreAfterError": true,
                            "mtype": "POST"
                        };
                        grid.jqGrid("editRow", rowKey, editparameters);
                    }

                    if (opciones.DblClickHandler != null && typeof (opciones.DblClickHandler) == 'function') {
                        opciones.DblClickHandler(rowid);
                    }
                    lastRowKey = rowKey;
                },
                onSelectRow: function (id) {
                    rowKey = grid.getGridParam('selrow');

                    if (rowKey != null) {
                        $("#" + opciones.identificador).val(rowKey);
                    }

                    if (opciones.EditingOptions != null && opciones.EditingOptions.canEditRowInline) {
                        if (lastRowKey !== rowKey) {
                            if (lastRowKey != null) {
                                var ind = grid.jqGrid('getInd', lastRowKey, true);
                                if (ind != false) {
                                    if ($(ind).attr("editable") === "1") {
                                        grid.jqGrid('restoreRow', lastRowKey);
                                        grid.jqGrid('resetSelection');
                                        rowKey = null;
                                    }
                                }
                            }
                        }
                    }

                    if (opciones.OnSelectRow != null && typeof (opciones.OnSelectRow) == 'function') {
                        if (opciones.canEventSameRow || (lastRowKey !== rowKey))
                            if (opciones.multiselect == false)
                                opciones.OnSelectRow(id);
                            else
                                opciones.OnSelectRow(id, opciones.nameArraySelected);
                    }
                    lastRowKey = rowKey;
                },
                onSelectAll: opciones.OnSelectAll,
                beforeEditCell: function (rowid, cellname, value, iRow, iCol) {
                    if (opciones.BeforeEditCellHandler != null)
                        opciones.BeforeEditCellHandler(rowid, cellname, value, iRow, iCol);
                },
                afterEditCell: function (rowid, cellname, value, iRow, iCol) {
                    if (opciones.AfterEditCellHandler != null)
                        opciones.AfterEditCellHandler(rowid, cellname, value, iRow, iCol);
                },
                rowattr: function (rowId) {
                    if (opciones.RowAttrHandler != null)
                        opciones.RowAttrHandler(rowId);
                }
            };

            if (opciones.pivotGridOptions == null) {
                settingsGrid.datatype = "local";

                grid.jqGrid(settingsGrid);
            } else {
                if (opciones.pivotGridOptions.colTotals)
                    settingsGrid.footerrow = true;

                grid.jqGrid('jqPivot', opciones.pivotGridOptions.urlData, {
                    xDimension: opciones.pivotGridOptions.xDimensionColumns,
                    yDimension: opciones.pivotGridOptions.yDimensionColumns,
                    aggregates: opciones.pivotGridOptions.aggregateColumns,
                    groupSummaryPos: opciones.pivotGridOptions.groupSummaryPos == null ? 'header' : opciones.pivotGridOptions.groupSummaryPos,
                    colTotals: opciones.pivotGridOptions.colTotals == null ? false : opciones.pivotGridOptions.colTotals,
                    frozenStaticCols: opciones.pivotGridOptions.frozenStaticCols == null ? false : opciones.pivotGridOptions.frozenStaticCols,
                    groupSummary: opciones.pivotGridOptions.groupSummary == null ? true : opciones.pivotGridOptions.groupSummary,
                    rowTotals: opciones.pivotGridOptions.rowTotals == null ? false : opciones.pivotGridOptions.rowTotals,
                    rowTotalsText: opciones.pivotGridOptions.rowTotalsText == null ? "Total" : opciones.pivotGridOptions.rowTotalsText
                }, settingsGrid, opciones.pivotGridOptions.ajaxOptions);
            }
        }

        grid.jqGrid('navGrid', "#" + opciones.pager, {
            edit: false,
            add: false,
            del: false,
            search: opciones.search,
            refresh: opciones.refresh,
            refreshtext: opciones.mostrarCaption ? opciones.refreshtext : '',
            refreshtitle: opciones.refreshtext
        },
        {}, // use default settings for edit
        {}, // use default settings for add
        {}, // delete instead that del:false we need this
        {
            multipleSearch: true,
            beforeShowSearch: function () {
                return true;
            }
        });

        if (opciones.eliminar) {
            grid.navButtonAdd('#' + opciones.pager, {
                id: opciones.eliminarId != null ? opciones.eliminarId : '',
                caption: opciones.mostrarCaption ? opciones.eliminarCaption : '',
                title: opciones.eliminarCaption,
                buttonicon: 'ui-icon-trash',
                position: 'first',
                onClickButton: function () {
                    if (rowKey != null) {
                        var dialogDelete = opciones.dialogDelete;
                        if (dialogDelete != null) {
                            var continuar = true;
                            if (dialogDelete.ContinueDeletingHandler != null && typeof (dialogDelete.ContinueDeletingHandler) == "function")
                                continuar = dialogDelete.ContinueDeletingHandler(rowKey);

                            if (continuar) {
                                var rowData = grid.getRowData(rowKey);

                                var parametrosConfirm = {
                                    dialogText: dialogDelete.dialogText == null ? dialogDelete.DialogGetTextHandler(rowData) : dialogDelete.dialogText,
                                    OkHandlerFunction: dialogDelete.OkHandler,
                                    CancelHandlerFunction: dialogDelete.CancelHandler,
                                    dialogTitle: dialogDelete.dialogTitle,
                                    dialogOkText: dialogDelete.okText,
                                    dialogCancelText: dialogDelete.cancelText,
                                    parametroHandlers: rowData
                                };
                                SIG.confirm(parametrosConfirm);
                            }
                        }
                    } else {
                        SIG.Alert(opciones.alertTitle, opciones.mensaje, null);
                    }
                }
            });
        }

        if (opciones.editar) {
            grid.navButtonAdd('#' + opciones.pager, {
                id: opciones.editarId != null ? opciones.editarId : '',
                caption: opciones.mostrarCaption ? opciones.editarCaption : '',
                title: opciones.editarCaption,
                buttonicon: opciones.editarButtonIcon == null ? 'ui-icon-pencil' : opciones.editarButtonIcon,
                position: 'first',
                onClickButton: function () {
                    if (rowKey != null) {
                        if (opciones.EditarCommand != null && typeof (opciones.EditarCommand) == "function")
                            opciones.EditarCommand(rowKey);
                        else
                            Editar(rowKey);
                    } else {
                        SIG.Alert(opciones.alertTitle, opciones.mensaje, null);
                    }
                }
            });
        }

        if (opciones.nuevo) {
            grid.navButtonAdd('#' + opciones.pager, {
                id: opciones.nuevoId != null ? opciones.nuevoId : '',
                caption: opciones.mostrarCaption ? opciones.nuevoCaption : '',
                title: opciones.nuevoCaption,
                buttonicon: 'ui-icon-plus',
                position: 'first',
                onClickButton: function () {
                    if (opciones.NuevoCommand != null && typeof (opciones.NuevoCommand) == "function")
                        opciones.NuevoCommand(rowKey);
                    else
                        Nuevo(rowKey);
                }
            });
        }

        if (opciones.customButtons) {
            $.each(opciones.customButtons, function (index, botonNuevo) {
                grid.navButtonAdd('#' + opciones.pager, {
                    id: botonNuevo.Id != null ? botonNuevo.Id : '',
                    caption: botonNuevo.Caption,
                    title: botonNuevo.Title,
                    buttonicon: botonNuevo.ButtonIcon ? botonNuevo.ButtonIcon : 'ui-icon-plus',
                    position: botonNuevo.Position ? botonNuevo.Position : 'first',
                    onClickButton: function () {
                        if (botonNuevo.ClickFunction != null && typeof (botonNuevo.ClickFunction) == "function")
                            botonNuevo.ClickFunction(rowKey);
                    }
                });
            });
        }
        grid.jqGrid('gridResize', opciones.resizable == null ? { minWidth: 450, minHeight: 150 } : opciones.resizable);
    },

    UpdateIdsOfSelectedRows: function (id, idsOfSelectedRows) {
        var index = $.inArray(id, idsOfSelectedRows);
        if (index >= 0) {
            var removeMe = -1;
            $.each(idsOfSelectedRows, function (i, v) {
                if (v == id) {
                    removeMe = i;
                }
            });

            if (removeMe != -1) {
                idsOfSelectedRows.splice(removeMe, 1);
            }
        } else if (index < 0) {
            idsOfSelectedRows.push(id);
        }
    },

    IniPopUp: function (main, mainTitle, alerta, msgdelete, mainHeight, mainWidth) {
        $("#" + main).dialog({
            autoOpen: false,
            resizable: false,
            title: mainTitle,
            height: mainHeight,
            width: mainWidth,
            modal: true,
            open: function () {
                $(this).closest('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
                $(this).parent().appendTo($('#aspnetForm'));
            }
        });

        $("#" + alerta).dialog({
            autoOpen: false,
            resizable: false,
            height: 100,
            width: 280,
            title: "Alert",
            modal: true
        });

        $("#" + msgdelete).dialog({
            autoOpen: false,
            resizable: false,
            title: "Eliminar",
            height: "150",
            width: "380",
            modal: true,
            buttons: [
                    {
                        text: "Eliminar",
                        click: function () {
                            Eliminar();
                        }
                    },
                    {
                        text: "Cancelar",
                        click: function () {
                            $(this).dialog("close");
                        }
                    }
            ]
        });
    },
    LoadDropDownList: function (name, url, parameters, selected, isValIndex, async) {
        var combo = document.getElementById(name);
        combo.options.length = 0;
        combo.options[0] = new Option("");
        combo.selectedIndex = 0;

        $('#' + name).ajaxError(function (event, request, settings) {
            combo.options[0] = new Option("Error al cargar.");
        });
        $.ajax({
            type: "POST",
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: async,
            data: JSON.stringify(parameters),
            success: function (items) {
                $.each(items, function (index, item) {
                    combo.options[index] = new Option(item.Nombre, item.IdComun);
                });
                if (selected == undefined) selected = 0;

                if (isValIndex) {
                    $('#' + name).attr('selectedIndex', selected);
                } else {
                    $('#' + name).val(selected);
                }
            },
            failure: function (msg) {
            },
            error: function (xhr, status, error) {
            }
        });
    },
    LoadDropDownListMulti: function (name, url, parameters, selected, async) {
        var combo = document.getElementById(name);

        $('#' + name).ajaxError(function (event, request, settings) {
            combo.options[0] = new Option("Error al cargar.");
        });
        $.ajax({
            type: "POST",
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: async,
            data: JSON.stringify(parameters),
            success: function (items) {
                var list = items;
                $.each(list, function (index, item) {
                    combo.options[index] = new Option(item.Nombre, item.IdComun);
                });
                if (selected == undefined) selected = 0;
                $('#' + name).val(selected);
            },
            failure: function (msg) {
            },
            error: function (xhr, status, error) {
            }
        });
    },
    LoadDropDownListSinFormato: function (name, url, parameters, selected, async) {
        var combo = document.getElementById(name);
        combo.options.length = 0;
        combo.options[0] = new Option("");
        combo.selectedIndex = 0;

        //        $('#' + name).ajaxError(function (event, request, settings) {
        //            combo.options[0] = new Option("Error al cargar.");
        //        });
        $.ajax({
            type: "POST",
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: async,
            data: JSON.stringify(parameters),
            success: function (items) {
                var list = items;
                $.each(list, function (index, item) {
                    combo.options[index] = new Option(item.Nombre, item.IdComun);
                });
                if (selected == undefined) selected = 0;
                $('#' + name).val(selected);
            },
            failure: function (msg) {
            },
            error: function (xhr, status, error) {
            }
        });
    },
    LoadDropDownListItems: function (name, url, parameters, selected) {
        var combo = document.getElementById(name);
        combo.options.length = 0;
        combo.options[0] = new Option("");
        combo.selectedIndex = 0;

        var opciones = {
            url: url,
            parametros: parameters
        };

        SIG.Ajax(opciones, function (response) {
            if (response.Success) {
                combo.disabled = true;
                $.each(response.Data, function (index, item) {
                    combo.options[index] = new Option(item.Nombre, item.IdComun);
                });
                combo.disabled = false;
                if (selected == undefined)
                    selected = 0;
                $('#' + name).val(selected);
            } else {
                SIG.Alert('Alerta', response.Message, null);
            }
        });
    },
    LoadDropDownListItemsAjaxId: function (name, opciones) {
        var combo = document.getElementById(name);
        combo.options.length = 0;
        combo.options[0] = new Option("");
        combo.selectedIndex = 0;

        if (opciones.selected == null || opciones.selected == undefined)
            opciones.selected = 0;

        if (opciones.tituloAlerta == null)
            opciones.tituloAlerta = 'Alerta';

        if (opciones.vacio == null)
            opciones.vacio = 'Vacio';

        SIG.Ajax(opciones, function (response) {
            if (response.Success) {
                if (response.Message != opciones.vacio) {
                    combo.disabled = true;
                    $.each(response.Data, function (index, item) {
                        combo.options[index] = new Option(item.Nombre, item.IdComun);
                    });
                    combo.disabled = false;
                    $('#' + name).val(opciones.selected);
                } else {
                    SIG.Alert(opciones.tituloAlerta, response.Message, null);
                }
            } else {
                SIG.Alert(opciones.tituloAlerta, response.Message, null);
            }
        });
    },

    padLeft: function (nr, n, str) {
        return Array(n - String(nr).length + 1).join(str || '0') + nr;
    },
    confirm: function (dialogText, okFunc, cancelFunc, dialogTitle) {
        $('<div style="padding: 10px; max-width: 500px; min-width: 300px; word-wrap: break-word;">' + dialogText + '</div>').dialog({
            //draggable: false,
            modal: true,
            resizable: false,
            width: 'auto',
            title: dialogTitle || 'Confirmación',
            minHeight: 75,
            buttons: {
                OK: function () {
                    if (typeof (okFunc) == 'function') { setTimeout(okFunc, 50); }
                    $(this).dialog('destroy');
                },
                Cancel: function () {
                    if (typeof (cancelFunc) == 'function') { setTimeout(cancelFunc, 50); }
                    $(this).dialog('destroy');
                }
            }
        });
    },

    confirmUpgrade: function (opciones) {
        var buttons = [
            {
                text: opciones.dialogOkText,
                click: function () {
                    if (typeof (opciones.OkHandlerFunction) == 'function') {
                        var dialogConfirm = $(this);

                        var respuestaHandler;
                        $.when(opciones.OkHandlerFunction(opciones.parametroHandlers)).then(function () {
                            dialogConfirm.dialog("destroy").remove();
                            respuestaHandler = esperaRespuesta.resolve();
                        }, function () {
                            respuestaHandler = esperaRespuesta.reject();
                        });

                        return respuestaHandler;
                    } else {
                        alert("Debe definir un handler para la accion OK");
                    }

                    return esperaRespuesta.reject();
                }
            }, {
                text: opciones.dialogCancelText,
                click: function () {
                    if (typeof (opciones.CancelHandlerFunction) == 'function') {
                        $(this).dialog("destroy").remove();
                        opciones.CancelHandlerFunction(opciones.parametroHandlers);
                    } else {
                        $(this).dialog("destroy").remove();
                    }

                    return esperaRespuesta.reject();
                }
            }
        ];

        var esperaRespuesta = new $.Deferred();
        var dialog = $('<div style="padding: 10px; min-width: 300px; word-wrap: break-word;">' + opciones.dialogText + '</div>').dialog({
            draggable: true,
            modal: true,
            resizable: opciones.resizable == null ? false : opciones.resizable,
            width: opciones.width == null ? 'auto' : opciones.width,
            height: opciones.height == null ? 'auto' : opciones.height,
            position: 'center',
            dialogClass: opciones.dialogClass,
            appendTo: opciones.container,
            title: opciones.dialogTitle || 'Confirmación',
            minHeight: 75,
            buttons: opciones.isAlert == null ? buttons : []
        });

        dialog.parent().draggable({
            containment: opciones.dragContainer == null ? 'body' : opciones.dragContainer
        });

        dialog.parent().position({
            my: opciones.positionMy != null ? opciones.positionMy : 'center',
            at: opciones.positionAt != null ? opciones.positionAt : 'center',
            of: opciones.dragContainer == null ? 'body' : opciones.dragContainer
        });

        return esperaRespuesta.promise();
    },

    Alert: function (dialogTitle, dialogText, okFunc, closeFunc) {
        $('<div style="padding: 10px; min-width: 250px; word-wrap: break-word;">' + dialogText + '</div>').dialog({
            //draggable: false,
            modal: true,
            resizable: false,
            width: '400px',
            title: dialogTitle || 'Alert',
            minHeight: 75,
            buttons: {
                OK: function () {
                    if (okFunc != null) {
                        if (typeof (okFunc) == 'function') { setTimeout(okFunc, 50); }
                    }
                    $(this).dialog('destroy');
                }
            },
            close: function () {
                if (closeFunc != null && typeof (closeFunc) == 'function') {
                    closeFunc();
                }

                $(this).dialog("destroy").remove();
            }
        });
    },

    InicializarMsg: function () {
        $(".msgModel").show();
        SIG.msgHide();
        SIG.ShowElement(".msgModel .loading");
    },

    InicializarMsgPopup: function (contentId, frmId) {
        $("#" + contentId + " .msgModel").show();
        SIG.msgHidePopup(contentId, frmId);
        SIG.ShowElement("#" + contentId + " .msgModel .loading");
    },

    // rpt = bool (true: exito, false: error)
    //Message = mensaje a mostrar
    //funcionout = funcion a ejecutar ejm : 'Cancelar()' or ''
    msgConfirm: function (rpt, Message, funcionout, title) {
        // Se agregó esta linea por que no se eliminaba los errores despues del Post, setea los estilos originales.
        $("#frmModel .merror").removeClass().addClass("validation-summary-valid merror");
        $.jGrowl.defaults.closerTemplate = "<div>[ Cerrar todo ]</div>";

        var theme = "";

        if (title == null)
            title = 'Notification';

        if (rpt) {
            $(".msgModel .loading").slideUp(200, function () {
                SIG.msgHide();
                setTimeout(funcionout, 200);
                $(".msgModel .mexito").html(Message);
                SIG.ShowElement(".msgModel .mexito");
                if (typeof (funcionout) == 'function') {
                    setTimeout(funcionout, 200);
                }
            });
            setTimeout(funcionout, 200);
            theme = "default";

        } else {
            $(".msgModel .loading").slideUp(200, function () {
                SIG.msgHide();
                $(".msgModel .merror").html(Message);
                SIG.ShowElement(".msgModel .merror");
            });

            theme = "error";
        }

        $.jGrowl(Message,
            {
                themeState: theme,
                life: 7000,
                closeTemplate: '<a href="#" class="ui-dialog-titlebar-close ui-corner-all" role="button"><span class="ui-icon ui-icon-closethick">close</span></a>',
                header: title
            });
    },
    msgConfirmModel: function (rpt, Message, funcionout) {
        Message = Message == "" ? " " : Message;
        if (rpt) {
            $(".msgModel .loading").slideUp(200, function () {
                SIG.msgHide();
                $(".msgModel .mexito").html(Message);
                SIG.ShowElement(".msgModel .mexito");
                if (typeof (funcionout) == 'function') {
                    setTimeout(funcionout, 50);
                }
            });
        } else {
            $(".msgModel .loading").slideUp(200, function () {
                SIG.msgHide();
                $(".msgModel .merror").html(Message);
                SIG.ShowElement(".msgModel .merror");
            });
        }
        $("#html_content").animate({ scrollTop: 0 }, 600);
        return false;
    },

    AlertNotificacion: function (rpt, title, message, funcionout) {
        var theme = "default";

        if (title == null)
            title = 'Notificación';
        if (rpt)
            funcionout;
        else
            theme = "error";

        $.jGrowl.defaults.closerTemplate = "<div>[ Cerrar todo ]</div>";
        $.jGrowl(Message,
            {
                themeState: theme,
                life: 7000,
                closeTemplate: '<a href="#" class="ui-dialog-titlebar-close ui-corner-all" role="button"><span class="ui-icon ui-icon-closethick">close</span></a>',
                header: title
            });
    },

    // rpt = bool (true: exito, false: error)
    //Message = mensaje a mostrar
    //funcionout = funcion a ejecutar ejm : 'Cancelar()' or ''
    msgConfirmPopup: function (contentId, frmId, rpt, Message, funcionout, title) {
        var contentIdLocal = "#" + contentId;
        // Se agregó esta linea por que no se eliminaba los errores despues del Post, setea los estilos originales.
        $("#" + frmId + " .merror").removeClass().addClass("validation-summary-valid merror");
        $.jGrowl.defaults.closerTemplate = "<div>[ Cerrar todo ]</div>";

        var theme = "";

        if (title == null)
            title = 'Notification';

        if (frmId != null) {
            // Se agregó esta linea por que no se eliminaba los errores despues del Post, setea los estilos originales.
            $("#" + frmId + " .merror").removeClass().addClass("validation-summary-valid merror");
        }
        if (rpt) {
            theme = "default";

            $(contentIdLocal + " .msgModel .loading").slideUp(200, function () {
                SIG.msgHidePopup(contentId, frmId);
                setTimeout(funcionout, 200);
                $(contentIdLocal + ".msgModel .mexito").html(Message);
                SIG.ShowElement(contentIdLocal + ".msgModel .mexito");
                if (typeof (funcionout) == 'function') {
                    setTimeout(funcionout, 200);
                }
            });
        } else {
            $(contentIdLocal + " .msgModel .loading").slideUp(200, function () {
                SIG.msgHidePopup(contentId, frmId);
                $(contentIdLocal + ".msgModel .merror").html(Message);
                SIG.ShowElement(contentIdLocal + ".msgModel .merror");
            });

            theme = "error";
        }

        $.jGrowl(Message,
            {
                themeState: theme,
                life: 7000,
                closeTemplate: '<a href="#" class="ui-dialog-titlebar-close ui-corner-all" role="button"><span class="ui-icon ui-icon-closethick">close</span></a>',
                header: title
            });
    },

    msgHide: function () {
        $(".msgModel .tips").hide();
        $(".msgModel .merror, .msgModel .mexito, .msgModel .loading").css({ "border-top": "none" });
        $("#frmModel .merror").css({ "border-top": "none", "border-left": "none", "border-right": "none" });
    },

    msgHidePopup: function (contentId, frmId) {
        contentId = "#" + contentId;
        $(contentId + " .msgModel .tips").hide();
        $(contentId + " .msgModel .merror, " + contentId + " .msgModel .mexito, " + contentId + " .msgModel .loading").css({ "border-top": "none" });
        if (frmId != null) {
            frmId = "#" + frmId;
            $(frmId + " .merror").css({ "border-top": "none", "border-left": "none", "border-right": "none" });
        }
    },
    CreateDialogPopUpForm: function (opciones) {
        var guardarButtonConfig, cancelarButtonConfig;
        var myButtons = [];

        var dialogForm = $('<div style="padding: 10px; min-width: 250px; word-wrap: break-word;"></div>');

        if (opciones.customCloseAction == null)
            opciones.customCloseAction = false;

        if (opciones.buttonsConfig.showGuardarButton == null)
            opciones.buttonsConfig.showGuardarButton = true;

        if (opciones.buttonsConfig.showCancelarButton == null)
            opciones.buttonsConfig.showCancelarButton = true;

        if (opciones.buttonsConfig.showGuardarButton) {
            guardarButtonConfig = {
                text: opciones.buttonsConfig.guardarText,
                icons: { primary: opciones.buttonsConfig.guardarIcon != null ? opciones.buttonsConfig.guardarIcon : "ui-icon ui-icon-disk" },
                click: function () {
                    var functionOk = window[opciones.buttonsConfig.GuardarHandlerFunction];
                    if (typeof (functionOk) == 'function') {
                        functionOk(this, opciones.buttonsConfig.parametroHandlers);
                    }
                }
            };
            myButtons.push(guardarButtonConfig);
        }
        if (opciones.buttonsConfig.showCancelarButton) {
            cancelarButtonConfig = {
                text: opciones.buttonsConfig.cancelarText,
                icons: { primary: opciones.buttonsConfig.cancelarIcon != null ? opciones.buttonsConfig.cancelarIcon : "ui-icon ui-icon-close" },
                click: function () {
                    var functionCancel = window[opciones.buttonsConfig.CancelHandlerFunction];
                    if (typeof (functionCancel) == 'function') {
                        functionCancel();
                    }
                    $(this).dialog("destroy").remove();
                }
            };
            myButtons.push(cancelarButtonConfig);
        }

        if (opciones.customButtons != null)
            $.merge(opciones.customButtons, myButtons);

        dialogForm = dialogForm.dialog({
            modal: opciones.modal == null ? true : opciones.modal,
            resizable: true,
            title: opciones.title,
            height: opciones.height,
            width: opciones.width,
            minWidth: opciones.minWidth != null ? opciones.minWidth : 75,
            minHeight: opciones.minHeight != null ? opciones.minHeight : 75,
            appendTo: opciones.container,
            open: function () {
                if (opciones.url != null) {
                    $.get(opciones.url, opciones.parametrosUrl).done(function (data) {
                        dialogForm.html(data);
                        window[opciones.popup] = this;
                    });

                } else {
                    $(this).append(opciones.content);
                }
            },
            beforeClose: function (event, ui) {
                if (opciones.beforeClosePopUp != null && typeof (opciones.beforeClosePopUp) == 'function') {
                    opciones.beforeClosePopUp(dialogForm);
                }
                return !opciones.customCloseAction;
            },
            close: function () {
                if (opciones.closePopUp != null && typeof (opciones.closePopUp) == 'function') {
                    opciones.closePopUp(dialogForm);
                }

                $(this).dialog("destroy").remove();
            },
            resize: function () {
                if (opciones.resizePopUp != null) {
                    if (typeof (opciones.resizePopUp) == 'function') {
                        opciones.resizePopUp();
                    } else {
                        var resizePopUp = window[opciones.resizePopUp];
                        if (typeof (resizePopUp) == 'function')
                            resizePopUp();
                    }
                }
            }
        });

        dialogForm.dialog('option', 'buttons', opciones.customButtons != null ? opciones.customButtons : myButtons);
        dialogForm.parent().draggable({
            containment: opciones.dragContainer == null ? 'body' : opciones.dragContainer
        });

        dialogForm.parent().position({
            my: opciones.positionMy != null ? opciones.positionMy : 'top',
            at: opciones.positionAt != null ? opciones.positionAt : 'top',
            of: opciones.dragContainer == null ? 'body' : opciones.dragContainer
        });

        if (opciones.dialogExtenderOptions != null) {
            dialogForm.dialogExtend(opciones.dialogExtenderOptions);
        }

        return dialogForm;
    },
};

// Quita la validación de ingreso de números
jQuery.fn.removeNumeric = function () {
    return this.data("numeric.decimal", null).data("numeric.negative", null).data("numeric.callback", null).unbind("keypress", $.fn.numeric.keypress).unbind("blur", $.fn.numeric.blur);
    return this
      .removeData('numeric.decimal')
      .removeData('numeric.negative')
      .removeData('numeric.callback')
      .unbind('keypress', $.fn.numeric.keypress)
      .unbind('blur', $.fn.numeric.blur)
      .unbind('keyup', $.fn.numeric.keyup);
};
