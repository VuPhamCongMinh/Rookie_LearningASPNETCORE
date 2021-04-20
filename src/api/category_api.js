import axios from "axios";

const category_url = "https://localhost:44348/api/categories";

export const GetCategories = () => {
  return axios
    .get(category_url)
    .then(({ data: { categories } }) => categories)
    .catch((error) => {
      console.log(error.response);
      return [];
    });
};

export const PostCategory = (myFormData) => {
  return axios({
    method: "post",
    url: category_url,
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

export const PutCategory = (myFormData) => {
  return axios({
    method: "put",
    url: category_url + "/" + myFormData.get("categoryId"),
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
