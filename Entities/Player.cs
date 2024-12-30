using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using Survivorslike.Component;

namespace Survivorslike.Entities;

public static class Player
{
    public static int Id { get; private set; }
    
    public static void NewPlayer(Game game, World world)
    {
        var player = world.CreateEntity();
        var transform = new Transform(new Vector2(300), new Vector2(100));
        player.Attach(transform);
        player.Attach(new Sprite(game, "Graphics/warrior_solo"));
        var velocity = new Velocity
        {
            MaxSpeed = 4
        };
        player.Attach(velocity);
        player.Attach(new CreatureData());
        var hitbox = new Hitbox();
        hitbox.Transform = transform;
        hitbox.Size = transform.Size / new Vector2(2);
        hitbox.TransformAnchorPoint = new Vector2(transform.Size.X / 4 + 2, transform.Size.Y / 4 - 4);
        player.Attach(hitbox);
        // var weapon = Weapon.NewWeapon(game, world);
        var targeter = new Targeter();
        var weapon = world.CreateEntity(); 
        weapon.Attach(new WeaponData(1, 3, 15));
        weapon.Attach(targeter);
        targeter.Origin = hitbox.Bounds.Center;
        targeter.Self = player.Id;
        var arsenal = new Arsenal();
        arsenal.Weapons.Add(weapon.Id);
        player.Attach(arsenal);
        
        // player.Attach(new Targeter(){ Origin = transform.Bounds.Center});
        
        Id = player.Id;
    }
}