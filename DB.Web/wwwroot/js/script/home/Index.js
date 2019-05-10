$(document).ready(function () {
    layui.use('element', function () {

        //显示用户名
        $(function () {
            $.ajax({
                type: "GET",
                url: "/Home/LoginUser",
                dataType: "json",
                success: function (data) {
                    $("#loginusername").html(data.userName);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        });

        //退出当前登录
        $("#signout").click(function () {
            $.ajax({
                type: "GET",
                url: "/Home/QuitLanding",
                dataType: "json",
                success: function (data) {
                    window.location.reload();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        });

        function getAhtml(obj) {
            return "<a href=\"javascript:;\" onclick=\" addTab('" + obj.title + "','" + obj.href + "')\" >" + obj.title + "</a>";
        }
        //动态菜单
        layui.jquery.ajax({
            url: "/Home/Query",
            method: 'GET',
            success: function (data) {
                var res = JSON.parse(data);
                var html = "";
                for (var i = 0; i < res.length; i++) {
                    var strli = "<li class=\"layui-nav-item lay-unselect \" >";
                    if (res[i].href === null) {
                        strli = strli + "<a href=\"javascript:;\">" + res[i].title + "</a>";
                        console.log(res[i].title);
                    } else {
                        strli = strli + getAhtml(res[i]);
                    }
                   
                    if (res[i].href === null) {
                        strli = strli + "<dl class=\"layui-nav-child\" >";
                        $.each(res[i].children, function (j, item2) {
                            strli = strli + "<dd>" + getAhtml(item2) + "</dd>";
                           });
                        strli = strli + "</dl>";
                    }
                    strli = strli + "</li>";
                    html = html + strli;
                }
                layui.jquery("#memus").html(html);
                layui.element.init(); //一定初始化一次
            }
        });

        //添加选项卡
        addTab = function (name, url) {
            if (layui.jquery(".layui-tab-title li[lay-id='" + name + "']").length > 0) {
                //选项卡已经存在
                layui.element.tabChange('tabDemo', name);
                //layer.msg('切换-' + name);
            } else {
                //动态控制iframe高度
                var tabheight = layui.jquery(window).height() - 80;
                contentTxt = '<iframe src="' + url + '" scrolling="no" width="100%" height="' + tabheight + 'PX"></iframe>';
                //新增一个Tab项
                layui.element.tabAdd('tabDemo', {
                    title: name,
                    content: contentTxt,
                    id: name
                });
                //切换刷新
                layui.element.tabChange('tabDemo', name);
                //layer.msg('新增-' + name);
            }
        };
    });
}); 