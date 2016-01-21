/// <summary>
/// Controlador de progreso de carga o peticiones
/// </summary>
/// <remarks>
/// Creacion: 	EDGAR MELGAREJO 20140707 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.Calendar');
Pe.GMD.UI.Web.Components.Calendar = function (opts) {
    this.init(opts);
};
ns('Pe.GMD.UI.Web.Formato');
Pe.GMD.UI.Web.Formato.Fecha = 'dd/mm/yy';
Pe.GMD.UI.Web.Formato.FechaMascara = '00/00/0000';
Pe.GMD.UI.Web.Formato.Decimal = '##0.00';
Pe.GMD.UI.Web.Formato.DecimalSeparadorDecimal = '.';
Pe.GMD.UI.Web.Formato.DecimalSeparadorMiles = '';
Pe.GMD.UI.Web.Formato.EnteroSeparadorMiles = '';

Pe.GMD.UI.Web.Components.Calendar.prototype = {

    inputFrom: null,
    inputTo: null,

    init: function (opts) {
        this.inputFrom = opts.inputFrom ? opts.inputFrom : null;
        this.inputTo = opts.inputTo ? opts.inputTo : null;
        var me = this;
        //this._privateFunction

        if (this.inputFrom && this.inputFrom != null) {
            var configFrom = {
                beforeShow: function (input, inst) {                    
                    inst.dpDiv.addClass('zIndexCalendar');
                },
                dateFormat: Pe.GMD.UI.Web.Formato.Fecha,
                onClose: function (selected) {
                    var result = Pe.GMD.UI.Web.Components.Util.ValidateBlurOnlyDate(this);
                    if (me.inputTo && me.inputTo != null) {
                        if (result) {
                            me.inputTo.datepicker('option', 'minDate', selected);
                        }
                        else {
                            me.inputTo.datepicker('option', 'minDate', null);
                        }
                    }
                }
            };
            if (opts.maxDateFrom && opts.maxDateFrom != null) {
                configFrom.maxDate = opts.maxDateFrom;
            }
            if (opts.minDateFrom && opts.minDateFrom != null) {
                configFrom.minDate = opts.minDateFrom;
            }
            this.inputFrom.datepicker(configFrom);
            this.inputFrom.bind("blur", function () {
                return Pe.GMD.UI.Web.Components.Util.ValidateBlurOnlyDate(this);
            });
            this.inputFrom.mask(Pe.GMD.UI.Web.Formato.FechaMascara);
            if (me.inputTo && me.inputTo != null) {
                this.inputFrom.change(function () {
                    if ($(this).val() == "" || $(this).val() == null) {
                        me.inputTo.datepicker('option', 'minDate', null);
                    }
                });
            }
        }



        if (this.inputTo && this.inputTo != null) {
            var configTo = {
                beforeShow: function (input, inst) {                    
                    inst.dpDiv.addClass('zIndexCalendar');
                },
                dateFormat: Pe.GMD.UI.Web.Formato.Fecha,
                onClose: function (selected) {
                    var result = Pe.GMD.UI.Web.Components.Util.ValidateBlurOnlyDate(this);
                    if (me.inputFrom && me.inputFrom != null) {
                        if (result) {
                            me.inputFrom.datepicker('option', 'maxDate', selected);
                        }
                        else {
                            me.inputFrom.datepicker('option', 'maxDate', null);
                        }
                    }
                }
            };
            if (opts.maxDateTo && opts.maxDateTo != null) {
                configTo.maxDate = opts.maxDateTo;
            }
            this.inputTo.datepicker(configTo);
            this.inputTo.bind("blur", function () {
                return Pe.GMD.UI.Web.Components.Util.ValidateBlurOnlyDate(this);
            });
            this.inputTo.mask(Pe.GMD.UI.Web.Formato.FechaMascara);
            if (me.inputFrom && me.inputFrom != null) {
                this.inputTo.change(function () {
                    if ($(this).val() == "" || $(this).val() == null) {
                        me.inputFrom.datepicker('option', 'maxDate', null);
                    }
                });
            }
        }

    },

    destroy: function () {
        if (this.inputFrom) {
            this.inputFrom.datepicker("destroy");
        }
        if (this.inputTo) {
            this.inputTo.datepicker("destroy");
        }
    },

    _privateFunction: {
        createDatePicker: function (input, reference) {
            if (input && input != null) {
                input.datepicker({
                    dateFormat: Pe.GMD.UI.Web.Formato.Fecha,
                    onClose: function (selected) {
                        if (reference && reference != null) {
                            reference.datepicker('option', 'minDate', selected);
                        }
                    }
                });
            }
        }
    }
};
