$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/SelectInput/getData",
        data: "{}",
        success: function (data) {
            var s = '<option value="-1">Please Select a Car</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].DeptNo + '">' + data[i].EmpName + '</option>';
            }
            $("#departmentsDropdown").html(s);
        }
    });
});

function getValue() {
    var myVal = $("#departmentsDropdown").val();
    $("#show").val(myVal);
}