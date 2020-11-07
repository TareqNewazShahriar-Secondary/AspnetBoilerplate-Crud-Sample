(function ($) {
    var _teamService = abp.services.app.teamService,
        l = abp.localization.getSource('Testing'),
        _$table = $('#TeamsTable'),
        _$modal = $('#TeamCreateModal'),
        _$form = _$modal.find('form');

    var _$teamsTable = _$table.DataTable({
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
                        `   <button type="button" class="btn btn-sm bg-secondary edit-team" data-team-id="${row.id}" data-toggle="modal" data-target="#TeamEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-team" data-team-id="${row.id}" data-team-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ],
        ajax: function (data, callback, settings) {
            //var filter = $('#TeamsSearchForm').serializeFormToObject(true);
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
                action: () => _$teamsTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        }
    });

    _$form.validate({
        rules: {
            Password: "required",
            ConfirmPassword: {
                equalTo: "#Password"
            }
        }
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var team = _$form.serializeFormToObject();
        team.roleNames = [];
        var _$roleCheckboxes = _$form[0].querySelectorAll("input[name='role']:checked");
        if (_$roleCheckboxes) {
            for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
                var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
                team.roleNames.push(_$roleCheckbox.val());
            }
        }

        abp.ui.setBusy(_$modal);
        _teamService.create(team).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$teamsTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-team', function () {
        var teamId = $(this).attr("data-team-id");
        var teamName = $(this).attr('data-team-name');

        deleteTeam(teamId, teamName);
    });

    function deleteTeam(teamId, teamName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                teamName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _teamService.delete({
                        id: teamId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$teamsTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-team', function (e) {
        var teamId = $(this).attr("data-team-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Teams/EditModal?teamId=' + teamId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#TeamEditModal div.modal-content').html(content);
            },
            error: function (e) { console.error('on team edit', e); }
        });
    });

    //$(document).on('click', 'a[data-target="#TeamCreateModal"]', (e) => {
    //    $('.nav-tabs a[href="#team-details"]').tab('show')
    //});

    abp.event.on('team.edited', (data) => {
        _$teamsTable.ajax.reload();
    });
    
    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

})(jQuery);
