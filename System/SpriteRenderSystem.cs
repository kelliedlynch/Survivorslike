using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using Survivorslike.Component;

namespace Survivorslike.System;

public class SpriteRenderSystem : EntityDrawSystem
{
    private ComponentMapper<Sprite> _spriteMapper;
    private ComponentMapper<Transform> _transformMapper;
    private SpriteBatch _spriteBatch;
    
    public SpriteRenderSystem(GraphicsDevice graphicsDevice) : base(Aspect.All(typeof(Sprite), typeof(Transform))){
        _spriteBatch = new SpriteBatch(graphicsDevice);
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        _spriteMapper = mapperService.GetMapper<Sprite>();
        _transformMapper = mapperService.GetMapper<Transform>();
    }

    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();
        foreach (var entity in ActiveEntities)
        {
            var transform = _transformMapper.Get(entity);
            var sprite = _spriteMapper.Get(entity);
            _spriteBatch.Draw(sprite.Texture, new Rectangle(transform.Position, transform.Size.ToPoint()), Color.White);            
        }
        _spriteBatch.End();
    }
}