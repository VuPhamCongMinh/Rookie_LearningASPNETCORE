import React from "react";
import {
  Col,
  Button,
  Form,
  FormGroup,
  Label,
  Input,
  FormText,
} from "reactstrap";

const MyForm = () => {
  return (
    <Form>
      <FormGroup row>
        <Label for="productName" sm={2}>
          Product Name
        </Label>
        <Col sm={10}>
          <Input
            type="text"
            name="productName"
            id="productName"
            placeholder="enter product name"
          />
        </Col>
      </FormGroup>
      <FormGroup row>
        <Label for="productPrice" sm={2}>
          Price
        </Label>
        <Col sm={10}>
          <Input
            type="number"
            name="productPrice"
            id="productPrice"
            placeholder="enter product price"
          />
        </Col>
      </FormGroup>
      <FormGroup row>
        <Label for="productDescription" sm={2}>
          Product Description
        </Label>
        <Col sm={10}>
          <Input type="textarea" name="text" id="productDescription" />
        </Col>
      </FormGroup>
      <FormGroup row>
        <Label for="productImage" sm={2}>
          Product File
        </Label>
        <Col sm={10}>
          <Input type="file" name="file" id="productImage" />
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
