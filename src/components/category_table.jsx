import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { Table, Button } from "reactstrap";
import {
  deleteCategoryRequest,
  setSelectedCategory,
} from "../redux/actions/category_actions";

export const CategoryTable = () => {
  const categoryList = useSelector((state) => state.category.categoryList);
  const dispatch = useDispatch();

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
        {categoryList.map((cate, index) => {
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
                <Button
                  color="primary"
                  onClick={() => dispatch(setSelectedCategory(cate))}
                >
                  Edit
                </Button>
                <Button
                  color="danger"
                  onClick={() =>
                    dispatch(deleteCategoryRequest(cate.categoryId))
                  }
                >
                  Delete
                </Button>
              </td>
            </tr>
          );
        })}
      </tbody>
    </Table>
  );
};
