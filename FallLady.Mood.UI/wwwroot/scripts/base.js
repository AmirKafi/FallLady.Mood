(function () {



    $('div[class*="list"]').on("change", "select.selectpicker", function () {
        window.$table.bootstrapTable("refresh", {
            silent: true,
            pageNumber: 1
        });
    });

    // For Refresh Lists On Press Enter Key In Index Views
    $('div[class*="list"]').on("keypress", "input", function (even) {
        if (event.keyCode == 13) {
            $('table[data-toggle=table]').bootstrapTable("refresh", {
                silent: true,
                pageNumber: 1
            });
        }
    });

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": true,
        "positionClass": "toast-bottom-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut",
        "tapToDismiss": true
    };

    $(document).ajaxStart(function () {
        $("#loading").show();
    });

    $(document).ajaxStop(function () {
        $("#loading").hide();
    });

    window.getAllUrlParams = function (url) {
        // get query string from url (optional) or window
        var queryString = url ? url.split('?')[1] : window.location.search.slice(1);

        // we'll store the parameters here
        var obj = {};

        // if query string exists
        if (queryString) {

            // stuff after # is not part of query string, so get rid of it
            queryString = queryString.split('#')[0];

            // split our query string into its component parts
            var arr = queryString.split('&');

            for (var i = 0; i < arr.length; i++) {
                // separate the keys and the values
                var a = arr[i].split('=');

                // set parameter name and value (use 'true' if empty)
                var paramName = a[0];
                var paramValue = typeof (a[1]) === 'undefined' ? true : a[1];

                // (optional) keep case consistent
                paramName = paramName.toLowerCase();
                if (typeof paramValue === 'string') paramValue = paramValue.toLowerCase();

                // if the paramName ends with square brackets, e.g. colors[] or colors[2]
                if (paramName.match(/\[(\d+)?\]$/)) {

                    // create key if it doesn't exist
                    var key = paramName.replace(/\[(\d+)?\]/, '');
                    if (!obj[key]) obj[key] = [];

                    // if it's an indexed array e.g. colors[2]
                    if (paramName.match(/\[\d+\]$/)) {
                        // get the index value and add the entry at the appropriate position
                        var index = /\[(\d+)\]/.exec(paramName)[1];
                        obj[key][index] = paramValue;
                    } else {
                        // otherwise add the value to the end of the array
                        obj[key].push(paramValue);
                    }
                } else {
                    // we're dealing with a string
                    if (!obj[paramName]) {
                        // if it doesn't exist, create property
                        obj[paramName] = paramValue;
                    } else if (obj[paramName] && typeof obj[paramName] === 'string') {
                        // if property does exist and it's a string, convert it to an array
                        obj[paramName] = [obj[paramName]];
                        obj[paramName].push(paramValue);
                    } else {
                        // otherwise add the property
                        obj[paramName].push(paramValue);
                    }
                }
            }
        }

        return obj;
    };

    window.getRandomInt = function (min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    };

    window.execFunc = function () {
        var args, context, func, i, name, namespace, namespaces, _i, _len;
        name = arguments[0], context = arguments[1], args = 3 <= arguments.length ? __slice.call(arguments, 2) : [];
        if ((name != null ? name.length : void 0) === 0) {
            return void 0;
        }
        namespaces = name.split(".");
        func = namespaces.pop();
        for (i = _i = 0, _len = namespaces.length; _i < _len; i = ++_i) {
            namespace = namespaces[i];
            context = context[namespace];
        }
        return context[func].apply(context, args);
    };

    window.gotoError = function () {
        $("body").delay(100).animate({
            scrollTop: $(".form-group.has-error:first").offset().top - 15 - $("header").height()
        }, {
            duration: 500
        });
    };

    window.gotoErrorModal = function () {
        $(".dialog-modal.dialog--open").delay(500).animate({
            scrollTop: $(".dialog-modal.dialog--open").scrollTop() + $(".form-group.has-error:first").offset().top - 15
        }, {
            duration: 500
        });
    };

    window.loader = function (preventScroll) {
        if (preventScroll == null) {
            preventScroll = true;
        }
    };



    resource = {
        message: {
            success: "ذخیره با موفقیت انجام شد",
            deleteError: "متاسفانه حذف با خطا مواجه شد",
            deleteSuccess: "حذف با موفقیت انجام شد",
            deleteFileQuestion: "آیا واقعا میخواهید این فایل را حذف کنید؟",
            deleteFilesQuestion: "آیا واقعا میخواهید همه فایل ها را حذف کنید؟",
            deleteQuestion: "آیا واقعا می خواهید این رکورد را حذف کنید؟",
            saveSuccess: "ذخیره با موفقیت انجام شد",
            deleteSuccess: "حذف با موفقیت انجام شد",
            recordNotFound: "هیچ رکوردی یافت نشد",
            notSelected: "هیچ موردی انتخاب نشده است",
            deleteQuestion: function (len) {
                return "آیا واقعا می خواهید موارد انتخاب شده (" + len + " رکورد) را حذف کنید؟";
            },
            ConfirmQuestion: "آیا واقعا میخواهید این مورد را تایید کنید ؟",
            UnConfirmQuestion: "آیا واقعا میخاهید این مورد را لغو تایید کنید ؟",
            ConfirmProcessQuestion: "آیا از انجام این عملیات اطمینان دارید ؟"
        },
        exception: {
            forbidden: "شما دسترسی لازم را ندارید",
            addForbidden: "شما دسترسی لازم برای درج را ندارید",
            editForbidden: "شما دسترسی لازم برای ویرایش را ندارید",
            detailForbidden: "شما دسترسی لازم برای نمایش جزئیات را ندارید",
            deleteForbidden: "شما دسترسی لازم برای حذف را ندارید",
            addError: "متاسفانه درج با خطا مواجه شد",
            editError: "متاسفانه ویرایش با خطا مواجه شد",
            detailError: "متاسفانه نمایش جزئیات با خطا مواجه شد",
            deleteError: "متاسفانه حذف با خطا مواجه شد",
            saveError: "متاسفانه ذخیره با خطا مواجه شد",
            loadError: "متاسفانه بارگذاری اطلاعات با خطا مواجه شد",
            serverError: "متاسفانه خطایی رخ داده است"
        },
        validation: {
            isRequired: "این فیلد اجباری است"
        },
        selectionForm: {
            save: "ذخیره",
            cancel: "انصراف"
        },
        dialog: {
            save: "ذخیره",
            cancel: "انصراف",
            close: "بستن",
            new: "جدید"
        },
        info: {
            lat: 34.6541675,
            lng: 50.8705117
        }
    };

    window.getScrollBarWidth = function () {
        var $outer, widthWithScroll;
        $outer = $('<div>').css({
            visibility: 'hidden',
            width: 100,
            overflow: 'scroll'
        }).appendTo('body');
        widthWithScroll = $('<div>').css({
            width: '100%'
        }).appendTo($outer).outerWidth();
        $outer.remove();
        return 100 - widthWithScroll;
    };

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

    window.addQueryStringParm = function (url, name, value) {
        var add, change, regex;
        if (value === void 0) {
            return url;
        }
        regex = new RegExp("([?&]" + name + "=)[^&]+", "");
        add = function (sep) {
            url += ("" + sep + name + "=") + encodeURIComponent(value);
        };
        change = function () {
            url = url.replace(regex, "$1" + encodeURIComponent(value));
        };
        if (url.indexOf("?") === -1) {
            add("?");
        } else {
            if (regex.test(url)) {
                change();
            } else {
                add("&");
            }
        }
        return url;
    };

    $(document).on("click", ".refresh-captcha", function () {
        var captchaImage;
        captchaImage = $("img.captcha-image");
        captchaImage.attr("src", window.addQueryStringParm(captchaImage.attr("src"), "rdnDate", new Date().getTime()));
    });


    $(document).on("click", ".showtoastr", function () {
        toastr["info"]("Toastr Is here");
    });

    persianCalendar = $.calendars.instance('persian', 'fa');

    $(".shamsi").calendarsPicker({
        calendar: persianCalendar
    }, $.calendarsPicker.regionalOptions['fa']);


    window.inputmasks = function () {
        $(".nationalityCode").inputmask({
            "mask": "9999999999",
            clearIncomplete: true
        });
        $(".phone").inputmask({
            "mask": "09999999999",
            clearIncomplete: true
        });
        $(".mobile").inputmask({
            "mask": "09999999999",
            clearIncomplete: true
        });
        $(".form").inputmask({
            "mask": "999",
            clearIncomplete: true
        });

        $(".formAction").inputmask({
            "mask": "99",
            clearIncomplete: true
        });
        $(".formState").inputmask({
            "mask": "9999",
            clearIncomplete: true
        });
        $(".threeDigit").inputmask({
            "mask": "999",
            "min": 100,
            "max": 999,
            clearIncomplete: true
        });

        $(".shamsi").inputmask("shamsi");

        $(".email").inputmask("email", {
            clearIncomplete: true
        });
        $(".numberOnly").inputmask("Regex", {
            regex: "[0-9]*"
        });

        $(".captchaField").inputmask("Regex", {
            regex: "[0-9]*"
        });

        $(".numberDash").inputmask("Regex", {
            regex: "[0-9\-]*"
        });
        $(".numberDot").inputmask("Regex", {
            regex: "[0-9-.]*"
        });

        $(".letterOnly").inputmask("Regex", {
            regex: "[a-zA-Z0-9]*"
        });
        $(".onlyEngLetter").inputmask("Regex", {
            regex: "[a-zA-Z]*"
        });
        $(".letterDash").inputmask("Regex", {
            regex: "[a-zA-Z\-]*"
        });
        $(".letterPersianOnly").inputmask({
            "mask": "l{1}",
            definitions: {
                "l": {
                    validator: "[\u0627-\u06CC]"
                }
            }
        });

        $(".dangerCode").inputmask({
            mask: "Hs{3}",
            definitions: { 's': { validator: "[0-9-.]" } }
        });

        $(".unitedNation").inputmask("Regex", {
            regex: "[0-9][0-9.]*[0-9]"
        });

        $(".webSiteAllowedLetters").inputmask("Regex", {
            regex: "[a-zA-Z0-9-.-@-/]*"
        });



        $('.plateCode').on('click',
            function () {
                var value = $(this).val();
                if ($(this).getCursorPosition() > 0) {
                    var char = value[$(this).getCursorPosition() - 1];
                    if (char === undefined || char.match(/[a-zA-Z]/i))
                        $(this).selectRange(0);
                }
            });

        $(".plateCode").inputmask({

            "mask": "9{2} l{1} 9{3} \u0627\u06CC\u0631\u0627\u0646 9{2}",
            showMaskOnHover: false,
            definitions: {
                "l": {
                    validator: "[\u0627-\u06CC]"
                }
            }
        });

        $(".plateCodeLtr").inputmask({

            "mask": "9{2} \u0627\u06CC\u0631\u0627\u0646 9{3} l{1} 9{2} ",
            showMaskOnHover: false,
            //removeMaskOnSubmit: true,
            definitions: {
                "l": {
                    validator: "[\u0627-\u06CC]"
                }
            }
        });


        $(".plateCodeRegister").inputmask({
            "mask": "9{2} l{1} 9{3} \u0627\u06CC\u0631\u0627\u0646 9{2}",
            clearIncomplete: true,
            definitions: {
                "l": {
                    validator: "[\u0627-\u06CC]"
                }

            }
        });

        $(".integer").inputmask("integer", {
            allowMinus: false,
            allowPlus: false,
            rightAlign: false
        });
        $(".integer.cost").inputmask("integer", {
            allowMinus: true,
            allowPlus: false,
            rightAlign: false,
            autoGroup: true,
            groupSeparator: ","
        });

        $(".decimal").inputmask("decimal", {
            digits: 2,
            allowMinus: false,
            allowPlus: false,
            rightAlign: false
        });

        $(".time").inputmask("hh:mm", {
            clearIncomplete: true
        });

        $(".year").inputmask({
            "mask": "9999",
            clearIncomplete: true
        });
    };

    window.inputmasks();

    $(document).on("click", "button.btn-print[data-url]", function () {
        var $this, additionalParams, downloadTimer, generateForm, inputs, params, token, url, waitCount;
        $this = $(this);
        url = $this.data("url");
        token = new Date().getTime();
        params = {};
        params.__RequestVerificationToken = $("input[name=__RequestVerificationToken]").val();
        params.token = token;
        additionalParams = $this.data("additionalParams");
        if (additionalParams != null) {
            params = $.extend({}, window.execFunc(additionalParams, window), params);
        }
        inputs = [];
        _.each(_.keys(params), function (item) {
            inputs.push("<input type='hidden' name='" + item + "' value='" + params[item] + "' />");
        });
        $.ajax({
            url: url,
            type: "POST",
            cache: false,
            data: params
        }).done(function (data, textStatus, jqXHR) {

            if (data.message === "NoDataToPrint") {
                toastr["warning"]("دیتایی برای پرینت وجود ندارد");
                return;
            }
            if (data === "FillTheSearchFields") {
                toastr["error"]("برای پرینت باید فیلد های سرچ پر شوند");
                return;
            }
            if (data === "Error") {
                toastr["error"]("متاسفانه پرینت با خطا مواجه شد");
                return;
            }
            var pdfWindow = window.open("");
            pdfWindow.document.write(
                "<iframe width='100%' height='100%' src='data:application/pdf;base64, " +
                encodeURI(data) +
                "'></iframe>"
            );
        }).fail(function (msg) {
            toastr["error"](msg.status === 403 ? resource.exception.forbidden : resource.exception.serverError);
        });
    });
}).call(this);

