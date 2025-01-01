using Friflo.Engine.ECS;
using Friflo.Engine.ECS.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Survivorslike.Component;
using BoundingBox = Survivorslike.Component.BoundingBox;


namespace Survivorslike.System;

public class SpriteRenderSystem (Game game, EntityStore world) : DrawableGameComponent (game)
{
    private readonly EntityStore _world = world;
    private SpriteBatch _spriteBatch;
    private bool ShowHitboxes = true;

    public override void Initialize()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    private void DrawSprite(Sprite sprite, BoundingBox box)
    {
        var rect = box.Bounds.ToRectangle();
        _spriteBatch.Draw(sprite.Texture, box.Bounds.ToRectangle(), sprite.Color);
    }

    private void DrawHitbox(Hitbox hitbox, BoundingBox box)
    {
        var hitboxRect = CalculateAnchoredRectangle(box.Bounds, box.HitboxAnchorPoint, hitbox.Size, hitbox.AnchorPoint);
        _spriteBatch.DrawRectangle(hitboxRect.ToRectangle(), Color.White);
    }

    private RectangleF CalculateAnchoredRectangle(RectangleF container, Vector2 anchorPosition, Vector2 size,
        Vector2 anchorPoint)
    {
        var absolutePosition = container.Position + anchorPosition;
        var anchoredPosition = absolutePosition - anchorPoint;
        return new RectangleF(anchoredPosition.X, anchoredPosition.Y, size.X, size.Y);
    }
    
    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        var sprites = _world.Query<Sprite, BoundingBox>();
        sprites.ForEachEntity((ref Sprite sprite, ref BoundingBox box, Entity _) => DrawSprite(sprite, box));
        if (ShowHitboxes)
        {
            var hitboxes = _world.Query<Hitbox, BoundingBox>();
            hitboxes.ForEachEntity((ref Hitbox box, ref BoundingBox bbox, Entity _) => DrawHitbox(box, bbox));
            
        }
        _spriteBatch.End();
    }

}