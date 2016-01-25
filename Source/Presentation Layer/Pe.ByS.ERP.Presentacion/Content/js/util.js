var util = {
    date: {
        toJson: function (value) {
            if (typeof value === 'string') {
                var a;
                var paternDefault = /\/Date\(-?(\d+)(-\d+)?\)\//;
                var paternString = /(\d{2})\/(\d{2})\/(\d{4})/;
                var patternISO = /(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2})/;
                if (paternDefault.test(value)) {
                    a = paternDefault.exec(value);
                    if (a) return new Date(+a[1]);
                }
                else if (paternString.test(value)) {
                    a = paternString.exec(value);
                    if (a) return new Date(parseInt(a[3]), parseInt(a[2]) - 1, parseInt(a[1]));
                }
                else if (patternISO.test(value)) {
                    a = patternISO.exec(value);
                    if (a) {
                        return new Date(parseInt(a[1]), parseInt(a[2]) - 1, parseInt(a[3]),
                            parseInt(a[4]), parseInt(a[5]), parseInt(a[6]));
                    }
                }
            }
            return value;
        },
        format: function (value, format) {
            value = util.date.toJson(value);
            if (value != null && value) {
                var hours = value.getHours();
                var ttime = "AM";
                if (format.indexOf("t") > -1 && hours > 12) {
                    hours = hours - 12;
                    ttime = "PM";
                }

                var o = {
                    "M+": value.getMonth() + 1, //month
                    "d+": value.getDate(),    //day
                    "h+": hours,   //hour
                    "m+": value.getMinutes(), //minute
                    "s+": value.getSeconds(), //second
                    "q+": Math.floor((value.getMonth() + 3) / 3),  //quarter
                    "S": value.getMilliseconds(), //millisecond,
                    "t+": ttime
                }

                if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
                      (value.getFullYear() + "").substr(4 - RegExp.$1.length));
                for (var k in o) if (new RegExp("(" + k + ")").test(format))
                    format = format.replace(RegExp.$1,
                      RegExp.$1.length == 1 ? o[k] :
                        ("00" + o[k]).substr(("" + o[k]).length));
                return format;
            }
            return value;
        }
    }
}