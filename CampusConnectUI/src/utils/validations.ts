import * as Yup from "yup";

export const StudentValidationSchema = Yup.object({
  name: Yup.string()
    .required("Name is requried")
    .min(5, "Name should be 5 or more character"),
  email: Yup.string().required("Email is required").email("invalid format"),
  phone: Yup.string()
    .required("phone number is required")
    .matches(/^[0-9]{10}$/, "Phone must be exactly 10 digits"),
  dob: Yup.date()
    .required("Date of Birth is required")
    .max(new Date(), "DOB cannot be in the future"),
});


export const StudentLoginValidationSchema = Yup.object({
  email: Yup.string().required("Email is required").email("invalid format"),
  password: Yup.string()
    .required("password is required")
});
