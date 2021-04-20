import React from "react";
import { Col, Row } from "reactstrap";
import { ProductForm } from "../components/product_form";
import { ProductTable } from "../components/product_table";
import { ProductToolbar } from "../components/product_toolbar";
export const ProductPage = () => {
  return (
    <Row>
      <Col md="12">
        {/* Form */}
        <ProductForm></ProductForm>
        {/* Spacer */}
        <div className="p-5"></div>
        {/* Toolbar */}
        <ProductToolbar></ProductToolbar>
        {/* Table */}
        <ProductTable></ProductTable>
      </Col>
    </Row>
  );
};
