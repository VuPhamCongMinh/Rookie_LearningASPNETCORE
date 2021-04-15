import React, { useState } from "react";

export const ProductContext = React.createContext();

const ProductContextProvider = ({ children }) => {
  const [productItems, setProductItems] = useState([]);
  const [selectedItems, setSelectedItems] = useState([]);

  return (
    <ProductContext.Provider
      value={{ productItems, setProductItems, selectedItems, setSelectedItems }}
    >
      {children}
    </ProductContext.Provider>
  );
};

export default ProductContextProvider;
