(function ($) {
    $(document).ready(function () {
        var cssClass = "layout-body";
        var cantwest = 0;
        var canteast = 0;
        var leftwest = new Array();
        var righteast = new Array();

        var setting = getWindowData();

        var width = setting[0];
        var height = setting[1];
        var widthTotal = setting[4];
        var heightTotal = setting[5];

        var heightsouth = $(".layout-south").height();
        var topSouth = height - heightsouth + 15;

        var heightnorth = $(".layout-nort").height();
        var heightContenido = heightTotal - heightnorth - heightsouth - 2;
        var widthContenido = 0;
        var leftContenido = 0;

        // agregar clase principal
        //$(".layout-nort").addClass(cssClass);
        //$(".layout-south").addClass(cssClass);

        //$(".layout-nort").css({ "width": + "100%" });
        //$(".layout-nort").css({ "overflow-x": +"auto" });
        //$(".layout-south").css({ "overflow-x": +"auto" });
        //$(".layout-south").css({ "display": +widthTotal + "px" });
        $(".layout-south").css({ "top": +topSouth + "px" });

        while (jQuery("#layout-west_" + cantwest).height() != null) {
            var widthwestx = $("#layout-west_" + cantwest).attr("width");
            if (cantwest == 0) {
                leftwest.push(cantwest);
            }
            else {
                leftwest.push(parseInt(leftwest[cantwest - 1]) + parseInt(widthwestx) + 5)
            }
            widthContenido = parseInt(widthContenido) + parseInt(widthwestx);
            leftContenido = parseInt(leftContenido) + parseInt(widthwestx);
            //$("#layout-west_" + cantwest).css({ "top": +heightnorth + "px" });
            $("#layout-west_" + cantwest).css({ "left": +leftwest[cantwest] + "px" });
            $("#layout-west_" + cantwest).css({ "width": +widthwestx + "px" });
            $("#layout-west_" + cantwest).css({ "height": +heightContenido + "px" });
            $("#layout-west_" + cantwest).addClass(cssClass);
            cantwest = cantwest + 1;

        }
        while (jQuery("#layout-east_" + canteast).height() != null) {
            var widtheastx = $("#layout-east_" + canteast).attr("width");
            if (canteast == 0) {
                righteast.push(canteast);
            }
            else {
                righteast.push(righteast[canteast - 1] + widtheastx + 5)
            }
            widthContenido = parseInt(widthContenido) + parseInt(widtheastx);
            //$("#layout-east_" + canteast).css({ "top": +heightnorth + "px" });
            $("#layout-east_" + canteast).css({ "right": +righteast[canteast] + "px" });
            $("#layout-east_" + canteast).css({ "width": +widtheastx + "px" });
            $("#layout-east_" + canteast).css({ "height": +heightContenido + "px" });
            $("#layout-east_" + canteast).addClass(cssClass);
            canteast = canteast + 1;
        }
        widthContenido = widthTotal - parseInt(widthContenido) - canteast * 5 - cantwest * 5;
        leftContenido = leftContenido + cantwest * 5;

        $(".layout-center").css({ "top": +heightnorth + "px" });
        $(".layout-center").css({ "height": +heightContenido + "px" });
        //$(".layout-center").css({ "width": +widthTotal + "px" });

        //$(".layout-content").css({ "top": +heightnorth + "px" });
        $(".layout-content").css({ "left": +leftContenido + "px" });
        $(".layout-content").css({ "width": +widthContenido + "px" });
        //$(".aplication").css({ "height": +heightContenido + "px" });
        $("#layout-content").addClass(cssClass);
        $(".aplicationContent").css({ "height": +heightContenido - 40 + "px" });
        //$("#RenderBody").css({ "min-width": +widthRenderBody + "px" });
    });
    function getWindowData() {
        var widthViewport, heightViewport, xScroll, yScroll, widthTotal, heightTotal;
        if (typeof window.innerWidth != 'undefined') {
            widthViewport = window.innerWidth - 17;
            heightViewport = window.innerHeight - 17;
        } else if (typeof document.documentElement != 'undefined' && typeof document.documentElement.clientWidth != 'undefined' && document.documentElement.clientWidth != 0) {
            widthViewport = document.documentElement.clientWidth;
            heightViewport = document.documentElement.clientHeight;
        } else {
            widthViewport = document.getElementsByTagName('body')[0].clientWidth;
            heightViewport = document.getElementsByTagName('body')[0].clientHeight;
        }
        xScroll = self.pageXOffset || (document.documentElement.scrollLeft + document.body.scrollLeft);
        yScroll = self.pageYOffset || (document.documentElement.scrollTop + document.body.scrollTop);
        widthTotal = Math.max(document.documentElement.scrollWidth, document.body.scrollWidth, widthViewport);
        heightTotal = Math.max(document.documentElement.scrollHeight, document.body.scrollHeight, heightViewport);
        return [widthViewport, heightViewport, xScroll, yScroll, widthTotal, heightTotal];
    }
})(jQuery);