var deleteHandlerInitial = function () {
    $('button[data-toggle="delete"]').click(function (event) {
        var url = $(this).data('url');
        var id = $(this).data('id');
        var callback = $(this).data('callback');
        var button = $(this);
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

        swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to recover this record!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        }) .then((willDelete) => {
                if (willDelete) {
                    $.ajax({
                        url: url,
                        type: 'Post',
                        data: { id: id },
                        success: function (data) {
                            if (data.type == "success") {
                                toastr.success(data.message, data.title, {
                                    onShown: function () {
                                        if (typeof callback !== "undefined") {
                                            var func = eval(callback)
                                            if (typeof func == 'function') {
                                                func()
                                            }
                                        }
                                        button.unblock();
                                        button.prop("disabled", false);
                                    }
                                });
                            }
                           
                        }
                    });
                } else {
                    button.unblock();
                    button.prop("disabled", false);
                }
            });

    })
}