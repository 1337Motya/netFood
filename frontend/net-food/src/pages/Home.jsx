import React from "react";
import { Categories, SortPopup, PizzaBlock, LoadingBlock } from "../components";
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

  return (
    <div className="container">
      <div className="content__top">
        <Categories
          activeCategory={category}
          onClickCategory={onSelectCategory}
          items={["Мясные", "Вегетринаские", "Гриль", "Острые"]}
        />
        <SortPopup
          onClickSort={onSelectSortType}
          sortType={sortBy.type}
          items={[
            { name: "популярности", type: "popular", order: "desc" },
            { name: "цене", type: "price", order: "desc" },
            { name: "алфавиту", type: "name", order: "asc" },
          ]}
        />
      </div>
      <h2 className="content__title">Все пиццы</h2>
      <div className="content__items">
        {isLoaded
          ? items &&
            items.map((obj) => (
              <PizzaBlock onClickAddPizza={addPizza} key={obj.id} addedAmount={cartItems[obj.id] && cartItems[obj.id].items.length} {...obj} />
            ))
          : Array(12)
              .fill(0)
              .map((_, index) => <LoadingBlock key={index} />)}
      </div>
    </div>
  );
}

export default Home;
