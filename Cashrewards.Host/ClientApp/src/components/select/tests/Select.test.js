import React from "react";
import { render, unmountComponentAtNode } from "react-dom";
import Select from "../Select";

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

describe("Select", () => {
  test("Render with no error section", () => {
    const props = {
      id: 1,
      label: "Label",
      name: "name",
      value: "value",
      onChange: jest.fn(),
      error: "",
      options: [],
    };

    render(<Select {...props} />, container);

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
      options: [],
    };

    render(<Select {...props} />, container);

    expect(container.querySelectorAll(".has-error").length).toBe(1);
  });
});
