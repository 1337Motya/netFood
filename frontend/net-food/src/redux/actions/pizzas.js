import axios from "axios";
import { setLoaded } from "../reducers/pizzas";

export const fetchPizzas = (category, sortBy) => (dispatch) => {
  console.log("перезагрузка");
  dispatch(setLoaded(false));
  axios
    .get(
      `https://localhost:44345/api/` + category
    )
    .then(({ data }) => {
      dispatch(setPizzas(data));
    });
};

export const deleteItem = (category, id) => (dispatch) => {
  axios.delete(`https://localhost:44345/api/` + category + '/' + id);
  setTimeout(() => dispatch(fetchPizzas(category, "name")), 500);
};

export const setPizzas = (items) => ({
  type: "SET_PIZZAS",
  payload: items,
});

