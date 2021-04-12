import { Col, Container, Row } from "reactstrap";
import MyNavbar from "./components/Navbar";
import { MyTable } from "./components/Table";

function App() {
  return (
    <div>
      <MyNavbar></MyNavbar>
      {/* Spacer */}
      <div className="p-5"></div>
      {/*  */}
      <Container>
        <Row>
          <Col md="12">
            <MyTable></MyTable>
          </Col>
        </Row>
      </Container>
    </div>
  );
}

export default App;
