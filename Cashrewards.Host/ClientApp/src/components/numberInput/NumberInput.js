import React from "react";

const NumberInput = (props) => {
  let wrapperClass = "form-group";
  if (props.error.length > 0) {
    wrapperClass += " has-error";
  }

  return (
    <div className={wrapperClass}>
      <label htmlFor={props.id}>{props.label}</label>
      <div className="field">
        <input
          id={props.id}
          type="number"
          name={props.name}
          step={props.step}
          value={props.value}
          onChange={props.onChange}
          className="form-control"
        />
      </div>
      {props.error && <div className="alert alert-danger">{props.error}</div>}
    </div>
  );
};

export default NumberInput;
