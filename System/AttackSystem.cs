using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Collections;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using Survivorslike.Component;
using Survivorslike.Entities;
using NotImplementedException = System.NotImplementedException;

namespace Survivorslike.System;

public class AttackSystem() : EntityUpdateSystem(Aspect.All(typeof(Arsenal)))
{
    private ComponentMapper<Arsenal> _arsenalMapper;
    private ComponentMapper<Targeter> _targeterMapper;
    private ComponentMapper<WeaponData> _weaponMapper;
    private ComponentMapper<Hitbox> _hitboxMapper;
    private ComponentMapper<CreatureData> _playerMapper;
    private ComponentMapper<Transform> _transformMapper;
    
    public override void Initialize(IComponentMapperService mapperService)
    {
        _arsenalMapper = mapperService.GetMapper<Arsenal>();
        _targeterMapper = mapperService.GetMapper<Targeter>();
        _weaponMapper = mapperService.GetMapper<WeaponData>();
        _hitboxMapper = mapperService.GetMapper<Hitbox>();
        _playerMapper = mapperService.GetMapper<CreatureData>();
        _transformMapper = mapperService.GetMapper<Transform>();
    }

    private List<Hitbox> FindValidTargets(Targeter targeter)
    {
        if (targeter.ValidTargets == Targeter.TargetType.Other)
        {
            if (targeter.Self == Player.Id)
            {
                var playerHitBox = _hitboxMapper.Get(Player.Id);
                var allHitboxes = _hitboxMapper.Components;
                // var allHitboxesCount = allHitboxes.Count;
                // var allHitboxesSize = allHitboxes.Capacity;
                // var weaponsCount = _weaponMapper.Components.Count;
                // var creaturesCount = _playerMapper.Components.Count;
                // var targetersCount = _targeterMapper.Components.Count;
                // var transformsCount = _transformMapper.Components.Count;
                var filteredHitboxes = allHitboxes.Where(box => box is not null && playerHitBox != box);
                return filteredHitboxes.ToList();
            }
        }

        return new List<Hitbox>();
    }


    
    public override void Update(GameTime gameTime)
    {
        foreach (var entityId in ActiveEntities)
        {
            foreach (var weaponId in _arsenalMapper.Get(entityId).Weapons)
            {
                var targeter = _targeterMapper.Get(weaponId);
                var validTargets = FindValidTargets(targeter);
                targeter.FindTarget(validTargets);
            }
        }
    }
}