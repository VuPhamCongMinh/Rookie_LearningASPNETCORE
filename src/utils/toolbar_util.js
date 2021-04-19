export const SortPrice = (
  productItems,
  setProductItems,
  sortOption,
  setSortOption
) => {
  if (sortOption.sort === "asc") {
    let newProduct = [...productItems].sort(
      (a, b) => a.productPrice - b.productPrice
    );
    setSortOption({ ...sortOption, sort: "desc" });
    setProductItems(newProduct);
  } else {
    let newProduct = [...productItems].sort(
      (a, b) => b.productPrice - a.productPrice
    );

    setSortOption({ ...sortOption, sort: "asc" });
    setProductItems(newProduct);
  }
};

export const SortCate = (
  productItems,
  setProductItems,
  sortOption,
  setSortOption
) => {
  if (sortOption.cate === "asc") {
    let newProduct = [...productItems].sort((a, b) =>
      a.category.categoryName.localeCompare(b.category.categoryName)
    );
    setSortOption({ ...sortOption, cate: "desc" });
    setProductItems(newProduct);
  } else {
    let newProduct = [...productItems].sort((a, b) =>
      b.category.categoryName.localeCompare(a.category.categoryName)
    );
    setSortOption({ ...sortOption, cate: "asc" });
    setProductItems(newProduct);
  }
};
