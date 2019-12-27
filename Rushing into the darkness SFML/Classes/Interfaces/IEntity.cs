using Rushing_into_the_darkness_SFML.Classes.Menegers;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rushing_into_the_darkness_SFML.Classes
{
    interface IEntity
    {
        float Speed { get; }

        Sprite EntitySprite { get; }

        //void Move(EntityMenager eMenager, Keyboard.Key);

        Vector2f GetCords();

        float getCordsX();

        float GetCrodsY();

        CollidersTags collider { get; }

        //void CollisionOccure(EntityMenager eMenager, ref bool left, ref bool right, ref bool up, ref bool down);
    }
}
