import axios from "axios";

const product_url = "https://localhost:44348/api/products";

export const GetProducts = () => {
  return axios.get(product_url);
};

export const PostProducts = (myFormData) => {
  return axios({
    method: "post",
    url: product_url,
    data: myFormData,
  })
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      console.log(error.response);
      return null;
    });
};

export const PutProducts = (myFormData) => {
  return axios({
    method: "put",
    url: product_url + "/" + myFormData.get("productId"),
    data: myFormData,
  })
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      console.log(error.response);
      return null;
    });
};
