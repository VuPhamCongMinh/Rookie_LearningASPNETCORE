function FilteredProductAjax(transformedUrl) {
    $.ajax({
        type: 'GET',
        url: transformedUrl,
        success: function (result) {
            $('#product-section').html(result);
            transformedUrl = `${window.location.href.split('?')[0]}home/itemsfoundajaxrequest/`;
            $.ajax({
                type: 'GET',
                url: transformedUrl,
                success: function (result) {
                    $('#product-found').html(result);
                    transformedUrl = `${window.location.href.split('?')[0]}home/paginationajaxrequest/`;
                    $.ajax({
                        type: 'GET',
                        url: transformedUrl,
                        success: function (result) {
                            $('#pagination-section').html(result);
                            $('html, body').stop().animate({
                                scrollTop: $("#moneo").offset().top
                            }, 800, 'swing');
                        }
                    });
                }
            });
        }
    });
};