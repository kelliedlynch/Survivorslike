using System;
using Friflo.Engine.ECS;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Survivorslike.Component;

public struct Velocity(float speed, float angle) : IComponent
{

    public float Speed = speed;
    public float Angle = angle;
    public float MaxSpeed = float.MaxValue;
 
    public static Velocity ApplyVelocity(Velocity vel1, Velocity vel2)
    {
        var newVector = VelocityToVector(vel1) + VelocityToVector(vel2);
        // NOTE: maybe vel2 MaxSpeed shouldn't be considered--do we want to limit the result by the applied velocity? If so, should it be like this?
        var newSpeed = Math.Min(Math.Min(float.Sqrt(float.Pow(newVector.X, 2) + float.Pow(newVector.Y, 2)), vel1.MaxSpeed), vel2.MaxSpeed);
        var newAngle = MathHelper.ToDegrees((float)float.Atan2(newVector.Y, newVector.X));
        return new Velocity{Speed=newSpeed, Angle=newAngle, MaxSpeed = Math.Min(vel1.MaxSpeed, vel2.MaxSpeed)};
    }

    public static Vector2 VelocityToVector(Velocity velocity)
    {
        return new Vector2(
            (float)(velocity.Speed * float.Cos(MathHelper.ToRadians(velocity.Angle))), 
            (float)(velocity.Speed * float.Sin(MathHelper.ToRadians(velocity.Angle))));
    }
}