import React from "react";
import {
  Categories,
  PizzaBlock,
  LoadingBlock,
  SnackEditBlock,
  DrinkEditBlock,
  DessertEditBlock,
  SnackAddBlock,
} from "../components";
import { useSelector, useDispatch } from "react-redux";
import { setCategory, setSortBy } from "../redux/actions/filters";
import { fetchPizzas, deleteItem } from "../redux/actions/pizzas";
import { addPizzaToCart } from "../redux/actions/cart";

function Admin() {
  const dispatch = useDispatch();
  const items = useSelector(({ pizzas }) => pizzas.items);
  const cartItems = useSelector(({ cart }) => cart.items);
  const isLoaded = useSelector(({ pizzas }) => pizzas.isLoaded);
  const { category, sortBy } = useSelector(({ filters }) => filters);

  React.useEffect(() => {
    dispatch(fetchPizzas(category, sortBy));
  }, [category, sortBy]);

  const onSelectCategory = (index) => {
    dispatch(setCategory(index));
  };

  const addPizza = (obj) => {
    dispatch(addPizzaToCart(obj));
  };

  const deleteI = (category, id) => {
    dispatch(deleteItem(category, id));
  };


  function handleCategory(category, items) {
    if (!isLoaded) {
      return Array(items.length)
        .fill(0)
        .map((_, index) => <LoadingBlock key={index} />);
    }
    if (items.length === 0) {
      return (
        <div className="cart cart--empty">
          <h2>
            Здесь пока ничего нет <i>🙃</i>
          </h2>
          <p>Но очень скоро появится</p>
          {/* <img src={emptyCartImage} alt="Empty cart" /> */}
        </div>
      );
    }
    switch (category) {
      case "pizzas":
        return items.map((obj) => (
          <PizzaBlock
            onClickAddPizza={addPizza}
            key={obj.id}
            addedAmount={cartItems[obj.id] && cartItems[obj.id].items.length}
            {...obj}
          />
        ));
      case "snacks":
        return items.map((obj) => (
          <SnackEditBlock onDelete={deleteI} key={obj.id} {...obj} />
        ));
      case "drinks":
        return items.map((obj) => (
          <DrinkEditBlock onDelete={deleteI} key={obj.id} {...obj} />
        ));
      case "desserts":
        return items.map((obj) => (
          <DessertEditBlock onDelete={deleteI} key={obj.id} {...obj} />
        ));
    }
  }

  return (
    <div className="container">
      <Categories
        activeCategory={category}
        onClickCategory={onSelectCategory}
        items={[
          { name: "Пицца", apiname: "pizzas" },
          { name: "Закуски", apiname: "snacks" },
          { name: "Десерты", apiname: "desserts" },
          { name: "Напитки", apiname: "drinks" },
          { name: "наборы", apiname: "bundles" },
          { name: "Заказы", apiname: "orders" },
          { name: "Сотрудники", apiname: "users" },
        ]}
      />

      <div className="content__items">
        {handleCategory(category, items)}
      </div>
    </div>
  );
}

export default Admin;
