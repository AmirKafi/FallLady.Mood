//#region Message

window.messageReadFormatter = function (messageId, row) {
    return "<button class='btn btn-sm btn-info m-1 readMessage' data-id='" + messageId + "'>مشاهده پیام</button> ";
}
window.messageReadEvents = {
    'click button.readMessage': function (row) {
        var $this, url;
        $this = $(this);
        url = $('table[data-toggle=table]').data("readUrl");

        $.ajax({
            url: url,
            type: "GET",
            cache: false,
            data: {
                messageId: $this.data("id")
            }
        }).done(function (data, textStatus, jqXHR) {
            if ((data != null ? data.length : void 0) === 0) {
                toastr["error"]((_ref1 = data.message) != null ? _ref1 : resource.exception.editError);
                return;
            }
            window.$table.bootstrapTable("refresh", {
                silent: true,
                pageNumber: 1
            });
            content = data;
            setTimeout(function () {
                var name, title, _ref1, _ref2;
                $this.dialog({
                    title: "مشاهده پیام",
                    mode: "medium",
                    showFooter: false,
                    destroyAfterClose: true,
                    content: content
                });
            }, 700);
        }).fail(function (msg) {
            toastr["error"](msg.status === 403 ? resource.exception.forbidden : resource.exception.serverError);
        });
    }
}


$(document).on("click", ".btn-sendMessage", function (e) {
    var $btnSave;
    $btnSave = $(this);

    var form = $btnSave.closest("form");
    if (form.valid()) {
        $btnSave.prop("disabled", true);
        $.ajax({
            url: form.attr("action"),
            method: "POST",
            data: new FormData(form.get(0)),
            processData: false,
            contentType: false,
            cache: false
        }).done(function (data, textStatus, jqXHR) {
            var _ref3;
            autoDestroyToastr();
            if (data.resultStatus !== 1 && data.resultStatus !== -2) {
                toastr["error"]((_ref3 = data.message) != null ? _ref3 : resource.exception.saveError);
                return;
            }
            toastr["success"](resource.message.saveSuccess);
            form.reset();
        }).fail(function (msg) {
            autoDestroyToastr();
            content = msg.status === 403 ? msg.statusText : "Error";
            if (content === "Error") {
                toastr["error"](resource.exception.addError);
                return;
            }
            if (content === "Forbidden") {
                toastr["error"](resource.exception.addForbidden);
                return;
            }
        }).always(function () {
            $btnSave.prop("disabled", false);
            manuallyDestroyToastr();
        });
    } else {
        window.gotoErrorModal();
    }
});
//#endregion