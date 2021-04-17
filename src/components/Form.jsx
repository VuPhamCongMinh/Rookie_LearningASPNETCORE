import axios from "axios";
import React, { useContext } from "react";
import { useForm } from "react-hook-form";
import { Col, Button, Form, FormGroup, Label, Input } from "reactstrap";
import { ProductContext } from "../context/product_context";

const MyForm = () => {
  const { categories } = useContext(ProductContext);
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const submitHandle = (formData) => {
    // Khởi tạo FormData từ các input trong form trả về thông qua biến formData
    // do sử dụng FormData nên phải trong API controller phải dùng attribute [FromForm] trước paramter - tui đã mất 1 ngày trời để biết chiện này :((
    let myFormData = new FormData();
    myFormData.append("productName", formData.productName);
    myFormData.append("productPrice", formData.productPrice);
    myFormData.append("productDescription", formData.productDescription);
    myFormData.append("categoryId", formData.categoryId);
    [...formData.ImageFiles].map((file) => {
      myFormData.append("ImageFiles", file);
    });

    axios({
      method: "post",
      url: "https://localhost:44348/api/products",
      data: myFormData,
    })
      .then((response) => {
        console.log(response);
      })
      .catch((error) => {
        console.log(error.response);
      });
  };

  return (
    <Form onSubmit={handleSubmit(submitHandle)}>
      <FormGroup row>
        <Label sm={2}>Product Name</Label>
        <Col sm={10}>
          <Input
            type="text"
            placeholder="enter product name"
            {...register("productName")}
          />
        </Col>
      </FormGroup>
      <FormGroup row>
        <Label sm={2}>Price</Label>
        <Col sm={10}>
          <Input
            type="number"
            placeholder="enter product price"
            {...register("productPrice")}
          />
        </Col>
      </FormGroup>
      <FormGroup row>
        <Label sm={2}>Product Description</Label>
        <Col sm={10}>
          <Input type="textarea" {...register("productDescription")} />
        </Col>
      </FormGroup>
      <FormGroup row>
        <Label sm={2}>Product File</Label>
        <Col sm={10}>
          <input
            accept="image/*"
            type="file"
            {...register("ImageFiles")}
            className="form-control-file"
            multiple
          />
        </Col>
      </FormGroup>
      <FormGroup row>
        <Label sm={2}>Select</Label>
        <Col sm={{ offset: 0, size: 10 }}>
          <Input type="select" {...register("categoryId", { required: true })}>
            <option>Select Category</option>
            {categories.map((cate) => {
              return (
                <option key={cate.categoryId} value={cate.categoryId}>
                  {cate.categoryName}
                </option>
              );
            })}
          </Input>
          {errors.categoryId && <span>This field is required</span>}
        </Col>
      </FormGroup>
      <FormGroup row>
        <Col sm={{ offset: 0, size: 12 }}>
          <Button className="w-100">Submit</Button>
        </Col>
      </FormGroup>
    </Form>
  );
};

export default MyForm;
