import React from "react";
import classNames from "classnames";
import Button from "../Button";

function PizzaEditBlock({
  id,
  name,
  categoryId,
  description,
  imageUrl,
  onDelete,
  pizzaDoughTypes,
  pizzaSizes
}) {

  console.log(pizzaDoughTypes);
  const availableTypes = pizzaDoughTypes.map(types => types.doughType);
  console.log(pizzaSizes);
  const availableSizes = pizzaSizes.map(sizes => sizes.size);
  const prices = pizzaSizes.map(sizes => sizes.price);
  const [activeType, setActiveType] = React.useState(0);
  const [activeSize, setActiveSize] = React.useState(0);

  const onSelectType = (index) => {
    setActiveType(index);
  };

  const onSelectSize = (index) => {
    setActiveSize(index);
  };

  const deletePizza = () => {
    onDelete("pizzas", id);
  };

  return (
    <div className="pizza-block">
      <div className="cart__item-remove">
        <Button
          onClick={deletePizza}
          className="button button--outline button--circle"
        >
          <svg
            width="10"
            height="10"
            viewBox="0 0 10 10"
            fill="none"
            xmlns="http://www.w3.org/2000/svg"
          >
            <path
              d="M5.92001 3.84V5.76V8.64C5.92001 9.17016 5.49017 9.6 4.96001 9.6C4.42985 9.6 4.00001 9.17016 4.00001 8.64L4 5.76L4.00001 3.84V0.96C4.00001 0.42984 4.42985 0 4.96001 0C5.49017 0 5.92001 0.42984 5.92001 0.96V3.84Z"
              fill="#EB5A1E"
            />
            <path
              d="M5.75998 5.92001L3.83998 5.92001L0.959977 5.92001C0.429817 5.92001 -2.29533e-05 5.49017 -2.29301e-05 4.96001C-2.2907e-05 4.42985 0.429817 4.00001 0.959977 4.00001L3.83998 4L5.75998 4.00001L8.63998 4.00001C9.17014 4.00001 9.59998 4.42985 9.59998 4.96001C9.59998 5.49017 9.17014 5.92001 8.63998 5.92001L5.75998 5.92001Z"
              fill="#EB5A1E"
            />
          </svg>
        </Button>
      </div>
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
        <Button className="button--add" outline>
          <span>Сохранить</span>
        </Button>
      </div>
    </div>
  );
}

export default PizzaEditBlock;
