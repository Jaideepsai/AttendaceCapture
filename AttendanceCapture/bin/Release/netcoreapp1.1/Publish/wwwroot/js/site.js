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
    format: 'DD/MM/YYYY'
});
window.onload = function () { $("#divLoader").hide(); };
$('#datetimepicker-default').datetimepicker({
    format: 'DD/MM/YYYY'
});
$('#datetimepicker-default-edit').datetimepicker({
    format: 'DD/MM/YYYY'
});