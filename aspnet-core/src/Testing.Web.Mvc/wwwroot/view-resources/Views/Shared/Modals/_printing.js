setTimeout(function () {
    (function ($) {
        let button = $('button[data-print-view]');
        button.click(function (e) {
            abp.ajax({
                url: $('input#print-view-url').val(),
                type: 'GET',
                dataType: 'html',
                success: function (content) {
                    $('#PrintModal div[data-printing-content]').html(content);
                },
                error: function (e) { console.error('on print component', e); }
            });
        });

        $('button[data-print]').click(function () {
            window.print();
        });

    })(jQuery);
}, 2000);
