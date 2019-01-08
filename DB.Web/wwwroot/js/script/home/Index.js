Ext.onReady(function () {

    var model = Ext.define("TreeModel", { // 定义树节点数据模型
        extend: "Ext.data.Model",
        fields: [
            { name: "id", type: "string" },
            { name: "text", type: "string" },
            { name: "leaf", type: "boolean" },
            { name: 'url', type: "string" },
            { name: 'data', type: "string" }]
    });

    var store = Ext.create('Ext.data.TreeStore', {
        model: model,//定义当前store对象的Model数据模型
        proxy: {
            type: 'ajax',
            url: '/Home/Query',//请求
            reader: {
                type: 'json'
            }
        },
        root: {
            expanded: true
        }
    });

    Ext.define('MyApp.view.layout.SystemMenuView', {
        extend: 'Ext.button.Button',
        xtype: 'app-systemmenu',
        text: '系统菜单',
        iconCls: 'icon-windows',
        initComponent: function () {
            var me = this;
            me.menu = [{
                text: '系统信息',
                iconCls: 'icon-about',
                handler: function () {
                    Ext.Msg.alert('提示', '该功能暂未开放');
                }
            }, '-',
            {
                text: '修改密码',
                iconCls: 'icon-password',
                handler: function () {
                    Ext.Msg.alert('提示', '该功能暂未开放');
                }
            }, '-',
            {
                text: '锁定屏幕',
                iconCls: 'icon-lock',
                handler: function () {
                    Ext.Msg.alert('提示', '该功能暂未开放');
                    /*seller.app.lock();
                    Ext.util.Cookies.set('lockFlag', true);*/
                }
            }, '-',
            {
                text: '退出登陆',
                iconCls: 'icon-logout',
                handler: function () {
                    Ext.Msg.alert('提示', '该功能暂未开放');
                }
            }];
            me.callParent(arguments);
        }
    });

    var tabpanel = Ext.create('Ext.tab.Panel', {
        id: 'myTabPanel',
        width: 1166,
        height: 660,
        header: false,
        activeTab: 0,
        border: false,
        renderTo: document.body,
        items: [
            {
                xtype: 'panel',
                title: "首页信息",
                html: '欢迎老板！',
                bodyPadding: '10px',
                layout: 'column',
                listeners: {
                    afterrender: function () {
                        Ext.getBody().unmask();
                    }
                }
            }]
    });

    Ext.define('TreePanel', {
        extend: 'Ext.tree.Panel',
        xtype: 'treepanel',
        rootVisible: false,
        collapsible: false,
        animate: false,
        store: store,
        listeners: {
            itemclick: function (v, r) {
                if (r.raw.url) {
                    var type = true;
                    tabpanel.items.keys.forEach(v => {
                        if (v === r.raw.id) {
                            type = false;
                        }
                    });
                    if (type) {
                        Ext.getCmp('myTabPanel').add(
                            {
                                id: '' + r.raw.id + '',
                                title: '' + r.raw.text + '',
                                html: '<iframe scrolling="auto" frameborder="0" width="100%" height="100%" src="' + r.raw.url + '"></iframe>',
                                closable: true,
                                split: true,
                                collapsible: true,
                                frame: true,
                                activeTab: 'none ',
                                layout: 'fit'
                            });
                        tabpanel.setActiveTab(r.raw.id);
                    } else {
                        tabpanel.setActiveTab(r.raw.id);
                    }
                }
            }
        },
        renderTo: Ext.getBody()
    });
    
    new Ext.Viewport({
        title: "Viewport",
        layout: "border",
        defaults: {
            bodyStyle: "background-color: #FFFFFF;",
            frame: true
        },
        items: [
            { region: "north", height: 100, split: false, border: false, },//头部
            { region: "west", width: 200, xtype: 'treepanel', title: '菜单' },//左侧
            { region: "center", xtype: tabpanel }//中间
        ]
    });
});