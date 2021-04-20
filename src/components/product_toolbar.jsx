import React, { useContext, useState } from "react";
import { Button, ButtonGroup, Row } from "reactstrap";
import { ProductContext } from "../context/product_context";
import { SortPrice, SortCate } from "../utils/toolbar_util";

export const ProductToolbar = () => {
  const { productItems, setProductItems } = useContext(ProductContext);
  const [sortOption, setSortOption] = useState({
    sort: "asc",
    cate: "asc",
  });

  return (
    <Row>
      <ButtonGroup className="w-100">
        <Button
          onClick={() =>
            SortPrice(productItems, setProductItems, sortOption, setSortOption)
          }
        >
          Sort by Price
        </Button>
        <Button
          onClick={() =>
            SortCate(productItems, setProductItems, sortOption, setSortOption)
          }
        >
          Sort by Category
        </Button>
      </ButtonGroup>
    </Row>
  );
};
