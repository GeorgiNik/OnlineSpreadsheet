$(function () {
    var elements = [$('.modal-content input'), $('.modal-content textarea')];
    var selects = $('.modal-content select');
    var approve = $('#modal-approve');

    $.each(elements, function () {
        $(this).prop('disabled', true);
    });

    //approve.prop('disabled', true);
    //approve.fadeTo(0, 0.4);

    $('#btn-edit').click(function () {
        $.each(elements, function () {
            if (!$(this).hasClass('forbidden')) {
                $(this).prop('disabled', false);
            }
        });

        approve.prop('disabled', false);
        approve.fadeTo(0, 1);
    });
});
