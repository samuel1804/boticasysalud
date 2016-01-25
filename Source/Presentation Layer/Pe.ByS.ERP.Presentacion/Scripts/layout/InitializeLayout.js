var outerLayout, innerLayout;
$(document).ready(function () {
    outerLayout = $("body").layout(layoutSettings_Outer);
    innerLayout = $("div.ui-layout-west").layout(layoutSettings_Inner);

    var westSelector = "body > .ui-layout-west";

    $("<span></span>").attr("id", "west-closer").prependTo(westSelector);
    outerLayout.addCloseBtn("#west-closer", "west");    
});

var westVisibleACO = localStorage.getItem("cerrarWest");
var initClosedWestLayoutACO = false;

if (westVisibleACO == null) {
    localStorage.setItem("cerrarWest", false);
    initClosedWestLayoutACO = false;
} else if (westVisibleACO == "true") {
    localStorage.setItem("cerrarWest", true);
    initClosedWestLayoutACO = true;
} else {
    localStorage.setItem("cerrarWest", false);
    initClosedWestLayoutACO = false;
}

var layoutSettings_Outer = {
    name: "outerLayout",
    defaults: {
        size: "auto"
		    , minSize: 8
		    , togglerLength_open: 35
		    , togglerLength_closed: 35
		    , hideTogglerOnSlide: true
		    , togglerTip_open: "Ocultar Panel"
		    , togglerTip_closed: "Mostrar Panel"
		    , resizerTip: "Redimensionar"
		    , fxName: "drop"
            , fxSpeed: "normal"
            , spacing_open: 0
    },
    north: {
              togglerLength_open: 0
		    , togglerLength_closed: -1
		    , resizable: false
		    , slidable: false
		    , fxName: "none"
    },
    south: {
              maxSize: 200
		    , spacing_closed: 0
		    , slidable: false
		    , initClosed: false
            , togglerLength_open: 0
            , resizable: false
		    , slidable: false
    },
    west: {
              size: 230
            , minWidth: 200
		    , spacing_closed: 21
		    , togglerLength_closed: 21
		    , togglerAlign_closed: "top"
            , togglerAlign_open: "center"
		    , slideTrigger_open: "click"
		    , initClosed: initClosedWestLayoutACO
            , spacing_open: 3
    },
    east: {
            size: 250
		    , spacing_closed: 21
		    , togglerLength_closed: 21
		    , togglerAlign_closed: "top"
		    , togglerLength_open: 0
		    , initClosed: true
		    , fxSpeed: "normal"
		    , fxSettings: { easing: ""} // nullify default easing
    },
    center: {
              minWidth: 200
		    , minHeight: 200
    }
};

var layoutSettings_Inner = {
    name: "innerLayout",
    defaults: {
              size: "auto"
		    , minSize: 8
		    , togglerLength_open: 35
		    , togglerLength_closed: 35
		    , hideTogglerOnSlide: true
		    , togglerTip_open: "Ocultar Panel"
		    , togglerTip_closed: "Mostrar Panel"
		    , resizerTip: "Redimensionar"
		    , fxName: "drop"
            , fxSpeed: "normal"
            , spacing_open: 0
    },
    north: {
             togglerLength_open: 0
		    , togglerLength_closed: -1
		    , resizable: false
		    , slidable: false
		    , fxName: "none"
    },
    south: {
		      spacing_closed: 0
		    , slidable: false
		    , initClosed: false
            , togglerLength_open: 0
            , resizable: false
		    , slidable: false
    }
};