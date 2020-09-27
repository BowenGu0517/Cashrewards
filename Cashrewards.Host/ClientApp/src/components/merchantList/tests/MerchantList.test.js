import React from "react";
import { MemoryRouter } from "react-router-dom";
import { render, unmountComponentAtNode } from "react-dom";
import MerchantList from "../MerchantList";

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

describe("MerchantList", () => {
  test("Should render correctly", () => {
    const props = {
      merchants: [
        {
          uniqueId: "62178593-efbc-4ba2-9bbd-d2841c896820",
          websiteUrl: "www.test-01.com",
          country: "Australia",
          currency: "AUD",
          discountPercentage: 10,
          isActive: true,
        },
        {
          uniqueId: "62178593-efbc-4ba2-9bbd-d2841c896821",
          websiteUrl: "www.test-02.com",
          country: "America",
          currency: "USD",
          discountPercentage: 20,
          isActive: false,
        },
      ],
      onDelete: jest.fn(),
    };

    render(
      <MemoryRouter>
        <MerchantList {...props} />
      </MemoryRouter>,
      container
    );

    const tableRows = container.querySelectorAll("tr");
    expect(tableRows.length).toBe(3);

    expect(tableRows[1].querySelector("a").getAttribute("href")).toEqual(
      "/merchant/62178593-efbc-4ba2-9bbd-d2841c896820"
    );

    expect(tableRows[2].querySelector("a").getAttribute("href")).toEqual(
      "/merchant/62178593-efbc-4ba2-9bbd-d2841c896821"
    );
  });
});
