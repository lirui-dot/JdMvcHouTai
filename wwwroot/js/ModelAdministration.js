$(function () {
    $('#search').click(function () {
        $('#search').submit();
    })
    $('#Btn-close').click(function(){
        window.location.href = "https://localhost:5001/Background/ModelAdministration";
    })
})
$(function () {
    $('#span-Add').click(function () {
        $('#Btn-Add').click(function () {
            var hobby = $('#HobbyClassification').val();
            $.ajax({
                url: 'https://localhost:5001/Background/ModelAdd',
                type: "POST",
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify(hobby),
                success: function () {
                    alert("添加成功");
                    window.location.href = "https://localhost:5001/Background/ModelAdministration";
                }
            })
        })
    })
})
$(function(){
    $('.span-Edit').click(function(){
        var id=$(this).data("aaaaa");
        $.ajax({
            url: "https://localhost:5001/Background/ModelEdit" + "?id=" + id,
            type: "GET",
            dataType: 'json',
            contentType: 'application/json',
            success: function (item) {
                console.log(item);
                $('#HobbyClassification').val(item.hobbyClassification);
            }
        })
        $('#Btn-Add').click(function(){
            var hobby=$('#HobbyClassification').val();
            const item={
                HobbyClassification:hobby,
                Id:id
            }
            $.ajax({
                url: 'https://localhost:5001/Background/ModelEdit',
                type: "POST",
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify(item),
                success: function () {
                    alert("修改成功");
                    window.location.href = "https://localhost:5001/Background/ModelAdministration";
                }
            })
        })
    })
})