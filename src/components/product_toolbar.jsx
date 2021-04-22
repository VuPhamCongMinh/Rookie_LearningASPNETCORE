import React, { useState } from "react";
import { Button, ButtonGroup, Row } from "reactstrap";
import { SortPrice, SortCate } from "../utils/toolbar_util";

export const ProductToolbar = () => {
  const [sortOption, setSortOption] = useState({
    sort: "asc",
    cate: "asc",
  });

  return (
    <Row>
      <ButtonGroup className="w-100">
        <Button onClick={() => SortPrice(sortOption, setSortOption)}>
          Sort by Price
        </Button>
        <Button onClick={() => SortCate(sortOption, setSortOption)}>
          Sort by Category
        </Button>
      </ButtonGroup>
    </Row>
  );
};
