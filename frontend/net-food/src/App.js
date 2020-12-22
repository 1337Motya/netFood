import React from "react";
import { Route } from "react-router-dom";

import { Header } from "./components";
import { Home, Cart, Admin, Order } from "./pages";

function App() {
  return (
    <div className="wrapper">
      <Header />
      <div className="content">
        <Route path="/" component={Home} exact />
        <Route path="/cart" component={Cart} exact />
        <Route path="/order" component={Order} exact />
        <Route path="/admin" component={Admin} exact />
      </div>
    </div>
  );
}

export default App;
