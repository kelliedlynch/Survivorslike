using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Survivorslike.Component;

public class Transform (Vector2 position, Vector2 size)
{
    public Vector2 Position { get; set; } = position;
    public Vector2 Size { get; set; } = size;
    public RectangleF Bounds => new(Position.X, Position.Y, Size.X, Size.Y);
    public float Rotation { get; set; } = 0;
    public float LayerDepth { get; set; } = 0;
}