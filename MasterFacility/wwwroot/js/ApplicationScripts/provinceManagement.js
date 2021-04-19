$(function () {
    modalIntial();
    loadProvince();
});

function loadProvince() {
    $('#ContentContainer').load('/Administration/Province/ProvinceList', function () {
        $('#provinceTable').DataTable({
            drawCallback: function () {
                modalIntial();
            }
        });
    });
}
