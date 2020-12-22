import React from "react";
import classNames from "classnames";
import PropTypes from "prop-types";
import Button from "../Button";
import {ReactComponent as PlusIcon} from '../../assets/img/plus.svg'

function PizzaBlock({
  id,
  name,
  description,
  imageUrl,
  onClickAddPizza,
  pizzaDoughTypes,
  pizzaSizes
}) {

  const availableTypes = pizzaDoughTypes.map(types => types.doughType);
  const availableSizes = pizzaSizes.sort((a, b) => a.size > b.size ? 1 : -1).map(sizes => sizes.size);
  const prices = pizzaSizes.map(sizes => sizes.price);
  const [activeType, setActiveType] = React.useState(0);
  const [activeSize, setActiveSize] = React.useState(0);

  const onSelectType = (index) => {
    setActiveType(index);
  };

  const onSelectSize = (index) => {
    setActiveSize(index);
  };

  const onAddPizza = () => {
    const obj = {
      cartId: `${id}_${1}_${availableSizes[activeSize]}_${availableTypes[activeType]}`,
      id,
      name,
      categoryId: 1,
      imageUrl,
      price: prices[activeSize],
      size: pizzaSizes[activeSize],
      type: pizzaDoughTypes[activeType],
    };
    onClickAddPizza(obj);
  };

  return (
    <div className="pizza-block">
      <img className="pizza-block__image" src={imageUrl} alt="Pizza" />
      <h4 className="pizza-block__title">{name}</h4>
      <span className="pizza-block__description">{description}</span>
      <div className="pizza-block__selector">
        <ul>
          {availableTypes.map((type, index) => (
            <li
              key={type}
              onClick={() => onSelectType(index)}
              className={classNames({
                active: activeType === index
              })}
            >
              {type}
            </li>
          ))}
        </ul>
        <ul>
          {availableSizes.map((size, index) => (
            <li
              key={size}
              onClick={() => onSelectSize(index)}
              className={classNames({
                active: activeSize === index
              })}
            >
              {size} см.
            </li>
          ))}
        </ul>
      </div>
      <div className="pizza-block__bottom">
        <div className="pizza-block__price">{prices[activeSize]} р.</div>
        <Button onClick={onAddPizza} className="button--add" outline>
          <PlusIcon />
          <span>Добавить</span>
        </Button>
      </div>
    </div>
  );
}

PizzaBlock.propTypes = {
  name: PropTypes.string,
  imageUrl: PropTypes.string,
  types: PropTypes.arrayOf(PropTypes.number),
  sizes: PropTypes.arrayOf(PropTypes.number),
  onClickAddPizza: PropTypes.func,
  addedAmount: PropTypes.number,
};

PizzaBlock.defaultProps = {
  name: "Название пиццы",
  imageUrl: "",
  pizzaDoughTypes: [],
  pizzaSizes: [],
};

export default PizzaBlock;
