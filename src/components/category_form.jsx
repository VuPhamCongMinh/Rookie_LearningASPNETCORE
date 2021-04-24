import React, { useEffect } from "react";
import { Controller, useForm } from "react-hook-form";
import { useSelector } from "react-redux";
import { Col, Button, Form, FormGroup, Label, Input } from "reactstrap";
import { cagetorySubmitHandle } from "../utils/form_util";

export const CategoryForm = () => {
  const selectedCategory = useSelector(
    (state) => state.category.selectedCategory
  );

  const {
    handleSubmit,
    setValue,
    control,
    formState: { errors, isSubmitting },
  } = useForm();

  useEffect(() => {
    Object.keys(selectedCategory).forEach((x) => {
      setValue(x, selectedCategory[x]);
    });
  }, [setValue, selectedCategory]);

  const submit = async (formData) => {
    cagetorySubmitHandle(formData, setValue);
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
          <Button className="w-100">
            {Object.getOwnPropertyNames(selectedCategory).length === 0
              ? "Add category"
              : "Update category"}
          </Button>
        </Col>
      </FormGroup>
    </Form>
  );
};

export default CategoryForm;
