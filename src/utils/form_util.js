import { PostProducts, PutProducts } from "../api/product_api";
import { ProductFormData } from "../model/product_formdata";

export const submitHandler = async (
  selectedItem,
  setProductItems,
  productItems,
  formData,
  setValue,
  setSelectedItem
) => {
  let returnData;
  let myFormData = ProductFormData(formData);

  if (myFormData.get("productId") === "") {
    returnData = await PostProducts(myFormData);
    if (returnData != null) setProductItems((prev) => [...prev, returnData]);
  } else {
    returnData = await PutProducts(myFormData);
    if (returnData != null) {
      let newProducts = productItems.map((prod) =>
        prod.productId === returnData.productId ? returnData : prod
      );
      setProductItems(newProducts);
    }
  }

  resetForm(selectedItem, setValue, setSelectedItem);
};

const resetForm = (selectedItem, setValue, setSelectedItem) => {
  Object.keys(selectedItem).forEach((x) => {
    setValue(x, "");
  });
  setSelectedItem({});
};
