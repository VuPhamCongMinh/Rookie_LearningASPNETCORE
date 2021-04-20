import React, { useContext, useEffect } from "react";
import { Controller, useForm } from "react-hook-form";
import { Col, Button, Form, FormGroup, Label, Input } from "reactstrap";
import { CategoryContext } from "../context/category_context";
import { cagetorySubmitHandle } from "../utils/form_util";

export const CategoryForm = () => {
  const {
    categories,
    setCategories,
    selectedCate,
    setSelectedCate,
  } = useContext(CategoryContext);
  const {
    handleSubmit,
    setValue,
    control,
    formState: { errors, isSubmitting },
  } = useForm();

  useEffect(() => {
    Object.keys(selectedCate).forEach((x) => {
      setValue(x, selectedCate[x]);
    });
  }, [setValue, selectedCate]);

  const submit = async (formData) => {
    cagetorySubmitHandle(
      categories,
      setCategories,
      selectedCate,
      setSelectedCate,
      formData,
      setValue
    );
  };

  return (
    <Form onSubmit={handleSubmit(submit)}>
      <FormGroup row>
        <Controller
          name="categoryId"
          control={control}
          defaultValue=""
          render={({ field }) => <Input type="hidden" {...field} />}
        />
        <Label sm={2}>Product Name</Label>
        <Col sm={10}>
          <Controller
            name="categoryName"
            control={control}
            rules={{
              required: {
                value: isSubmitting,
                message: "this field is require",
              },
            }}
            defaultValue=""
            render={({ field }) => (
              <Input {...field} placeholder="enter category name" />
            )}
          />
          <span>{errors?.categoryName?.message}</span>
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

export default CategoryForm;
