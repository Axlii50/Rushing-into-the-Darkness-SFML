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
        private RenderWindow render;
        Clock _timer;
        int fpsc = 0;
        const int mWidth = 11;
        const int mHeight = 6;

        Player ePlayer;

        EntityMenager eMenager;

        Map_Meneger mMeneger;


        public Window(RenderWindow Target)
        {
            ePlayer = new Player();
            eMenager = new EntityMenager();
            mMeneger = new Map_Meneger(eMenager);


            render = Target;
            render.KeyPressed += Render_KeyPressed;
            //render.KeyReleased += Render_KeyReleased;
            render.Resized += Render_Resized;


            _timer = new Clock();

            int wid = (int)render.Size.X;
            int hgt = (int)render.Size.Y;
            int hgt2 = (int)(hgt / 2);
            int x = 0;
            bool inc = true;


            RectangleShape rect = new RectangleShape(new Vector2f(wid, hgt))
            {
                //Position = new Vector2f(wid, hgt)
                //Position = new Vector2f(render.Size.X / 2 + 50, render.Size.Y / 2 + 50)
            };


            mMeneger.CreateMap(new char[mWidth * mHeight] { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w',
                                                  'w', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b','b', 'w',
                                                  'w', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b','b', 'w',
                                                  'w', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b','b', 'w',
                                                  'w', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b','b', 'w',
                                                  'w', 'w', 'w', 'w','w', 'b', 'w', 'w', 'w', 'w', 'w',});

            //klasa mapy (wysokosc szerokosc MapCharacters)

            while (render.IsOpen)
            {
                render.DispatchEvents();

                #region Fps
                if (_timer.ElapsedTime.AsMilliseconds() > 250)
                {
                    render.SetTitle(wName + ":" + fpsc * 4);
                    fpsc = 0;
                    _timer.Restart();
                }
                #endregion

                //move actions
                //nie wywoływac jezeli nic nie kliknięte


                ePlayer.MoveEntity(eMenager);
                

                //this.render.Clear(SFML.Graphics.Color.Green);

                //Draw
                #region Raindbow
                if (true)
                {
                    if (inc)
                        x++;
                    else
                        x--;

                    if (x == 0)
                        inc = true;
                    else if (x == wid)
                        inc = false;

                    rect.FillColor = (SFML.Graphics.Color)MapRainbowColor(x, 0, wid);
                    rect.Draw(render, RenderStates.Default);

                }
                #endregion



                //draw things

                //drawing map
                mMeneger.DrawMap(render);

                //rect.Draw(render, RenderStates.Default);

                eMenager.DrawEntities(render);
                ePlayer.EntitySprite.Draw(render, RenderStates.Default);

                render.Display();
                fpsc++;
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

        private SFML.Graphics.Color MapRainbowColor(float value, float red_value, float blue_value)
        {
            // Convert into a value between 0 and 1023.
            int int_value = (int)(1023 * (value - red_value) /
                (blue_value - red_value));

            // Map different color bands.
            if (int_value < 256)
            {
                // Red to yellow. (255, 0, 0) to (255, 255, 0).
                return new SFML.Graphics.Color(255, (byte)int_value, 0);
            }
            else if (int_value < 512)
            {
                // Yellow to green. (255, 255, 0) to (0, 255, 0).
                int_value -= 256;
                return new SFML.Graphics.Color((byte)(255 - int_value), 255, 0);
            }
            else if (int_value < 768)
            {
                // Green to aqua. (0, 255, 0) to (0, 255, 255).
                int_value -= 512;
                return new SFML.Graphics.Color(0, 255, (byte)int_value);
            }
            else
            {
                // Aqua to blue. (0, 255, 255) to (0, 0, 255).
                int_value -= 768;
                return new SFML.Graphics.Color(0, (byte)(255 - int_value), 255);
            }
        }
    }
}
