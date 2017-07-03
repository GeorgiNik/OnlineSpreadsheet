$(function () {
    $('#modal-container').on('shown.bs.modal', function () {
        $(document).off('focusin.modal');
    });
    $('#second-modal-container').on('shown.bs.modal', function () {
        $(document).off('focusin.modal');
    });
    $('body').on('click', '.modal-link', function (e) {
        e.preventDefault();
        var attr = $(this).attr('disabled');
        if (typeof attr !== typeof undefined && attr !== false) {
            return;
        }
        $(this).attr('data-ajax', 'true');
        $(this).attr('data-ajax-mode', 'replace');
        $(this).attr('data-ajax-update', '#modal-container');
        $(this).attr('data-target', '#modal-container');
        $(this).attr('data-toggle', 'modal');
    });
    $('body').on('click', '.modal-close-btn', function () {
        $('#modal-container').modal('hide');
    });
    $('#modal-container').on('hidden.bs.modal', function () {
        $(this).removeData('bs.modal').empty();
    });
    $('body').on('click', '.second-modal-link', function (e) {
        e.preventDefault();
        var attr = $(this).attr('disabled');
        if (typeof attr !== typeof undefined && attr !== false) {
            return;
        }
        $(this).attr('data-ajax', 'true');
        $(this).attr('data-ajax-mode', 'replace');
        $(this).attr('data-ajax-update', '#second-modal-container');
        $(this).attr('data-target', '#second-modal-container');
        $(this).attr('data-toggle', 'modal');
    });
    $('body').on('click', '.second-modal-close-btn', function () {
        $('#second-modal-container').modal('hide');
    });
    $('#second-modal-container').on('hidden.bs.modal', function () {
        $(this).removeData('bs.modal').empty();
    });
    $('body').on('click', '#btn-close-confirmation', function () {
        if (!$('#second-modal-container').html()) {
            console.log("close");
            $(this).attr('data-backdrop', 'static');
            $(this).attr('data-target', '#second-modal-container');
            $(this).attr('data-toggle', 'modal');
            $('#second-modal-container').load("/Home/ConfirmationPopup");
            $('#second-modal-container').show();
        }
        else {
            $('#second-modal-container').modal('hide');
        }
    });
    $('body').on('click', '.btn-confirm-back', function () {
        $('#second-modal-container').modal('hide');
        $('body').addClass('modal-open');
    });
    $('body').on('click', '#btn-confirm-dismiss', function () {
        $('#modal-container').modal('hide');
        $('#second-modal-container').modal('hide');
    });
});