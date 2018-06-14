using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SwitchButton
{
    public partial class Switcher : Window
    {
        public Switcher()
        {
            InitializeComponent();
        }

        bool Action = false;
        double   InitPxls = 15;
        double FinitePxls = 420;
        double Movement;
        Point Point;

        private void CircleKnob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Action = true;
            Point = Mouse.GetPosition(CircleKnob);
            Mouse.Capture(CircleKnob);
        }

        private void CircleKnob_MouseMove(object sender, MouseEventArgs e)
        {
            if (Action)
            {
                Movement = Canvas.GetLeft(CircleKnob) + Mouse.GetPosition(CircleKnob).X - Point.X;

                if (Movement > InitPxls && Movement < FinitePxls) {
                    Canvas.SetLeft(CircleKnob, Movement);
                    Canvas.SetLeft(CircleShadow, Movement - 15);
                }
            }
        }

        private void CircleKnob_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Action = false;
            Mouse.Capture(null);

            if (Movement < InitPxls + 210)
            {
                Canvas.SetLeft(CircleKnob,   InitPxls);
                Canvas.SetLeft(CircleShadow, InitPxls - 15);
            }
            else
            {
                Canvas.SetLeft(CircleKnob, FinitePxls);
                Canvas.SetLeft(CircleShadow, FinitePxls - 15);
            }
        }
    }
}
