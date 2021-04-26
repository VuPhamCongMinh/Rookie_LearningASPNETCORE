import React, { useEffect, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { useSelector } from "react-redux";
import { Col, Button, Form, FormGroup, Label, Input } from "reactstrap";
import { productSubmitHandle } from "../utils/form_util";

export const ProductForm = () => {
  const selectedProduct = useSelector((state) => state.product.selectedProduct);
  const categoryList = useSelector((state) => state.category.categoryList);
  const [currentImages, setCurrentImages] = useState([]);
  const {
    register,
    handleSubmit,
    setValue,
    control,
    formState: { errors, isSubmitting },
  } = useForm();

  useEffect(() => {
    if (selectedProduct) {
      Object.keys(selectedProduct).forEach((x) => {
        setValue(x, selectedProduct[x]);
      });
    }
  }, [setValue, selectedProduct]);

  const submit = async (formData) => {
    productSubmitHandle(formData, setValue);
    setCurrentImages([]);
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
            onChange={(e) => {
              setCurrentImages([...e.target.files]);
            }}
          />
        </Col>
      </FormGroup>
      <FormGroup row>
        <Label sm={2}>Images in Database</Label>
        <Col sm={10}>
          {selectedProduct?.images?.map((img) => {
            return (
              <img src={img.imageUrl} alt={img.imageId} className="w-25" />
            );
          })}
        </Col>
      </FormGroup>
      <FormGroup row>
        <Label sm={2}>Current images</Label>
        <Col sm={10}>
          {currentImages?.map((img) => {
            return (
              <img
                src={URL.createObjectURL(img)}
                key={img.name}
                alt={img.name}
                className="w-25"
              />
            );
          })}
        </Col>
      </FormGroup>
      <FormGroup row>
        <Label sm={2}>Select</Label>
        <Col sm={{ offset: 0, size: 10 }}>
          <Controller
            name="categoryId"
            control={control}
            rules={{
              validate: (value) => !isNaN(value) || "invalid number",
            }}
            defaultValue=""
            render={({ field }) => (
              <Input type="select" {...field}>
                <option>Select categoryList</option>
                {categoryList.map((cate) => {
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
          <Button className="w-100">
            {Object.getOwnPropertyNames(selectedProduct).length === 0
              ? "Add product"
              : "Update product"}
          </Button>
        </Col>
      </FormGroup>
    </Form>
  );
};

export default ProductForm;
