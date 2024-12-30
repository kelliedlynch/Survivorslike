#nullable enable
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Collections;
using MonoGame.Extended.ECS;

namespace Survivorslike.Component;

public class Targeter
{
    
    public virtual HitBox? FindTarget(Point origin, Bag<HitBox> hitBoxes)
    {
        HitBox? nearestTarget = null;
        float minDistance = float.MaxValue;
        foreach (var hitBox in hitBoxes)
        {
            var dist1 = hitBox.Bounds.DistanceTo(origin.ToVector2());
            var point2 = hitBox.Bounds.ClosestPointTo(origin.ToVector2());
            var dist2 = float.Sqrt(float.Pow(Math.Abs(origin.X - point2.X), 2) + float.Pow(Math.Abs(origin.Y - point2.Y), 2));
            if (dist1 < minDistance)
            {
                nearestTarget = hitBox;
            }
        }
        return nearestTarget;
    }
}