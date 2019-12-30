using Rushing_into_the_darkness_SFML.Classes.Entitis;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rushing_into_the_darkness_SFML.Classes.Menegers
{
    enum CollidersTags
    {
        Collider,
        NonColider
    }
    class EntityMenager
    {

        public EntityMenager()
        {
            this.AddEntity(new TestEntity());
            //this.AddEntity(new TestEntity());
            //this.AddEntity(new TestEntity());
            //this.AddEntity(new TestEntity());
        }



        private List<IEntity> Entities = new List<IEntity>();

        public List<Sprite> EntitiesSpritesCollision = new List<Sprite>();

        /// <summary>
        /// Return list of all entities 
        /// </summary>
        /// <returns></returns>
        public List<IEntity> GetEntities()
        {
            return Entities;
        }

        /// <summary>
        /// Draw sprites of all entities in that menager have 
        /// </summary>
        /// <param name="target"></param>
        public void DrawEntities(RenderWindow target)
        {
            foreach (IEntity x in Entities)
                x.EntitySprite.Draw(target, RenderStates.Default);
        }
        public void AddEntity(IEntity Entity)
        {
            Entities.Add(Entity);
            if (Entity.collider == CollidersTags.Collider)
                EntitiesSpritesCollision.Add(Entity.EntitySprite);
        }
    }
}
