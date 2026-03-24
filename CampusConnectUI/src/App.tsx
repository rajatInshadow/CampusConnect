import React from 'react';
import logo from './logo.svg';
import './App.css';
import StudentList from './components/student/StudentList';
import StudentForm from './components/student/studentForm';
import { Route, Routes } from 'react-router-dom';
import { Login } from './pages/login/login';
import { ToastContainer } from 'react-toastify';

function App() {
  return (
    <div className="App">
      <ToastContainer />
      
      <Routes>
        <Route path="/Student" element={<StudentList />} ></Route>
          <Route path="/CreateStudent" element={<StudentForm />} ></Route>
      <Route path="/EditStudent/:id" element={<StudentForm />} ></Route>
      
      <Route path="/login" element={<Login />} ></Route>
      </Routes>
    </div>
  );
}

export default App;
