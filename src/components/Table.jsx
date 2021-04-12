import React, { useState, useEffect } from "react";
import { Table } from "reactstrap";

export const MyTable = () => {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    fetch("https://localhost:44348/api/products")
      .then((res) => res.json())
      .then((result) => {
        const { products } = result;
        setProducts(products);
      });
  }, []);

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
        </tr>
      </thead>
      <tbody>
        {products.map((prod, index) => {
          return (
            <tr key={prod.productId}>
              <th className="align-middle" scope="row">
                {index + 1}
              </th>
              <td className="align-middle">{prod.productName}</td>
              <td className="align-middle">$ {prod.productPrice}</td>
              <td className="align-middle">{prod.category.categoryName}</td>
              <td>
                <img className="img-fluid" src={prod.images[0].imageUrl} />
              </td>
              <td className="align-middle">{prod.productDescription}</td>
            </tr>
          );
        })}
      </tbody>
    </Table>
  );
};
