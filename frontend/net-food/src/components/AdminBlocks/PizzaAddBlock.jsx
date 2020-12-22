import React from "react";
import Button from "../Button";
import addImage from "../../assets/img/addItem.png"
import classNames from "classnames";
import { ReactComponent as PlusIcon } from '../../assets/img/plus.svg'

function ItemAddBlock({ category, addPizza }) {

    var pizzaSizes = [{size: 26, price: 15}, {size: 30, price: 21}, {size: 35, price: 25}];
    var pizzaDoughTypes = [{doughType: 'Традиционное'}, {doughType: 'Тонкое'}];
    const [name, setName] = React.useState('');
    const [description, setDescription] = React.useState('');
    const [imageUrl, setImageUrl] = React.useState('');
    const prices = pizzaSizes.map(sizes => sizes.price);
    const availableTypes = pizzaDoughTypes.map(types => types.doughType);
    const availableSizes = pizzaSizes.map(sizes => sizes.size);
    const [activeType, setActiveType] = React.useState(0);
    const [activeSize, setActiveSize] = React.useState(0);

    const handleSubmit = () => {
        var pizza = {
            name: name,
            description: description,
            ImageUrl: imageUrl,
        }
        addPizza(category, pizza, pizzaSizes, pizzaDoughTypes);
    };

    const onSelectType = (index) => {
        setActiveType(index);
    };

    const onSelectSize = (index) => {
        setActiveSize(index);
    };

    return (
        <div className="pizza-block">
            <div className="add-block"></div>
            <img className="pizza-block__image" alt="Pizza" src={addImage} />
            <div className="link-block">
                <input placeholder="ссылка на изображение" type="text" className="item-input" value={imageUrl} onChange={(e) => setImageUrl(e.target.value)} />
            </div>
            <div>
                <textarea className="item-edit-textarea textarea-name" placeholder="Название" type="text" value={name} onChange={(e) => setName(e.target.value)} />
            </div>
            <div>
                <textarea className="item-edit-textarea textarea-description" placeholder="Описание" type="text" value={description} onChange={(e) => setDescription(e.target.value)} />
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
            <div className="pizza-block__bottom">
                <div className="pizza-block__price">
                {prices[activeSize]} р.
                </div>
                <Button onClick={handleSubmit} className="button--add" outline>
                    <PlusIcon />
                    <span>Добавить</span>
                </Button>
            </div>
        </div>
    );
}

export default ItemAddBlock;
