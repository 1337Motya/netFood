import React from "react";
import Button from "../Button";
import addImage from "../../assets/img/addItem.png"
import { ReactComponent as PlusIcon } from '../../assets/img/plus.svg'

function DrinkAddBlock({ category, addItem }) {
  const [name, setName] = React.useState('');
  const [description, setDescription] = React.useState('');
  const [imageUrl, setImageUrl] = React.useState('');
  const [price, setPrice] = React.useState('');
  const [volume, setVolume] = React.useState('');

  const handleSubmit = () => {
    var newItem = {
      name: name,
      description: description,
      volume: volume,
      ImageUrl: imageUrl,
      price: price,
      categoryId: 2
    }
    addItem(category, newItem);
  };

  return (
    <div className="pizza-block">
      <div className="add-block"></div>
      <img className="pizza-block__image" alt="Pizza" src={addImage} />
      <div className="link-block">
        <input placeholder="ссылка на изображение"type="text" className="item-input" value={imageUrl} onChange={(e) => setImageUrl(e.target.value)} />
      </div>
      <div>
        <textarea className="item-edit-textarea textarea-name" placeholder="Название" type="text" value={name} onChange={(e) => setName(e.target.value)} />
      </div>
      <div>
        <textarea className="item-edit-textarea textarea-description" placeholder="Описание" type="text" value={description} onChange={(e) => setDescription(e.target.value)} />
      </div>
      <div className="pizza-block__price">
          <input placeholder="0.0" className="item-edit-input input-price-edit" type="text" value={volume} onChange={(e) => setVolume(e.target.value)} /> л.
        </div>
      <div className="pizza-block__bottom">
      <div className="pizza-block__price">
          <input placeholder="0.0" className="item-edit-input input-price-edit" type="text" value={price} onChange={(e) => setPrice(e.target.value)} />
          р.
        </div>
        <Button onClick={handleSubmit} className="button--add" outline>
          <PlusIcon />
          <span>Добавить</span>
        </Button>
      </div>
    </div>
  );
}

export default DrinkAddBlock;
