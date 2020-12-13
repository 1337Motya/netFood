import React from "react";
import {
  Categories,
  SortPopup,
  PizzaBlock,
  LoadingBlock,
  SnackBlock,
  DrinkBlock,
  DessertBlock,
} from "../components";
import { useSelector, useDispatch } from "react-redux";
import { setCategory, setSortBy } from "../redux/actions/filters";
import { fetchPizzas } from "../redux/actions/pizzas";
import { addPizzaToCart } from "../redux/actions/cart";

function Home() {
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

  const onSelectSortType = (type) => {
    dispatch(setSortBy(type));
  };

  const addPizza = (obj) => {
    dispatch(addPizzaToCart(obj));
  };

  function handleCategory(category, items) {
    if (!isLoaded) {
      return Array(items.length)
        .fill(0)
        .map((_, index) => <LoadingBlock key={index} />);
    }
    if (items.length === 0) {
      return <div className="cart cart--empty">
      <h2>
        Здесь пока ничего нет <i>🙃</i>
      </h2>
      <p>
        Но очень скоро появится
      </p>
      {/* <img src={emptyCartImage} alt="Empty cart" /> */}
    </div>
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
          <SnackBlock
            onClickAddPizza={addPizza}
            key={obj.id}
            {...obj}
          />
        ));
      case "drinks":
        return items.map((obj) => (
          <DrinkBlock
            onClickAddPizza={addPizza}
            key={obj.id}
            {...obj}
          />
        ));
      case "desserts":
        return items.map((obj) => (
          <DessertBlock
            onClickAddPizza={addPizza}
            key={obj.id}
            {...obj}
          />
        ));
    }
  }

  return (
    <div className="container">
      <div className="content__top">
        <Categories
          activeCategory={category}
          onClickCategory={onSelectCategory}
          items={[
            { name: "Пицца", apiname: "pizzas" },
            { name: "Закуски", apiname: "snacks" },
            { name: "Десерты", apiname: "desserts" },
            { name: "Напитки", apiname: "drinks" },
            { name: "Комбо", apiname: "bundles" },
          ]}
        />
        <SortPopup
          onClickSort={onSelectSortType}
          sortType={sortBy.type}
          items={[
            { name: "алфавиту", type: "name", order: "asc" },
            { name: "цене", type: "price", order: "desc" }
          ]}
        />
      </div>
      <div className="content__items">{handleCategory(category, items)}</div>
    </div>
  );
}

export default Home;
