using System;
using System.Numerics;
using Friflo.Engine.ECS.Systems;
using Microsoft.Xna.Framework;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using Survivorslike.Component;
using BoundingBox = Survivorslike.Component.BoundingBox;
using NotImplementedException = System.NotImplementedException;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Survivorslike.System;

public class MovementSystem : QuerySystem<BoundingBox, Velocity>
{
    protected override void OnUpdate()
    {
        foreach (var entity in Query.Entities)
        {
            ref var box = ref entity.GetComponent<BoundingBox>();
            var velocity = entity.GetComponent<Velocity>();

            var tick = Tick.deltaTime;
            box.Position += Velocity.VelocityToVector(velocity) * new Vector2(Tick.deltaTime / 10);
            // if (velocity.Vector != Vector2.Zero)
            // {
            //     continue;
            // }
            var pos = box.Position;
            // var velocity = _velocityMapper.Get(entityId);
            // var transform = _transformMapper.Get(entityId);
            // transform.Position += velocity.Vector * new Vector2(gameTime.ElapsedGameTime.Milliseconds / 10f);
            // // look at weapons for this
            // var arsenal = _arsenalMapper.Get(entityId);
            // if (arsenal == null) continue;
            // foreach (var weaponId in arsenal.Weapons)
            // {
            //     var targeter = _targeterMapper.Get(weaponId);
            //     if (targeter != null)
            //     {
            //         targeter.Origin = transform.Bounds.Center;
            //     }
            // }

        }
    }



}