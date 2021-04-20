import React, { useEffect, useState } from "react";
import { GetCategories } from "../api/category_api";

export const CategoryContext = React.createContext();

const CategoryContextProvider = ({ children }) => {
  const [categories, setCategories] = useState([]);
  const [selectedCate, setSelectedCate] = useState({});

  useEffect(() => {
    const fetchData = async () => {
      setCategories(await GetCategories());
    };

    fetchData();
  }, []);

  return (
    <CategoryContext.Provider
      value={{
        categories,
        setCategories,
        selectedCate,
        setSelectedCate,
      }}
    >
      {children}
    </CategoryContext.Provider>
  );
};

export default CategoryContextProvider;
