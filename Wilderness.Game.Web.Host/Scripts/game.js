var Wilderness = Wilderness || {};

Wilderness.Game = function () {
  var startSignalRCommunication = function (url) {
    $.connection.hub.url = url;

    // Reference the auto-generated proxy for the hub.
    var msgHub = $.connection.gameMessageHub;

    msgHub.client.handleRenderMessage = Wilderness.MessageHandlers.handleRenderMessage;

    $.connection.hub.start();
  };


  var stage = null;

  var renderer = null;

  var startRender = function (cfg) {
    //Create a container object called the `stage`
    stage = new PIXI.Container();

    //var sprite = Wilderness.SpriteManager.getOrCreateSprite("abc", "B");
    //sprite.x = 96;
    //sprite.y = 60;
    //stage.addChild(sprite);

    //Create the renderer
    renderer = PIXI.autoDetectRenderer(256, 256);

    //Add the canvas to the HTML document
    $(cfg.viewElement).append(renderer.view);

    //Tell the `renderer` to `render` the `stage`
    renderer.render(stage);
  };


  var initialize = function (cfg) {
    Wilderness.SpriteManager.initialize(cfg, onLoaded);
  };


  var onLoaded = function (cfg) {
    startSignalRCommunication(cfg.signalRUrl);
    startRender(cfg);
    if (cfg.onReady != null)
      cfg.onReady();
  }


  var gameLoop = function () {
    //Loop this function 60 times per second
    requestAnimationFrame(gameLoop);

    //Render the stage
    renderer.render(stage);
  }


  var module =
    {
      initialize: initialize,
      getStage: function () { return stage; },
      runGameLoop: gameLoop
    };

  return module;
}();

