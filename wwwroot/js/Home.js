$(function () {
    $('#search').click(function () {
        $('#search').submit();
    })
    $('#Add-Home-Close').click(function(){
        window.location.href = "https://localhost:5001/Background/Home";
    })
})
$(function () {
    //异步添加一个用户
    $('#span-Add').click(function () {
        $('#Add-Home').click(function () {
            var username = $('#UserName').val();
            var loginname = $('#LoginName').val();
            var name = $('#Name').val();
            var password = $('#PassWord').val();
            const item = {
                UserName: username,
                LoginName: loginname,
                Name: name,
                PassWord: password
            }
            $.ajax({
                url: 'https://localhost:5001/Background/AddHome',
                type: "POST",
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify(item),
                success: function () {
                    alert("添加成功");
                    window.location.href = "https://localhost:5001/Background/Home";
                }
            })

        })
    })
})
$(function () {
    //异步获取数据
    $('.span-Edit').click(function () {
        var id = $(this).data("aaaa");
        $.ajax({
            url: "https://localhost:5001/Background/EditHome" + "?id=" + id,
            type: "GET",
            dataType: 'json',
            contentType: 'application/json',
            success: function (item) {
                console.log(item);
                $('#UserName').val(item.userName);
                $('#LoginName').val(item.loginName);
                $('#Name').val(item.name);
                $('#PassWord').val(item.passWord);
            }
        })
        //异步修改数据
        $('#Add-Home').click(function () {
            var username = $('#UserName').val();
            var loginname = $('#LoginName').val();
            var name = $('#Name').val();
            var password = $('#PassWord').val();
            const item = {
                Id: id,
                UserName: username,
                LoginName: loginname,
                Name: name,
                PassWord: password
            }
            $.ajax({
                url: 'https://localhost:5001/Background/EditHome',
                type: "POST",
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify(item),
                success: function () {
                    alert("修改成功");
                    window.location.href = "https://localhost:5001/Background/Home";
                }
            })
        })
    })
})