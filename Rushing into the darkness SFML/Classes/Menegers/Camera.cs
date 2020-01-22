using Rushing_into_the_darkness_SFML.Classes.Entitis;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rushing_into_the_darkness_SFML.Classes.Menegers
{
    class Camera
    {
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;

        static int TileSize = (int)(Tile.Size * Tile.Factor);
        const int TileCount = 7;

        public int CameraViewX { get; } = (TileCount+2) * TileSize;
        public int CameraViewY { get; } = TileCount * TileSize;

        public Vector2f PlayerPose { get; set; }

        public void Move(Player Player)
        {
            X = (int)(Player.EntitySprite.Position.X - (this.CameraViewX / 2)) + Player.EntitySprite.TextureRect.Width / 2 < 0 
                ? 0 : (int)(Player.EntitySprite.Position.X - (CameraViewX / 2)) + Player.EntitySprite.TextureRect.Width/2;
            Y = (int)(Player.EntitySprite.Position.Y - (this.CameraViewY / 2)) + Player.EntitySprite.TextureRect.Height / 2 < 0 
                ? 0 : (int)(Player.EntitySprite.Position.Y - (CameraViewY / 2)) + Player.EntitySprite.TextureRect.Height / 2;
        }
    }
}
