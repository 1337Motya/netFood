import React from "react";
import Button from "../Button";

function SnackBlock() {

  return (
    <div className="pizza-block">
      <img className="pizza-block__image" alt="Pizza" />
      <h4 className="pizza-block__title">
          <input type="text"/>
      </h4>
      <span className="pizza-block__description"><input type="text"/></span>
      <div className="pizza-block__bottom">
        <div className="pizza-block__price"><input type="text"/> р.</div>
        <Button className="button--add" outline>
          <span>Сохранить</span>
        </Button>
        <Button className="button--add" outline>
          <span>Удалить</span>
        </Button>
      </div>
    </div>
  );
}

export default SnackBlock;
