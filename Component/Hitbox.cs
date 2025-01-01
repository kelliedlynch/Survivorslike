using Friflo.Engine.ECS;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Survivorslike.Component;

public struct Hitbox : IComponent
{
    public Vector2 Size;
    // public Vector2 Position;
    // public RectangleF Bounds => new(Position, Size);

    public Vector2 AnchorPoint => Size / 2;
}