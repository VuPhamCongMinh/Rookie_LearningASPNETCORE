import React from "react";
import { Col, Row } from "reactstrap";
import { CategoryForm } from "../components/category_form";
import { CategoryTable } from "../components/category_table";
export const CategoryPage = () => {
  return (
    <Row>
      <Col md="12">
        {/* Form */}
        <CategoryForm></CategoryForm>
        {/* Spacer */}
        <div className="p-5"></div>
        {/* Toolbar */}
        {/* <ProductToolbar></ProductToolbar> */}
        {/* Table */}
        <CategoryTable></CategoryTable>
      </Col>
    </Row>
  );
};
