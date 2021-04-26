import React, { useState } from "react";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavbarText,
  Button,
} from "reactstrap";
import { Link } from "react-router-dom";
import { signoutRedirect } from "../auth/auth_services";
import { useSelector } from "react-redux";

export const MyNavbar = () => {
  const [isOpen, setIsOpen] = useState(false);
  const toggle = () => setIsOpen(!isOpen);

  const currentUser = useSelector((state) => state.auth.user);

  return (
    <div>
      <Navbar color="light" light expand="md">
        <NavbarBrand href="/">SimpleShop.Admin</NavbarBrand>
        <NavbarToggler onClick={toggle} />
        <Collapse isOpen={isOpen} navbar>
          <Nav className="mr-auto" navbar>
            <NavItem>
              <Link className="nav-link" to="/products">
                Products
              </Link>
            </NavItem>
            <NavItem>
              <Link className="nav-link" to="/categories">
                Categories
              </Link>
            </NavItem>
            <NavItem>
              <Link className="nav-link" to="/users">
                Users
              </Link>
            </NavItem>
          </Nav>
          {currentUser && (
            <NavbarText>
              Hello,{currentUser.profile.name}
              <Button
                color="danger"
                className="ml-1"
                onClick={() => signoutRedirect()}
              >
                Sign Out
              </Button>
            </NavbarText>
          )}
        </Collapse>
      </Navbar>
    </div>
  );
};

export default MyNavbar;
