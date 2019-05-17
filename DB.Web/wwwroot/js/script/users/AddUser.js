layui.use(['form', 'table'], function () {
    var form = layui.form,
        table = layui.table;

   
    //提交
    form.on('submit(user_but)', function (obj) {
        var s = GetQueryString("Id");
        alert(s);
        //判断Id是否为空，如果为空执行添加操作，为空修改操作
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
                    Status: obj.field.Status
                },
                success: function (data) {
                    //layer.alert('添加成功！');
                    //table.reload('table');
                    form.layer.close(layer.index);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        } else {
            //修改
            $.ajax({
                type: 'POST',
                url: '/User/ModifyUser',
                dataType: "json",
                data: {
                    Id: obj.field.Id,
                    UserAccount: obj.field.UserAccount,
                    UserName: obj.field.UserName,
                    UserPassword: obj.field.UserPassword,
                    PhoneNumber: obj.field.PhoneNumber,
                    Email: obj.field.Email,
                    Status: obj.field.Status
                },
                success: function (data) {
                    //layer.alert('添加成功！');
                    //table.reload('table');
                    form.layer.close(layer.index);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        }

        return false;
    });
});