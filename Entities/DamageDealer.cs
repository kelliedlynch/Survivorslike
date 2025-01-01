using Friflo.Engine.ECS;
using NotImplementedException = System.NotImplementedException;

namespace Survivorslike.Entities;

public struct DamageDealer : IComponent
{
    public DamageEffectType EffectType = DamageEffectType.Bullet;
    public int MinTargets = 1;
    public int MaxTargets = 1;
    public int MinHits = 1;
    public int MaxHits = 1;
    public int Damage = 1;
    public float PulseInterval = 0.5f;
    public float PulseDuration = 0.5f;

    public DamageDealer()
    {
    }
}

public enum DamageEffectType
{
    // Hits single target once
    Bullet,
    // Hits up to X targets once
    MultiBullet,
    // Hits up to X targets Y times
    RepeatingMultiBulletDistinct,
    // Hits X times, distributed among up to X targets
    RepeatingMultiBullet,
    // Hits all entities in line containing origin and target
    Beam,
    // Hits all entities in line containing origin and target, repeating at interval X
    SustainedBeam,
    // Hits specified targets (no predetermined limit) X times
    Pulse,
    // Hits specified targets (no predetermined limit), repeating at interval X
    SustainedPulse
}