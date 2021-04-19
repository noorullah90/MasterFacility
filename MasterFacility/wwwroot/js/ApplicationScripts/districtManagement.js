$(function () {
    modalIntial();
    FillDatatable("/Administration/District/getList");
    fillDropDownByURL('provinceList', '/Lookups/ListProvinces');
    $('#provinceList').select2({
        placeholder: "Select a state",
        allowClear: true
    });
    $('#provinceList').on('change', function () {
        if (parseInt($('#provinceList option:selected').val()) > 0) {
            $("#example").dataTable().fnDestroy();
            $("#example tbody").html("");
            FillDatatable("/Administration/District/geListByProvince?provinceId=" + $('#provinceList option:selected').val());
        }
        else {
            $("#example").dataTable().fnDestroy();
            $("#example tbody").html("");
            FillDatatable("/Administration/District/getList");
        }

    });

    $('#activationFilterElement').on('change', function () {
        $("#example").dataTable().fnDestroy();
        $("#example tbody").html("");
        FillDatatable("/Administration/District/getList?onlyActive=" + $('#activationFilterElement option:selected').val());
    })
})

function FillDatatable(url) {
    $.extend($.fn.dataTable.defaults, {
        autoWidth: false,
        //dom: '<"datatable-header"fl><"datatable-scroll"t><"datatable-footer"ip>',
        language: {
            search: '<span>Filter:</span> _INPUT_',
            searchPlaceholder: 'Type to filter...',
            lengthMenu: '<span>Show:</span> _MENU_',
            paginate: { 'first': 'First', 'last': 'Last', 'next': $('html').attr('dir') == 'rtl' ? '&larr;' : '&rarr;', 'previous': $('html').attr('dir') == 'rtl' ? '&rarr;' : '&larr;' },


        }
    });
    $("#example").DataTable({

        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ordering": false,
        "bLengthChange": false,
        "drawCallback": function () {
            modalIntial();
        },
        "ajax": {
            "url": url,
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }],
        "columns": [
            { "data": "id", "id": "id", "autoWidth": true },
            { "data": "province", "province": "province", "autoWidth": true },
            { "data": "name", "name": "name", "autoWidth": true },
            { "data": "namedari", "namedari": "namedari", "autoWidth": true },
            { "data": "namepashto", "namepashto": "namepashto", "autoWidth": true },
            { "data": "isactive", "isactive": "isactive", "autoWidth": true },
            {
                "render": function (data, type, full, meta) { return ` <button data-toggle="ajax-modal" data-target="#exampleModalLong" data-callback="CreateFormInitialization" data-url="/Administration/District/Edit/${full.id}" data-modal-title="@DbRes.T("UpdateProvince", "Provinces")" class="btn btn-sm btn-icon btn-secondary"><i class="fa fa-pencil-alt"></i> <span class="sr-only">Edit</span></button>`; }
            },
            
        ]

    });

}


function CreateFormInitialization() {
    fillDropDownByURL('provinceid', '/Lookups/ListProvinces');
    $(".only-english").keypress(function (event) {
        var ew = event.which;
        if (ew == 32)
            return true;
        if (48 <= ew && ew <= 57)
            return true;
        if (65 <= ew && ew <= 90)
            return true;
        if (97 <= ew && ew <= 122)
            return true;
        return false;
    });

    $(".only-dari").keypress(function (event) {
        if (onlyDari(event.key) === false) 
            event.preventDefault();
    })

    $('#provinceid').select2({
        placeholder: "Select a state",
        allowClear: true
    });
}