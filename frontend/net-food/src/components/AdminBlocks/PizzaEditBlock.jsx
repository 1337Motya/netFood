import React from "react";
import PropTypes from "prop-types";
import classNames from "classnames";
import Button from "../Button";
import { ReactComponent as PlusIcon } from '../../assets/img/plus.svg';
import { ReactComponent as MinusIcon } from '../../assets/img/minus.svg';
import {ReactComponent as ReplaceIcon} from '../../assets/img/replace.svg';

function PizzaEditBlock({
  id,
  name,
  categoryId,
  description,
  imageUrl,
  onDelete,
  onEdit,
  pizzaDoughTypes,
  pizzaSizes,
  onEditSize,
  onAddSize,
  onDeleteSize,
  onEditDough,
  onAddDough,
  onDeleteDough,
}) {
  pizzaSizes.sort((a, b) => a.size > b.size ? 1 : -1);
  const [nameEdit, setName] = React.useState(name);
  const [descriptionEdit, setDescription] = React.useState(description);
  const [imageUrlEdit, setImageUrl] = React.useState(imageUrl);
  const [newSize, addSize] = React.useState();
  const [newDoughType, setNewDoughType] = React.useState('');
  const [newSizePrice, addSizePrice] = React.useState();
  const [editSize, setEditSize] = React.useState(pizzaSizes[0].size);
  const [editSizePrice, setEditSizePrice] = React.useState(pizzaSizes[0].price);
  const [editDoughType, setEditDoughType] = React.useState(pizzaDoughTypes[0].doughType);
  const availableTypes = pizzaDoughTypes.map(types => types.doughType);
  const availableSizes = pizzaSizes.map(sizes => sizes.size);
  const [activeType, setActiveType] = React.useState(0);
  const [activeSize, setActiveSize] = React.useState(0);

  const onSelectType = (index) => {
    setActiveType(index);
    setEditDoughType(pizzaDoughTypes[index].doughType);
  };

  const onSelectSize = (index) => {
    setActiveSize(index);
    setEditSize(pizzaSizes[index].size);
    setEditSizePrice(pizzaSizes[index].price);
  };

  const deletePizza = () => {
    onDelete("pizzas", id);
  };

  const handleSubmit = () => {
    var newItem = {
      id: id,
      name: nameEdit,
      description: descriptionEdit,
      ImageUrl: imageUrl,
    };
    onEdit("pizzas", newItem, id);
  };

  const createPizzaSize = () => {
    var size = {
      pizza: id,
      size: newSize,
      price: newSizePrice
    };
    onAddSize("pizzas", size);
  };

  const createPizzaDough = () => {
    var type = {
      pizza: id,
      doughType: newDoughType,
    };
    onAddDough("pizzas", type);
  };


  const editPizzaSize = () => {
    var size = {
      id: pizzaSizes[activeSize].id,
      pizza: id,
      size: editSize,
      price: editSizePrice
    };
    onEditSize("pizzas", size);
  };

  const deletePizzaSize = () => {
    onDeleteSize("pizzas", pizzaSizes[activeSize].id);
  };

  const editPizzaDough = () => {
    var type = {
      id: pizzaDoughTypes[activeType].id,
      pizza: id,
      doughType: editDoughType,
    };
    onEditDough("pizzas", type);
  };

  const deletePizzaDough = () => {
    onDeleteDough("pizzas", pizzaDoughTypes[activeType].i);
  };

  return (
    <div className="pizza-block">
      <div className="cart__item-remove">
        <Button onClick={deletePizza}
          className="button button--outline button--circle"
        >
          <PlusIcon />
        </Button>
      </div>
      <img className="pizza-block__image" src={imageUrl} alt="Pizza" />
      <div className="link-block">
        <input type="text" className="item-input" placeholder="Название" value={imageUrlEdit} onChange={(e) => setImageUrl(e.target.value)} />
      </div>
      <div>
        <textarea className="item-edit-textarea textarea-name" placeholder="Имя" type="text" value={nameEdit} onChange={(e) => setName(e.target.value)} />
      </div>
      <div>
        <textarea className="item-edit-textarea textarea-description" placeholder="Описание" type="text" value={descriptionEdit} onChange={(e) => setDescription(e.target.value)} />
      </div>
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
      <h3>Редактироваь опции</h3>
      <div className="pizza-block__bottom">
      <div onClick={deletePizzaDough}
          className="button button--outline button--circle cart__item-count-minus"
        >
          <MinusIcon />
        </div>
        <input className="item-edit-input pizza-option-input" value={editDoughType} type="text" placeholder="тесто" onChange={(e) => setEditDoughType(e.target.value)} />
        <div onClick={editPizzaDough}
          className="button button--outline button--circle cart__item-count-plus"
        >
          <ReplaceIcon />
        </div>
      </div>
      <div className="pizza-block__bottom">
      <div onClick={deletePizzaSize}
          className="button button--outline button--circle cart__item-count-minus"
        >
          <MinusIcon />
        </div>
        <input className="item-edit-input input-size-edit" value={editSize} type="number" placeholder="0" onChange={(e) => setEditSize(e.target.value)} />
        <b>см.</b>
        <input className="item-edit-input input-size-edit" value={editSizePrice} type="number" placeholder="0" onChange={(e) => setEditSizePrice(e.target.value)} />
        <b>р.</b>
        <div onClick={editPizzaSize}
          className="button button--outline button--circle cart__item-count-plus"
        >
          <ReplaceIcon />
        </div>
      </div>
      <h3>Добавить опции</h3>
      <div className="pizza-block__bottom">
        <input className="item-edit-input pizza-option-input" value={newDoughType} type="text" placeholder="тесто" onChange={(e) => setNewDoughType(e.target.value)} />
        <div onClick={createPizzaDough}
          className="button button--outline button--circle cart__item-count-plus"
        >
          <PlusIcon />
        </div>
      </div>
      <div className="pizza-block__bottom">
        <input className="item-edit-input input-size-edit" value={newSize} type="number" placeholder="0" onChange={(e) => addSize(e.target.value)} />
        <b>см.</b>
        <input className="item-edit-input input-size-edit" value={newSizePrice} type="number" placeholder="0" onChange={(e) => addSizePrice(e.target.value)} />
        <b>р.</b>
        <div onClick={createPizzaSize}
          className="button button--outline button--circle cart__item-count-plus"
        >
          <PlusIcon />
        </div>
      </div>
      <div className="pizza-block__bottom">
        <div className="pizza-block__price"></div>
        <Button onClick={handleSubmit} className="button--add" outline>
          <span>Сохранить</span>
        </Button>
      </div>
    </div>
  );
}

PizzaEditBlock.propTypes = {
  name: PropTypes.string,
  imageUrl: PropTypes.string,
  types: PropTypes.arrayOf(PropTypes.number),
  sizes: PropTypes.arrayOf(PropTypes.number),
};

PizzaEditBlock.defaultProps = {
  name: "Название пиццы",
  imageUrl: "",
  pizzaDoughTypes: [{ id: 1, doughType: 'традиционное' }],
  pizzaSizes: [{ id: 1, size: 26, price: 14 }],
};

export default PizzaEditBlock;
