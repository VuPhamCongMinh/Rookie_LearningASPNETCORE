$(function () {
    let sortFilterBtn = $('select.filters');
    let pagingSection = $('#pagination-section');
    let priceFilterBtn = $('button[filter-btn]');
    let searchBtn = $('i[search-btn]');
    let searchInput = $('input[search-input]');
    let minInput = $('input[min-price-input]');
    let maxInput = $('input[max-price-input]');


    sortFilterBtn.on('change', function (e) {
        let $this = $(this).val();
        let baseUrl = new URL(window.location);

        if (baseUrl.searchParams.has('pageIndex')) {
            baseUrl.searchParams.set('pageIndex', 0);
        }

        if ($this.length != 0) {
            if (baseUrl.searchParams.has('sortOrder')) {
                baseUrl.searchParams.set('sortOrder', $this);
            }
            else {
                baseUrl.searchParams.append('sortOrder', $this);
            }
        }
        if (window.location.href != baseUrl.href) {
            history.pushState({}, null, baseUrl);
            let transformedUrl = baseUrl.toString().replace(window.location.href.split('?')[0], `${window.location.href.split('?')[0]}home/productsajaxrequest/`);
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
                                }
                            });
                        }
                    });
                }
            });
        }

    })

    priceFilterBtn.on('click', () => {
        let baseUrl = new URL(window.location);

        if (baseUrl.searchParams.has('pageIndex')) {
            baseUrl.searchParams.set('pageIndex', 0);
        }

        if (minInput.val().length != 0) {
            if (baseUrl.searchParams.has('minPrice')) {
                baseUrl.searchParams.set('minPrice', minInput.val());
            }
            else {
                baseUrl.searchParams.append('minPrice', minInput.val());
            }
        }
        else {
            if (baseUrl.searchParams.has('minPrice')) {
                baseUrl.searchParams.delete('minPrice');
            }
        }
        if (maxInput.val().length != 0) {
            if (baseUrl.searchParams.has('maxPrice')) {
                baseUrl.searchParams.set('maxPrice', maxInput.val());
            }
            else {
                baseUrl.searchParams.append('maxPrice', maxInput.val());
            }
        }
        else {
            if (baseUrl.searchParams.has('maxPrice')) {
                baseUrl.searchParams.delete('maxPrice');
            }
        }
        if (window.location.href != baseUrl.href) {
            history.pushState({}, null, baseUrl);
            let transformedUrl = baseUrl.toString().replace(window.location.href.split('?')[0], `${window.location.href.split('?')[0]}home/productsajaxrequest/`);
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
                                }
                            });
                        }
                    });
                }
            });
        }
    })

    searchBtn.on('click', () => {
        let baseUrl = new URL(window.location);

        if (baseUrl.searchParams.has('pageIndex')) {
            baseUrl.searchParams.set('pageIndex', 0);
        }

        if (searchInput.val() != ' ') {
            if (baseUrl.searchParams.has('searchString')) {
                baseUrl.searchParams.set('searchString', searchInput.val());
            }
            else {
                baseUrl.searchParams.append('searchString', searchInput.val());
            }
        }
        else {
            if (baseUrl.searchParams.has('searchString')) {
                baseUrl.searchParams.delete('searchString');
            }
        }

        if (window.location.href != baseUrl.href) {
            history.pushState({}, null, baseUrl);
            let transformedUrl = baseUrl.toString().replace(window.location.href.split('?')[0], `${window.location.href.split('?')[0]}home/productsajaxrequest/`);
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
                                }
                            });
                        }
                    });
                }
            });
        }
    })

    pagingSection.on('click', '.data-paging [paging-btn]', function (e) {
        let $this = $(this).attr("paging-btn");

        let baseUrl = new URL(window.location);
        if ($.isNumeric($this)) {
            if (baseUrl.searchParams.has('pageIndex')) {
                baseUrl.searchParams.set('pageIndex', $this);
            }
            else {
                baseUrl.searchParams.append('pageIndex', $this);
            }
        }
        if (window.location.href != baseUrl.href) {
            history.pushState({}, null, baseUrl);
            let transformedUrl = baseUrl.toString().replace(window.location.href.split('?')[0], `${window.location.href.split('?')[0]}home/productsajaxrequest/`);
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
                                }
                            });
                        }
                    });
                }
            });
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