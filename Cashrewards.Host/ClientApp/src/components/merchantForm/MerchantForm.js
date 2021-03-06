import React from "react";
import { Link } from "react-router-dom";
import TextInput from "../textInput/TextInput";
import Select from "../select/Select";
import NumberInput from "../numberInput/NumberInput";

const MerchantForm = (props) => {
  return (
    <form onSubmit={props.onSubmit}>
      <TextInput
        id="websiteUrl"
        label="Website Url"
        name="websiteUrl"
        onChange={props.onChange}
        value={props.merchant.websiteUrl}
        error={props.errors.websiteUrl}
      />
      <Select
        id="country"
        label="Country"
        name="country"
        onChange={props.onChange}
        value={props.merchant.country}
        options={props.merchant.options.countryOptions}
        error={props.errors.country}
      />
      <Select
        id="currency"
        label="Currency"
        name="currency"
        onChange={props.onChange}
        value={props.merchant.currency}
        options={props.merchant.options.currencyOptions}
        error={props.errors.currency}
      />
      <NumberInput
        id="discountPercentage"
        label="Discount Percentage"
        name="discountPercentage"
        onChange={props.onChange}
        value={props.merchant.discountPercentage}
        error={props.errors.discountPercentage}
      />
      <div className="form-group">
        <label htmlFor="isActive">IsActive</label>
        <div className="field">
          <input
            id="isActive"
            type="checkbox"
            name="isActive"
            checked={props.merchant.isActive}
            onChange={props.onChange}
          />
        </div>
      </div>
      <input
        type="submit"
        value={props.merchant.uniqueId ? "Save" : "Add"}
        className="btn btn-primary"
      />
      <Link className="btn btn-secondary" style={{ marginLeft: "1rem" }} to="/">
        Cancel
      </Link>
    </form>
  );
};

export default MerchantForm;
