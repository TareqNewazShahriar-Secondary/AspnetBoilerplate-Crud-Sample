(function ($) {
    var _teamService = abp.services.app.teamService,
        _$table = $('#TeamsTable');

    _$table.DataTable({
        ajax: function (data, callback, settings) {
            //var filter = $('#UsersSearchForm').serializeFormToObject(true);
            //filter.maxResultCount = data.length;
            //filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _teamService.getAll().done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        }
    });
})(jQuery);
