using System.Numerics;
using Friflo.Engine.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using Survivorslike.Component;
using BoundingBox = Survivorslike.Component.BoundingBox;
using Entity = Friflo.Engine.ECS.Entity;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Survivorslike.Entities;

public static class Player
{
    
    public static Entity NewPlayer(Game game, EntityStore world)
    {
        var player = world.CreateEntity(new UniqueEntity("Player"));
        
        var spriteSize = new Vector2(100, 100);
        var position = game.GraphicsDevice.Viewport.Bounds.Center.ToVector2() - spriteSize / new Vector2(2);
        var boundingBox = new BoundingBox(position, spriteSize);
        player.AddComponent(boundingBox);

        var velocity = new Velocity{Angle = 0f, Speed = 0f, MaxSpeed = 2.5f};
        player.AddComponent(velocity);

        var texture = game.Content.Load<Texture2D>("Graphics/warrior_solo");
        var sprite = new Sprite(texture);
        player.AddComponent(sprite);
        
        var hitboxRect = boundingBox.Bounds.GetRelativeRectangle(spriteSize.X / 4, spriteSize.Y / 4, spriteSize.X / 2, spriteSize.Y / 2);
        var hitbox = new Hitbox{ Size = hitboxRect.Size };
        player.AddComponent(hitbox);
        
        return player;
    }

}