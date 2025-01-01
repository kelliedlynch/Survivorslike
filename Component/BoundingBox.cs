using Friflo.Engine.ECS;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Survivorslike.Component;

public struct BoundingBox (Vector2 position, Vector2 size) : IComponent
{
    public Vector2 Position = position;
    public Vector2 Size = size;
    public RectangleF Bounds => new(Position.X, Position.Y, Size.X, Size.Y);
    public float Rotation = 0;
    public Vector2 HitboxAnchorPoint => Bounds.Center - Bounds.Position;
}