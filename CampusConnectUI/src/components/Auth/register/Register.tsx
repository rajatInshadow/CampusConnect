import { useFormik } from "formik";
import { UserSignUpValidationSchema } from "../../../utils/validations";
import { FloatingInputTextField } from "../../common/Input";

export const Register = () => {
  const registerForm = useFormik({
    initialValues: {
      firstName: "",
      middleName: "",
      lastName: "",
      email: "",
      dob: "",
      phone: "",
      password: "",
    },
    validationSchema: UserSignUpValidationSchema,
    onSubmit: ()=>{
        console.log("form details", registerForm);
    }
  });

  return (
    <>
      <h1>Register</h1>
      <div className="container">
              <div className="row">
                <div className="col">
                  {/* <h1>{isCreate ? "Create Student" : "Update Student"}</h1> */}
                  <form onSubmit={registerForm.handleSubmit}>
                    <FloatingInputTextField
                      name="firstName"
                      value={registerForm.values.firstName}
                      lable="First Name"
                      onChange={registerForm.handleChange}
                      onBlur={registerForm.handleBlur}
                      error={registerForm.errors.firstName}
                      touched={registerForm.touched.firstName}
                      type="text"
                    />
                    <FloatingInputTextField
                      name="middleName"
                      value={registerForm.values.middleName}
                      lable="Middle Name"
                      onChange={registerForm.handleChange}
                      onBlur={registerForm.handleBlur}
                      error={registerForm.errors.middleName}
                      touched={registerForm.touched.middleName}
                      type="text"
                    />
                    <FloatingInputTextField
                      name="lastName"
                      value={registerForm.values.lastName}
                      lable="Last Name"
                      onChange={registerForm.handleChange}
                      onBlur={registerForm.handleBlur}
                      error={registerForm.errors.lastName}
                      touched={registerForm.touched.lastName}
                      type="text"
                    />
                    <FloatingInputTextField
                      name="email"
                      value={registerForm.values.email}
                      lable="Email"
                      onChange={registerForm.handleChange}
                      onBlur={registerForm.handleBlur}
                      error={registerForm.errors.email}
                      touched={registerForm.touched.email}
                    />
                    <FloatingInputTextField
                      name="phone"
                      value={registerForm.values.phone}
                      lable="Phone"
                      onChange={registerForm.handleChange}
                      onBlur={registerForm.handleBlur}
                      error={registerForm.errors.phone}
                      touched={registerForm.touched.phone}
                      type="tel"
                    />
                    <FloatingInputTextField
                      name="dob"
                      value={registerForm.values.dob}
                      lable="Date of birth"
                      onChange={registerForm.handleChange}
                      onBlur={registerForm.handleBlur}
                      error={registerForm.errors.dob}
                      touched={registerForm.touched.dob}
                      type="Date"
                    />
                     <FloatingInputTextField
                      name="password"
                      value={registerForm.values.password}
                      lable="Password"
                      onChange={registerForm.handleChange}
                      onBlur={registerForm.handleBlur}
                      error={registerForm.errors.password}
                      touched={registerForm.touched.password}
                      type="password"
                    />
                    <button type="submit">Submit</button>
                  </form>
                </div>
              </div>
            </div>
    </>
  );
};
