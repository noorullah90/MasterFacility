$(function () {

    modalIntial();
    loadProgram();
  
});

function loadProgram() {
    $('#ContentContainer').load('/Administration/Program/ProgramList', function () {
        $('#ProgramTable').DataTable({
            drawCallback: function () {
                modalIntial();
            }
        });
    });
}

function CreateFormInitialization() {

    fillDropDownByLookup('donorcode', 17);
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
}