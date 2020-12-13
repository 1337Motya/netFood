import React from "react";
import ContentLoader from "react-content-loader";

function LoadingBlock() {
  return (
    <ContentLoader
    className="pizza-block"
      speed={2}
      width={280}
      height={460}
      viewBox="0 0 280 460"
      backgroundColor="#f3f3f3"
      foregroundColor="#ecebeb"
    >
      <circle cx="120" cy="120" r="120" />
      <rect x="0" y="254" rx="6" ry="0" width="240" height="23" />
      <rect x="-1" y="289" rx="6" ry="6" width="240" height="85" />
      <rect x="118" y="389" rx="19" ry="19" width="121" height="42" />
    </ContentLoader>
  );
}

export default LoadingBlock;
