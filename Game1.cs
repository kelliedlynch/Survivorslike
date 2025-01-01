using Friflo.Engine.ECS;
using Friflo.Engine.ECS.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using Survivorslike.Component;
using Survivorslike.Entities;
using Survivorslike.System;
using BoundingBox = Microsoft.Xna.Framework.BoundingBox;

namespace Survivorslike;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    // private SpriteBatch _spriteBatch;
    private EntityStore _world;
    private SystemRoot _systemRoot;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _world = new EntityStore();
        _systemRoot = new SystemRoot(_world) { new MovementSystem(), new AttackSystem() };

        var spriteRenderer = new SpriteRenderSystem(this, _world);
        Components.Add(spriteRenderer);
        var playerControlSystem = new PlayerControlSystem(this, _world);
        Components.Add(playerControlSystem);
        var targetRenderSystem = new TargetRenderSystem(this, _world);
        Components.Add(targetRenderSystem);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // _spriteBatch = new SpriteBatch(GraphicsDevice);
        // Services.AddService(_spriteBatch);
        
    }

    protected override void BeginRun()
    {
        var player = Player.NewPlayer(this, _world);

        var loc = new EntityLocation(){ Position = Vector2.One, Size = new Vector2(200, 300) };
        var hitbox = new Hitbox() { Size = new Vector2(200, 300) };
        var monster = _world.CreateEntity(loc, hitbox);
        
        
        base.BeginRun();
    }

    protected override void Update(GameTime gameTime)
    {
        var tick = new UpdateTick(gameTime.ElapsedGameTime.Milliseconds, 0);
        _systemRoot.Update(tick);
        base.Update(gameTime);
    }

    // protected override bool BeginDraw()
    // {
    //     _spriteBatch.Begin();
    //     return base.BeginDraw();
    // }

    protected override void Draw(GameTime gameTime)
    {
        // GraphicsDevice.Clear(Color.CornflowerBlue);
        base.Draw(gameTime);
    }

    // protected override void EndDraw()
    // {
    //     _spriteBatch.End();
    //     base.EndDraw();
    // }
}