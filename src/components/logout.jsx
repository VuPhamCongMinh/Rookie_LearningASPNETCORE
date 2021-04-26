import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { useHistory } from "react-router";
import { signoutRedirectCallback } from "../auth/auth_services";
import { clearUser } from "../redux/actions/auth_actions";

const LogoutPage = () => {
  const history = useHistory();
  const dispatch = useDispatch();

  useEffect(() => {
    signoutRedirectCallback().then((_) => {
      dispatch(clearUser);
    });
  }, [history, dispatch]);
  history.push("/");
  return <div>Sign Out Redirecting...</div>;
};

export default LogoutPage;
