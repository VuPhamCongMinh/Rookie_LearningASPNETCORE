import React, { useContext } from "react";
import { Table, Button } from "reactstrap";
import { CategoryContext } from "../context/category_context";

export const CategoryTable = () => {
  const { categories, setSelectedCate } = useContext(CategoryContext);

  return (
    <Table responsive={true} striped={true}>
      <thead>
        <tr>
          <th>#</th>
          <th>Category</th>
          <th>Items</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        {categories.map((cate, index) => {
          return (
            <tr key={cate.categoryId}>
              <th className="align-middle" scope="row">
                {index + 1}
              </th>
              <td className="align-middle">{cate.categoryName}</td>
              <td className="align-middle">
                {cate?.products?.length || 0} product
              </td>
              <td>
                <Button color="primary" onClick={() => setSelectedCate(cate)}>
                  Edit
                </Button>
              </td>
            </tr>
          );
        })}
      </tbody>
    </Table>
  );
};
