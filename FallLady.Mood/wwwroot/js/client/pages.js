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

//#region Courses

$(document).on("click", ".btn-addToCart", function (e) {
    var $btn;
    $btn = $(this);

    $btn.prop("disabled", true);
    $.ajax({
        url: $btn.data("url"),
        method: "POST",
        data: {
            orderType: "Course",
            orderItemId: $(".course-details #CourseId").val()
        },
    }).done(function (data, textStatus, jqXHR) {
        var _ref3;
        autoDestroyToastr();
        if (data.resultStatus !== 1 && data.resultStatus !== -2) {
            toastr["error"]((_ref3 = data.message) != null ? _ref3 : resource.exception.saveError);
            return;
        }
        toastr["success"](resource.message.saveSuccess);
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
        $btn.prop("disabled", false);
        manuallyDestroyToastr();
    });
});

//#endregion

//#region Orders

window.orderAjaxRequest = function (params) {
    var additionalParams;
    params.type = "post";
    params.data.__RequestVerificationToken = $("input[name=__RequestVerificationToken]").val();
    params.url = $table.data("url");
    params.contentType = "application/x-www-form-urlencoded; charset=UTF-8";
    additionalParams = window.$table.data("additionalParams");
    setTimeout(function () {
        $.ajax(params).done(function (data, textStatus, jqXHR) {
            var objects, _ref;

            if (data.resultStatus !== 1 && data.resultStatus !== -2) {
                toastr["error"]((_ref3 = data.message) != null ? _ref3 : resource.exception.saveError);
                return;
            }

            objects = {
                total: data.total,
                rows: data.data
            };
            window.$table.bootstrapTable('load', objects);

            let totalPrice = 0.0, discountPrice = 0.0, payablePrice = 0.0,taxPrice = 0.0;

            discountPrice = parseFloat($(".order-list #DiscountPrice").html());

            _.each(data.data, function (item) {
                totalPrice += item.totalPrice;
            });
            taxPrice = (totalPrice - discountPrice) * (9 / 100);
            console.log((totalPrice - discountPrice) * (0.09));
            console.log(taxPrice)
            payablePrice = (totalPrice - discountPrice) + taxPrice;

            $(".order-list #DiscountPrice").html(window.separateThreeDigit(discountPrice.toFixed(0)))
            $(".order-list #TotalPrice").html(window.separateThreeDigit(totalPrice.toFixed(0)));
            $(".order-list #PayablePrice").html(window.separateThreeDigit(payablePrice.toFixed(0)));
            $(".order-list #TaxPrice").html(window.separateThreeDigit(taxPrice.toFixed(0)));


        }).fail(function (msg) {
            toastr["error"](msg.status === 403 ? resource.exception.forbidden : resource.exception.serverError);
        }).always(function () { });
    }, 313);
};

$(document).on("click", ".removeAllOrders", function (e) {
    var $btn;
    $btn = $(this);

    $btn.prop("disabled", true);
    $.ajax({
        url: $btn.data("url"),
        method: "POST",
    }).done(function (data, textStatus, jqXHR) {
        var _ref3;
        autoDestroyToastr();
        if (data.resultStatus !== 1 && data.resultStatus !== -2) {
            toastr["error"]("متاسفانه عملیات با خطا مواجه شد");
            return;
        }
        toastr["success"](resource.message.success);
        window.$table.bootstrapTable("refresh", {
            silent: true,
            pageNumber: 1
        });
    }).fail(function (msg) {
        autoDestroyToastr();
        content = msg.status === 403 ? msg.statusText : "Error";
        if (content === "Error") {
            toastr["error"]("متاسفانه عملیات با خطا مواجه شد");
            return;
        }
    }).always(function () {
        $btn.prop("disabled", false);
        manuallyDestroyToastr();
    });
});

//#endregion

$(document).on("click", ".search-btn", function (e) {
    var $btn;
    $btn = $(this);
    var text = $("#SearchText").val();

    window.location = "/Search?query=" + text;
});

