using System;
using System.ComponentModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lesson03;

public class LoopGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _pixel;

    private Vector2 _position, _dimensions;

    private int _count;

    private float _spacing, _distance, _degreeOffset;
    
    private Rectangle[] _rectangles;
    public LoopGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _position = new Vector2(GraphicsDevice.Viewport.Width/2, GraphicsDevice.Viewport.Height/2);
        _dimensions = new Vector2(50, 50);
        _count = 10;
        _spacing = 10;
        _rectangles = new Rectangle[_count];
        _distance = 125;
        _degreeOffset = 0;
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        _pixel = new Texture2D(GraphicsDevice, 1, 1);
        _pixel.SetData(new [] {Color.White});
        
    }

    protected override void Update(GameTime gameTime)
    {
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        if (_degreeOffset >= Math.PI*2)
        {
            _degreeOffset = 0;
        }
        else
        {
            _degreeOffset += (float)(1 * gameTime.ElapsedGameTime.TotalSeconds);
        }
        float degs = 360f / (_count);
        
        for (int i = 0; i < _count; i++)
        {
            float newRadians = (float)((i * degs) * Math.PI / 180);

            float new_x = (float)Math.Cos(newRadians + _degreeOffset) * _distance;
            float new_y = (float)Math.Sin(newRadians + _degreeOffset) * _distance;

            int position_x = (int)(_position.X + new_x - (_dimensions.X / 2));
            int position_y = (int)(_position.Y + new_y - (_dimensions.Y / 2));
            Rectangle rect = new Rectangle(position_x, position_y, (int)_dimensions.X, (int)_dimensions.Y);
            
            _rectangles[i] = rect;
        }
        
        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        
        foreach (Rectangle rect in _rectangles)
        {
            _spriteBatch.Draw(_pixel, rect, Color.BlueViolet);   
        }
        
        
        
        
        
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}