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

        bool activated = false;
        Point point;

        private void CircleKnob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            activated = true;
            point = Mouse.GetPosition(CircleKnob);
            Mouse.Capture(CircleKnob);
        }

        private void CircleKnob_MouseMove(object sender, MouseEventArgs e)
        {
            if (activated)
            {
                double movement = Canvas.GetLeft(CircleKnob) + Mouse.GetPosition(CircleKnob).X - point.X;
                Canvas.SetLeft(CircleKnob, movement);
            }
        }

        private void CircleKnob_MouseUp(object sender, MouseButtonEventArgs e)
        {
            activated = false;
            Mouse.Capture(null);
        }
    }
}
