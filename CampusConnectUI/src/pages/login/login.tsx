import { useFormik } from "formik";
import "./login.css";

export function Login() {
  const loginForm = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    onSubmit: (value) => {
      console.log(value);
    },
  });

  return (
    <>
      <div className="container-fluid">
        <div className="row">
          <div className="col-md-6">
            <strong>Login form</strong>
            <form onSubmit={loginForm.handleSubmit}>
              <input
                name="email"
                value={loginForm.values.email}
                onChange={loginForm.handleChange}
                placeholder="Email"
              />{" "}
              <input
                name="password"
                value={loginForm.values.password}
                onChange={loginForm.handleChange}
                placeholder="Password"
              />{" "}
              <button type="submit">login</button>
            </form>
          </div>
          <div className="d-md-block d-none col-md-6">
            <img className="sideImage" src="/assests/login.jpg" alt="campus" />
          </div>
        </div>
      </div>
    </>
  );
}
