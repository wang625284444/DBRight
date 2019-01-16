Ext.onReady(function () {
    //获取角色下拉
    var boxStore = new Ext.data.Store({
        proxy: new Ext.data.HttpProxy({
            url: '/Role/QueryRoleEffective'
        }),
        reader: new Ext.data.JsonReader(
            { data: '' },
            ['roleName', 'id']
        ),
        remoteSort: false
    });
    //创建按钮
    var nowTbar = Ext.create('Ext.Container', {
        items: [{
            //tbar第一行工具栏
            xtype: "toolbar",
            width: 1116,//宽度
            items: [{
                id: 'text_RoleName',
                fieldLabel: '角色名称',
                labelWidth: 60,
                xtype: 'textfield',
                width: 200
            }, {
                xtype: 'button',
                text: '查询',
                margin: '0 10 0 0',
                height: 30,
                width: 75,
                handler: function () {
                    store.load();//重新加载数据
                }
            }]
        }, {
            //tbar第二行工具栏
            xtype: "toolbar",
            items: [
                {
                    xtype: 'button',
                    id: 'but_add',
                    text: '添加角色',
                    margin: '0 10 0 0',
                    height: 30,
                    width: 75,
                    handler: function () {
                        winAddRole.show();
                    }
                }, {
                    xtype: 'button',
                    id: 'but_update',
                    text: '修改角色',
                    margin: '0 10 0 0',
                    height: 30,
                    width: 75,
                    handler: function () {
                        var recs = grid.getSelectionModel().getSelection();
                        if (recs.length === 1) {
                            Ext.getCmp("modify_Id").setValue(recs[0].data.id);
                            Ext.getCmp("modify_RoleId").setValue(recs[0].data.userName);
                            Ext.getCmp("modify_RoleName").setValue(recs[0].data.userPassword);
                            winModifyRole.show();
                        } else {
                            Ext.Msg.alert("提示", "请选择一条数据！");
                        }

                    }
                }, {
                    xtype: 'button',
                    id: 'but_delete',
                    text: '删除角色',
                    margin: '0 10 0 0',
                    height: 30,
                    width: 75,
                    handler: function () {
                        Ext.Msg.confirm('选择框', '您确定要删除一下数据？', function (btn) {
                            if (btn === 'Yes') {
                                var list = [];
                                var selectedData = grid.getSelectionModel().getSelection();
                                if (selectedData.length !== 0) {
                                    for (var i = 0; i < selectedData.length; i++) {
                                        roleList = { Id: selectedData[i].id };
                                        list.push(roleList);
                                    }
                                    Ext.Ajax.request({
                                        url: '/Role/DelRoleId',
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
                        });
                    }
                }, {
                    xtype: 'button',
                    //id: 'but_SeeRole',
                    text: '添加模块',
                    margin: '0 10 0 0',
                    height: 30,
                    width: 75,
                    handler: function () {
                        var recs = grid.getSelectionModel().getSelection();
                        if (recs.length === 1) {
                            winModulrTree.show();

                            Ext.Ajax.request({
                                url: '/Module/QueryInId',
                                params: { guid: recs[0].data.id },
                                success: function (response) {
                                    var json = JSON.parse(response.responseText);
                                    var roonodes = treeFrom.getRootNode().childNodes; //获取主节点; 
                                    for (var i = 0; i < roonodes.length; i++) { //从节点中取出子节点依次遍历

                                        for (var j = 0; j < roonodes[i].childNodes.length; j++) {//循环子节点

                                            for (var k = 0; k < json.dataList.length; k++) { //循环要勾选的数据
                                                if (roonodes[i].childNodes[j].data.id === json.dataList[k].Id) {
                                                    //当查询数据存在勾选这个节点
                                                    //roonodes[i].childNodes[j].parentNode.ui.checkbox.checked = false;
                                                    //roonodes[i].childNodes[j].attributes.checked = 'checked';

                                                }
                                            }
                                        }
                                    }
                                }
                            });
                        }
                    }
                }, {
                    xtype: 'button',
                    id: 'but_SeeRole',
                    text: '查看角色层级',
                    margin: '0 10 0 0',
                    height: 30,
                    width: 100,
                    handler: function () {
                        Ext.Msg.alert('提示', '请选择数据，最少一条！');
                    }
                }]
        }]
    });
    //创建grid数据源
    var store = Ext.create('Ext.data.Store', {
        pageSize: 10,  //页容量10条数据\
        proxy: {
            type: 'ajax',
            url: '/Role/QueryRole',
            extraParams: {},//post给后台的参数
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
                    RoleName: Ext.getCmp('text_RoleName').getValue()
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
            { text: '模块名称', dataIndex: 'roleName', maxWidth: 120, align: 'center' },
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
    //添加角色
    var addform = new Ext.FormPanel({
        bodyStyle: 'padding:5px 5px 0',
        layout: 'form',
        items: [
            {
                id: 'add_RoleId',
                fieldLabel: '上级角色',
                labelWidth: 60,
                xtype: 'combobox',
                valueField: 'id',
                displayField: 'roleName',
                store: boxStore,
                width: 200,
                allowBlank: false,
                editable: false,
                forceSelection: true,
                selectOnFocus: true,
                listeners: { //监听 
                    render: function (combo) {//渲染 
                        combo.getStore().on("load", function (s, r, o) {
                            combo.setValue(r[0].get('id'));//第一个值 
                        });
                    }
                }
            },
            { xtype: 'textfield', fieldLabel: '角色名称', id: 'add_RoleName', name: 'title', anchor: '100%', allowBlank: false }
        ],
        buttonAlign: 'center',
        buttons: [
            {
                text: '保存',
                handler: function () {
                    Ext.Ajax.request({
                        url: '/Role/AddRole',
                        method: 'POST',
                        params: {
                            Pid: Ext.getCmp('add_RoleId').getValue(),
                            RoleName: Ext.getCmp('add_RoleName').getValue()
                        },
                        success: function (response) {
                            var obj = JSON.parse(response.responseText);
                            Ext.Msg.alert('提示', obj.status_message);

                            store.load();//重新加载数据
                            addform.reset();//清空Window所有控件内容
                            winAddRole.close();//关闭
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
                    winAddRole.close();//关闭
                }
            }
        ]
    });
    //添加角色
    var winAddRole = Ext.create("Ext.window.Window", {
        title: "添加模块",
        draggable: false,
        closable: false,
        closeAction: 'close', //关闭
        height: 200, //高度
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
            {
                id: 'modify_RoleId',
                fieldLabel: '上级角色',
                labelWidth: 60,
                xtype: 'combobox',
                valueField: 'id',
                displayField: 'roleName',
                triggerAction: 'all',
                store: boxStore,
                width: 200,
                allowBlank: false,
                editable: false,
                forceSelection: true,
                selectOnFocus: true

            },
            { xtype: 'textfield', fieldLabel: '角色名称', id: 'modify_RoleName', name: 'title', anchor: '100%' }
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
                            UserAccount: Ext.getCmp('modify_UserAccount').getValue()
                        },
                        success: function (response) {
                            var obj = JSON.parse(response.responseText);
                            Ext.Msg.alert('提示', obj.status_message);

                            store.load();//重新加载数据
                            modifyForm.reset();//清空Window所有控件内容
                            winModifyRole.close();//关闭
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
                    winModifyRole.close();//关闭
                }
            }
        ]
    });
    //修改用户
    var winModifyRole = Ext.create("Ext.window.Window", {
        title: "修改用户",
        draggable: false,
        closdraggable: false,
        closable: false,
        closeAction: 'close', //关闭
        height: 200, //高度
        width: 350,//宽度
        layout: "fit",//窗口布局类型
        modal: true, //是否模态窗口，默认为false
        resizable: false,
        items: [modifyForm]
    });
    //添加模块
    var treeFrom = new Ext.tree.Panel({
        rootVisible: false,
        collapsible: false,
        useArrows: true,
        frame: true,
        animate: false,
        store: Ext.create('Ext.data.TreeStore', {
            proxy: {
                type: 'ajax',
                url: '/Module/Query',
                reader: {
                    type: 'json'
                }
            },
            root: {
                expanded: true
            }
        }),
        viewConfig: {
            onCheckboxChange: function (e, t) {
                var item = e.getTarget(this.getItemSelector(), this.getTargetEl()), record;
                if (item) {
                    record = this.getRecord(item);
                    var check = !record.get('checked');
                    record.set('checked', check);
                    if (check) {
                        record.bubble(function (parentNode) {
                            parentNode.set('checked', true);
                            parentNode.expand(false, true);
                        });
                        record.cascadeBy(function (node) {
                            node.set('checked', true);
                            node.expand(false, true);
                        });
                    } else {
                        record.cascadeBy(function (node) {
                            node.set('checked', false);
                        });
                    }
                }
            }
        },
        buttonAlign: 'center',
        buttons: [
            {
                text: '保存',
                handler: function () {
                    //获取所有选择的tree
                    var recs = grid.getSelectionModel().getSelection()[0].data.id;
                    var list = [];
                    var nodes = treeFrom.getChecked();
                    Ext.each(nodes, function (node) {
                        //alert(node.data.id);
                        //子节点 也就是用户节点
                        if (node.data.leaf) {
                            var moduleList = { RoleId: recs, ModuleId: node.data.id };
                            list.push(moduleList);
                        }
                    });
                    Ext.Ajax.request({
                        url: '/RoleModule/AddModuleToArray',
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
                }
            }, {
                text: '关闭',
                handler: function () {
                    winModulrTree.close();
                }
            }]
    });
    treeFrom.expandAll();
    //添加模块
    var winModulrTree = Ext.create("Ext.window.Window", {
        title: "角色模块管理",
        draggable: false,
        closdraggable: false,
        closable: false,
        closeAction: 'close', //关闭
        height: 400, //高度
        width: 350,//宽度
        layout: "fit",//窗口布局类型
        modal: true, //是否模态窗口，默认为false
        resizable: false,
        items: [treeFrom]
    });
});
