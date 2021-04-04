$(function () {
    let categoriesRadio = $('input:radio[name="category-radio"]');

    categoriesRadio.on('click', function (e) {
        let $this = $(this).val();
        let transformedUrl = new URL(window.location);

        if (transformedUrl.searchParams.has('pageIndex')) {
            transformedUrl.searchParams.set('pageIndex', 0);
        }

        if ($this != '') {
            if (transformedUrl.searchParams.has('cate')) {
                transformedUrl.searchParams.set('cate', $this);
            }
            else {
                transformedUrl.searchParams.append('cate', $this);
            }
        }
        if (window.location.href != transformedUrl.href) {
            window.location = transformedUrl;
        }
    })
});