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

export default function StudentForm() {
  const [isCreate, setIsCreate] = useState<boolean>(true);
    const [student, setStudent] = useState<Student>();
  const { id } = useParams();
  const formik =  useFormik({
    initialValues: {
      name: "",
      email: "",
      dob: "",
      phone: "",
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

useEffect(() => {
  const fetchData = async () => {
    const data = await getStudentById(Number(id));
    console.log("with id ", data);
    setStudent(data)

  };

  if(id) {
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
              value={id ? student?.name :formik.values.name}
              onChange={formik.handleChange}
              placeholder="Name"
            />
            <input
              name="email"
              value={id ? student?.email :formik.values.email}
              onChange={formik.handleChange}
              placeholder="Email"
            />{" "}
            <input  
              name="Phone"
              value={id ? student?.phone :formik.values.phone}
              onChange={formik.handleChange}
              placeholder="Mobile"
            />{" "}
            <input
              name="DOB"
              type="Date"
              value={id ? student?.dob :formik.values.dob}
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
