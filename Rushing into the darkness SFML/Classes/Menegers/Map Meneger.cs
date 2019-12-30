using Rushing_into_the_darkness_SFML.Classes.Entitis;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rushing_into_the_darkness_SFML.Classes.Menegers
{
    enum MapTileType
    {
        surface,
        wall,
        none
    }
    class Map_Meneger
    {
        public List<Tile> MapTiles = new List<Tile>();

        private EntityMenager eMeneger;

        const int width = 11;
        const int height = 6;

        public Map_Meneger(EntityMenager entityMenager)
        {
            eMeneger = entityMenager;
        }

        public void CreateMap(char[] MapCharacters)
        {
            MapTiles.Clear();
            int y = 0;
            int x = 0;
            for (int i = 0; i < MapCharacters.Length; i++)
            {
                if (width == x/32)
                {
                    y += 32;
                    x = 0;
                }
                Tile tile = new Tile();
                tile.TileTexture = GetTileTexture(MapCharacters[i]);

                tile.TileType = GetTileType(MapCharacters[i]);
                if (tile.TileType == MapTileType.wall)
                    eMeneger.EntitiesSpritesCollision.Add(tile.TileTexture);

                tile.TileTexture.Scale = new Vector2f(2, 2);
                x += 32;
                tile.TileTexture.Position = new SFML.System.Vector2f(x - 32, y);
               
                MapTiles.Add(tile);
            }
        }

        private Sprite GetTileTexture(char e)
        {
            switch (e)
            {
                case 'w': //wall
                    return new Sprite(new Texture("Resources/MapSprite.png"), new IntRect(16, 16, 16, 16));
                case 'b': //surface / blank
                    return new Sprite(new Texture("Resources/MapSprite.png"), new IntRect(32, 48, 16, 16));
                default:
                    return null;
            }
        }
        private MapTileType GetTileType(char e)
        {
            switch (e)
            {
                case 'w': 
                    return MapTileType.wall;
                case 'b': 
                    return MapTileType.surface;
                default:
                    return MapTileType.none;
            }
        }
        public void DrawMap(RenderTarget target)
        {
            foreach (Tile x in MapTiles)
                x.TileTexture.Draw(target,RenderStates.Default);
        }
    }
}
