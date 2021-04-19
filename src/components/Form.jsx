import React, { useContext, useEffect } from "react";
import { Controller, useForm } from "react-hook-form";
import { Col, Button, Form, FormGroup, Label, Input } from "reactstrap";
import { PostProducts, PutProducts } from "../api/product_api";
import { ProductContext } from "../context/product_context";
import { ProductFormData } from "../model/product_formdata";

const MyForm = () => {
  const {
    categories,
    selectedItem,
    productItems,
    setProductItems,
  } = useContext(ProductContext);
  const {
    register,
    handleSubmit,
    setValue,
    control,
    formState: { errors },
  } = useForm();

  useEffect(() => {
    Object.keys(selectedItem).forEach((x) => {
      setValue(x, selectedItem[x]);
    });
  }, [selectedItem]);

  const submitHandle = async (formData) => {
    console.log(formData);
    let returnData;
    let myFormData = ProductFormData(formData);
    if (myFormData.get("productId") === null) {
      returnData = await PostProducts(myFormData);
      setProductItems((prev) => [...prev, returnData]);
    } else {
      returnData = await PutProducts(myFormData);
      console.log(returnData);
      let newProducts = productItems.map((prod) =>
        prod.productId === returnData.productId ? returnData : prod
      );
      setProductItems(newProducts);
    }
  };

  return (
    <Form onSubmit={handleSubmit(submitHandle)}>
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
        <Col sm={10}>
          <Controller
            name="productDescription"
            control={control}
            defaultValue=""
            render={({ field }) => <Input type="textarea" {...field} />}
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
              required: true,
              validate: (value) => !isNaN(value) || "error message",
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

          {errors.categoryId && <span>{errors.categoryId.message}</span>}
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
