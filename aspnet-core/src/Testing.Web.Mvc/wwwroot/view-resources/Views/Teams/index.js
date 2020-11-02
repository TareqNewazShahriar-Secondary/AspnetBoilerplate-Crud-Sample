(function ($) {
    var _teamService = abp.services.app.teamService,
        l = abp.localization.getSource('Testing'),
        _$table = $('#TeamsTable');

    _$table.DataTable({
        paging: true,
        serverSide: true,
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-user" data-user-id="${row.id}" data-toggle="modal" data-target="#UserEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-user" data-user-id="${row.id}" data-user-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ],
        ajax: function (data, callback, settings) {
            //var filter = $('#UsersSearchForm').serializeFormToObject(true);
            //filter.maxResultCount = data.length;
            //filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            var filter = { keyword: "", maxResultCount: 10, skipCount: 0 };
            _teamService.getAll(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$table.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        }
    });
})(jQuery);
