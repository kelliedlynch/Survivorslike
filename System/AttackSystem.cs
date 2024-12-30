using System.Linq;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Collections;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using Survivorslike.Component;
using Survivorslike.Entities;
using NotImplementedException = System.NotImplementedException;

namespace Survivorslike.System;

public class AttackSystem() : EntityUpdateSystem(Aspect.All(typeof(Targeter)))
{
    private ComponentMapper<Targeter> _targeterMapper;
    private ComponentMapper<WeaponData> _weaponMapper;
    private ComponentMapper<HitBox> _hitBoxMapper;
    private ComponentMapper<PlayerData> _playerMapper;
    
    public override void Initialize(IComponentMapperService mapperService)
    {
        _targeterMapper = mapperService.GetMapper<Targeter>();
        _weaponMapper = mapperService.GetMapper<WeaponData>();
        _hitBoxMapper = mapperService.GetMapper<HitBox>();
        _playerMapper = mapperService.GetMapper<PlayerData>();
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var entityId in ActiveEntities)
        {
            var targeter = _targeterMapper.Get(entityId);
            var weaponData = _weaponMapper.Get(entityId);
            var hitBoxes = new Bag<HitBox>();
            var playerHitBox = _hitBoxMapper.Get(Player.Id);
            foreach (var box in _hitBoxMapper.Components.Where(box => playerHitBox != box))
            {
                hitBoxes.Add(box);
            }
            var target = targeter.FindTarget(Point.Zero, hitBoxes);
            if (target == null) continue;
            
        }
    }
}