using Microsoft.Xna.Framework;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using Survivorslike.Component;
using NotImplementedException = System.NotImplementedException;

namespace Survivorslike.System;

public class MovementSystem() : EntityUpdateSystem(Aspect.All(typeof(Velocity), typeof(Transform)))
{
    private ComponentMapper<Velocity> _velocityMapper;
    private ComponentMapper<Transform> _transformMapper;
    
    public override void Initialize(IComponentMapperService mapperService)
    {
        _velocityMapper = mapperService.GetMapper<Velocity>();
        _transformMapper = mapperService.GetMapper<Transform>();
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var entityId in ActiveEntities)
        {
            var velocity = _velocityMapper.Get(entityId);
            var transform = _transformMapper.Get(entityId);
            transform.Position += velocity.Vector.ToPoint() * new Point(gameTime.ElapsedGameTime.Milliseconds / 10);
            
        }
    }
}