import React from "react";
import { MemoryRouter } from "react-router-dom";
import { render, unmountComponentAtNode } from "react-dom";
import MerchantForm from "../MerchantForm";

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

describe("MerchantForm", () => {
  test("Should render correctly when add", () => {
    const props = {
      merchant: {
        websiteUrl: "www.test-01.com",
        country: "Australia",
        currency: "AUD",
        discountPercentage: 10,
        isActive: true,
        options: {
          countryOptions: [],
          currencyOptions: [],
        },
      },
      errors: {
        websiteUrl: "",
        country: "",
        currency: "",
        discountPercentage: "",
      },
      onChange: jest.fn(),
      onSubmit: jest.fn(),
    };

    render(
      <MemoryRouter>
        <MerchantForm {...props} />
      </MemoryRouter>,
      container
    );

    expect(container.querySelectorAll("input[id='websiteUrl']").length).toEqual(
      1
    );

    expect(container.querySelectorAll("select[id='country']").length).toEqual(
      1
    );
    expect(container.querySelectorAll("select[id='currency']").length).toEqual(
      1
    );

    expect(
      container.querySelectorAll("input[id='discountPercentage']").length
    ).toEqual(1);

    expect(container.querySelectorAll("input[id='isActive']").length).toEqual(
      1
    );

    const submitInput = container.querySelector("input[type='submit']");
    expect(submitInput.getAttribute("value")).toEqual("Add");
  });
  test("Should render correctly when edit", () => {
    const props = {
      merchant: {
        uniqueId: "62178593-efbc-4ba2-9bbd-d2841c896820",
        websiteUrl: "www.test-01.com",
        country: "Australia",
        currency: "AUD",
        discountPercentage: 10,
        isActive: true,
        options: {
          countryOptions: [],
          currencyOptions: [],
        },
      },
      errors: {
        websiteUrl: "",
        country: "",
        currency: "",
        discountPercentage: "",
      },
      onChange: jest.fn(),
      onSubmit: jest.fn(),
    };

    render(
      <MemoryRouter>
        <MerchantForm {...props} />
      </MemoryRouter>,
      container
    );

    expect(container.querySelectorAll("input[id='websiteUrl']").length).toEqual(
      1
    );

    expect(container.querySelectorAll("select[id='country']").length).toEqual(
      1
    );
    expect(container.querySelectorAll("select[id='currency']").length).toEqual(
      1
    );

    expect(
      container.querySelectorAll("input[id='discountPercentage']").length
    ).toEqual(1);

    expect(container.querySelectorAll("input[id='isActive']").length).toEqual(
      1
    );

    const submitInput = container.querySelector("input[type='submit']");
    expect(submitInput.getAttribute("value")).toEqual("Save");
  });
});
