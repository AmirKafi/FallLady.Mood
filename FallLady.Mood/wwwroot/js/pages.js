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