function onlyDari(str) {
    var p = /^[\u0600-\u06FF\s]+$/;
    if (!p.test(str)) {
        return false
    }
    return true;
}