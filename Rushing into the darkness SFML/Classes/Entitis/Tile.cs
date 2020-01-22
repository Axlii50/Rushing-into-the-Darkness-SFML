using Rushing_into_the_darkness_SFML.Classes.Menegers;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rushing_into_the_darkness_SFML.Classes.Entitis
{
    class Tile
    {
        public static float Factor = 1.5f;
        public static int Size = 16;
        public TileTypes TileType { get; set; }
        public Sprite TileTexture { get; set; }

        public Tile(int x, int y,int height, int width, TileTypes type, Texture textureSprite)
        {
            TileTexture = new Sprite(textureSprite);
            TileTexture.Scale = new SFML.System.Vector2f(Factor, Factor);
            TileTexture.Position = new SFML.System.Vector2f(x, y);
            TileTexture.TextureRect = new IntRect(0, 0, (int)(width / Factor), (int)(height / Factor));
            TileType = type;
        }
    }
}
