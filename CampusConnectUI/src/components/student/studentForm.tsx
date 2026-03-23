import {
  Formik,
  FormikHelpers,
  FormikValues,
  useFormik,
  useFormikContext,
} from "formik";
import { createStudent, getStudentById } from "../../services/studentService";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Student } from "../../utils/types";
import { StudentValidationSchema } from "../../utils/validations";

export default function StudentForm() {
  const [isCreate, setIsCreate] = useState<boolean>(true);
  const [student, setStudent] = useState<Student>();
  const { id } = useParams();
  const formik = useFormik({
    initialValues: {
      name: "",
      email: "",
      dob: "",
      phone: "",
    },
    validationSchema: StudentValidationSchema,
    onSubmit: (values) => {
      console.log(values);
      const payload = {
        ...values,
        studentID: 1,
      };
      createStudent(payload);
    },
  });

  useEffect(() => {
    const fetchData = async () => {
      const data = await getStudentById(Number(id));
      console.log("with id ", data);
      setStudent(data);
    };

    if (id) {
      fetchData();
    }
  }, [id]);

  return (
    <>
      <div className="container">
        <div className="row">
          <h1>{isCreate ? "Create Student" : "Update Student"}</h1>
          <form onSubmit={formik.handleSubmit}>
            <input
              name="name"
              value={id ? student?.name : formik.values.name}
              onChange={formik.handleChange}
              placeholder="Name"
              onBlur={formik.handleBlur}
            />
            {formik.touched.name && formik.errors.name && (
              <div style={{ color: "red" }}>{formik.errors.name}</div>
            )}
            <input
              name="email"
              value={id ? student?.email : formik.values.email}
              onChange={formik.handleChange}
              placeholder="Email"
              onBlur={formik.handleBlur}
            />{" "}
            {formik.touched.email && formik.errors.email && (
              <div style={{ color: "red" }}>{formik.errors.email}</div>
            )}
            <input
              name="phone"
              value={id ? student?.phone : formik.values.phone}
              onChange={formik.handleChange}
              placeholder="Mobile"
              onBlur={formik.handleBlur}
            />{" "}
            {formik.touched.phone && formik.errors.phone && (
              <div style={{ color: "red" }}>{formik.errors.phone}</div>
            )}
            <input
              name="dob"
              type="Date"
              value={id ? student?.dob : formik.values.dob}
              onChange={formik.handleChange}
              placeholder="DOB"
              onBlur={formik.handleBlur}
            />{" "}
            {formik.touched.dob && formik.errors.dob && (
              <div style={{ color: "red" }}>{formik.errors.dob}</div>
            )}
            <button type="submit">Submit</button>
          </form>
        </div>
      </div>
    </>
  );
}
