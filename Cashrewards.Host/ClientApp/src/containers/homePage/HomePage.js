import React, { useState, useEffect } from "react";
import MerchantList from "../../components/merchantList/MerchantList";
import { getMerchants } from "../../api/merchantApi";

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

  return (
    <>
      <h2>Merchants</h2>
      <MerchantList merchants={merchants} />
    </>
  );
};

export default HomePage;
