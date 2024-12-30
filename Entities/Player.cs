using Microsoft.Xna.Framework;
using MonoGame.Extended.ECS;
using Survivorslike.Component;

namespace Survivorslike.Entities;

public static class Player
{
    public static int Id { get; private set; }
    
    public static void NewPlayer(Game game, World world)
    {
        var player = world.CreateEntity();
        player.Attach(new Transform(new Point(300), new Vector2(100)));
        player.Attach(new Sprite(game, "Graphics/warrior_solo"));
        var velocity = new Velocity();
        velocity.MaxSpeed = 4;
        player.Attach(velocity);
        player.Attach(new PlayerData());
        player.Attach(new HitBox());
        
        Id = player.Id;
    }
}