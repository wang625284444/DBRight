
layui.use(['table', 'layer', 'form'], function () {
    var table = layui.table,
        layer = layui.layer,
        form = layui.form;

    table.render({
        elem: '#table',
        url: '/User/QueryUser',//请求地址
        method: 'GET',//请求方式 GET
        title: '用户数据表',
        toolbar: '#toolbar',
        height: 'full-0',
        defaultToolbar: false,
        cellMinWidth: 20,
        page: true,//开启分页
        cols: [[
            { field: 'id', title: 'ID', hide: true },
            { field: 'userPassword', title: '密码', hide: true },
            { type: 'numbers', align: 'center', fixed: 'left' },
            { type: 'checkbox', align: 'center', fixed: 'left' },
            { field: 'userNumber', align: 'center', width: 110, title: '用户编码', unresize: true, fixed: 'left', sort: true },
            { field: 'userAccount', align: 'center', width: 100, title: '用户账号' },
            { field: 'userName', align: 'center', width: 100, title: '用户名称' },
            { field: 'phoneNumber', align: 'center', width: 120, title: '电话号' },
            { field: 'email', align: 'center', width: 140, title: '邮箱' },
            { field: 'status', align: 'center', width: 100, title: '用户状态' },
            { field: 'creationTime', align: 'center', width: 140, title: '创建日期' },
            { field: 'workflowStatus', align: 'center', width: 100, title: '审批状态' },
            { field: 'workflowTime', align: 'center', width: 140, title: '审批日期' },
            { fixed: 'right', align: 'center', title: '操作', unresize: true, toolbar: '#bar', width: 200 }
        ]]
    });

    //头工具栏事件
    table.on('toolbar(table)', function (obj) {

        switch (obj.event) {
            case 'but_query':
                //查询
                var index = layer.msg('查询中，请稍候...', { icon: 16, time: false, shade: 0 });
                setTimeout(function () {
                    table.reload('table', {
                        url: '/User/QueryUser',
                        where: {
                            UserNumber: $("#userNumber").val(),
                            UserAccount: $("#userAccount").val(),
                            Status: $("#status").val(),
                            WorkflowStatus: $("#workflowStatus").val()
                        }, page: {
                            curr: 1 //重新从第 1 页开始
                        }
                    });
                    layer.close(index);
                }, 800);
                break;
            case 'but_add':
                layer.open({
                    type: 2,
                    title: '用户添加',
                    area: ['400px', '420px'],
                    shade: 0,
                    maxmin: true,
                    content: './UserForm/cshtml',
                    zIndex: layer.zIndex, //重点1
                    success: function (layero, index) {
                        var body = layui.layer.getChildFrame('body', index); //获取页面body
                        body.find("#Id").val("");
                        layer.setTop(layero); //重点2
                    }
                });
                break;
            case 'but_SeeRole':
                //弹出查看角色模块
                $("#but_add").css({ "display": "none" });
                layer.msg('查看：' + obj.event);
                break;
        }
    });

    //监听行工具事件
    table.on('tool(table)', function (obj) {
        switch (obj.event) {
            case 'but_update':
                layer.open({
                    type: 2,
                    title: '用户修改',
                    area: ['400px', '420px'],
                    shade: 0,
                    maxmin: true,
                    content: './UserForm/cshtml',
                    zIndex: layer.zIndex, //重点1
                    success: function (layero, index) {
                        var body = layui.layer.getChildFrame('body', index); //获取页面body
                        //绑定参数
                        body.find("input[name='Id']").val(obj.data.id);
                        body.find("input[name='UserAccount']").val(obj.data.userAccount);
                        body.find("input[name='UserName']").val(obj.data.userName);
                        body.find("input[name='UserPassword']").val(obj.data.userPassword);
                        body.find("input[name='PhoneNumber']").val(obj.data.phoneNumber);
                        body.find("input[name='Email']").val(obj.data.email);
                        body.find("input[name='Status']").val(obj.data.status);
                        body.find("input[name='WorkflowStatus']").val(obj.data.workflowStatus);
                        form.render(); // 更新渲染
                        layer.setTop(layero); //重点2

                    }
                });
                break;
            case 'but_delete':
                //删除
                layer.confirm('是否删除？', function (index) {
                    $.ajax({
                        type: 'DELETE',
                        url: '/User/DelUserId',
                        data: { obj: obj.data.id },
                        dataType: "json",
                        success: function (data) {
                            layer.alert('删除成功！');
                            table.reload('table');
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            layer.alert(errorThrown);
                        }
                    });
                });
                break;
            case 'but_AddModuleRole':
                break;
        }
    });
});
