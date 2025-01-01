using Friflo.Engine.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NotImplementedException = System.NotImplementedException;

namespace Survivorslike.Component;

public struct Sprite(Texture2D texture) : IComponent
{
    public Texture2D Texture = texture;
    public Color Color = Color.White;
    public float LayerDepth = 0;
}