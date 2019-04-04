$(document).ready(function () {
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
    layui.use('element', function () {
        var element = layui.element;
       
        //加载左侧导航
        $(function () {
            $.ajax({
                url: "/Home/Query",
                type: "Get",
                dataType: "json",
                success: function (data) {
                    var html = '';
                    html += '<ul class="layui-nav layui-nav-tree"  lay-filter="test">';
                    $.each(data, function (i, item) {
                        html = html + '<li class="layui-nav-item">';
                        html += '<a href="javascript:;"class="site-tab-active" data-url="' + item.href + '" nav-id="' + item.id + '">' + '<cite>' + item.title + '</cite></a>';
                        if (item.children.length > 0) {
                            html += '<dl class="layui-nav-child">';
                            $.each(item.children, function (j, item2) {
                                html += '<dd>';
                                html += '<a href="javascript:;" class="site-tab-active" data-url="' + item2.href + '" ' + 'nav-id="' + item2.id + '">' + '<cite>' + item2.title + '</cite></a>';
                            });
                            html += '</dl>';
                        }
                        html += '</li>';
                    });
                    html += '</ul>';

                    $("#navigation-tree").html(html);
                    element.render('nav');

                }
            });


            $('.site-tab-active').on('click', function () {
                alert("asdf");
            });
            element.init();
        });
    });
}); 