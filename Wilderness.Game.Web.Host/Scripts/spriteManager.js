var Wilderness = Wilderness || {};

Wilderness.SpriteManager = function () {
  var sprites = {};

  var textures = {};

  var initialize = function (cfg, callback) {
    PIXI.loader
      .add(cfg.rootUrl + "game/images/bear.png")
      .load(function () { onTexturesLoaded(cfg, callback); });
  }

  var onTexturesLoaded = function (cfg, callback) {
    textures["B"] = PIXI.loader.resources[cfg.rootUrl + "game/images/bear.png"].texture;

    callback(cfg);
  }


  var getTexture = function(name)
  {
    return textures[name];
  }


  var getOrCreateSprite = function(spriteId, textureId)
  {
    if (!(spriteId in sprites)) {
      sprites[spriteId] = new PIXI.Sprite(getTexture(textureId));
      Wilderness.Game.getStage().addChild(sprites[spriteId]);
    }

    return sprites[spriteId];
  }


  var module =
  {
    initialize: initialize,
    getTexture: getTexture,
    getOrCreateSprite: getOrCreateSprite
  };

  return module;
}();
