//
//
//
function zzsGetUrlVar(key){ 
 	var result = new RegExp(key + "=([^&]*)", "i").exec(window.location.search);  
 	return result && unescape(result[1]) || "";  
} 

//
//
function zzsParseMSJsonDate(value) {
    var a;
    if (typeof value === 'string') {
        a = /Date\(([-+]?\d+)\)/.exec(value);
        if (a) {
            return new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
        }
    }
    return value;
}
function zzsDateToItalianString(dt) {
    var d = dt.getDate();
    var dd = "";
    if (d < 10) {
        dd = "0" + d.toString();
    } else {
        dd = d.toString();
    }
    var m = dt.getMonth() + 1;
    var mm = "";
    if (m < 10) {
        mm = "0" + m.toString();
    } else {
        mm = m.toString();
    }
    return dd + "/" + mm + "/" + dt.getFullYear().toString();
}
function zzsDateToISOString(dt) {
    if (dt == null)
        return '';
    var d = dt.getDate();
    var dd = "";
    if (d < 10) {
        dd = "0" + d.toString();
    } else {
        dd = d.toString();
    }
    var m = dt.getMonth() + 1;
    var mm = "";
    if (m < 10) {
        mm = "0" + m.toString();
    } else {
        mm = m.toString();
    }
    return dt.getFullYear() + "-" + mm + "-" + dd;
}
function zzsHtmlEncoded(str) {
    str = str.replace('<', '&#60;');
    str = str.replace('>', '&#62;');
    return str;
}