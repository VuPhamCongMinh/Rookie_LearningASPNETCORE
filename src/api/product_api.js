import axios from "axios";

const product_url = process.env.REACT_APP_PRODUCT_API;

export const GetProducts = () => {
  return axios.get(product_url);
};

export const PostProducts = async (myFormData) => {
  try {
    const response = await axios({
      method: "post",
      url: product_url,
      data: myFormData,
    });
    return response.data;
  } catch (error) {
    console.log(error.response);
    return null;
  }
};

export const PutProducts = async (myFormData) => {
  try {
    const response = await axios({
      method: "put",
      url: product_url + "/" + myFormData.get("productId"),
      data: myFormData,
    });
    return response.data;
  } catch (error) {
    console.log(error.response);
    return null;
  }
};

export const DeleteProduct = async (id) => {
  try {
    return await axios({
      method: "delete",
      url: product_url + "/" + id,
    }).then((_) => true);
  } catch (error) {
    return false;
  }
};
