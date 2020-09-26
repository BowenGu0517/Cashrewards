import React, { useState, useEffect } from "react";
import MerchantForm from "../../components/merchantForm/MerchantForm";
import {
  getMerchant,
  createMerchant,
  updateMerchant,
} from "../../api/merchantApi";
import { countryOptions, currencyOptions } from "../../common/constant";
import styles from "./ManageMerchantPage.module.css";

const ManageMerchantPage = (props) => {
  const [merchant, setMerchant] = useState({
    uniqueId: null,
    websiteUrl: "",
    country: "",
    currency: "",
    discountPercentage: "",
    isActive: false,
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
            uniqueId: uniqueId,
          });
        })
        .catch((error) => {
          console.log(error);
        });
    }
  }, []);

  const handleOnChange = ({ target }) => {
    setMerchant({
      ...merchant,
      [target.name]: target.type === "checkbox" ? target.checked : target.value,
    });
  };

  const handleOnSubmit = (e) => {
    e.preventDefault();
    if (!isFormInvalid()) return;

    if (merchant.uniqueId) {
      updateMerchant({
        ...merchant,
        discountPercentage: parseFloat(merchant.discountPercentage),
      })
        .then(() => props.history.push("/"))
        .catch(() => window.alert("Failed at Update!!!"));
    } else {
      createMerchant({
        ...merchant,
        discountPercentage: parseFloat(merchant.discountPercentage),
      })
        .then(() => props.history.push("/"))
        .catch(() => window.alert("Failed at Create!!!"));
    }
  };

  const isFormInvalid = () => {
    const _errors = {};

    if (!merchant.websiteUrl) _errors.websiteUrl = "Website Url is required";
    if (!merchant.country) _errors.country = "Country is required";
    if (!merchant.currency) _errors.currency = "Currency is required";
    if (
      !merchant.discountPercentage ||
      isNaN(merchant.discountPercentage) ||
      merchant.discountPercentage < 0 ||
      merchant.discountPercentage > 100
    ) {
      _errors.discountPercentage =
        "Discount Pertentage must be between 0 and 100";
    }

    setErrors({
      ...errors,
      ..._errors,
    });

    return Object.keys(_errors).length === 0;
  };

  return (
    <div className={styles.container}>
      <div className={styles.header}>
        <h2>{`${merchant.uniqueId ? "Update" : "Create"} Merchant`}</h2>
      </div>
      <div>
        <MerchantForm
          merchant={merchant}
          errors={errors}
          onChange={handleOnChange}
          onSubmit={handleOnSubmit}
        />
      </div>
    </div>
  );
};

export default ManageMerchantPage;
