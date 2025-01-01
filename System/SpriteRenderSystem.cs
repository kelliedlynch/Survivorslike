using Friflo.Engine.ECS;
using Friflo.Engine.ECS.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Survivorslike.Component;


namespace Survivorslike.System;

public class SpriteRenderSystem (Game game, EntityStore world) : DrawableGameComponent (game)
{
    private SpriteBatch _spriteBatch;
    private bool ShowHitboxes = true;

    public override void Initialize()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    private void DrawSprite(Sprite sprite, EntityLocation box)
    {
        var rect = box.Bounds.ToRectangle();
        _spriteBatch.Draw(sprite.Texture, box.Bounds.ToRectangle(), sprite.Color);
    }

    private void DrawHitbox(Hitbox hitbox, EntityLocation box)
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
        var sprites = world.Query<Sprite, EntityLocation>();
        sprites.ForEachEntity((ref Sprite sprite, ref EntityLocation box, Entity _) => DrawSprite(sprite, box));
        if (ShowHitboxes)
        {
            var hitboxes = world.Query<Hitbox, EntityLocation>();
            hitboxes.ForEachEntity((ref Hitbox box, ref EntityLocation bbox, Entity _) => DrawHitbox(box, bbox));
            
        }
        _spriteBatch.End();
    }

}