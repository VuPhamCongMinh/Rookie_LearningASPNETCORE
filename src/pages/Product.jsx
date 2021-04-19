import React from "react";
import { Col, Row } from "reactstrap";
import { MyForm } from "../components/Form";
import { MyTable } from "../components/Table";
import { Toolbar } from "../components/Toolbar";
export const ProductPage = () => {
  return (
    <Row>
      <Col md="12">
        {/* Form */}
        <MyForm></MyForm>
        {/* Spacer */}
        <div className="p-5"></div>
        {/* Toolbar */}
        <Toolbar></Toolbar>
        {/* Table */}
        <MyTable></MyTable>
      </Col>
    </Row>
  );
};
