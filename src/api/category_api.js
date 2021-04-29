import axios from "axios";

const category_url = process.env.REACT_APP_CATEGORY_API;

export const GetCategories = () => {
  return axios.get(category_url);
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

export const DeleteCategory = async (id) => {
  try {
    return await axios({
      method: "delete",
      url: category_url + "/" + id,
    }).then((_) => true);
  } catch (error) {
    return false;
  }
};
