import React from "react";
import PropTypes from "prop-types";
import {OrderItem} from "../../components"


function OrderBlock({ order, products }) {

  return (
    <div className="order">
      <h2>Заказ №{order.id}</h2>
      <div className="order__info">
        <div>Адрес доставки: {order.address}</div>
        <div>Телефон: {order.phoneNumber}</div>
        <div>Оплата наличными: да</div>
        <div>Сумма заказа: {order.orderSum} р.</div>
      </div>
      <div className="order__items">
        {products.map((obj) => (
          <OrderItem key={`${obj.id}_${obj.categoryId}`} {...obj} />
        ))}
      </div>
    </div>
  );
}

OrderBlock.propTypes = {
  order: PropTypes.object,
  products: PropTypes.array
};

OrderBlock.defaultProps = {
  order: {
    id: 0,
    address: "адрес",
    сashPayment: true,
    orderSum: 0,
    orderDate: "2020-12-15T00:00:00",
    phoneNumber: "+375(29)6915517"
  },
  products: [{
    id: 0,
    name: "название",
    description: "описание",
    categoryId: 1,
    price: 0,
    imageUrl: "ссылка"
  }]
};

export default OrderBlock;
