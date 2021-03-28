﻿$(function () {
    let sortFilterBtn = $('.filters [data-filter]');
    let priceFilterBtn = $('button[filter-btn]');
    let searchBtn = $('button[search-btn]');
    let searchInput = $('input[search-input]');
    let minInput = $('input[min-price-input]');
    let maxInput = $('input[max-price-input]');

    sortFilterBtn.on('click', function (e) {
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

    priceFilterBtn.on('click', () => {
        let transformedUrl = new URL(window.location);
        if (minInput.val().length != 0) {
            if (transformedUrl.searchParams.has('minPrice')) {
                transformedUrl.searchParams.set('minPrice', minInput.val());
            }
            else {
                transformedUrl.searchParams.append('minPrice', minInput.val());
            }
        }
        else {
            if (transformedUrl.searchParams.has('minPrice')) {
                transformedUrl.searchParams.delete('minPrice');
            }
        }
        if (maxInput.val().length != 0) {
            if (transformedUrl.searchParams.has('maxPrice')) {
                transformedUrl.searchParams.set('maxPrice', maxInput.val());
            }
            else {
                transformedUrl.searchParams.append('maxPrice', maxInput.val());
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

    searchBtn.on('click', () => {
        let transformedUrl = new URL(window.location);
        if (searchInput.val() != ' ') {
            if (transformedUrl.searchParams.has('searchString')) {
                transformedUrl.searchParams.set('searchString', searchInput.val());
            }
            else {
                transformedUrl.searchParams.append('searchString', searchInput.val());
            }
        }
        else {
            if (transformedUrl.searchParams.has('searchString')) {
                transformedUrl.searchParams.delete('searchString');
            }
        }
        if (maxInput.val().length != 0) {
            if (transformedUrl.searchParams.has('maxPrice')) {
                transformedUrl.searchParams.set('maxPrice', maxInput.val());
            }
            else {
                transformedUrl.searchParams.append('maxPrice', maxInput.val());
            }
        }
        else {
            if (transformedUrl.searchParams.has('maxPrice')) {
                transformedUrl.searchParams.delete('maxPrice');
            }
        }
        if (window.location.href != transformedUrl.href) {
            window.location = transformedUrl;

        }
    })














    var noNegative = function (e) {
        if (!((e.keyCode > 95 && e.keyCode < 106)
            || (e.keyCode > 47 && e.keyCode < 58)
            || e.keyCode == 8)) {
            return false;
        }
    }

    minInput.keydown(noNegative);
    maxInput.keydown(noNegative);
});