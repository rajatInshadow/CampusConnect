import React from 'react';
import logo from './logo.svg';
import './App.css';
import StudentList from './components/student/StudentList';
import StudentForm from './components/student/studentForm';

function App() {
  return (
    <div className="App">
      
      <StudentList/>
      <StudentForm/>
    </div>
  );
}

export default App;
