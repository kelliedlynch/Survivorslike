using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Survivorslike.Component;

public class Sprite
{
    private Game _game;

    private string _filename = "Graphics/dickbutt";
    public string Filename => _filename;
    public Texture2D Texture { get; set; }

    public Sprite(Game game, string filename)
    {
        _game = game;
        _filename = filename;
        Texture = game.Content.Load<Texture2D>(filename);
    }

    public Sprite(Game game, Texture2D texture)
    {
        _game = game;
        Texture = texture;
    }

    public void SetFilename(string filename)
    {
        _filename = filename;
        Texture = _game.Content.Load<Texture2D>(filename);
    }
    
}