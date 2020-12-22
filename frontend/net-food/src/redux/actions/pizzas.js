import axios from "axios";
import { setLoaded } from "../reducers/pizzas";
import { clearCart } from "./cart";

export const fetchPizzas = (category, sortBy) => (dispatch) => {
  dispatch(setLoaded(false));
  axios
    .get(
      `https://localhost:44345/api/` + category
    )
    .then(({ data }) => {
      dispatch(setPizzas(data));
    });
};

export const addPizzaSize = (category, size) => (dispatch) => {
  axios.post(`https://localhost:44345/api/pizzasizes`, size);
  setTimeout(() => dispatch(fetchPizzas(category, "name")), 500);
};

export const editPizzaSize = (category, size) => (dispatch) => {
  axios.put(`https://localhost:44345/api/pizzasizes/${size.id}`, size);
  setTimeout(() => dispatch(fetchPizzas(category, "name")), 500);
};

export const deletePizzaSize = (category, id) => (dispatch) => {
  axios.delete(`https://localhost:44345/api/pizzasizes/${id}`);
  setTimeout(() => dispatch(fetchPizzas(category, "name")), 500);
};

export const addPizzaDoughType = (category, doughType) => (dispatch) => {
  axios.post(`https://localhost:44345/api/pizzadoughtypes`, doughType);
  setTimeout(() => dispatch(fetchPizzas(category, "name")), 500);
};

export const editPizzaDoughType = (category, doughType) => (dispatch) => {
  axios.put(`https://localhost:44345/api/pizzadoughtypes/${doughType.id}`, doughType);
  setTimeout(() => dispatch(fetchPizzas(category, "name")), 500);
};

export const deletePizzaDoughType = (category, id) => (dispatch) => {
  axios.delete(`https://localhost:44345/api/pizzadoughtypes/${id}`);
  setTimeout(() => dispatch(fetchPizzas(category, "name")), 500);
};

export const deleteItem = (category, id) => (dispatch) => {
  axios.delete(`https://localhost:44345/api/` + category + '/' + id);
  setTimeout(() => dispatch(fetchPizzas(category, "name")), 500);
};

export const addItem = (category, item) => (dispatch) => {
  axios.post(`https://localhost:44345/api/` + category, item);
  setTimeout(() => dispatch(fetchPizzas(category, "name")), 500);
};

export const editItem = (category, item, id) => (dispatch) => {
  axios.put(`https://localhost:44345/api/` + category + '/' + id, item);
  setTimeout(() => dispatch(fetchPizzas(category, "name")), 500);
};

function addPizzaSizes(pizzaId, sizes) {
  for (var i = 0; i < sizes.length; i++) {
    sizes[i].pizza = pizzaId;
    console.log(sizes[i]);
    axios.post(`https://localhost:44345/api/pizzaSizes/`, sizes[i]);
  }
}

function addPizzaDoughTypes(pizzaId, doughTypes) {
  for (var i = 0; i < doughTypes.length; i++) {
    doughTypes[i].pizza = pizzaId;
    axios.post(`https://localhost:44345/api/pizzaDoughTypes/`, doughTypes[i]);
  }
};

export const addPizza = (category, pizza, sizes, doughTypes) => (dispatch) => {
  axios.post(`https://localhost:44345/api/pizzas/`, pizza).then((response) => {
    addPizzaSizes(response.data.id, sizes);
    addPizzaDoughTypes(response.data.id, doughTypes);
  });
  setTimeout(() => dispatch(fetchPizzas(category, "name")), 500);
}

export const orderPizza = (orderId, pizzaOrderId, amount) => (dispatch) => {
  axios.post(`https://localhost:44345/api/orderItems/`,
    {
      orderId: orderId,
      categoryId: 1,
      productId: pizzaOrderId,
      Amount: amount
    });
}

export const orderItems = (orderId, orderProducts) => (dispatch) => {
  for (var key in orderProducts) {
    if (orderProducts[key].items[0].categoryId === 1) {
      console.log(orderProducts[key]);
      var pizzaOrder = {
        PizzaId: orderProducts[key].items[0].id,
        PizzaSizeId: orderProducts[key].items[0].size.id,
        PizzaDoughTypeId: orderProducts[key].items[0].type.id,
        categoryId: 1
      };
      console.log(pizzaOrder);
      // eslint-disable-next-line no-loop-func
      axios.post(`https://localhost:44345/api/pizzaOrders/`, pizzaOrder).then((response) => {
        dispatch(orderPizza(orderId, response.data.id, orderProducts[key].items.length));
      });
    } else {
      axios.post(`https://localhost:44345/api/orderItems/`,
        {
          orderId: orderId,
          categoryId: orderProducts[key].items[0].categoryId,
          productId: orderProducts[key].items[0].id,
          Amount: orderProducts[key].items.length
        })
    }
  }
}

export const makeOrder = (orderData, orderProducts) => (dispatch) => {
  axios.post(`https://localhost:44345/api/orders/`, orderData).then((response) => {
    dispatch(orderItems(response.data.id, orderProducts));
  });
  dispatch(clearCart());
};

export const setPizzas = (items) => ({
  type: "SET_PIZZAS",
  payload: items,
});

