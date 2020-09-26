import React from "react";
import { Route, Switch } from "react-router-dom";
import Header from "../header/Header";
import HomePage from "../homePage/HomePage";
import ManageMerchantPage from "../manageMerchantPage/ManageMerchantPage";
import styles from "./App.module.css";

const App = () => {
  return (
    <div>
      <Header />
      <div className={styles.page}>
        <Switch>
          <Route exact path="/" component={HomePage} />
          <Route path="/merchant/:uniqueId" component={ManageMerchantPage} />
          <Route path="/merchant" component={ManageMerchantPage} />
        </Switch>
      </div>
    </div>
  );
};

export default App;
