var Wilderness = Wilderness || {};

Wilderness.MessageHandlers = function () {
  var handleRenderMessage = function (msg) {
    //$('#discussion').append('<li>Render: ' + htmlEncode(msg.Texture) + '</li>');

    var sprite = Wilderness.SpriteManager.getOrCreateSprite(msg.SpriteId, msg.Texture);
    sprite.x = msg.X + 128;
    sprite.y = msg.Y + 128;
  };


  function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
  }


  var module =
    {
      handleRenderMessage: handleRenderMessage
    };

  return module;
}();
