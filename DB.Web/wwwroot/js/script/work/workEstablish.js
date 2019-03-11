
var WinEstablish;

Ext.onReady(function () {
    var establish;
    var guid;
    var store;
    WinEstablish = function test(a, b, c, d) {
        establish = b;
        guid = c;
        store = d;
        if (guid[0].data.workflowStatus !== 0) {
            Ext.Msg.alert('提示', "只能提交未提交数据！");
            return;
        }
        winEstablish.title = a;
        winEstablish.show();
    };
    var establishForm = new Ext.FormPanel({
        bodyStyle: 'padding:5px 5px 0',
        layout: 'form',
        items: [
            {
                xtype: "textarea",
                fieldLabel: "备注",
                id: "text_Message",
                labelSepartor: "：",
                labelWidth: 70
            }
        ],
        buttonAlign: 'center',
        buttons: [
            {
                text: '提交',
                handler: function () {
                    Ext.Ajax.request({
                        url: '/Work/' + establish,
                        method: 'POST',
                        params: { guid: guid[0].id, message: Ext.getCmp('text_Message').getValue() },
                        success: function (response) {
                            if (response.responseText) {
                                Ext.Msg.alert('提示', "提交成功！");
                                winEstablish.close();//关闭
                                establishForm.reset();//清空Window所有控件内容
                                store.load();
                            } else {
                                Ext.Msg.alert('提示', "提交失败！");
                            }
                        },
                        failure: function (response) {
                            Ext.Msg.alert('失败', '请求超时或网络故障，错误编号：' + response.status);
                        }
                    });
                }
            }, {
                text: '关闭',
                handler: function () {
                    establishForm.reset();//清空Window所有控件内容
                    winEstablish.close();//关闭
                }
            }
        ]
    });
    var winEstablish = Ext.create("Ext.window.Window", {
        draggable: false,
        closdraggable: false,
        closable: false,
        closeAction: 'close', //关闭
        height: 220, //高度
        width: 350,//宽度
        layout: "fit",//窗口布局类型
        modal: true, //是否模态窗口，默认为false
        resizable: false,
        items: [establishForm]
    });

});