using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using Survivorslike.Component;
using Survivorslike.Entities;
using NotImplementedException = System.NotImplementedException;

namespace Survivorslike.System;

public class PlayerControlSystem() : EntityUpdateSystem(Aspect.All(typeof(CreatureData)))
{
    private ComponentMapper<CreatureData> _playerMapper;
    private ComponentMapper<Velocity> _velocityMapper;
    
    public override void Initialize(IComponentMapperService mapperService)
    {
        _playerMapper = mapperService.GetMapper<CreatureData>();
        _velocityMapper = mapperService.GetMapper<Velocity>();
    }

    public override void Update(GameTime gameTime)
    {
        var k = Keyboard.GetState();

        var entity = Player.Id;
        var moveKeyDown = false;
        if (k.IsKeyDown(Keys.A) || k.IsKeyDown(Keys.Left))
        {
            var velocity = _velocityMapper.Get(entity);
            velocity.ApplyTransform(180, 0.25f);
            moveKeyDown = true;
        } 
        if (k.IsKeyDown(Keys.D) || k.IsKeyDown(Keys.Right))
        {
            var velocity = _velocityMapper.Get(entity);
            velocity.ApplyTransform(0, 0.25f);
            moveKeyDown = true;
        } 
        if (k.IsKeyDown(Keys.W) || k.IsKeyDown(Keys.Up))
        {
            var velocity = _velocityMapper.Get(entity);
            velocity.ApplyTransform(270, 0.25f);
            moveKeyDown = true;
        } 
        if (k.IsKeyDown(Keys.S) || k.IsKeyDown(Keys.Down))
        {
            var velocity = _velocityMapper.Get(entity);
            velocity.ApplyTransform(90, 0.25f);
            moveKeyDown = true;
        }
        if(!moveKeyDown)
        {
            var velocity = _velocityMapper.Get(entity);
            velocity.Angle = 0;
            velocity.Speed = 0;
        }
    }
}