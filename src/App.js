import { Container } from "reactstrap";
import { MyNavbar } from "./components/Navbar";
import { ProductPage } from "./pages/Product";
import ProductContextProvider from "./context/product_context";

function App() {
  return (
    <div>
      <MyNavbar></MyNavbar>
      {/* Spacer */}
      <div className="p-5"></div>
      <Container>
        <ProductContextProvider>
          <ProductPage />
        </ProductContextProvider>
      </Container>
    </div>
  );
}

export default App;
