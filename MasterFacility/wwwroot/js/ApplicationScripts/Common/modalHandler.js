var modalIntial = function () {
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        var target = $(this).data('target');
        var callback = $(this).data('callback');
        var button = $(this);
        var modalTitle = $(this).data('modal-title');
        button.block({
            message: '<div class="spinner-border text-primary" role="status"> <span class= "sr-only" > Loading...</span></div >',
            overlayCSS: {
                backgroundColor: '#fff',
                opacity: 0,
                cursor: 'wait'
            },
            css: {
                border: 0,
                padding: 0,
                backgroundColor: 'none'
            }
        });
        button.prop("disabled", true);
        $.get(url).done(function (page) {
            $(target).find('.modal-title').html(modalTitle);
            $(target).find('.modal-body').html(page);
            $(target).modal('show');
            button.prop("disabled", false);
            button.unblock();
            $.validator.unobtrusive.parse($(target).find('.modal-body'));
            if (typeof callback !== "undefined") {
                var func = eval(callback)
                if (typeof func == 'function') {
                    func()
                }
            }
        });
    })
};