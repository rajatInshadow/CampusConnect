import {
  Formik,
  FormikHelpers,
  FormikValues,
  useFormik,
  useFormikContext,
} from "formik";
import { createStudent } from "../../services/studentService";

export default function StudentForm() {
  const formik =  useFormik({
    initialValues: {
      name: "",
      email: "",
      DOB: "",
      Phone: "",
    },
     onSubmit: (values) => {
      console.log(values);
      const payload = {
        ...values,
        studentID:1
      }
        createStudent(payload);
    },
  });

  return (
    <>
      <div className="container">
        <div className="row">
          <h1>Form</h1>
          <form onSubmit={formik.handleSubmit}>
            <input
              name="name"
              value={formik.values.name}
              onChange={formik.handleChange}
              placeholder="Name"
            />
            <input
              name="email"
              value={formik.values.email}
              onChange={formik.handleChange}
              placeholder="Email"
            />{" "}
            <input
              name="Phone"
              value={formik.values.Phone}
              onChange={formik.handleChange}
              placeholder="Mobile"
            />{" "}
            <input
              name="DOB"
              type="Date"
              value={formik.values.DOB}
              onChange={formik.handleChange}
              placeholder="DOB"
            />{" "}
            <button type="submit">Submit</button>
          </form>
        </div>
      </div>
    </>
  );
}
