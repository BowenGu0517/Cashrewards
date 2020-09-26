import React from "react";
import { Link } from "react-router-dom";
import styles from "./MerchantList.module.css";

const MerchantList = (props) => {
  return (
    <div className={styles.container}>
      <table className="table">
        <thead>
          <tr>
            <th>Website Url</th>
            <th>Country</th>
            <th>Currency</th>
            <th>Discount Percentage</th>
            <th>Status</th>
            <th>Edit</th>
            <th>Delete</th>
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
                  <Link
                    className="btn btn-primary"
                    to={"/merchant/" + merchant.uniqueId}
                  >
                    Edit
                  </Link>
                </td>
                <td>
                  <button
                    className="btn btn-secondary"
                    onClick={() => {
                      props.onDelete(merchant.uniqueId);
                    }}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            );
          })}
        </tbody>
      </table>
    </div>
  );
};

export default MerchantList;
