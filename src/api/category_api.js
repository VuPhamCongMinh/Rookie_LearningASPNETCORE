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
