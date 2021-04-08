$('input[name="star-demo"]').rating({
    required: true,
    callback: function (value, link) {
        $("input[name='rate']").attr('value', value);
    },
});


$('#message_form').submit(function (e) {
    e.preventDefault();
    let starsEle = $("input[name='rate']").attr('value');
    let textareaEle = $("textarea[name='message']").val();
    if (!starsEle) {
        alert('Chưa chọn sao');
        return;
    }
    if (!textareaEle) {
        alert('Chưa nhập bình luận');
        return;
    }
    this.submit();
});



