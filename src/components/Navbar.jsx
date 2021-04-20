import React, { useState } from "react";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  NavbarText,
} from "reactstrap";
import { Link } from "react-router-dom";

export const MyNavbar = () => {
  const [isOpen, setIsOpen] = useState(false);

  const toggle = () => setIsOpen(!isOpen);

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
              <NavLink>User</NavLink>
            </NavItem>
          </Nav>
          <NavbarText>Hello User !</NavbarText>
        </Collapse>
      </Navbar>
    </div>
  );
};

export default MyNavbar;
