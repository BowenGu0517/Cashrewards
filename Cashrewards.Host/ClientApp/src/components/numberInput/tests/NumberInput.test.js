import React from "react";
import { render, unmountComponentAtNode } from "react-dom";
import NumberInput from "../NumberInput";

let container = null;

beforeEach(() => {
  container = document.createElement("div");
  document.body.appendChild(container);
});

afterEach(() => {
  unmountComponentAtNode(container);
  container.remove();
  container = null;
});

describe("NumberInput", () => {
  test("Render with no error section", () => {
    const props = {
      id: 1,
      label: "Label",
      name: "name",
      value: "value",
      onChange: jest.fn(),
      error: "",
    };

    render(<NumberInput {...props} />, container);

    expect(container.querySelectorAll(".has-error").length).toBe(0);
  });
  test("Render with error section", () => {
    const props = {
      id: 1,
      label: "Label",
      name: "name",
      value: "value",
      onChange: jest.fn(),
      error: "error",
    };

    render(<NumberInput {...props} />, container);

    expect(container.querySelectorAll(".has-error").length).toBe(1);
  });
});
