layui.use(['form', 'layer'], function () {
    var form = layui.form,
        layer = layui.layer;

    //提交
    form.on('submit(user_but)', function (obj) {
        var status = status === "on" ? "Normal" : "Disable";
        if (obj.field.Id === "") {
            //添加
            $.ajax({
                type: 'POST',
                url: '/User/AddUser',
                dataType: "json",
                data: {
                    UserAccount: obj.field.UserAccount,
                    UserName: obj.field.UserName,
                    UserPassword: obj.field.UserPassword,
                    PhoneNumber: obj.field.PhoneNumber,
                    Email: obj.field.Email,
                    Status: status
                },
                success: function (data) {
                    layer.alert('添加成功！');
                    //table.reload('table');
                    layer.closeAll();
                    //form.layer.close(layer.index);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        } else {
            //修改
            $.ajax({
                type: 'PUT',
                url: '/User/ModifyUser',
                dataType: "json",
                data: {
                    Id: obj.field.Id,
                    UserAccount: obj.field.UserAccount,
                    UserName: obj.field.UserName,
                    UserPassword: obj.field.UserPassword,
                    PhoneNumber: obj.field.PhoneNumber,
                    Email: obj.field.Email,
                    WorkflowStatus: obj.field.WorkflowStatus,
                    Status: status
                },
                success: function (data) {
                    layer.alert('修改成功！');
                    //table.reload('table');
                    form.layer.close(layer.index);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        }
    });
    //初始化
    form.on('submit(reset_but)', function (obj) {
        if (obj.field.Id === "") {
            $("input[name='Id']").val("");
            $("input[name='UserAccount']").val("");
            $("input[name='UserName']").val("");
            $("input[name='UserPassword']").val("");
            $("input[name='PhoneNumber']").val("");
            $("input[name='Email']").val("");
            $("input[name='Status']").val("");
        } else {
            //修改

        }
    });
});