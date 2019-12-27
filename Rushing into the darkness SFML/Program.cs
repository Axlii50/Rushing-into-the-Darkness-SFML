using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rushing_into_the_darkness_SFML
{
    class Program
    {
        static RenderWindow _Window = new RenderWindow(new VideoMode(800, 600), "Smlf Window");

        static void Main(string[] args)
        {
            _Window.SetFramerateLimit(60);

            _Window.LostFocus += _Window_LostFocus;
            _Window.GainedFocus += _Window_GainedFocus;
            _Window.Closed += _Window_Closed;

            Window _win = new Window(_Window);  
        }

        private static void _Window_Closed(object sender, EventArgs e)
        {
            _Window.Close();
        }

        private static void _Window_GainedFocus(object sender, EventArgs e)
        {
            _Window.SetFramerateLimit(60);
        }

        private static void _Window_LostFocus(object sender, EventArgs e)
        {
            _Window.SetFramerateLimit(20);
        }
    }
}
