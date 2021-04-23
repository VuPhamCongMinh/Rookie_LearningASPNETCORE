import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { useHistory } from "react-router";
import { signoutRedirectCallback } from "../auth/auth_services";
import { storeUser } from "../redux/actions/auth_actions";

const LogoutPage = () => {
  const history = useHistory();
  const dispatch = useDispatch();

  useEffect(() => {
    async function signoutAsync() {
      var alu = await signoutRedirectCallback();
      dispatch(storeUser(alu));
      // history.push("/");
    }
    signoutAsync();
  }, [history]);

  return <div>Sign Out Redirecting...</div>;
};

export default LogoutPage;
