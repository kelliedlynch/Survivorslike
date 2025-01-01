using System.Collections.Generic;
using System.Linq;
using Friflo.Engine.ECS.Systems;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Collections;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using Survivorslike.Component;
using Survivorslike.Entities;
using Entity = Friflo.Engine.ECS.Entity;
using NotImplementedException = System.NotImplementedException;

namespace Survivorslike.System;

public class AttackSystem() : QuerySystem<Targeter, DamageDealer>
{
    protected override void OnUpdate()
    {
        Query.ForEachEntity((ref Targeter targeter, ref DamageDealer damage, Entity entity) =>
        {
            var targets = FindTargets(targeter);
            targeter.CurrentTargets = targets.Select(target => target.Id).ToList();
        });
    }

    private List<Entity> FindTargets(Targeter targeter)
    {
        var returnTargets = new List<Entity>();
        if (targeter.Type == TargeterType.NearestSingle)
        {
            var worlds = SystemRoot.Stores;
            foreach (var world in worlds)
            {
                var shortestDistance = float.MaxValue;
                // var targetEntities = new List<Entity>();
                Entity? nearestEntity = null;
                world.Query<Hitbox, EntityLocation>().ForEachEntity((ref Hitbox hitbox, ref EntityLocation boundingBox, Entity entity) =>
                {
                    if (entity == world.GetUniqueEntity("Player")) return;
                    var pos = HitboxPosition(hitbox, boundingBox);
                    var rect = new RectangleF(pos, hitbox.Size);
                    var distance = rect.DistanceTo(targeter.Origin);
                    if (distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        nearestEntity = entity;
                    }
                } );
                if(nearestEntity != null) returnTargets.Add(nearestEntity.Value);

            }
        }
        else
        {
            throw new NotImplementedException();
        }
        return returnTargets;
    }

    public static Vector2 HitboxPosition(Hitbox hitbox, EntityLocation entityLocation)
    {
        return entityLocation.Position + entityLocation.HitboxAnchorPoint - hitbox.AnchorPoint;
    }
}