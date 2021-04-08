$(function () {
    $('#add_cart_form').submit(function () {
        let productId = $("input[name='product_id']").val();
        var input = $("<input>")
            .attr("type", "hidden")
            .attr("name", "product_id").val(productId);
        $('#add_cart_form').append(input);
    });
});