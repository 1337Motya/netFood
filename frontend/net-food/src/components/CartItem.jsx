import React from "react";
import Button from "./Button";
import { ReactComponent as MinusIcon } from '../assets/img/minus.svg'
import { ReactComponent as PlusIcon } from '../assets/img/plus.svg'

function CartItem({
  id,
  volume,
  cartId,
  name,
  imageUrl,
  type,
  size,
  totalPrice,
  totalCount,
  onRemove,
  onInc,
  onDec,
}) {
  const handleRemove = () => {
    onRemove(cartId);
  };

  const handleIncItem = () => {
    onInc(cartId);
  };

  const handleDecItem = () => {
    onDec(cartId);
  };

  const handleDescription = () => {
    if (size !== undefined && type !== undefined) {
      return (
        <p>
          {type.doughType} тесто, {size.size} см.
        </p>
      );
    } else if (volume !== undefined) {
      return (
        <p>
          {volume} л.
        </p>
      );
    }
  };

  return (
    <div className="cart__item">
      <div className="cart__item-img">
        <img className="pizza-block__image" src={imageUrl} alt="Pizza" />
      </div>
      <div className="cart__item-info">
        <h3>{name}</h3>
        {handleDescription()}
      </div>
      <div className="cart__item-count">
        <div
          onClick={handleDecItem}
          className="button button--outline button--circle cart__item-count-minus"
        >
          <MinusIcon />
        </div>
        <b>{totalCount}</b>
        <div
          onClick={handleIncItem}
          className="button button--outline button--circle cart__item-count-plus"
        >
          <PlusIcon />
        </div>
      </div>
      <div className="cart__item-price">
        <b>{totalPrice.toFixed(2)} р.</b>
      </div>
      <div className="cart__item-remove">
        <Button
          onClick={handleRemove}
          className="button button--outline button--circle"
        >
          <PlusIcon />
        </Button>
      </div>
    </div>
  );
}

export default CartItem;
