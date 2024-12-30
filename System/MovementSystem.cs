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
    private ComponentMapper<Targeter> _targeterMapper;
    private ComponentMapper<Arsenal> _arsenalMapper;
    
    public override void Initialize(IComponentMapperService mapperService)
    {
        _velocityMapper = mapperService.GetMapper<Velocity>();
        _transformMapper = mapperService.GetMapper<Transform>();
        _targeterMapper = mapperService.GetMapper<Targeter>();
        _arsenalMapper = mapperService.GetMapper<Arsenal>();
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var entityId in ActiveEntities)
        {
            var velocity = _velocityMapper.Get(entityId);
            var transform = _transformMapper.Get(entityId);
            transform.Position += velocity.Vector * new Vector2(gameTime.ElapsedGameTime.Milliseconds / 10f);
            // look at weapons for this
            var arsenal = _arsenalMapper.Get(entityId);
            if (arsenal == null) continue;
            foreach (var weaponId in arsenal.Weapons)
            {
                var targeter = _targeterMapper.Get(weaponId);
                if (targeter != null)
                {
                    targeter.Origin = transform.Bounds.Center;
                }
            }

        }
    }
}