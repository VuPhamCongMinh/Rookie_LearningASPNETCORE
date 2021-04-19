import React, { useEffect, useState } from "react";
import { GetCategories } from "../api/category_api";
import { GetProducts } from "../api/product_api";

export const ProductContext = React.createContext();

const ProductContextProvider = ({ children }) => {
  const [productItems, setProductItems] = useState([]);
  const [selectedItem, setSelectedItem] = useState({});
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      setCategories(await GetCategories());
      setProductItems(await GetProducts());
    };

    fetchData();
  }, []);

  return (
    <ProductContext.Provider
      value={{
        productItems,
        setProductItems,
        categories,
        setCategories,
        selectedItem,
        setSelectedItem,
      }}
    >
      {children}
    </ProductContext.Provider>
  );
};

export default ProductContextProvider;
