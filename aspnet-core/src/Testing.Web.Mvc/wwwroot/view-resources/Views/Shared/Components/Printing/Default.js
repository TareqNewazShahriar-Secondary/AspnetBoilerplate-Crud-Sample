(function ($) {
    let openerButton = $('button#print-dialog-opener');
    if (openerButton.length) {
        openerButton.click(function () {
            abp.ajax({
                url: $('input#print-view-url').val(),
                type: 'GET',
                dataType: 'html',
                success: function (content) {
                    let modal = $('#PrintModal');
                    modal.find('.modal-body').html(content);

                    modal.find('button#print').off().on('click', function () {
                        window.print();
                        $('#PrintModal').modal('hide');
                    });
                },
                error: function (e) {
                    console.error('on print component', e);
                }
            });
        });
    }
})(jQuery);
