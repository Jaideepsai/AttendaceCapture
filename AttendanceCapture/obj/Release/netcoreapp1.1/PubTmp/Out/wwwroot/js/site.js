// Write your Javascript code.
$(".pmd-switch").find("input[type=checkbox]").on("change", function () {
    if ($(this).prop('checked') == true) {
       
         $(this).parent().parent().prev().prop('checked', true);

    }
    else {
        $(this).parent().parent().prev().prop('checked', false) 
    }
});
$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})
$('#datepicker-inline').datetimepicker({
    inline: true,
    format: 'MM/DD/YYYY'
});
window.onload = function () { $("#divLoader").hide(); };
$('#datetimepicker-default').datetimepicker({
    format: 'MM/DD/YYYY'
});
$('#datetimepicker-default-edit').datetimepicker({
    format: 'MM/DD/YYYY'
});