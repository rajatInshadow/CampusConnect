import apiClient from "../api/apiClient";

import { Student } from "../utils/types";

export async function getStudent(): Promise<Student[]> {
    const response = await apiClient.get("/student");
    console.log("res ",response)
    return response.data;
}

export async function createStudent(data: Student ): Promise<Student> {
    const res = await apiClient.post("/student",data);
    console.log("res ",res);
    return res.data;
}

export async function getStudentById(Id:number): Promise<Student> {
    const res = await apiClient.get(`/student/${Id}`);
    console.log("get student id ", res)
    return res.data;
}

export async function deleteStudent(Id:number): Promise<string> {
    const res = await apiClient.delete(`/student/${Id}`);
    console.log(res);
    return res.data;
}