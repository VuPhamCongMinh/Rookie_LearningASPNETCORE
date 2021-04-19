import { useContext } from "react";
import { Col, Container, Row } from "reactstrap";
import MyForm from "./components/Form";
import MyNavbar from "./components/Navbar";
import { MyTable } from "./components/Table";
import { ProductContext } from "./context/product_context";

function App() {
  return (
    <div>
      <MyNavbar></MyNavbar>
      {/* Spacer */}
      <div className="p-5"></div>
      <Container>
        <Row>
          <Col md="12">
            {/* Form */}
            <MyForm></MyForm>
            {/* Spacer */}
            <div className="p-5"></div>
            {/* Table */}
            <MyTable></MyTable>
          </Col>
        </Row>
      </Container>
    </div>
  );
}

export default App;
