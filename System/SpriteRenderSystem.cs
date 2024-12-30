using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using Survivorslike.Component;

namespace Survivorslike.System;

public class SpriteRenderSystem : EntityDrawSystem
{
    private ComponentMapper<Sprite> _spriteMapper;
    private ComponentMapper<Transform> _transformMapper;
    private ComponentMapper<Hitbox> _hitboxMapper;
    private SpriteBatch _spriteBatch;
    private bool ShowHitboxes = true;
    
    
    public SpriteRenderSystem(GraphicsDevice graphicsDevice) : base(Aspect.All(typeof(Sprite), typeof(Transform))){
        _spriteBatch = new SpriteBatch(graphicsDevice);
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        _spriteMapper = mapperService.GetMapper<Sprite>();
        _transformMapper = mapperService.GetMapper<Transform>();
        _hitboxMapper = mapperService.GetMapper<Hitbox>();
    }

    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();
        foreach (var entity in ActiveEntities)
        {
            var transform = _transformMapper.Get(entity);
            var sprite = _spriteMapper.Get(entity);
            _spriteBatch.Draw(sprite.Texture, new Rectangle(transform.Position.ToPoint(), transform.Size.ToPoint()), Color.White);
            if (ShowHitboxes)
            {
                var box = _hitboxMapper.Get(entity);
                _spriteBatch.DrawRectangle(box.Bounds, Color.Red);
            }
        }
        _spriteBatch.End();
    }
}