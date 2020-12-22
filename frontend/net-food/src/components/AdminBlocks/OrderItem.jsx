import React from "react";

function OrderItem({
  id,
  volume,
  name,
  imageUrl,
  doughType,
  size,
  amount,
  categoryId
}) {
  
  const handleDescription = () => {
    switch(categoryId) {
      case 1:
      return (
        <p>
          {doughType} тесто, {size} см.
        </p>
      );
     case 2:
      return (
        <p>
          {volume} л.
        </p>
      );
      default:
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
        <b>{amount} шт.</b> 
      </div>
    </div>
  );
}

export default OrderItem;
