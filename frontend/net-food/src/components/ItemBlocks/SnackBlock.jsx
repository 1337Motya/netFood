import React from "react";
import PropTypes from "prop-types";
import Button from "../Button";
import { ReactComponent as PlusIcon } from '../../assets/img/plus.svg'

function SnackBlock({
  id,
  name,
  categoryId,
  description,
  imageUrl,
  onClickAddPizza,
  price,
}) {

  const onAddPizza = () => {
    const obj = {
      cartId: `${id}_${categoryId}`,
      id,
      name,
      categoryId,
      imageUrl,
      price: price,
    };
    onClickAddPizza(obj);
  };

  return (
    <div className="pizza-block">
      <img className="pizza-block__image" src={imageUrl} alt="Pizza" />
      <h4 className="pizza-block__title">{name}</h4>
      <span className="pizza-block__description">{description}</span>
      <div className="pizza-block__bottom">
        <div className="pizza-block__price">{price} р.</div>
        <Button onClick={onAddPizza} className="button--add" outline>
          <PlusIcon />
          <span>Добавить</span>
        </Button>
      </div>
    </div>
  );
}

SnackBlock.propTypes = {
  name: PropTypes.string,
  imageUrl: PropTypes.string,
  price: PropTypes.number,
  onClickAddPizza: PropTypes.func,
  addedAmount: PropTypes.number,
};

SnackBlock.defaultProps = {
  name: "Название закуски",
  price: 0,
  imageUrl: "",
};

export default SnackBlock;
