var pageSize = 10;
var pageIndex = 0;
//var isLast = false;
var loadedId = null;
var provinceid = [];

$(document).ready(function () {
    $('#progressDom').hide();
    GetData();
    $('.board').bind('scroll', function () {
        if ($(this).scrollTop() + $(this).innerHeight() >= $(this)[0].scrollHeight) {
            GetData();
        }
    })
    filterList();
    modalIntial();
})

function GetData() {
    $.ajax({
        type: 'GET',
        url: '/Administration/Users/UserList',
        data: { pageIndex, pageSize },
        dataType: 'json',
        success: function (data) {
            data.forEach(function (item) {
                $(`
                    <div class="list-group-item " data-toggle="sidebar" data-sidebar="show">
                              <a href="#" class="stretched-link viewLink" data-id="${item.id}" ></a>
                    <div class="list-group-item-figure">
                        <div class="tile tile-circle bg-blue"> ${item.firstName.substring(0, 1)} </div>
                        </div>
                   
                    <div class="list-group-item-body">
                        <h4 class="list-group-item-title"> ${item.firstName} ${item.lastName}</h4>
                        <p class="list-group-item-text"> ${item.userName} </p>
                    </div><!-- /.list-group-item-body -->
                            </div><!-- /.list-group-item -->
                `).insertBefore('#progressDom');

            })

            $('.viewLink').on('click', function () {
                let link = $(this).parent('.list-group-item');
                let id = $(this).data('id');
                link.block({
                    message: `<div class="spinner-grow text-primary" style="width: 3rem; height: 3rem;" role="status">
                        <span class="sr-only"></span>
                      </div>`,
                    overlayCSS: {
                        backgroundColor: '#fff',
                        opacity: 0,
                        cursor: 'wait',
                        alignItems: 'center'
                    },
                    css: {
                        border: 0,
                        padding: 0,
                        backgroundColor: 'none',
                        alignItems: 'center'
                    }
                });
                $('#user-section').block({
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
                viewDetail(id);
                loadedId = id;
                link.unblock();
            })

        },
        beforeSend: function () {
            $('#progressDom').show();
        },
        complete: function () {
            $('#progressDom').hide();
        },
        error: function () {
            alert('Error');
        }

    })
}

function filterList() {
    $(document).on('keyup', '[data-filter]', function () {
        var target = $(this).data('filter');
        var value = $(this).val().toLowerCase();
        var text;
        $(target).filter(function () {
            text = $(this).text().toLowerCase();
            $(this).toggle(text.indexOf(value) > -1);
            $('#progressDom').hide();
            let lastTest = $('.board .list-group-item').length;
            console.log(lastTest);
        });
    });
}

function addProvince() {
    $('#provincesSaveBtn').prop("disabled", true);
    $("#selectAll").click(function () {
        $("input[type=checkbox]").prop('checked', $(this).prop('checked'));

    });
    $('input[type=checkbox]').change(
        function () {
            let data = [];
            $(':checkbox:checked').each(function (i) {
                data.push(parseInt($(this).val()));
            });
            data = data.filter(function (el) {
                if (!isNaN(el))
                    return el;
            });

            provinceid = data.map(function (i) {
                return { UserId: loadedId, ProvinceId: i }
            });
            console.log(provinceid);
            if (provinceid.length > 0)
                $('#provincesSaveBtn').prop("disabled", false);
            else
                $('#provincesSaveBtn').prop("disabled", true);
        });
}


function viewDetail(id) {
    $.get(`/Administration/Users/Details/${id}`).done(function (page) {
        $('#user-section').html(page);
        modalIntial();
        deleteHandlerInitial();
    })
}

function reloadCurrentRecord() {
    viewDetail(loadedId)
}


function saveProvince(obj) {
    var button = $(obj);
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
    $.ajax({
        url: '/Administration/Users/AddProvinces',
        type: 'Post',
        data: { data: provinceid },
        success: function (data) {
            if (data.type == "success") {
                toastr.success(data.message, data.title, {
                    onShown: function () {
                        reloadCurrentRecord();
                        $('.modal').modal("hide");
                        button.unblock();
                        button.prop("disabled", false);
                    }
                });
            }
            else {
                toastr[data.type](data.message, data.title, {
                    onShown: function () {
                        button.unblock();
                        button.prop("disabled", false);
                    }
                });
            }

        }
    });

}