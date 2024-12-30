using System;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Survivorslike.Component;

public class Velocity
{
    public float Speed { get; set; } = 0;
    public float Angle { get; set; } = 0;
    
    public float MaxSpeed { get; set; } = 1000;
    
    public Vector2 Vector => ToVector(Angle, Speed);

    public void ApplyTransform(float angle, float speed)
    {
        var newVector = Vector + ToVector(angle, speed); 
        Speed = Math.Min(float.Sqrt(float.Pow(newVector.X, 2) + float.Pow(newVector.Y, 2)), MaxSpeed);
        Angle = MathHelper.ToDegrees((float)float.Atan2(newVector.Y, newVector.X));
    }

    private Vector2 ToVector(float angle, float speed)
    {
        return new Vector2(
            (float)(speed * float.Cos(MathHelper.ToRadians(angle))), 
            (float)(speed * float.Sin(MathHelper.ToRadians(angle))));
    }
}