$(function () {
    //在全局 定义验证码
    var code = "";
    //JS验证码

    function createCode() {
        code = "";
        var codeLength = 4;//验证码的长度
        var checkCode = document.getElementById("checkCode");
        checkCode.value = "";
        var selectChar = new Array(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
        for (var i = 0; i < codeLength; i++) {
            var charIndex = Math.floor(Math.random() * 35);
            code += selectChar[charIndex];
        }
        if (code.length !== codeLength) {
            createCode();
        }
        document.getElementById("checkCode").innerHTML = code;
    }
    $(function () {
        createCode();
    });
    //刷新验证码
    $("#checkCode").click(function () {
        createCode();
    });
    //输入验证
    function InputVerification() {
        if ($("#text_userAccount").val() === "") {
            alert("请输账号！");
            return false;
        }
        if ($("#text_userPasword").val() === "") {
            alert("请输密码！");
            return false;
        }
        var verificationcode = $("#text_verificationcode").val();
        if (verificationcode === "") {
            alert("请输入验证码！");
            return false;
        }
        if (verificationcode.toUpperCase() !== code.toUpperCase()) {
            alert("验证码输入错误！");
            createCode();
            return false;
        }
        return true;
    }
    //点击请求
    $("#login").click(function () {
        //判断验证是否通过
        if (!InputVerification()) {
            return false;
        } else {
            //执行get登陆请求
            $.ajax({
                type: 'GET',
                url: '/Signin/Signin?userAccount=' + $('#text_userAccount').val() + '&userPasword=' + $('#text_userPasword').val(),
                dataType: 'json',
                success: function (data) {
                    if (data.status_Type) {
                        $(window).attr('location', '/Home/Index');
                    } else {
                        $.messager.alert('Warning', data.status_message);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        }
    });

});