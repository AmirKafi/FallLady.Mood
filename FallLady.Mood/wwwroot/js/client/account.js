
$(document).on("click", ".btn-login", function (e) {
    var $btnSave;
    $btnSave = $(this);
    var form = $btnSave.closest("form");
    if (form.valid()) {
        $btnSave.prop("disabled", true);
        $.ajax({
            url: $btnSave.data("url"),
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

            var modal = window.modal;
            modal.data("dialog").hide(modal.data("dialogId"));
            window.location = "/";
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

$(document).on("click", ".btn-register", function (e) {
    var $btnSave;
    $btnSave = $(this);
    var form = $btnSave.closest("form");
    if (form.valid()) {
        $btnSave.prop("disabled", true);
        $.ajax({
            url: $btnSave.data("url"),
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

            var modal = window.modal;
            modal.data("dialog").hide(modal.data("dialogId"));
            window.location = "/";
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

$(document).on("click", ".signOut[data-url]", function () {
    var $this, deleteDialog, ids;
    $this = $(this);
    autoDestroyToastr();
    content = "<p>آیا از خروج از سامانه مطمئن هستید؟</p>";
    setTimeout(function () {
        $this.dialog({
            mode: "small",
            showHeader: false,
            destroyAfterClose: true,
            content: content,
            onSaveClick: function (e) {
                $.ajax({
                    url: $this.data("url"),
                    type: "POST",
                    cache: false,
                    data: {
                        "__RequestVerificationToken": $("input[name=__RequestVerificationToken]").val()
                    }
                }).done(function (data, textStatus, jqXHR) {
                    window.location = "/";
                }).fail(function (msg) {
                    toastr["error"](msg.status === 403 ? resource.exception.deleteForbidden : resource.exception.deleteError);
                }).always(function () { });
            }
        });
    }, 700);
    return false;
});
