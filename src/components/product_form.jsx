import React, { useContext, useEffect } from "react";
import { Controller, useForm } from "react-hook-form";
import { Col, Button, Form, FormGroup, Label, Input } from "reactstrap";
import { CategoryContext } from "../context/category_context";
import { ProductContext } from "../context/product_context";
import { productSubmitHandle } from "../utils/form_util";

export const ProductForm = () => {
  const {
    selectedItem,
    productItems,
    setProductItems,
    setSelectedItem,
  } = useContext(ProductContext);
  const { categories } = useContext(CategoryContext);
  const {
    register,
    handleSubmit,
    setValue,
    control,
    formState: { errors, isSubmitting },
  } = useForm();

  useEffect(() => {
    Object.keys(selectedItem).forEach((x) => {
      setValue(x, selectedItem[x]);
    });
  }, [setValue, selectedItem]);

  const submit = async (formData) => {
    productSubmitHandle(
      selectedItem,
      setProductItems,
      productItems,
      formData,
      setValue,
      setSelectedItem
    );
  };

  return (
    <Form onSubmit={handleSubmit(submit)}>
      <FormGroup row>
        <Controller
          name="productId"
          control={control}
          defaultValue=""
          render={({ field }) => <Input type="hidden" {...field} />}
        />
        <Label sm={2}>Product Name</Label>
        <Col sm={10}>
          <Controller
            name="productName"
            control={control}
            rules={{
              required: {
                value: isSubmitting,
                message: "you forgot to enter product name",
              },
            }}
            defaultValue=""
            render={({ field }) => (
              <Input {...field} placeholder="enter product name" />
            )}
          />
        </Col>
      </FormGroup>
      <FormGroup row>
        <Label sm={2}>Price</Label>
        <Col sm={10}>
          <Controller
            name="productPrice"
            control={control}
            defaultValue=""
            rules={{
              validate: (value) => value > 0 || "you forgot to enter price",
            }}
            render={({ field }) => (
              <Input
                {...field}
                type="number"
                placeholder="enter product price"
              />
            )}
          />
        </Col>
      </FormGroup>
      <FormGroup row>
        <Label sm={2}>Product Description</Label>
        <Col sm={10} className="text-center">
          <Controller
            name="productDescription"
            control={control}
            rules={{
              required: {
                value: isSubmitting,
                message: "you forgot to enter description",
              },
            }}
            defaultValue=""
            render={({ field }) => (
              <Input
                placeholder="enter product description"
                type="textarea"
                {...field}
              />
            )}
          />
        </Col>
      </FormGroup>
      <FormGroup row>
        <Label sm={2}>Product File</Label>
        <Col sm={10}>
          <input
            defaultValue={null}
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
          <Controller
            name="categoryId"
            control={control}
            rules={{
              validate: (value) =>
                !isNaN(value) || "you forgot to select category",
            }}
            defaultValue=""
            render={({ field }) => (
              <Input type="select" {...field} key={selectedItem.categoryId}>
                <option>Select Category</option>
                {categories.map((cate) => {
                  return (
                    <option key={cate.categoryId} value={cate.categoryId}>
                      {cate.categoryName}
                    </option>
                  );
                })}
              </Input>
            )}
          />
          {errors &&
            Object.entries(errors).map((x, i) => <p key={i}>{x[1].message}</p>)}
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

export default ProductForm;
