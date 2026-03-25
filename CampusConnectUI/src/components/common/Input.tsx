import React from "react";
import "./Input.css";

// Common props type
type InputProps = {
  value: string;
  lable: string;
  name: string;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  onBlur: (e: React.FocusEvent<HTMLInputElement>) => void;
  error?: string;
  touched?: boolean;
  type?: string;
};

export const FloatingInputTextField: React.FC<InputProps> = ({
  value,
  lable,
  name,
  onChange,
  onBlur,
  error,
  touched,
  type
}) => {
  return (
    <div className="floating-field">
    
    <div className="floatingInput-group">
      <input
        id={value}
        type={type}
        className="floatingInput-field"
        name={name}
        onChange={onChange}
        onBlur={onBlur}
        placeholder=" "
      />
      <label className="floatingInput-label" htmlFor={name}>
        {lable}
      </label>

     
    </div>
      {error && touched && (
        <span className="error-text">{error}</span>
      )}
    </div>
  );
};


