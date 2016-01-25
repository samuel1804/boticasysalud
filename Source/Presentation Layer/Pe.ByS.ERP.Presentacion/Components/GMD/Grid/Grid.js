/// Copyright (c) 2015.
/// All rights reserved.
/// <summary>
/// Libreria para la creación de grillas
/// </summary>
/// <remarks>
/// Creacion: 	GMD(JLRR) 20150107 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.Grid');
Pe.GMD.UI.Web.Components.Grid = function (opts) {
    this.Init(opts);
};

Pe.GMD.UI.Web.Components.Grid.prototype = {
    id: null,
    renderTo: null,
    columns: null,
    columnDefs: null,
    hasPaging: null,
    hasInfo: null,
    hasSelectionRows: null,
    height: null,
    proxy: null,
    core: null,
    table: null,
    events: null,
    scrollY: null,
    scrollX: null,
    scrollCollapse: null,
    data: null,
    Init: function (opts) {

        this.renderTo = $('#' + opts.renderTo);
        if (this.renderTo && this.renderTo.length == 0) {
            alert('ERROR: Not renderTo defined');
            return;
        }

        this.columns = opts.columns && opts.columns != null ? opts.columns : null;
        this.columnDefs = opts.columnDefs && opts.columnDefs != null ? opts.columnDefs : null;
        this.proxy = opts.proxy && opts.proxy != null ? opts.proxy : null;
        this.events = opts.events && opts.events != null ? opts.events : null;
        this.hasPaging = opts.hasPaging != null ? opts.hasPaging : true;
        this.hasInfo = opts.hasInfo != null ? opts.hasInfo : true;
        this.scrollY = opts.scrollY != null ? opts.scrollY : null;
        this.scrollX = opts.scrollX != null ? opts.scrollX : null;
        this.scrollCollapse = opts.scrollCollapse != null ? opts.scrollCollapse : null;
        this.hasSelectionRows = opts.hasSelectionRows != null ? opts.hasSelectionRows : true;
        this.data = opts.data != null ? opts.data : new Array();
        this.onLoad = opts.onLoad != null ? opts.onLoad : null;

        if (this.columns == null) {
            alert('ERROR: Not columms defined');
            return;
        }
        this.id = opts.id && opts.id != null ? opts.id : 'GMD-Grid-';
        this._privateFunction.ImplementTableElement.apply(this, [this.renderTo]);
        this._privateFunction.ProcessSelectionRows.apply(this);
        this._privateFunction.CreateGrid.apply(this, [this.data]);

    },
    Load: function (params) {
        this.proxy.params = params;
        this._privateFunction.CallProxy.apply(this);
    },
    ExportToExcel: function (name) {
        this.table.tableExport({ type: 'excel', escape: 'false', tableName: "shieldui-grid", documentName: name });

    },
    DestroyGrid: function () {
        if (this.core != null) {
            this.core.destroy();
            this.core = null;
        }
    },
    GetSelectedData: function () {
        var data = this.core.rows('.selected').data();
        var lista = new Array();
        for (var i = 0; i < data.length; i++) {
            lista.push(data[i]);
        }
        return lista;
    },
    GetData: function () {
        return this.core.rows().data();
    },
    _privateFunction: {
        CreateGrid: function (dataSource) {

            if (this.core != null) {
                this.core.destroy();
            }

            var opts = {
                columns: this.columns,
                data: dataSource,
                paging: this.hasPaging,
                "bInfo": this.hasInfo,
                serverSide: false,
                ordering: false,
                searching: false,
                columnDefs: this.columnDefs
            }

            if (this.scrollY != null) {
                opts['scrollY'] = this.scrollY;
            }
            if (this.scrollCollapse != null) {
                opts['scrollCollapse'] = this.scrollCollapse;
            }

            this.core = this.table.DataTable(opts);
        },
        ImplementTableElement: function (renderTo) {
            this.table = $('<table />').uniqueId();
            this.id = this.id + this.table.attr('id');
            this.table.attr('id', this.id);
            this.table.width('100%');
            this.table.attr('cellspacing', '0');

            this.table.addClass('table table-bordered table-hover text-center text-middle');
            this.table.closest('div').addClass('table-responsive');
            renderTo.append(this.table);

            this._privateFunction.ProcessColumns.apply(this);

            if (this.events != null) {
                var me = this;
                $.each(this.events, function (index, event) {
                    if (event.isRowEvent) {
                        me.table.on(event.type, event.selector, function () {
                            var row = me.core.row($(this).parents('tr'))
                            var data = row.data();
                            var grid = me;
                            event.callBack.apply(this, [row, data, grid]);
                        });
                    }
                    else {
                        me.table.on(event.type, event.selector, event.callBack);
                    }
                });
            }
            return this.table;
        },
        ProcessColumns: function () {
            var me = this;
            this.events = this.events || new Array();
            $.each(this.columns, function (index, column) {
                if (column.actionButtons) {

                    $.each(column.actionButtons, function (index, action) {

                        me.events.push({
                            type: action.event.on,
                            selector: '.' + action.type.Icon + '-' + me.id,
                            callBack: action.event.callBack,
                            isRowEvent: true
                        });

                    });

                    column.mRender = function (data, type, full) {
                        var htmlSource = '';
                        $.each(column.actionButtons, function (index, action) {
                            var renderAction = action.validateRender ? action.validateRender(data, type, full) : true;
                            if (renderAction) {
                                htmlSource += action.type.Source(me.id, action.toolTip);
                            } else {
                                //14072015
                                //if (typeof data === "undefined"){
                                if (data != null) {
                                    htmlSource += data;
                                }
                            }
                        });
                        return htmlSource;
                    };
                };
            });
        },
        ProcessSelectionRows: function () {

            var me = this;

            var idCheckHeader = 'chkHeader-' + this.id;
            var idCheckRow = 'chkRow-' + this.id;

            if (this.hasSelectionRows) {
                this.columns.splice(0, 0, {
                    data: '', title: '<input class="' + idCheckHeader + '" type="checkbox">',
                    'mRender': function (data, type, full) {
                        var html = '';
                        html += '<input class="' + idCheckRow + '" type="checkbox">';
                        return html;
                    }
                });
            }

            this.table.on('click', '.' + idCheckRow, function () {
                var row = $(this).parents('tr');
                var chkHeader = $(me.table.find('.' + idCheckHeader));

                row.toggleClass('selected');
                chkHeader.prop('checked', (me.core.data().length == me.core.rows('.selected').data().length));
            });

            this.table.on('click', '.' + idCheckHeader, function () {
                var chk = $(this);
                var rows = me.table.find('tr');
                rows.removeClass('selected');
                if (chk.is(':checked')) {
                    rows.addClass('selected');
                }
                me.table.find('.' + idCheckRow).prop('checked', chk.is(':checked'));
            });

        },
        CallProxy: function () {
            var me = this;

            var ajaxBuscar = new Pe.GMD.UI.Web.Components.Ajax({
                action: this.proxy.url,
                data: this.proxy.params,
                onSuccess: function (data) {
                    me._privateFunction.CreateGrid.apply(me, [data[me.proxy.source]]);
                    if (me.onLoad && me.onLoad != null) {
                        me.onLoad(data[me.proxy.source]);
                    }
                }
            });
        }
    }
};
ns('Pe.GMD.UI.Web.Components.GridAction');
Pe.GMD.UI.Web.Components.GridAction = {
    Check: {
        Class: 'check',
        Icon: 'fa-check-square',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('check', 'fa-check-square fa-check-square-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridAprobar);
        }
    },
    Consulta: {
        Class: 'consulta',
        Icon: 'fa-question-circle',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('consulta', 'fa-question-circle fa-question-circle-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridConsulta);
        }
    },
    Observacion: {
        Class: 'eyes',
        Icon: 'fa-eye',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('eyes', 'fa-eye fa-eye-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridObservacion);
        }
    },
    DetalleBandeja: {
        Class: 'detalleBandeja',
        Icon: 'fa-tasks',
        Source: function (id, tooltip) {
            return Pe.GMD.UI.Web.Components.GridAction.Source(id, Pe.GMD.UI.Web.Components.GridAction.DetalleBandeja, tooltip);
        }
    },
    Pdf: {
        Class: 'pdf',
        Icon: 'fa-file-pdf-o',
        Source: function (id, tooltip) {
            return Pe.GMD.UI.Web.Components.GridAction.Source(id, Pe.GMD.UI.Web.Components.GridAction.Pdf, (tooltip ? tooltip : Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridContrato));
            //return Pe.GMD.UI.Web.Components.Util.RenderIcono('pdf', 'fa-file-pdf-o fa-file-pdf-o-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridPdf);
        }
    },
    Adjunto: {
        Class: 'paperclip',
        Icon: 'fa-paperclip',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('paperclip', 'fa-paperclip fa-paperclip-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridAdjunto);
        }
    },
    VistaPrevia: {
        Class: 'vistaPrevia',
        Icon: 'fa-file-pdf-o',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('vistaPrevia', 'fa-file-pdf-o fa-file-pdf-o-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridVistaPrevia);
        }
    },
    Parrafo: {
        Class: 'parrafo',
        Icon: 'fa-tasks',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('parrafo', 'fa-tasks fa-tasks-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridParrafo);
        }
    },
    Variable: {
        Class: 'variable',
        Icon: 'fa-sign-in',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('variable', 'fa-sign-in fa-sign-in-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridAgregarVariable);
        }
    },
    Estadios: {
        Class: 'estadios',
        Icon: 'fa-external-link',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('estadios', 'fa-external-link fa-external-link-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridEstadios);
        }
    },
    Temas: {
        Class: 'temas',
        Icon: 'fa-tasks',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('temas', 'fa-tasks fa-tasks-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridTemas);
        }
    },
    Predecesora: {
        Class: 'predecesora',
        Icon: 'fa-tasks',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('predecesora', 'fa-tasks fa-tasks-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridPredecesora);
        }
    },
    Evidencia: {
        Class: 'evidencia',
        Icon: 'fa-external-link',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('evidencia', 'fa-external-link fa-external-link-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridEvidencia);
        }
    },
    Edit: {
        Class: 'edit',
        Icon: 'fa-edit',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('edit', 'fa-edit fa-edit-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.EtiquetaEditar);

        }
    },
    EditText: {
        Class: 'editarTexto',
        Icon: 'fa-text-width',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('edit', 'fa-text-width fa-text-width-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.EtiquetaEditarContenidoContrato);
        }
    },
    Delete: {
        Class: 'eliminar',
        Icon: 'fa-trash',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('delete', 'fa-trash fa-trash-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.EtiquetaEliminar);
        }
    },
    Copy: {
        Class: 'copiar',
        Icon: 'fa-copy',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('copiar', 'fa-copy fa-copy-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.EtiquetaCopiar);
        }
    },
    CopyEstadios: {
        Class: 'copiarEstadio',
        Icon: 'fa-copy',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('copiarEstadio', 'fa-copy fa-copy-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.EtiquetaCopiarEstadio);
        }
    },
    Close: {
        Class: 'cerrar',
        Icon: 'fa-lock',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('cerrar', 'fa-lock fa-lock-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.EtiquetaBloquear);
        }
    },
    Open: {
        Class: 'abrir',
        Icon: 'fa-unlock',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('abrir', 'fa-unlock fa-unlock-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.EtiquetaDesbloquear);
        }
    },
    Notify: {
        Class: 'notificar',
        Icon: 'fa-envelope-o',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('notificar', 'fa-envelope-o fa-envelope-o-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.EtiquetaNotificar);
        }
    },
    Play: {
        Class: 'iniciar',
        Icon: 'fa-play',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('iniciar', 'fa-play fa-play-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.EtiquetaIniciar);
        }
    },
    FechaActividad: {
        Class: 'fechaActividad',
        Icon: 'fa-calendar',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('fechaActividad', 'fa-calendar fa-calendar-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.EtiquetaFechaActividad);
        }
    },
    Responsables: {
        Class: 'responsable',
        Icon: 'fa-tasks',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('responsable', 'fa-tasks fa-tasks-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.EtiquetaResponsables);
        }
    },
    ResponsableEvidencia: {
        Class: 'responsableEvidencia',
        Icon: 'fa-external-link',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('responsableEvidencia', 'fa-external-link fa-external-link-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.EtiquetaResponsableEvidencias);
        }
    },
    FileUpload: {
        Class: 'fileupload',
        Icon: 'fa-upload',
        Source: function (id) {
            var selector = 'fa-upload-' + id;
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('verificar', 'fa-upload ' + selector, Pe.ByS.ERP.Presentacion.Base.GenericoResource.EtiquetaGridFileUpload);
        }
    },
    DetalleBandeja: {
        Class: 'detalleBandeja',
        Icon: 'fa-tasks',
        Source: function (id, tooltip) {
            return Pe.GMD.UI.Web.Components.GridAction.Source(id, Pe.GMD.UI.Web.Components.GridAction.DetalleBandeja, tooltip);
        }
    },
    ArchivoArchivado: {
        Class: 'archivoArchivado',
        Icon: 'fa-file-archive-o',
        Source: function (id, tooltip) {
            return Pe.GMD.UI.Web.Components.GridAction.Source(id, Pe.GMD.UI.Web.Components.GridAction.ArchivoArchivado, tooltip);
        }
    },
    Source: function (id, atributos, tooltip) {
        var selector = atributos.Icon + '-' + id;
        return Pe.GMD.UI.Web.Components.Util.RenderIcono(atributos.Class, atributos.Icon + ' ' + selector, tooltip);
    },
    ValorAlquiler: {
        Class: 'valorAlquiler',
        Icon: 'fa-tasks',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('valorAlquiler', 'fa-tasks fa-tasks-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridValorAlquiler);
        }
    },
    DescargarAdjunto: {
        Class: 'descargar',
        Icon: 'fa-download',
        Source: function (id) {
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('descargar', 'fa-download fa-download-' + id, Pe.ByS.ERP.Presentacion.Base.GenericoResource.GridDescargar);
        }
    },
};