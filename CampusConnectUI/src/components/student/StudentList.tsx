import { useEffect, useState } from "react";
import { Student } from "../../utils/types";
import { deleteStudent, getStudent, getStudentById } from "../../services/studentService";
import {
  Paper,
  styled,
  Table,
  TableBody,
  TableCell,
  tableCellClasses,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";
import { useNavigate, useParams } from "react-router-dom";
import Button from "../common/Button";

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  "&:nth-of-type(odd)": {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  "&:last-child td, &:last-child th": {
    border: 0,
  },
}));

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

export default function StudentList() {
  const [studentList, setStudentList] = useState<Student[]>();
  const [studentForm, setStudentForm] = useState<boolean>(false);
  const navigate = useNavigate();
  const { id } = useParams();

  useEffect(() => {
    if (id) {
      const data = getStudentById(Number(id));
      console.log("with id ", data);
    } else {
      loadStudents();
    }

    async function loadStudents() {
      const data = await getStudent();
      console.log("data ", data);
      setStudentList(data);
    }
    console.log(studentList, typeof studentList);
  }, []);

  return (
    <>
      <div className="container">
        <div className="row">
          <div className="col">
            <TableContainer component={Paper}>
              <Table sx={{ minWidth: 700 }} aria-label="customized table">
                <TableHead>
                  <TableRow>
                    <StyledTableCell align="center">ID</StyledTableCell>
                    <StyledTableCell align="center">Name</StyledTableCell>
                    <StyledTableCell align="center">Email</StyledTableCell>
                    <StyledTableCell align="center">Phone</StyledTableCell>
                     <StyledTableCell align="center">DOB</StyledTableCell>
                    <StyledTableCell align="center">Status</StyledTableCell>
                    <StyledTableCell align="center">Action</StyledTableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {studentList?.map((row) => (
                    <StyledTableRow key={row.studentID}>
                      <StyledTableCell align="center">
                        {row.studentID}
                      </StyledTableCell>
                      <StyledTableCell align="center">
                        {row.name}
                      </StyledTableCell>
                      <StyledTableCell align="center">
                        {row.email}
                      </StyledTableCell>
                       <StyledTableCell align="center">
                        {row.phone}
                      </StyledTableCell>
                       <StyledTableCell align="center">
                        {row.dob}
                      </StyledTableCell>
                      <StyledTableCell align="center">Test</StyledTableCell>
                      <StyledTableCell align="center">
                        <button
                          onClick={() => {
                            navigate(`/EditStudent/${row.studentID}`);
                          }}
                        >
                          <i className="fa-solid fa-pen-to-square">Edit</i>
                          </button>
                          <button  onClick={() => {
                            const res = deleteStudent(row.studentID);
                            console.log(res);
                          }}>
                          <i className="fa-sharp fa-solid fa-user">Delete</i>
                        </button>
                      </StyledTableCell>
                    </StyledTableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
          </div>
        </div>
      </div>
    </>
  );
}
