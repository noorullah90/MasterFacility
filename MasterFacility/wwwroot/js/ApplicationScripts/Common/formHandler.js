function onLoadingHandler(obj) {
    var Button = $(obj).find(':submit');
    $(Button).block({
        message: '<div class="spinner-border text-primary" role="status"> <span class= "sr-only" > Loading...</span></div >',
        overlayCSS: {
            backgroundColor: '#fff',
            opacity: 0.8,
            cursor: 'wait'
        },
        css: {
            border: 0,
            padding: 0,
            backgroundColor: 'none'
        }
    });
    Button.prop("disabled", true);
}

function onSuccessHandler(obj, data, hideModal = false, refreshPage = false, func) {
    if (data.type === "success") {
        toastr.success(data.message, data.title, {
            onShown: function () {
                if (hideModal) {
                    $('.modal').modal("hide");
                }
                if (refreshPage) {
                    window.location.reload();
                }
                if (func != null) {
                    func();
                }
                $(obj).find(':submit').prop("disabled", false);
                $(obj).find(':submit').unblock();
            }
        });
        //$(obj).trigger("reset");
    }
    else {
        toastr[data.type](data.message, data.title, {
            onShown: function () {
                $(obj).find(':submit').prop("disabled", false);
                $(obj).find(':submit').unblock();
            }
        })
    }
}