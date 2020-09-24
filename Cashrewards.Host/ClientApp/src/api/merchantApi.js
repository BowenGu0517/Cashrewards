import { handleResponse, handleError } from "./apiUtils";

const baseUrl = "api/merchants/";

export const getMerchants = () => {
  const options = {
    method: "GET",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json;charset=UTF-8",
    },
  };

  return fetch(baseUrl, options).then(handleResponse).catch(handleError);
};

export const getMerchant = (uniqueId) => {
  const options = {
    method: "GET",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json;charset=UTF-8",
    },
  };

  return fetch(`${baseUrl}${uniqueId}`, options)
    .then(handleResponse)
    .catch(handleError);
};

export const createMerchant = (body) => {
  const options = {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json;charset=UTF-8",
    },
    body: { ...body },
  };

  return fetch(baseUrl, options).then(handleResponse).catch(handleError);
};

export const updateMerchant = (body) => {
  const options = {
    method: "PUT",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json;charset=UTF-8",
    },
    body: { ...body },
  };

  return fetch(baseUrl, options).then(handleResponse).catch(handleError);
};

export const deleteMerchant = (uniqueId) => {
  const options = {
    method: "DELETE",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json;charset=UTF-8",
    },
  };

  return fetch(`${baseUrl}${uniqueId}`, options)
    .then(handleResponse)
    .catch(handleError);
};
