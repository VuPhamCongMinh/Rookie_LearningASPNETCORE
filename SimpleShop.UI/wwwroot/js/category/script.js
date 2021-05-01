$(function () {
    let categoriesRadio = $('input:radio[name="category-radio"]');

    categoriesRadio.on('click', function (e) {
        let $this = $(this).val();
        let baseUrl = new URL(window.location);

        if (baseUrl.searchParams.has('pageIndex')) {
            baseUrl.searchParams.set('pageIndex', 0);
        }

        if ($this != '') {

            if (baseUrl.searchParams.has('cate')) {
                baseUrl.searchParams.set('cate', $this);
            }
            else {
                baseUrl.searchParams.append('cate', $this);
            }
        }
        if (window.location.href != baseUrl.href) {
            history.pushState({}, null, baseUrl);
            let transformedUrl = baseUrl.toString().replace(window.location.href.split('?')[0], `${window.location.href.split('?')[0]}home/productsajaxrequest/`);
            FilteredProductAjax(transformedUrl);
        }

    })
});