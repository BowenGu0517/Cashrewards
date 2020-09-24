import React from "react";
import { Link } from "react-router-dom";

const MerchantList = (props) => {
  return (
    <table className="table">
      <thead>
        <tr>
          <th>Website Url</th>
          <th>Country</th>
          <th>Currency</th>
          <th>Discount Percentage</th>
          <th>Status</th>
          <th></th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {props.merchants.map((merchant) => {
          return (
            <tr key={merchant.uniqueId}>
              <td>{merchant.websiteUrl}</td>
              <td>{merchant.country}</td>
              <td>{merchant.currency}</td>
              <td>{merchant.discountPercentage}</td>
              <td>{merchant.isActive ? "Active" : "Inactive"}</td>
              <td>
                <Link to={"/merchant/" + merchant.uniqueId}>Edit</Link>
              </td>
              <td>
                <button>Delete</button>
              </td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
};

export default MerchantList;
