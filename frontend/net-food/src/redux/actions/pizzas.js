import axios from "axios";
import { setLoaded } from "../reducers/pizzas";

export const fetchPizzas = (category, sortBy) => (dispatch) => {
  dispatch(setLoaded(false));
  axios
    .get(
      `https://localhost:44345/api/pizzas`
    )
    .then(({ data }) => {
      console.log(data);
      dispatch(setPizzas(data));
    });
};

export const setPizzas = (items) => ({
  type: "SET_PIZZAS",
  payload: items,
});

