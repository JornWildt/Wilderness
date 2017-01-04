var Wilderness = Wilderness || {};

Wilderness.SpriteManager = function () {
  var sprites = {};

  var textures = {};

  var initialize = function (cfg, callback) {
    PIXI.loader
      .add(cfg.rootUrl + "game/images/bear.png")
      .add(cfg.rootUrl + "game/tiles/tiles1.bmp")
      .load(function () { onTexturesLoaded(cfg, callback); });
  }

  var onTexturesLoaded = function (cfg, callback) {
    textures["B"] = PIXI.loader.resources[cfg.rootUrl + "game/images/bear.png"].texture;

    textures["T1"] = PIXI.loader.resources[cfg.rootUrl + "game/tiles/tiles1.bmp"].texture;
    textures["T1"].frame = new PIXI.Rectangle(0, 0, 32, 32);

    textures["T2"] = PIXI.loader.resources[cfg.rootUrl + "game/tiles/tiles1.bmp"].texture;
    textures["T2"].frame = new PIXI.Rectangle(32, 0, 32, 32);

    textures["T3"] = PIXI.loader.resources[cfg.rootUrl + "game/tiles/tiles1.bmp"].texture;
    textures["T3"].frame = new PIXI.Rectangle(64, 0, 32, 32);

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
