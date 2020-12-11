import React from "react";
import PropTypes from 'prop-types';

function Categories({ activeCategory, items, onClickCategory }) {

  return (
    <div className="categories">
      <ul>
        {items && items.map((item, index) => (
          <li
            className={activeCategory === item.apiname ? "active" : ""}
            onClick={() => onClickCategory(item.apiname)}
            key={`${item.name}_${index}`}
          >
            {item.name}
          </li>
        ))}
      </ul>
    </div>
  );
}

Categories.propTypes = {
  onClickCategory: PropTypes.func
}

Categories.defaultProps = {
  activeCategory: "pizzas",
  items: []
}

export default Categories;
