import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { Table, Button } from "reactstrap";
import {
  deleteCategoryRequest,
  setSelectedCategory,
} from "../redux/actions/category_actions";
import { scrollToTop } from "../utils/form_util";
import { alertConfirm } from "../utils/sweetalert_util";

export const CategoryTable = () => {
  const categoryList = useSelector((state) => state.category.categoryList);
  const dispatch = useDispatch();

  const selectHandle = (cate) => {
    dispatch(setSelectedCategory(cate));
    scrollToTop();
  };

  const deleteHandle = (cate_id) => {
    dispatch(deleteCategoryRequest(cate_id));
    scrollToTop();
  };

  return (
    <Table responsive striped>
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
                <Button color="primary" onClick={() => selectHandle(cate)}>
                  Edit
                </Button>
                <Button
                  className="ml-2"
                  color="danger"
                  onClick={() => {
                    alertConfirm(deleteHandle, cate.categoryId);
                  }}
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
