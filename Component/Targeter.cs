#nullable enable
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Collections;
using MonoGame.Extended.ECS;

namespace Survivorslike.Component;

public struct Targeter(Vector2 origin, float range)
{
    public TargeterType Type = TargeterType.NearestSingle;
    public Vector2 Origin = origin;
    public float Range = range;
    public int MinTargets = 1;
    public int MaxTargets = 1;
}

public enum TargeterType
{
    // Closest target
    NearestSingle,
    // Up to X targets, starting with closest
    NearestMultiple,
    // Fires in specified direction, whether targets exist or not
    FixedDirection,
    // All targets within specified area, may be zero
    CircularArea,
    // All targets on screen
    AllTargets
}

