import { useEffect, useState } from "react";
import { Student } from "../../utils/types";
import { getStudent } from "../../services/studentService";
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

  useEffect(() => {
    async function loadStudents() {
      const data = await getStudent();
      console.log("data ", data);
      setStudentList(data);
    }
    loadStudents();
    console.log(studentList, typeof studentList);
  }, [studentList]);

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
                    <StyledTableCell align="center">Status</StyledTableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {studentList?.map((row) => (
                    <StyledTableRow key={row.name}>
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
                        Test
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
