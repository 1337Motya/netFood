import React from "react";
import { Link } from "react-router-dom";
import logo from "../assets/img/pizza-logo.svg";
import {ReactComponent as CartLogo} from "../assets/img/cart.svg";

import Button from "./Button";
import { useSelector } from "react-redux";

function Header() {
  const {totalPrice, totalCount} = useSelector(({cart}) => cart);

  return (
    <div className="header">
      <div className="container">
        <Link to="/">
          <div className="header__logo">
            <img width="38" src={logo} alt="Pizza logo" />
            <div>
              <h1>NetFood</h1>
              <p>самая вкусная пицца во вселенной</p>
            </div>
          </div>
        </Link>

        <div className="header__cart">
          <Link to="/cart">
            <Button className="button--cart">
              <span>{totalPrice.toFixed(2)} р.</span>
              <div className="button__delimiter"></div>
              <CartLogo />
              <span>{totalCount}</span>
            </Button>
          </Link>
        </div>
      </div>
    </div>
  );
}

export default Header;
