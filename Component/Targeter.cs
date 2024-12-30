#nullable enable
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Collections;
using MonoGame.Extended.ECS;

namespace Survivorslike.Component;

public class Targeter
{
    public Vector2 Origin { get; set; }
    public Hitbox? TargetHitbox { get; set; }
    public Vector2? TargetPoint { get; set; }
    
    public TargetType ValidTargets { get; set; } = TargetType.Other;

    // Self is the Entity ID of the entity that will count as "self" for target selection purposes
    public int Self { get; set; }
    
    public void FindTarget(List<Hitbox> hitBoxes)
    {
        float minDistance = float.MaxValue;
        foreach (var hitBox in hitBoxes)
        {
            var distance = hitBox.Bounds.DistanceTo(Origin);
            if (distance < minDistance)
            {
                minDistance = distance;
                TargetHitbox = hitBox;
                TargetPoint = hitBox.Bounds.Center;
            }
        }
    }

    public enum TargetType
    {
        Self = 1,
        Other = 2,
        Location = 4
    }

}