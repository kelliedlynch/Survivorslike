using System.Linq;
using Friflo.Engine.ECS;
using Friflo.Engine.ECS.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using Survivorslike.Component;
using Survivorslike.Entities;
using NotImplementedException = System.NotImplementedException;

namespace Survivorslike.System;

public class PlayerControlSystem(Game game, EntityStore world) : GameComponent(game)
{
    public override void Update(GameTime gameTime)
    {
        var k = Keyboard.GetState();

        var player = world.GetUniqueEntity("Player");
        ref var velocity = ref player.GetComponent<Velocity>();
        var appliedSpeed = 0.25f;
        var appliedAngle = 0f;
        var moveKeyDown = false;
        if (k.IsKeyDown(Keys.A) || k.IsKeyDown(Keys.Left))
        {
            appliedAngle = 180;
            moveKeyDown = true;
        } 
        if (k.IsKeyDown(Keys.D) || k.IsKeyDown(Keys.Right))
        {
            moveKeyDown = true;
        } 
        if (k.IsKeyDown(Keys.W) || k.IsKeyDown(Keys.Up))
        {
            appliedAngle = 270;
            moveKeyDown = true;
        } 
        if (k.IsKeyDown(Keys.S) || k.IsKeyDown(Keys.Down))
        {
            appliedAngle = 90;
            moveKeyDown = true;
        }
        if(!moveKeyDown)
        {
            velocity.Angle = 0;
            velocity.Speed = 0;
        }
        else
        {
            var appliedVel = new Velocity(appliedSpeed, appliedAngle);
            velocity = Velocity.ApplyVelocity(velocity, appliedVel);
        }
    }
    
    
}