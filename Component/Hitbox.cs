using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Survivorslike.Component;

public class Hitbox
{
    public Vector2 Size { get; set; }
    public RectangleF Bounds => new(Transform.Position + TransformAnchorPoint, Size);
    public Transform Transform { get; set; }
    public Vector2 TransformAnchorPoint { get; set; }
}