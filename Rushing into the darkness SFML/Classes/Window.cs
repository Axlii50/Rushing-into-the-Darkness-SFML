using Rushing_into_the_darkness_SFML.Classes;
using Rushing_into_the_darkness_SFML.Classes.Entitis;
using Rushing_into_the_darkness_SFML.Classes.Menegers;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Rushing_into_the_darkness_SFML
{
    class Window
    {
        const string wName = "Rushing Into The Darkness";
        View ViewPoint;
        private RenderWindow render;
        Clock _timer;
        int fps_c = 0;

        Player ePlayer;

        EntityMenager eMenager;

        Map_Meneger mMeneger;


        Camera _camera;

        public Window(RenderWindow Target)
        {
            _camera = new Camera();
            ViewPoint = new View(new FloatRect(0, 0, 400, 250));
            ePlayer = new Player(_camera, ViewPoint);
            eMenager = new EntityMenager(ePlayer);
            mMeneger = new Map_Meneger(eMenager);
            
            

            render = Target;
            render.KeyPressed += Render_KeyPressed;
            //render.KeyReleased += Render_KeyReleased;
            render.Resized += Render_Resized;


            _timer = new Clock();

            int wid = (int)render.Size.X;
            int hgt = (int)render.Size.Y;
            int hgt2 = (int)(hgt / 2);

            Target.SetView(ViewPoint);


            RectangleShape rect = new RectangleShape(new Vector2f(1, 1));
            rect.FillColor = SFML.Graphics.Color.Black;
            //klasa mapy (wysokosc szerokosc MapCharacters)

            while (render.IsOpen)
            {
                render.DispatchEvents();

                #region Fps
                if (_timer.ElapsedTime.AsMilliseconds() > 250)
                {
                    render.SetTitle(wName + ":" + fps_c * 4);
                    fps_c = 0;
                    _timer.Restart();
                }
                #endregion

                //move actions

                
                ePlayer.MoveEntity(eMenager);
                eMenager.MoveEntity();
                

                this.render.Clear(SFML.Graphics.Color.Green);


                Target.SetView(ViewPoint);
                //Draw

                mMeneger.DrawMap(render, _camera);

                eMenager.DrawEntities(render);

                

                //draw things
                //rect.Position = new Vector2f(eMenager._Player.EntitySprite.Position.X, eMenager._Player.EntitySprite.Position.Y);
                //rect.Draw(render, RenderStates.Default);

                ePlayer.EntitySprite.Draw(render, RenderStates.Default);

                render.Display();
                fps_c++;
            }
        }

        private void Render_KeyReleased(object sender, KeyEventArgs e)
        {

        }

        private void Render_Resized(object sender, SizeEventArgs e)
        {
            render.SetView(new View(new Vector2f(render.Size.X / 2, render.Size.Y / 2),new Vector2f(render.Size.X, render.Size.Y)));
        }

        private void Render_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Q)
                eMenager.AddEntity(new TestEntity());
        }
    }
}
