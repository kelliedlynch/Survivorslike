using Microsoft.Xna.Framework;

namespace Survivorslike.Component;

public class Transform (Point position, Vector2 size)
{
    public Point Position { get; set; } = position;
    public Vector2 Size { get; set; } = size;
    public float Rotation { get; set; } = 0;
    public float LayerDepth { get; set; } = 0;
}