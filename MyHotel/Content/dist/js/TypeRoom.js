$(function () {
    $("#typeRoom").DataTable({
        "responsive": true,
        "autoWidth": true,
        "detroye": true
    });

    $("#btnNuevo").on("click", (event) => {
        event.preventDefault();
        var _url = event.target.href;
        $.ajax({
            type: "Get",
            url: _url,
            contentType: 'application/json',
            dataType: 'json',
            success: function (data, textStatus, jQxhr) {

                if (data.error === false) {
                    $("#modalContent").html(data.result);
                    $("#modal-sm").modal("show");
                    RegisterAjaxEvents();
                }
                else {
                    AlertError(data.result);
                }
            },
            error: function (jqXhr, textStatus, errorThrown) {
                AlertError(errorThrown);
            }
        });
    });

    $(document).on("click", "#btnEditar", (event) => {
        event.preventDefault();
        var _url = event.target.href;
        $.ajax({
            type: "Get",
            url: _url,
            contentType: 'application/json',
            dataType: 'json',
            success: function (data, textStatus, jQxhr) {
                if (data.error === false) {
                    $("#modalContent").html(data.result);
                    $("#modal-sm").modal("show");
                    RegisterAjaxEvents();
                }
                else {
                    AlertError(data.result);
                }
            },
            error: function (jqXhr, textStatus, errorThrown) {
                AlertError(errorThrown);
            }
        });
    });
});

function OnSuccess(data) {
    RegisterAjaxEvents();

    if (data.error === false) {
        AlertSuccess(data.result)
        $("#modal-sm").modal("hide");
        Load();
    }
    else {
        AlertError(data.result);
    }
}

function Load() {

    var _url = urlBase + 'TypeRoom/Table';

    $.ajax({
        type: "Get",
        url: _url,
        contentType: 'application/json',
        dataType: 'json',
        success: function (data, textStatus, jQxhr) {

            if (data.error === false) {
                $('#typeRoomcard').html(data.result);

                $("#typeRoom").DataTable({
                    "responsive": true,
                    "autoWidth": true,
                    "detroye": true
                });
            }
            else {
                AlertError(data.result);
            }
        },
        error: function (jqXhr, textStatus, errorThrown) {
            AlertError(jqXhr.responseText);
        }
    });
}