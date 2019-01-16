Ext.onReady(function () {

    var workflowStore = Ext.create("Ext.data.Store", {
        fields: ["Name", "Value"],
        data: [
            { Name: "--请选择--", Value: null },
            { Name: "未提交", Value: 0 },
            { Name: "待审核", Value: 100 },
            { Name: "审批通过", Value: 200 },
            { Name: "审批拒绝", Value: 300 }
        ]
    });
    //创建按钮
    var nowTbar = Ext.create('Ext.Container', {
        items: [{
            //tbar第一行工具栏
            xtype: "toolbar",
            width: 1116,//宽度
            items: [{
                id: 'text_UserNumber',
                fieldLabel: '用户编码',
                labelWidth: 60,
                xtype: 'textfield',
                width: 200

            }, {
                id: 'text_UserAccount',
                fieldLabel: '用户账号',
                labelWidth: 60,
                xtype: 'textfield',
                width: 200
            }, {
                id: 'text_UserName',
                fieldLabel: '用户名称',
                labelWidth: 60,
                xtype: 'textfield',
                width: 200
            }, {
                id: 'text_Workflow',
                fieldLabel: '审批状态',
                labelWidth: 60,
                xtype: 'combobox',
                displayField: "Name",
                valueField: "Value",
                emptyText: "--请选择--",
                store: workflowStore,
                width: 200
            }, {
                xtype: 'button',
                text: '查询',
                margin: '0 10 0 0',
                    height: 30,
                width: 75,
                handler: function () {
                    store.reload({

                    });
                }
            }]
        }, {
            //tbar第二行工具栏
            xtype: "toolbar",
            items: [
                {
                    xtype: 'button',
                    id: 'but_add',
                    text: '添加用户',
                    margin: '0 10 0 0',
                    height: 30,
                    width: 75,
                    handler: function () {
                        winAddUser.show();
                    }
                }, {
                    xtype: 'button',
                    id: 'but_update',
                    text: '修改用户',
                    margin: '0 10 0 0',
                    height: 30,
                    width: 75,
                    handler: function () {
                        var recs = grid.getSelectionModel().getSelection();
                        if (recs.length === 1) {
                            Ext.getCmp("modify_Id").setValue(recs[0].data.id);
                            Ext.getCmp("modify_UserName").setValue(recs[0].data.userName);
                            Ext.getCmp("modify_UserPassword").setValue(recs[0].data.userPassword);
                            Ext.getCmp("modify_UserAccount").setValue(recs[0].data.userAccount);
                            Ext.getCmp("modify_PhoneNumber").setValue(recs[0].data.phoneNumber);
                            Ext.getCmp("modify_Mail").setValue(recs[0].data.mail);
                            winModifyUser.show();
                        } else {
                            Ext.Msg.alert("提示", "请选择一条数据！");
                        }
                    }
                }, {
                    xtype: 'button',
                    id: 'but_delete',
                    text: '删除用户',
                    margin: '0 10 0 0',
                    height: 30,
                    width: 75,
                    handler: function () {
                        var list = [];
                        var selectedData = grid.getSelectionModel().getSelection();
                        if (selectedData.length !== 0) {
                            for (var i = 0; i < selectedData.length; i++) {
                                var userList = { Id: selectedData[i].id };
                                list.push(userList);
                            }
                            Ext.Ajax.request({
                                url: '/User/DelUserId',
                                method: 'POST',
                                params: { obj: JSON.stringify(list) },
                                success: function (response) {
                                    var obj = JSON.parse(response.responseText);
                                    Ext.Msg.alert('提示', obj.status_message);
                                    store.load();
                                },
                                failure: function (response) {
                                    Ext.Msg.alert('失败', '请求超时或网络故障，错误编号：' + response.status);
                                }
                            });
                        } else {
                            Ext.Msg.alert('提示', '请选择数据，最少一条！');
                        }
                    }
                }, {
                    xtype: 'button',
                    id: 'bit_ble',
                    text: '禁用/启用',
                    margin: '0 10 0 0',
                    height: 30,
                    width: 80,
                    handler: function () {
                        var selectedData = grid.getSelectionModel().getSelection();
                        if (selectedData.length === 1) {
                            Ext.Ajax.request({
                                url: '/User/UpdateStatusUserId',
                                method: 'POST',
                                params: {
                                    guid: selectedData[0].data.id
                                },
                                success: function (response) {
                                    var obj = JSON.parse(response.responseText);
                                    Ext.Msg.alert('提示', obj.status_message);
                                    store.load();
                                },
                                failure: function (response) {
                                    Ext.Msg.alert('失败', '请求超时或网络故障，错误编号：' + response.status);
                                }
                            });
                        } else {
                            Ext.Msg.alert('提示', '请选择一条数据！');
                        }

                    }
                }]
        }]
    });
    //创建grid数据源
    var store = Ext.create('Ext.data.Store', {
        pageSize: 10,  //页容量10条数据\
        proxy: {
            type: 'ajax',
            url: '/User/QueryUser',
            actionMethods: { read: 'POST' },
            reader: {   //这里的reader为数据存储组织的地方
                type: 'json',
                rootProperty: 'rows',
                totalProperty: 'total'
            }
        },
        listeners: {
            'beforeload': function (store) {
                var params = {
                    UserNumber: Ext.getCmp('text_UserNumber').getValue(),
                    UserAccount: Ext.getCmp('text_UserAccount').getValue(),
                    UserName: Ext.getCmp('text_UserName').getValue(),
                    WorkflowStatus: Ext.getCmp('text_Workflow').getValue()
                };
                Ext.apply(store.proxy.extraParams, params);
            }
        },
        sorters: [{
            property: 'creationTime',//排序字段。
            direction: 'desc'//排序类型，默认为 ASC 
        }],
        autoLoad: true  //即时加载数据
    });
    //创建Grid
    var grid = Ext.create('Ext.grid.Panel', {
        renderTo: 'grid',
        region: 'south',
        loadMask: { msg: '正在加载数据，请稍侯……' },
        autoHeight: true,
        forceFit: true,
        //设置自适应的高度
        height: document.documentElement.clientHeight - 100,
        frame: true,
        split: false,
        layout: "fit",
        margin: 2,
        autoScroll: true,
        tbar: [nowTbar],
        store: store,
        selModel: { selType: 'checkboxmodel' },   //选择框
        columns: [
            { text: 'ID', dataIndex: 'id', hidden: true },
            { text: '密码', dataIndex: 'userPassword', hidden: true },
            { text: '用户编码', dataIndex: 'userNumber', maxWidth: 120, align: 'center' },
            { text: '用户账号', dataIndex: 'userAccount', maxWidth: 120, align: 'center' },
            { text: '用户名称', dataIndex: 'userName', maxWidth: 120, align: 'center' },
            { text: '电话号', dataIndex: 'phoneNumber', maxWidth: 120, align: 'center' },
            { text: '邮箱', dataIndex: 'mail', maxWidth: 160, align: 'center' },
            {
                text: '用户状态', dataIndex: 'status', maxWidth: 80, align: 'center', renderer: function (value) {
                    if (value === 0) {
                        return "启用";
                    } else {
                        return "禁用";
                    }
                }
            },
            { text: '创建日期', dataIndex: 'creationTime', maxWidth: 140, align: 'center', renderer: Ext.util.Format.dateRenderer('Y-m-d H:i') },
            {
                text: '审批状态', dataIndex: 'workflowStatus', maxWidth: 120, align: 'center', renderer: function (value) {
                    switch (value) {
                        case 0:
                            return "未提交";
                        case 100:
                            return "待审核";
                        case 200:
                            return "审批通过";
                        case 300:
                            return "审批拒绝";

                    }
                }
            },
            { text: '审批日期', dataIndex: 'workflowTime', maxWidth: 140, align: 'center', renderer: Ext.util.Format.dateRenderer('Y-m-d H:i') }
        ],
        bbar: [{
            xtype: 'pagingtoolbar',
            store: store,
            displayMsg: '显示 {0} - {1} 条，共计 {2} 条',
            emptyMsg: "没有数据",
            beforePageText: "当前页",
            afterPageText: "共{0}页",
            displayInfo: true
        }]
    });
    //添加用户
    var addform = new Ext.FormPanel({
        bodyStyle: 'padding:5px 5px 0',
        layout: 'form',
        items: [
            { xtype: 'textfield', fieldLabel: '用户账号', id: 'add_UserAccount', name: 'title', anchor: '100%', allowBlank: false },
            { xtype: 'textfield', fieldLabel: '用户名称', id: 'add_UserName', name: 'title', anchor: '100%', allowBlank: false },
            { xtype: 'textfield', fieldLabel: '用户密码', id: 'add_UserPassword', name: 'title', anchor: '100%', inputType: 'password', allowBlank: false },
            { xtype: 'textfield', fieldLabel: '用户电话', id: 'add_PhoneNumber', name: 'title', anchor: '100%' },
            { xtype: 'textfield', fieldLabel: '用户邮箱', id: 'add_Mail', name: 'title', anchor: '100%' }
        ],
        buttonAlign: 'center',
        buttons: [
            {
                text: '保存',
                handler: function () {
                    Ext.Ajax.request({
                        url: '/User/AddUser',
                        method: 'POST',
                        params: {
                            UserName: Ext.getCmp('add_UserName').getValue(),
                            UserAccount: Ext.getCmp('add_UserAccount').getValue(),
                            UserPassword: Ext.getCmp('add_UserPassword').getValue(),
                            PhoneNumber: Ext.getCmp('add_PhoneNumber').getValue(),
                            Mail: Ext.getCmp('add_Mail').getValue()
                        },
                        success: function (response) {
                            var obj = JSON.parse(response.responseText);
                            Ext.Msg.alert('提示', obj.status_message);

                            store.load();//重新加载数据
                            addform.reset();//清空Window所有控件内容
                            winAddUser.close();//关闭
                        },
                        failure: function (response) {
                            Ext.Msg.alert('失败', '请求超时或网络故障，错误编号：' + response.status);
                        }
                    });
                }
            }, {
                text: '关闭',
                handler: function () {
                    store.load();//重新加载数据
                    addform.reset();//清空Window所有控件内容
                    winAddUser.close();//关闭
                }
            }
        ]
    });
    //添加用户
    var winAddUser = Ext.create("Ext.window.Window", {
        title: "添加用户",
        draggable: false,
        closable: false,
        closeAction: 'close', //关闭
        height: 320, //高度
        width: 350,//宽度
        layout: "fit",//窗口布局类型
        modal: true, //是否模态窗口，默认为false
        resizable: false,
        items: [addform]
    });
    //修改用户
    var modifyForm = new Ext.FormPanel({
        bodyStyle: 'padding:5px 5px 0',
        layout: 'form',
        items: [
            { xtype: 'textfield', fieldLabel: 'id', id: 'modify_Id', hidden: true },
            { xtype: 'textfield', fieldLabel: '用户账号', id: 'modify_UserAccount', name: 'title', anchor: '100%', readOnly: true },
            { xtype: 'textfield', fieldLabel: '用户名称', id: 'modify_UserName', name: 'title', anchor: '100%', allowBlank: false },
            { xtype: 'textfield', fieldLabel: '用户密码', id: 'modify_UserPassword', name: 'title', anchor: '100%', inputType: 'password', allowBlank: false },
            { xtype: 'textfield', fieldLabel: '用户电话', id: 'modify_PhoneNumber', name: 'title', anchor: '100%' },
            { xtype: 'textfield', fieldLabel: '用户邮箱', id: 'modify_Mail', name: 'title', anchor: '100%' }
        ],
        buttonAlign: 'center',
        buttons: [
            {
                text: '保存',
                handler: function () {
                    Ext.Ajax.request({
                        url: '/User/ModifyUser',
                        method: 'POST',
                        params: {
                            Id: Ext.getCmp('modify_Id').getValue(),
                            UserName: Ext.getCmp('modify_UserName').getValue(),
                            UserAccount: Ext.getCmp('modify_UserAccount').getValue(),
                            UserPassword: Ext.getCmp('modify_UserPassword').getValue(),
                            PhoneNumber: Ext.getCmp('modify_PhoneNumber').getValue(),
                            Mail: Ext.getCmp('modify_Mail').getValue()
                        },
                        success: function (response) {
                            var obj = JSON.parse(response.responseText);
                            Ext.Msg.alert('提示', obj.status_message);

                            store.load();//重新加载数据
                            modifyForm.reset();//清空Window所有控件内容
                            winModifyUser.close();//关闭
                        },
                        failure: function (response) {
                            Ext.Msg.alert('失败', '请求超时或网络故障，错误编号：' + response.status);
                        }
                    });
                }
            }, {
                text: '关闭',
                handler: function () {
                    store.load();//重新加载数据
                    modifyForm.reset();//清空Window所有控件内容
                    winModifyUser.close();//关闭
                }
            }
        ]
    });
    //修改用户
    var winModifyUser = Ext.create("Ext.window.Window", {
        title: "修改用户",
        draggable: false,
        closdraggable: false,
        closable: false,
        closeAction: 'close', //关闭
        height: 320, //高度
        width: 350,//宽度
        layout: "fit",//窗口布局类型
        modal: true, //是否模态窗口，默认为false
        resizable: false,
        items: [modifyForm]
    });
});
