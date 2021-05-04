import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { useHistory } from "react-router";
import { signinRedirectCallback, signoutRedirect } from "../auth/auth_services";
import { storeUser } from "../redux/actions/auth_actions";
import { fetchInitialDatas } from "../redux/actions/common_actions";
import { alertError } from "../utils/sweetalert_util";

const LoginPage = () => {
  const history = useHistory();
  const dispatch = useDispatch();

  useEffect(() => {
    async function signinAsync() {
      await signinRedirectCallback().then((user) => {
        if (user.profile.role === "Admin") {
          dispatch(storeUser(user));
          dispatch(fetchInitialDatas());
        } else {
          alertError("Đăng nhập");
          signoutRedirect();
        }
      });
      history.push("/");
    }
    signinAsync();
  }, [history, dispatch]);

  return <div>Sign In Redirecting...</div>;
};

export default LoginPage;
