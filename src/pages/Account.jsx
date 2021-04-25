import React from "react";
import { Col, Row } from "reactstrap";
import { UserTable } from "../components/user_table";
export const AccountPage = () => {
  return (
    <Row>
      <Col md="12">
        {/* Spacer */}
        <div className="p-5"></div>
        {/* Table */}
        <UserTable></UserTable>
      </Col>
    </Row>
  );
};
