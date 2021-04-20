import React, { useEffect, useState } from "react";
import { GetProducts } from "../api/product_api";

export const ProductContext = React.createContext();

const ProductContextProvider = ({ children }) => {
  const [productItems, setProductItems] = useState([]);
  const [selectedItem, setSelectedItem] = useState({});

  useEffect(() => {
    (async () => {
      setProductItems(await GetProducts());
    })();
  }, []);

  return (
    <ProductContext.Provider
      value={{
        productItems,
        setProductItems,
        selectedItem,
        setSelectedItem,
      }}
    >
      {children}
    </ProductContext.Provider>
  );
};

export default ProductContextProvider;
