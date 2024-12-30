using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ECS;
using Survivorslike.Component;

namespace Survivorslike.Entities;

public class WeaponFactory
{
    public static void NewWeapon(Game game, World world)
    {
        var weapon = world.CreateEntity(); 
        weapon.Attach(new WeaponData(1, 3, 15, WeaponMode.Missile));
    }

    public enum WeaponMode
    {
        Missile,
        Melee,
        Aura
    }
}
