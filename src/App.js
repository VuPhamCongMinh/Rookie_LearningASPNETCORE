import { Container } from "reactstrap";
import { MyNavbar } from "./components/Navbar";
import { ProductPage } from "./pages/Product";
import { CategoryPage } from "./pages/Category";
import { AccountPage } from "./pages/Account";
import "bootstrap/dist/css/bootstrap.min.css";
import { Route, Switch } from "react-router";
import LoginPage from "./components/login";
import LogoutPage from "./components/logout";
import store from "./redux/store";
import ProtectedRoute from "./utils/route_ulti";
import { loadUserFromStorage } from "./auth/auth_services";
import { useEffect } from "react";

function App() {
  useEffect(() => {
    loadUserFromStorage(store);
  }, []);

  return (
    <div>
      <MyNavbar></MyNavbar>
      {/* Spacer */}
      <div className="p-5"></div>
      <Container>
        <Switch>
          <Route path="/signin-oidc" component={LoginPage} />
          <Route path="/signout-oidc" component={LogoutPage} />

          <ProtectedRoute path="/products" component={ProductPage} />
          <ProtectedRoute path="/users" component={AccountPage} />
          <ProtectedRoute path="/categories" component={CategoryPage} />
        </Switch>
      </Container>
    </div>
  );
}

export default App;
