using System;
using System.Linq;
using System.Numerics;
using Friflo.Engine.ECS.Systems;
using Microsoft.Xna.Framework;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using Survivorslike.Component;
using NotImplementedException = System.NotImplementedException;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Survivorslike.System;

public class MovementSystem : QuerySystem<EntityLocation, Velocity>
{
    protected override void OnUpdate()
    {
        foreach (var entity in Query.Entities)
        {
            ref var box = ref entity.GetComponent<EntityLocation>();
            var velocity = entity.GetComponent<Velocity>();
            if( velocity.Speed == 0 ) continue;

            box.Position += Velocity.VelocityToVector(velocity) * new Vector2(Tick.deltaTime / 10);

            if (entity.ChildEntities.Count > 0)
            {
                var children = entity.ChildEntities.Where(e => e.HasComponent<Targeter>());
                foreach (var child in children)
                {
                    ref var targeter = ref child.GetComponent<Targeter>();
                    targeter.Origin = box.Position + box.TargeterAnchorPoint;
                }
            }
        }
    }



}