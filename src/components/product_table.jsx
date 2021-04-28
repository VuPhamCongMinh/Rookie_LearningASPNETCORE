import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { Table, Button } from "reactstrap";
import {
  deleteProductRequest,
  setSelectedProduct,
} from "../redux/actions/product_actions";
import { scrollToTop } from "../utils/form_util";
import { alertConfirm } from "../utils/sweetalert_util";

export const ProductTable = () => {
  const productItems = useSelector((state) => state.product.productList);
  const dispatch = useDispatch();

  const selectHandle = (product) => {
    dispatch(setSelectedProduct(product));
    scrollToTop();
  };

  const deleteHandle = (product_id) => {
    dispatch(deleteProductRequest(product_id));
    scrollToTop();
  };

  return (
    <Table responsive striped>
      <thead>
        <tr>
          <th>#</th>
          <th>Product Name</th>
          <th>Product Price</th>
          <th>Category</th>
          <th>Product Images</th>
          <th>Product Description</th>
          <th>Operation</th>
        </tr>
      </thead>
      <tbody>
        {productItems.map((prod, index) => {
          return (
            <tr key={prod.productId}>
              <th className="align-middle" scope="row">
                {index + 1}
              </th>
              <td className="align-middle">{prod.productName}</td>
              <td className="align-middle">$ {prod.productPrice}</td>
              <td className="align-middle">{prod.category?.categoryName}</td>
              {prod.images.length > 0 && (
                <td>
                  <img
                    className="img-fluid"
                    src={prod.images[0].imageUrl}
                    alt="alu alu"
                  />
                </td>
              )}

              <td className="align-middle">{prod.productDescription}</td>
              <td>
                <Button
                  className="w-100"
                  color="primary"
                  onClick={() => selectHandle(prod)}
                >
                  Edit
                </Button>
                <Button
                  className="w-100 mt-2"
                  color="danger"
                  onClick={() => alertConfirm(deleteHandle, prod.productId)}
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
