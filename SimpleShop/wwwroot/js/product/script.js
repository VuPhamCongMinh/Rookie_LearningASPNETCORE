$(function () {
    let filtersBtns = $('.filters [data-filter]');
    let filterBtn = $('button[filter-btn]');
    let mininPut = $('input[min-price-input]');
    let maxinPut = $('input[max-price-input]');

    filtersBtns.on('click', function (e) {
        let $this = $(this).attr("data-filter");
        //let transformedUrl = new URL(window.location);
        let transformedUrl = new URL(window.location);
        if ($this == 'asc') {
            if (transformedUrl.searchParams.has('sortOrder')) {
                transformedUrl.searchParams.set('sortOrder', 'asc');
            }
            else {
                transformedUrl.searchParams.append('sortOrder', 'asc');
            }
        }
        else {
            if (transformedUrl.searchParams.has('sortOrder')) {
                transformedUrl.searchParams.set('sortOrder', 'desc');
            }
            else {
                transformedUrl.searchParams.append('sortOrder', 'desc');
            }
        }
        if (window.location.href != transformedUrl.href) {
            window.location = transformedUrl;
        }

    })

    filterBtn.on('click', () => {
        let transformedUrl = new URL(window.location);
        if (mininPut.val().length != 0) {
            if (transformedUrl.searchParams.has('minPrice')) {
                transformedUrl.searchParams.set('minPrice', mininPut.val());
            }
            else {
                transformedUrl.searchParams.append('minPrice', mininPut.val());
            }
        }
        else {
            if (transformedUrl.searchParams.has('minPrice')) {
                transformedUrl.searchParams.delete('minPrice');
            }
        }
        if (maxinPut.val().length != 0) {
            if (transformedUrl.searchParams.has('maxPrice')) {
                transformedUrl.searchParams.set('maxPrice', maxinPut.val());
            }
            else {
                transformedUrl.searchParams.append('maxPrice', maxinPut.val());
            }
        }
        else {
            if (transformedUrl.searchParams.has('maxPrice')) {
                transformedUrl.searchParams.delete('maxPrice');
            }
        }
        if (window.location.href != transformedUrl.href) {
            window.location = transformedUrl;
            //$.get(transformedUrl, function (data) {
            //    console.log(transformedUrl);
            //    $('#product_section').html(data);
            //});
        }
    })














    var noNegative = function (e) {
        if (!((e.keyCode > 95 && e.keyCode < 106)
            || (e.keyCode > 47 && e.keyCode < 58)
            || e.keyCode == 8)) {
            return false;
        }
    }

    mininPut.keydown(noNegative);
    maxinPut.keydown(noNegative);
});