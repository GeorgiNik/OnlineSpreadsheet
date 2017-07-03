$('body').on('click', '.modal-link', function (e) {
    e.preventDefault();

    var attr = $(this).attr('disabled');

    if (typeof attr !== typeof undefined && attr !== false) {
        return;
    }

    $(this).attr('data-target', '#modal-container');
    $(this).attr('data-toggle', 'modal');
    $(this).attr('data-ajax', 'true');
    $(this).attr('data-ajax-mode', 'replace');
    $(this).attr('data-ajax-update', '#modal-container');
});

$('body').on('click', '.modal-close-btn', function () {
    $('#modal-container').modal('hide');
});

$('#modal-container').on('hidden.bs.modal', function () {
    $(this).removeData('bs.modal').empty();
});
