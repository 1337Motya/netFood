import React from "react";
import { CartItem } from "../components";
import { useDispatch, useSelector } from "react-redux";
import {
  clearCart,
  removeCartItem,
  incCartItemAmount,
  decCartItemAmount,
} from "../redux/actions/cart";
import emptyCartImage from "../assets/img/empty-cart.png";
import { ReactComponent as CartIcon } from "../assets/img/cart.svg";
import { ReactComponent as TrashIcon } from "../assets/img/trash.svg";
import { ReactComponent as LeftArrowIcon } from "../assets/img/grey-arrow-left.svg";
import { Link } from "react-router-dom";

function Cart() {
  const dispatch = useDispatch();
  const { items, totalPrice, totalCount } = useSelector(({ cart }) => cart);

  const addedPizzas = Object.keys(items).map((key) => {
    return items[key].items[0];
  });

  const onClearCart = () => {
    dispatch(clearCart());
  };

  const onRemoveItem = (id) => {
    dispatch(removeCartItem(id));
  };

  const onIncItem = (id) => {
    dispatch(incCartItemAmount(id));
  };

  const onDecItem = (id) => {
    dispatch(decCartItemAmount(id));
  };



  return (
    <div className="container container--cart">
      {totalCount ? (
        <div>
          <div className="cart">
            <div className="cart__top">
              <h2 className="content__title">
                <CartIcon />
                Корзина
              </h2>
              <div className="cart__clear">
                <TrashIcon />
                <span onClick={onClearCart}>Очистить корзину</span>
              </div>
            </div>
            <div className="content__items">
              {addedPizzas.map((obj) => (
                <CartItem
                  key={obj.cartId}
                  totalPrice={items[obj.cartId].totalPrice}
                  totalCount={items[obj.cartId].items.length}
                  onRemove={onRemoveItem}
                  onInc={onIncItem}
                  onDec={onDecItem}
                  {...obj}
                />
              ))}
            </div>
          </div>
          <div className="cart__bottom">
            <div className="cart__bottom-details">
              <span>
                Всего позиций: <b>{totalCount} шт.</b>
              </span>
              <span>
                Сумма заказа: <b>{totalPrice.toFixed(2)} р.</b>
              </span>
            </div>
            <div className="cart__bottom-buttons">
              <Link
                to="/"
                className="button button--outline button--add go-back-btn"
              >
                <LeftArrowIcon />
                <span>Вернуться назад</span>
              </Link>
              <Link className="button pay-btn" to="Order">Оформить заказ</Link>
            </div>
          </div>
        </div>
      ) : (
          <div className="cart cart--empty">
            <h2>
              Корзина пустая <span role="img" aria-label="smile">😕</span>
            </h2>
            <p>
              Вероятней всего, вы не заказывали ещё пиццу.
            <br />
            Для того, чтобы заказать пиццу, перейди на главную страницу.
          </p>
            <img src={emptyCartImage} alt="Empty cart" />
            <Link to="/" className="button button--black">
              <span>Вернуться назад</span>
            </Link>
          </div>
        )}
    </div>
  );
}

export default Cart;
