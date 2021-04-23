import React from "react";
import { Route } from "react-router-dom";
import { useSelector } from "react-redux";
import { signinRedirect } from "../auth/auth_services";

function ProtectedRoute({ children, component: Component, ...rest }) {
  const user = useSelector((state) => state.auth.user);
  if (!user) signinRedirect();

  return user && <Route {...rest} component={Component} />;
}

export default ProtectedRoute;
