import { Container } from "reactstrap";
import { MyNavbar } from "./components/Navbar";
import { ProductPage } from "./pages/Product";
import ProductContextProvider from "./context/product_context";
import CategoryContextProvider from "./context/category_context";
import { CategoryPage } from "./pages/Category";
import "bootstrap/dist/css/bootstrap.min.css";
import { Route } from "react-router";

function App() {
  return (
    <div>
      <MyNavbar></MyNavbar>
      {/* Spacer */}
      <div className="p-5"></div>
      <Container>
        <ProductContextProvider>
          <CategoryContextProvider>
            <Route path="/products" component={ProductPage}></Route>
            <Route path="/categories" component={CategoryPage}></Route>
          </CategoryContextProvider>
        </ProductContextProvider>
      </Container>
    </div>
  );
}

export default App;
