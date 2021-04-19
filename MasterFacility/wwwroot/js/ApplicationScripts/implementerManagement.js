$(function () {
    modalIntial();
    loadImplementer();
});

function loadImplementer() {
    $('#ContentContainer').load('/Administration/Implementer/ImplementerList', function () {
        $('#ImplementerTable').DataTable({
            drawCallback: function () {
                modalIntial();
            }
        });
    });
}
