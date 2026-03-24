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
import Alert from "@mui/material/Alert";
import { render } from "@testing-library/react";
import { toast } from "react-toastify";
import { FloatingInputTextField } from "../common/Input";

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
      toast.success("Form submitted successfully!");
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
          <div className="col">
            <h1>{isCreate ? "Create Student" : "Update Student"}</h1>
            <form onSubmit={formik.handleSubmit}>
              <FloatingInputTextField
                name="name"
                value={formik.values.name}
                lable="Name"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                error={formik.errors.name}
                touched={formik.touched.name}
                type="text"
              />
              <FloatingInputTextField
                name="email"
                value={formik.values.email}
                lable="Email"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                error={formik.errors.email}
                touched={formik.touched.email}
              />
              <FloatingInputTextField
                name="phone"
                value={formik.values.phone}
                lable="Phone"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                error={formik.errors.phone}
                touched={formik.touched.phone}
                type="tel"
              />
              <FloatingInputTextField
                name="dob"
                value={formik.values.dob}
                lable="Date of birth"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                error={formik.errors.dob}
                touched={formik.touched.dob}
                type="Date"
              />
              <button type="submit">Submit</button>
            </form>
          </div>
        </div>
      </div>
    </>
  );
}
