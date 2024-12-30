using System;
using Microsoft.Xna.Framework;
using MonoGame.Extended.ECS;
using Survivorslike.Component;

namespace Survivorslike.Entities;

public class Monster
{
    private static Random _random = new Random();
    
    public static Entity NewMonster(Game game, World world)
    {
        var monster = world.CreateEntity();
        monster.Attach(new CreatureData());
        
        var size = new Point(120, 150);
        var pos = new Vector2(_random.Next(game.GraphicsDevice.Viewport.Width), _random.Next(game.GraphicsDevice.Viewport.Height));
        var transform = new Transform(pos, size.ToVector2());
        monster.Attach(transform);
        monster.Attach(new Sprite(game, "Graphics/Boss_Big_Fish"));
        monster.Attach(new Hitbox()
        {
            Size = size.ToVector2(),
            Transform = transform,
            TransformAnchorPoint = Vector2.Zero
        });
        return monster;
    }
}