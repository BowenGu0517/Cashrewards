import React, { useState, useEffect } from "react";
import MerchantForm from "../../components/merchantForm/MerchantForm";
import { getMerchant } from "../../api/merchantApi";
import { countryOptions, currencyOptions } from "../../common/constant";

const ManageMerchantPage = (props) => {
  const [merchant, setMerchant] = useState({
    uniqueId: null,
    websiteUrl: "",
    country: "",
    currency: "",
    discountPercentage: 0,
    isActive: true,
    options: {
      countryOptions: [...countryOptions],
      currencyOptions: [...currencyOptions],
    },
  });
  const [errors, setErrors] = useState({
    websiteUrl: "",
    country: "",
    currency: "",
    discountPercentage: "",
  });

  useEffect(() => {
    const uniqueId = props.match.params.uniqueId;
    if (uniqueId) {
      getMerchant(uniqueId)
        .then((merchantData) => {
          setMerchant({
            ...merchant,
            ...merchantData,
          });
        })
        .catch((error) => {
          console.log(error);
        });
    }
  }, [props.match.params.uniqueId]);

  const handleOnChange = ({ target }) => {
    setMerchant({
      ...merchant,
      [target.name]: target.type === "checkbox" ? target.checked : target.value,
    });
  };

  const handleOnSubmit = (e) => {
    e.preventDefault();
    window.alert("Submit!");
  };

  return (
    <>
      <h2>Merchant</h2>
      <MerchantForm
        merchant={merchant}
        errors={errors}
        onChange={handleOnChange}
        onSubmit={handleOnSubmit}
      />
    </>
  );
};

export default ManageMerchantPage;
