import axios from "axios";
import React, { useEffect, useState } from "react";

export const ProductContext = React.createContext();

const ProductContextProvider = ({ children }) => {
  const [productItems, setProductItems] = useState([]);
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    axios
      .get("https://localhost:44348/api/products")
      .then(({ data: { products } }) => {
        setProductItems(products);
        return axios.get("https://localhost:44348/api/categories");
      })
      .then(({ data: { categories } }) => setCategories(categories));
  }, []);
  return (
    <ProductContext.Provider
      value={{ productItems, setProductItems, categories, setCategories }}
    >
      {children}
    </ProductContext.Provider>
  );
};

export default ProductContextProvider;
