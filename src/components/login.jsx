import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { useHistory } from "react-router";
import { signinRedirectCallback } from "../auth/auth_services";
import { storeUser } from "../redux/actions/auth_actions";

const LoginPage = () => {
  const history = useHistory();
  const dispatch = useDispatch();

  useEffect(() => {
    async function signinAsync() {
      var alu = await signinRedirectCallback();
      dispatch(storeUser(alu));
      history.push("/");
    }
    signinAsync();
  }, [history]);

  return <div>Sign In Redirecting...</div>;
};

export default LoginPage;
