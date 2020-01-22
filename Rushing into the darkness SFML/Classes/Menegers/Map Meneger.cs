using Newtonsoft.Json;
using Rushing_into_the_darkness_SFML.Classes.Entitis;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rushing_into_the_darkness_SFML.Classes.Menegers
{
    public enum TileTypes
    {
        WallR1,
        WallR2,
        WallR3,
        WallR4,
        WallR5,
        WallR6,
        WallR7,
        WallR8,
        WallR9,
        FloorR1,
        FloorR2,
        FloorR3,
        FloorR4,
        FloorR5,
        FloorR6,
        FloorR7,
        FloorR8,
        FloorR9,
        FloorR10,
        none
    }
    class SaveInstance
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public string Characters { get; set; }
    }
    class Map_Meneger
    {
        public List<Tile> MapTiles = new List<Tile>();
        string map = new StreamReader("Resources/t4.json").ReadToEnd();
        private Texture[] ListTexture = { new Texture("Resources/floor_1.png"), new Texture("Resources/floor_2.png"), new Texture("Resources/floor_3.png"), new Texture("Resources/floor_4.png"),
                                          new Texture("Resources/floor_5.png"),new Texture("Resources/floor_6.png"),new Texture("Resources/floor_7.png"),new Texture("Resources/floor_8.png"),
                                          new Texture("Resources/floor_9.png"),new Texture("Resources/floor_10.png"),new Texture("Resources/wall_1.png"),new Texture("Resources/wall_2.png"),
                                          new Texture("Resources/wall_3.png"),new Texture("Resources/wall_crack.png"),
        };



        private EntityMenager eMeneger;

        const int width = 11;
        const int height = 6;

        public Map_Meneger(EntityMenager entityMenager)
        {
            eMeneger = entityMenager;

            CreateMap(map);

        }

        public void CreateMap(string MapCharacters)
        {
            float factor = 16 * Tile.Factor;
            MapTiles.Clear();
            SaveInstance Map = JsonConvert.DeserializeObject<SaveInstance>(MapCharacters);

            int width = Map.Width;
            int height = Map.Height;

            string[] Characters = Map.Characters.Split(',');

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    switch (Characters[(width * j) + i])
                    {
                        case "-":
                            MapTiles.Add(new Tile(i * (int)factor, j * (int)factor, (int)factor,(int)factor,TileTypes.none, null));
                            break;
                        case "f1":
                            MapTiles.Add(new Tile(i * (int)factor, j * (int)factor, (int)factor, (int)factor,TileTypes.FloorR1, ListTexture[0]));
                            break;
                        case "f2":
                            MapTiles.Add(new Tile(i * (int)factor,j * (int)factor, (int)factor, (int)factor, TileTypes.FloorR2, ListTexture[1]));
                            break;
                        case "f3":
                            MapTiles.Add(new Tile(i * (int)factor, j * (int)factor, (int)factor, (int)factor,   TileTypes.FloorR3, ListTexture[2]));
                            break;
                        case "f4":
                            MapTiles.Add(new Tile(i * (int)factor, j * (int)factor, (int)factor, (int)factor,   TileTypes.FloorR4, ListTexture[3]));
                            break;
                        case "f5":
                            MapTiles.Add(new Tile(i * (int)factor, j * (int)factor, (int)factor, (int)factor,  TileTypes.FloorR5, ListTexture[4]));
                            break;
                        case "f6":
                            MapTiles.Add(new Tile(i * (int)factor, j * (int)factor, (int)factor, (int)factor,  TileTypes.FloorR6, ListTexture[5]));
                            break;
                        case "f7":
                            MapTiles.Add(new Tile(i * (int)factor, j * (int)factor, (int)factor, (int)factor,  TileTypes.FloorR7, ListTexture[6]));
                            break;
                        case "f8":
                            MapTiles.Add(new Tile(i * (int)factor, j * (int)factor, (int)factor, (int)factor,  TileTypes.FloorR8, ListTexture[7]));
                            break;
                        case "f9":
                            MapTiles.Add(new Tile(i * (int)factor, j * (int)factor, (int)factor, (int)factor, TileTypes.FloorR9, ListTexture[8]));
                            break;
                        case "f10":
                            MapTiles.Add(new Tile(i * (int)factor, j * (int)factor, (int)factor, (int)factor,  TileTypes.FloorR10, ListTexture[9]));
                            break;
                        case "w1":
                            MapTiles.Add(new Tile(i * (int)factor, j * (int)factor, (int)factor, (int)factor, TileTypes.WallR1, ListTexture[10]));
                            eMeneger.EntitiesSpritesCollision.Add(new Sprite(new Texture(ListTexture[10]), new IntRect(0,0, (int)factor, (int)factor)) { Position = new Vector2f(i * (int)factor, j * (int)factor) });
                            break;
                        case "w2":
                            MapTiles.Add(new Tile(i * (int)factor, j * (int)factor, (int)factor, (int)factor, TileTypes.WallR2, ListTexture[11]));
                            eMeneger.EntitiesSpritesCollision.Add(new Sprite(new Texture(ListTexture[11]), new IntRect(0, 0, (int)factor, (int)factor)) {Position = new Vector2f(i * (int)factor, j * (int)factor)});
                            break;
                        case "w3":
                            MapTiles.Add(new Tile(i * (int)factor, j * (int)factor, (int)factor, (int)factor, TileTypes.WallR3, ListTexture[12]));
                            eMeneger.EntitiesSpritesCollision.Add(new Sprite(new Texture(ListTexture[12]), new IntRect(0, 0, (int)factor, (int)factor)) { Position = new Vector2f(i * (int)factor, j * (int)factor) });
                            break;
                        case "w4":
                            MapTiles.Add(new Tile(i * (int)factor, j * (int)factor, (int)factor, (int)factor, TileTypes.WallR4, ListTexture[13]));
                            eMeneger.EntitiesSpritesCollision.Add(new Sprite(new Texture(ListTexture[13]), new IntRect(0, 0, (int)factor, (int)factor)) { Position = new Vector2f(i * (int)factor, j * (int)factor) });
                            break;
                    }
                }
            }

        }

        public void DrawMap(RenderTarget target, Camera _camera)
        {

            int vx = _camera.CameraViewX;
            int vy = _camera.CameraViewY;

            foreach (Tile c in MapTiles)
            {
                if ((c.TileTexture.Position.X <= _camera.X - 96 || c.TileTexture.Position.X >= _camera.X + _camera.CameraViewX + 96)
                    || (c.TileTexture.Position.Y <= _camera.Y - 96 || c.TileTexture.Position.Y >= _camera.Y + _camera.CameraViewY + 96)) ;
                else
                    c.TileTexture.Draw(target, RenderStates.Default);
            }
        }

        //łądowanie map z json
        //wiecej textur 


    }
}
