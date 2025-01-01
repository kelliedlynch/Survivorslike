using Friflo.Engine.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using Survivorslike.Component;
using Entity = Friflo.Engine.ECS.Entity;
using NotImplementedException = System.NotImplementedException;

namespace Survivorslike.System;

public class TargetRenderSystem(Game game, EntityStore world) : DrawableGameComponent(game)
{
    private SpriteBatch _spriteBatch;

    public override void Initialize()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }
    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();
        world.Query<Targeter>().ForEachEntity((ref Targeter targeter, Entity entity) =>
        {
            foreach (var targetId in targeter.CurrentTargets)
            {
                var target = world.GetEntityById(targetId);
                var targetHitbox = target.GetComponent<Hitbox>();
                var hitPos =
                    AttackSystem.HitboxPosition(targetHitbox, target.GetComponent<EntityLocation>());
                var hitRect = new RectangleF(hitPos, targetHitbox.Size);
                _spriteBatch.DrawLine(targeter.Origin, hitRect.ClosestPointTo(targeter.Origin), Color.White);
            }
        });
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
// public class TargetingRenderSystem : EntityDrawSystem
// {
//     private SpriteBatch _spriteBatch;
//     private ComponentMapper<Targeter> _targeterMapper;
//     private ComponentMapper<Hitbox> _hitboxMapper;
//     
//     public TargetingRenderSystem(GraphicsDevice graphicsDevice) : base(Aspect.All(typeof(Targeter)))
//     {
//         _spriteBatch = new SpriteBatch(graphicsDevice);
//     }
//
//     public override void Initialize(IComponentMapperService mapperService)
//     {
//         _targeterMapper = mapperService.GetMapper<Targeter>();
//         _hitboxMapper = mapperService.GetMapper<Hitbox>();
//     }
//
//     public override void Draw(GameTime gameTime)
//     {
//         _spriteBatch.Begin();
//         foreach (var entityId in ActiveEntities)
//         {
//             var targeter = _targeterMapper.Get(entityId);
//             if (targeter.TargetPoint is not null)
//             {
//                 _spriteBatch.DrawLine(targeter.Origin, (Vector2)targeter.TargetPoint, Color.Aqua);
//             }
//             
//         }
//         _spriteBatch.End();
//     }
// }