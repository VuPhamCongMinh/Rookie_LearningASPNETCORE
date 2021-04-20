import React, { useContext } from "react";
import { Table, Button } from "reactstrap";
import { ProductContext } from "../context/product_context";

export const ProductTable = () => {
  const { productItems, setSelectedItem } = useContext(ProductContext);

  return (
    <Table responsive={true} striped={true}>
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
              <td className="align-middle">{prod.category.categoryName}</td>
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
                <Button color="primary" onClick={() => setSelectedItem(prod)}>
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
