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

        void MoveEntity(EntityMenager eMenager);

        void CollisionOccureKey(EntityMenager eMenager, Keyboard.Key lastkey);
        void CollisionOccureWay(EntityMenager eMenager, int way);

        Vector2f GetCords();

        CollidersTags collider { get; }

    }
}
