$(document).ready(function () {
    $('#example').DataTable();
    $('#Btn-close').click(function () {
        window.location.href = "https://localhost:5001/Background/Provinces";
    })
});
$(function () {
    $('#span-Add').click(function () {
        $('#Btn-Add').click(function () {
            var hobby = $('#PrvoncesName').val();
            $.ajax({
                url: 'https://localhost:5001/Background/ProvincesAdd',
                type: "POST",
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify(hobby),
                success: function () {
                    alert("添加成功");
                    window.location.href = "https://localhost:5001/Background/Provinces";
                }
            })
        })
    })
})
$(function () {
    $('.span-Edit').click(function () {
        var id = $(this).data("aaaaa");
        $.ajax({
            url: "https://localhost:5001/Background/ProvincesEdit" + "?id=" + id,
            type: "GET",
            dataType: 'json',
            contentType: 'application/json',
            success: function (item) {
                console.log(item);
                $('#PrvoncesName').val(item.name);
            }
        })
        $('#Btn-Add').click(function () {
            var name = $('#PrvoncesName').val();
            const item = {
                PrvoncesName: name,
                Id: id
            }
            $.ajax({
                url: 'https://localhost:5001/Background/ProvincesEdit',
                type: "POST",
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify(item),
                success: function () {
                    alert("修改成功");
                    window.location.href = "https://localhost:5001/Background/Provinces";
                }
            })
        })
    })
})