import React from 'react';
import logo from './logo.svg';
import './App.css';
import StudentList from './components/student/StudentList';
import StudentForm from './components/student/studentForm';
import { Route, Routes } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      
      <StudentList/>
      <Routes>
      <Route path="/EditStudent/:id" element={<StudentForm />} ></Route>
      </Routes>
    </div>
  );
}

export default App;
