using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using Survivorslike.Component;
using NotImplementedException = System.NotImplementedException;

namespace Survivorslike.System;


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