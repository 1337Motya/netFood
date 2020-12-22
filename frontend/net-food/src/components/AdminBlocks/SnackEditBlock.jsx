import React from "react";
import PropTypes from "prop-types";
import Button from "../Button";
import { ReactComponent as PlusIcon } from '../../assets/img/plus.svg'

function SnackBlock({
  id,
  name,
  categoryId,
  onDelete,
  onEdit,
  description,
  imageUrl,
  price,
}) {
  const [nameEdit, setName] = React.useState(name);
  const [descriptionEdit, setDescription] = React.useState(description);
  const [imageUrlEdit, setImageUrl] = React.useState(imageUrl);
  const [priceEdit, setPrice] = React.useState(price);

  const deleteSnack = () => {
    onDelete("snacks", id);
  };

  const handleSubmit = () => {
    var newItem = {
      id: id,
      name: nameEdit,
      description: descriptionEdit,
      ImageUrl: imageUrl,
      price: priceEdit,
    }
    onEdit("snacks", newItem, id);
  };

  return (
    <div className="pizza-block">
      <div className="cart__item-remove">
        <Button onClick={deleteSnack} className="button button--outline button--circle">
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
      <div className="pizza-block__bottom">
        <div className="pizza-block__price">
          <input placeholder="0.0" className="item-edit-input input-price-edit" type="text" value={priceEdit} onChange={(e) => setPrice(e.target.value)} /> р.
        </div>
        <Button onClick={handleSubmit} className="button--add" outline>
          <span>Сохранить</span>
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
