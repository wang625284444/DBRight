
var WinEstablish;

Ext.onReady(function () {
    var establish;
    var guid;
    WinEstablish = function test(a, b, c) {
        establish = b;
        guid = c;
        winEstablish.title = a;
        winEstablish.show();
    };
    var establishForm = new Ext.FormPanel({
        bodyStyle: 'padding:5px 5px 0',
        layout: 'form',
        items: [
            { xtype: 'textfield', fieldLabel: 'id', id: 'asdfasdf', hidden: true },
            { xtype: 'textfield', fieldLabel: '用户账号', id: 'asdfasdf', name: 'title', anchor: '100%', readOnly: true }
        ],
        buttonAlign: 'center',
        buttons: [
            {
                text: '提交',
                handler: function () {
                    Ext.Ajax.request({
                        url: '/Work/WorkEstablish',
                        method: 'POST',
                        params: { establish: establish, guid: guid },
                        success: function (response) {
                            var obj = JSON.parse(response.responseText);
                            Ext.Msg.alert('提示', obj.status_message);
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
        height: 320, //高度
        width: 350,//宽度
        layout: "fit",//窗口布局类型
        modal: true, //是否模态窗口，默认为false
        resizable: false,
        items: [establishForm]
    });

});