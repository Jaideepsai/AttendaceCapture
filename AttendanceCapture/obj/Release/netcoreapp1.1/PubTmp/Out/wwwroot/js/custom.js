$(document).ready(function () {
    var exampleDatatable = $('#example').DataTable({
        responsive: {
            details: {
                type: 'column',
                target: 'tr'
            }
        },
        scrollY: '60vh',
        order: [1, 'asc'],
        bFilter: true,
        bLengthChange: true,
        pagingType: "simple",
        "paging": true,
        "searching": true,
        "language": {
            "info": " _START_ - _END_ of _TOTAL_ ",
            "sLengthMenu": "<span class='custom-select-title'>Rows per page:</span> <span class='custom-select'> _MENU_ </span>",
            "sSearch": "",
            "sSearchPlaceholder": "Search",
            "paginate": {
                "sNext": " ",
                "sPrevious": " "
            },
        },
        dom:
        "<'pmd-card-title'<'data-table-title-responsive'><'search-paper pmd-textfield'f>>" +
        "<'row'<'col-sm-12'tr>>" +
        "<'pmd-card-footer' <'pmd-datatable-pagination' l i p>>",
    });

    /// Select value
    $('.custom-select-info').hide();
    
    $("div.data-table-title-responsive").html('<h2 class="pmd-card-title-text">Marked Attendance</h2>');

});

$('#datepicker-inline').datetimepicker({
    inline: true,
    format: 'MM/DD/YYYY'
});