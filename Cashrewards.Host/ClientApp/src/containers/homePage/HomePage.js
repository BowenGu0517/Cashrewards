import React, { useState, useEffect } from "react";
import MerchantList from "../../components/merchantList/MerchantList";
import { getMerchants, deleteMerchant } from "../../api/merchantApi";
import { Link } from "react-router-dom";
import styles from "./HomePage.module.css";

const HomePage = () => {
  const [merchants, setMerchants] = useState([]);

  useEffect(() => {
    getMerchants()
      .then((data) => {
        setMerchants(data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  const handleOnDelete = (uniqueId) => {
    deleteMerchant(uniqueId)
      .then(() => {
        setMerchants([
          ...merchants.filter((merchant) => merchant.uniqueId !== uniqueId),
        ]);
      })
      .catch(() => window.alert("Failed to delete!!!"));
  };

  return (
    <div className={styles.container}>
      <div className={styles.header}>
        <h2>Merchants</h2>
      </div>
      <div className={styles.create}>
        <Link className="btn btn-primary" to="/merchant">
          New Merchant
        </Link>
      </div>
      <div>
        <MerchantList merchants={merchants} onDelete={handleOnDelete} />
      </div>
    </div>
  );
};

export default HomePage;
