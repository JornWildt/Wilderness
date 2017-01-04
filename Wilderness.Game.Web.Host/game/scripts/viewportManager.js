var Wilderness = Wilderness || {};

Wilderness.ViewPortManager = function () {
  var width = 100;
  
  var height = 100;
  
  var pixelWidth = 500;
  
  var pixelHeight = 500;


  var positionToPixelX = function (x) {
    return (x + width / 2) * (pixelWidth / width);
  }


  var positionToPixelY = function (y) {
    return (y + height / 2) * (pixelHeight / height);
  }

  var module =
  {
    getPixelWidth: function () { return pixelWidth; },
    getPixelHeight: function() { return pixelHeight; },
    positionToPixelX: positionToPixelX,
    positionToPixelY: positionToPixelY
  };

  return module;
}();
