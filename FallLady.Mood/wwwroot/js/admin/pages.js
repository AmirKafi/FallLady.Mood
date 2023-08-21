//#region Course
window.courseAdditionalParams = function () {
    return {

    }
}

$(document).on("change", "select#CourseType", function (e) {
    if ($(this).val() === "Online") {
        $(".course-create .offlineCourse").css("display", "none");
        $(".course-create .onlineCourse").css("display", "flex");
    } else if ($(this).val() === "Offline") {
        $(".course-create .onlineCourse").css("display", "none");
        $(".course-create .offlineCourse").css("display", "flex");
    } else {
        $(".course-create .onlineCourse").css("display", "none");
        $(".course-create .offlineCourse").css("display", "none");
    }
});

//#endregion

//#region Teacher

window.teacherAdditionalParams = function () {
    return {

    }
}

//#endregion

//#region User

window.userAdditionalParams = function () {
    return {

    }
}

window.promoteToAdminFormatter = function (role, row) {
    console.log(row);
    if (role === 2)//User
        return "<button class='btn btn-sm btn-success m-1 promoteToAdmin' data-id='" + row.id + "'><span class='glyphicon glyphicon-arrow-up'></span>ارتقا به مدیرسیستم</button>";
    else
        return "<button class='btn btn-sm btn-info m-1'>مدیرسیستم</button> ";
}
window.promoteToAdminEvents = {
    'click button.promoteToAdmin': function (row) {
        var $this, url;
        $this = $(this);
        url = $('table[data-toggle=table]').data("promoteUrl");

        $.ajax({
            url: url,
            type: "POST",
            cache: false,
            data: {
                id: $this.data("id")
            }
        }).done(function (data, textStatus, jqXHR) {
            if ((data != null ? data.length : void 0) === 0) {
                toastr["error"]((_ref1 = data.message) != null ? _ref1 : resource.exception.editError);
                return;
            }

            toastr["success"]("عملیات با موفقیت انجام شد");
            $('table[data-toggle=table]').bootstrapTable("refresh", {
                silent: true,
                pageNumber: 1
            });
        }).fail(function (msg) {
            toastr["error"](msg.status === 403 ? resource.exception.forbidden : resource.exception.serverError);
        });
    }
}

//#endregion