using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Friflo.Engine.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Survivorslike.Component;

namespace Survivorslike.Entities;

public static class Monster
{
    private static Random _random = new Random();
    
    public static Entity NewMonster(Game game, EntityStore world, int id)
    {
        var monster = world.CreateEntity();
        var jsonString = new StreamReader("Data/MonsterData.json").ReadToEnd();
        var mData = JsonSerializer.Deserialize<List<MonsterData>>(jsonString)[id];
        
        var loc = new EntityLocation(){ Position = Vector2.One, Size = new Vector2(mData.Width, mData.Height) };
        monster.AddComponent(loc);
        
        var hitbox = new Hitbox() { Size = loc.Size };
        monster.AddComponent(hitbox);
        
        var sprite = new Sprite( game.Content.Load<Texture2D>($"Graphics/Monster/{mData.Texture}"));
        monster.AddComponent(sprite);
        
        return monster;
    }
}

public struct MonsterData
{
    public string Name { get; set; }
    public string Texture { get; set; }
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Width { get; set; }
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Height { get; set; }
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public float HitPoints { get; set; }
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public float MoveSpeed { get; set; }
}