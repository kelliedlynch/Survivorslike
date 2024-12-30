using MonoGame.Extended.Collections;
using MonoGame.Extended.ECS;
using Survivorslike.Entities;

namespace Survivorslike.Component;

public class Arsenal
{
    public Bag<int> Weapons { get; set; } = new ();
}