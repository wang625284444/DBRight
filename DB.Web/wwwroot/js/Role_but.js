$(function () {
    var iframe = $('#content_info', parent.document).click();

    $.ajax({
        type: 'GET',
        url: '/RoleButtion/QueryByRoleList',
        data: { guid: iframe[0].name },
        dataType: "json",
        success: function (data) {
            for (var i = 0; i <= data.data.length - 1; i++) {
                //$("#" + data.data[i].ModuleButtion.ButtionId + "").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            layer.alert(errorThrown);
        }
    });
});