export const addPizzaToCart = (pizza) => ({
  type: "ADD_PIZZA_CART",
  payload: pizza,
});

export const clearCart = () => ({
  type: "CLEAR_CART",
});

export const removeCartItem = (id) => ({
  type: "REMOVE_CART_ITEM",
  payload: id,
});


export const incCartItemAmount = (id) => ({
  type: "INC_CART_ITEM_AMOUNT",
  payload: id,
});

export const decCartItemAmount = (id) => ({
  type: "DEC_CART_ITEM_AMOUNT",
  payload: id,
});

