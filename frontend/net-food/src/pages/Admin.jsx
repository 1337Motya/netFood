import React from "react";
import {
  Categories,
  PizzaEditBlock,
  PizzaAddBlock,
  LoadingBlock,
  SnackEditBlock,
  DrinkEditBlock,
  DessertEditBlock,
  ItemAddBlock,
  DrinkAddBlock,
  OrderBlock,
  Login
} from "../components";
import { useSelector, useDispatch } from "react-redux";
import { setCategory } from "../redux/actions/filters";
import {
  fetchPizzas,
  deleteItem,
  addItem,
  editItem,
  addPizzaDoughType,
  addPizzaSize,
  editPizzaDoughType,
  editPizzaSize,
  deletePizzaDoughType,
  deletePizzaSize,
  addPizza
} from "../redux/actions/pizzas";

function Admin() {
  const dispatch = useDispatch();
  const items = useSelector(({ pizzas }) => pizzas.items);
  const isLoaded = useSelector(({ pizzas }) => pizzas.isLoaded);
  const { category, sortBy } = useSelector(({ filters }) => filters);
  const [isLogged, setLogged] = React.useState(false);

  React.useEffect(() => {
    dispatch(fetchPizzas(category, sortBy));
  }, [category, dispatch, sortBy]);

  const onSelectCategory = (index) => {
    dispatch(setCategory(index));
  };

  const deleteI = (category, id) => {
    dispatch(deleteItem(category, id));
  };

  const addI = (category, item) => {
    dispatch(addItem(category, item));
  };

  const editI = (category, item, id) => {
    dispatch(editItem(category, item, id));
  };

  const addSize = (category, item) => {
    dispatch(addPizzaSize(category, item));
  }

  const addDough = (category, item) => {
    dispatch(addPizzaDoughType(category, item));
  }

  const editSize = (category, item) => {
    dispatch(editPizzaSize(category, item));
  };

  const editDough = (category, item) => {
    dispatch(editPizzaDoughType(category, item));
  };

  const deleteSize = (category, id) => {
    dispatch(deletePizzaSize(category, id));
  };

  const deleteDough = (category, id) => {
    dispatch(deletePizzaDoughType(category, id));
  };

  const addNewPizza = (category, pizza, sizes, doughTypes) => {
    dispatch(addPizza(category, pizza, sizes, doughTypes));
  };

  const login = () => {
    setLogged(isLoaded);
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
            Здесь пока ничего нет <span role="img" aria-label="smile">🙃</span>
          </h2>
          <p>Но очень скоро появится</p>
          {/* <img src={emptyCartImage} alt="Empty cart" /> */}
        </div>
      );
    }

    switch (category) {
      case "pizzas":
        return <div className="content__items">
          {items.map((obj) => (
            <PizzaEditBlock
              onEdit={editI}
              onDelete={deleteI}
              key={obj.id}
              onEditSize={editSize}
              onAddSize={addSize}
              onDeleteSize={deleteSize}
              onEditDough={editDough}
              onAddDough={addDough}
              onDeleteDough={deleteDough}
              {...obj} />
          ))}
          <PizzaAddBlock category={category} addPizza={addNewPizza} />
        </div>
      case "snacks":
        return <div className="content__items">
          {items.map((obj) => (
            <SnackEditBlock onEdit={editI} onDelete={deleteI} key={obj.id} {...obj} />
          ))}
          <ItemAddBlock categoryId={3} category={category} addItem={addI} />
        </div>
      case "drinks":
        return <div className="content__items">
          {items.map((obj) => (
            <DrinkEditBlock onEdit={editI} onDelete={deleteI} key={obj.id} {...obj} />
          ))}
          <DrinkAddBlock category={category} addItem={addI} />
        </div>
      case "desserts":
        return <div className="content__items">
          {items.map((obj) => (
            <DessertEditBlock onEdit={editI} onDelete={deleteI} key={obj.id} {...obj} />
          ))}
          <ItemAddBlock categoryId={4} category={category} addItem={addI} />
        </div>
      case "orders":
        return <div>
          {items.map((obj) => (
            <OrderBlock key={obj.id === undefined ? obj.order.id : obj.id} {...obj} />
          ))}
        </div>
      default:
        return <h2>Не реализовано</h2>
    }
  }

  
  return (
    <div className="container">
      {isLogged ? (
        <div>
          <Categories
            activeCategory={category}
            onClickCategory={onSelectCategory}
            items={[
              { name: "Пицца", apiname: "pizzas" },
              { name: "Закуски", apiname: "snacks" },
              { name: "Десерты", apiname: "desserts" },
              { name: "Напитки", apiname: "drinks" },
              // { name: "наборы", apiname: "bundles" },
              { name: "Заказы", apiname: "orders" }
            ]}
          />
          {handleCategory(category, items)}
        </div>
      ) : (<Login setLogged={login} />)}
    </div>
  );
}

export default Admin;
