import {useEffect, useState} from "react";
import { Student } from "../../utils/types";
import { getStudent } from "../../services/studentService";

export default function StudentList(){

const [studentList,setStudentList] = useState<Student[]>();

useEffect(() => {
    async function loadStudents() {
        const data = await getStudent();
        setStudentList(data);
    }
    loadStudents();
    console.log(studentList);
},[]);

return (
    <>
   
    </>
)
}