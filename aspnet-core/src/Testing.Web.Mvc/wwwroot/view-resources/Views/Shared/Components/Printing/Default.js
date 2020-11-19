(function ($, jsPDF) {
    let openerButton = $('button#print-modal-opener');
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

                    modal.find('button#export-to-pdf').off().on('click', function () {
                        let doc = new jsPDF({
                            unit: 'px',
                            format: 'a4'
                        });
                        doc.fromHTML(modal.find('.modal-body').html());
                        doc.save('test.pdf');
                    });
                },
                error: function (e) {
                    console.error('on print component', e);
                }
            });
        });
    }
})(jQuery, jsPDF);
