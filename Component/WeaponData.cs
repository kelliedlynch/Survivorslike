using Microsoft.Xna.Framework;
using Survivorslike.Entities;

namespace Survivorslike.Component;

public class WeaponData(float damage, float speed, float range)
{
    public float Damage { get; set; } = damage;
    public float Speed { get; set; } = speed;
    private float _cooldown = 0f;

    public float RemainingCooldown
    {
        get => _cooldown;
        set
        {
            if (value < 0) value = 0;
            _cooldown = value;
        }
    }

    public float Range { get; set; } = range;
}