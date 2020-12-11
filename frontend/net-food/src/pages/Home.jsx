import React from "react";
import { Categories, SortPopup, PizzaBlock, LoadingBlock } from "../components";
import { useSelector, useDispatch } from "react-redux";
import { setCategory, setSortBy } from "../redux/actions/filters";
import { fetchPizzas } from "../redux/actions/pizzas";
import { addPizzaToCart } from "../redux/actions/cart";

import pizzas from "../redux/reducers/pizzas";

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

  console.log(category);


  return (
    <div className="container">
      <div className="content__top">
        <Categories
          activeCategory={category}
          onClickCategory={onSelectCategory}
          items={[{ name: "Пицца", apiname: "pizzas" }, { name: "Закуски", apiname: "snacks" },
          { name: "Десерты", apiname: "desserts" }, { name: "Напитки", apiname: "drinks" },
          { name: "Комбо", apiname: "bundles" }]}
        />
        {/* <SortPopup
          onClickSort={onSelectSortType}
          sortType={sortBy.type}
          items={[
            { name: "популярности", type: "popular", order: "desc" },
            { name: "цене", type: "price", order: "desc" },
            { name: "алфавиту", type: "name", order: "asc" },
          ]}
        /> */}
      </div>
      <div className="content__items">

        {
          isLoaded
            ? items &&
            items.map((obj) => (
              <PizzaBlock onClickAddPizza={addPizza} key={obj.id} addedAmount={cartItems[obj.id] && cartItems[obj.id].items.length} {...obj} />

            ))
            : Array(items.length)
              .fill(0)
              .map((_, index) => <LoadingBlock key={index} />)
        }
      </div>
    </div>
  );
}

export default Home;
