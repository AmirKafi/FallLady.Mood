(function () {

    var autoDestroyToastr, manuallyDestroyToastr;

    autoDestroyToastr = function (tapToDismiss) {
        toastr.options.tapToDismiss = tapToDismiss === void 0 ? true : tapToDismiss;
        toastr.options.preventDuplicates = false;
        toastr.options.closeButton = false;
        toastr.options.timeOut = "5000";
        return toastr.options.extendedTimeOut = "1000";
    };

    manuallyDestroyToastr = function (tapToDismiss) {
        toastr.options.tapToDismiss = tapToDismiss === void 0 ? true : tapToDismiss;
        toastr.options.preventDuplicates = false;
        toastr.options.closeButton = true;
        toastr.options.timeOut = "0";
        return toastr.options.extendedTimeOut = "0";
    };

    $(document).on("click", ".btn-signIn", function (e) {
        var $createItem, content, url, _ref;
        e.preventDefault();
        $createItem = $(this);
        $.fn.dialog.defaults = $.extend({}, $.fn.dialog.defaults, {
            saveBtnLabel: resource.dialog.save,
            cancelBtnLabel: resource.dialog.cancel,
            closeLabel: resource.dialog.close
        });

        content = "";
        $createItem.tooltip("hide");
        url = $createItem.data("url");
        $.ajax({
            url: url,
            type: "GET",
            cache: false
        }).done(function (data, textStatus, jqXHR) {

            var _ref1;
            if ((data != null ? data.length : void 0) === 0) {
                toastr["error"]((_ref1 = data.message) != null ? _ref1 : resource.exception.addError);
                return;
            }
            setTimeout(function () {
                $createItem.dialog({
                    title: "ورود",
                    mode: "medium",
                    destroyAfterClose: true,
                    content: content,
                    showFooter:false,
                    onSaveClick: function (e) {
                        var $btnSave, form;
                        $btnSave = $(e);
                        form = $btnSave.parent().prev().find("form");
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

                                if (data.resultStatus !== "Successful") {
                                    toastr["error"]((_ref = data.message) != null ? _ref : "متاسفانه ورود با خطا مواجه شد");
                                    $(".refresh-captcha").trigger("click");
                                    form.get(0).reset();
                                    return;
                                }
                                toastr["success"]("ورود شما با موفقیت انجام شد");
                                window.location = "/Account/Index";
                                toastr["success"](resource.message.saveSuccess);
                                $createItem.data("dialog").hide($createItem.data("dialogId"));
                                window.$table.bootstrapTable("refresh", {
                                    silent: true,
                                    pageNumber: 1
                                });
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
                    },
                    onBeforeOpen: function () {
                        var persianCalendar;
                        $('form').validateBootstrap(true);
                        window.inputmasks();
                        $(".dialog-body select").selectpicker({
                            container: "body"
                        });
                        persianCalendar = $.calendars.instance('persian', 'fa');
                        $(".shamsi").calendarsPicker({
                            calendar: persianCalendar
                        }, $.calendarsPicker.regionalOptions['fa']);

                        imageFiles = $("input[type=file].imageFile");
                        _.each(imageFiles, function (imageFile, index) {
                            var fileName, imagePreview, imageThumbnails, _ref;
                            $(imageFile).fileinput({
                                language: "fa",
                                showUpload: false,
                                uploadAsync: true,
                                allowedFileExtensions: ["jpg", "png", "pdf", "xlsx", "docx"],
                                fileActionSettings: {
                                    showDrag: false
                                }
                            });
                            fileName = $("#" + ((_ref = $(imageFile).data('fileName')) != null ? _ref : 'FileName')).val();
                            if (fileName === "undefined" || fileName === void 0 || fileName === "") {
                                fileName = [];
                            }
                            if (fileName.length > 0) {
                                imagePreview = $("" + ($(imageFile).data('previewTarget')));
                                imageThumbnails = imagePreview.find(".file-preview-thumbnails");
                                imagePreview.removeClass("hidden");
                                imageThumbnails.append("<div class='file-preview-frame krajee-default kv-preview-thumb' data-fileindex='" + index + "' data-template='image'> <div class='kv-file-content'> <img src='" + ($(imageFile).data('url')) + "/" + fileName + "' class='kv-preview-data file-preview-image' style='width:auto;height:160px;' /> </div> <div> <div class='file-footer-buttons'> <button type='button' data-id='" + fileName + "' class='kv-file-remove btn btn-xs btn-default'><i class='glyphicon glyphicon-trash text-danger'></i></button> </div> <div class='clearfix'></div> </div> </div>");
                                $(document).off("click", "" + ($(imageFile).data('previewTarget')) + " .close.fileinput-remove");
                                $(document).on("click", "" + ($(imageFile).data('previewTarget')) + " .close.fileinput-remove", function () {
                                    bootbox.confirm("آیا واقعا میخواهید همه فایل ها را حذف کنید؟", function (result) {
                                        var _ref1;
                                        if (result === true) {
                                            $("#" + ((_ref1 = $(imageFile).data('fileName')) != null ? _ref1 : 'FileName')).val("");
                                            imageThumbnails.empty();
                                            return imagePreview.addClass("hidden");
                                        }
                                    });
                                });
                                $(document).off("click", "" + ($(imageFile).data('previewTarget')) + " .kv-file-remove");
                                return $(document).on("click", "" + ($(imageFile).data('previewTarget')) + " .kv-file-remove", function () {
                                    var $this, id;
                                    $this = $(this);
                                    id = $this.attr("data-id");
                                    bootbox.confirm("آیا واقعا میخواهید این فایل را حذف کنید؟", function (result) {
                                        var _ref1, _ref2;
                                        if (result === true) {
                                            $("#" + ((_ref1 = $(imageFile).data('fileName')) != null ? _ref1 : 'FileName')).val("");
                                            $this.closest(".file-preview-frame").remove();
                                            if (((_ref2 = imageThumbnails.find(".file-preview-frame")) != null ? _ref2.length : void 0) === 0) {
                                                return imagePreview.addClass("hidden");
                                            }
                                        }
                                    });
                                });
                            }
                        });

                        _.each($(".dialog-body .tree"), function (item, index) {
                            $("#" + item.id).jstree({
                                'core': {
                                    'data': {
                                        type: "POST",
                                        "url": $(item).attr("data_url"),
                                        "data": function (node) {
                                            return {
                                                "__RequestVerificationToken": $("input[name=__RequestVerificationToken]").val()
                                            };
                                        }
                                    }
                                },
                                "checkbox": {
                                    keep_selected_style: true,
                                    three_state: true, // to avoid that fact that checking a node also check others
                                    tie_selection: true // for checking without selecting and selecting without checking
                                },
                                "plugins": [$(item).attr("data_plugins")]
                            });

                            $("#" + item.id).on("check_node.jstree uncheck_node.jstree",
                                function (e, data) {
                                    var selectedElmsIds = [];
                                    var selectedElms = $("#" + item.id).jstree("get_checked", true);
                                    $.each(selectedElms, function () {
                                        selectedElmsIds.push(parseInt(this.id));
                                    });
                                    var listName = ((_ref = $(item).attr("data_list")) != null ? _ref : 'list');
                                    $("#" + listName).val(selectedElmsIds);
                                });
                        });

                        _.each($(".dialog-body select.shortcut"), function (item, index) {
                            var wrapper;
                            if ($(item).closest(".input-group").length > 0) {
                                return;
                            }
                            wrapper = $("<div class='input-group ig_" + index + "'/>");
                            $(item).parent().wrap(wrapper);
                            wrapper = $(".dialog-body .ig_" + index);
                            if ($(item).data("refreshUrl") != null) {
                                wrapper.append("<span class='input-group-btn'> <button class='btn btn-default refresh' type='button' style=' border: 2px solid #E020FF; border-radius: 7px; background: transparent; color: #E020FF;' data-url='" + ($(item).data('refreshUrl')) + "' data-parent='" + ($(item).data('parent')) + "'><i class='glyphicon glyphicon-refresh icon-refresh'></i></button> </span>");
                            }
                            if ($(item).data("newUrl") != null) {
                                wrapper.append("<span class='input-group-btn'> <a href='javascript:void(0)' data-dialog-title='" + ($(item).data('dialogTitle')) + "' data-url='" + ($(item).data('newUrl')) + "' class='btn btn-default btn-shortcut createItem'><i class='material-icons'>add</i></a> </span>");
                            }
                        });
                    }
                });
            }, 700);
            content = data;
        }).fail(function (msg) {
            content = msg.status === 403 ? "Forbidden" : "Error";
        }).always(function () {
            if (content === "Error") {
                toastr["error"](resource.exception.addError);
                return;
            }
            if (content === "Forbidden") {
                toastr["error"](resource.exception.addForbidden);
                return;
            }
        });
    });

    $(document).on("click", "a.logOff", function () {
        return $("#singoutForm").submit();
    });

    $(document).on("click", "a.btnChangePass", function () {
        var $this, form;
        $this = $(this);
        form = $this.closest("form");
        $this.prop("disabled", true);
        $.ajax({
            method: "POST",
            data: new FormData(form.get(0)),
            processData: false,
            contentType: false,
            cache: false
        }).done(function (data, textStatus, jqXHR) {
            var _ref;
            autoDestroyToastr();
            if (data.resultStatus !== "Successful") {
                toastr["error"]((_ref = data.message) != null ? _ref : "متاسفانه ذخیره با خطا مواجه شد");
                form.get(0).reset();
                return;
            }
            toastr["success"]("رمز عبور شما با موفقیت تغییر یافت");
            location.reload();
        }).always(function () {
            $(".refresh-captcha").trigger("click");
            $this.prop("disabled", false);
            manuallyDestroyToastr();
        });
        return;
    });
}).call(this);