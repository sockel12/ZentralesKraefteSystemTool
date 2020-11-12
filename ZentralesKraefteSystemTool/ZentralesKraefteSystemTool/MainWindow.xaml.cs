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
using ZKSTLib;

namespace ZentralesKraefteSystemTool
{
    public partial class MainWindow : Window
    {
        public ZentralesKraefteSystem z;
        public const int length = 120;
        private double force1;
        private double angle1;
        private double angle2;
        private double angle3;

        public MainWindow()
        {
            InitializeComponent();

            DrawGraph();
        }

        public void DrawGraph()
        {
            Line startingLineX = new Line();
            startingLineX.StrokeThickness = 2f;
            startingLineX.Stroke = Brushes.Black;
            startingLineX.X1 = 0;
            startingLineX.Y1 = CV_Graph.Height / 2;
            startingLineX.X2 = CV_Graph.Width;
            startingLineX.Y2 = CV_Graph.Height / 2;

            Line startingLineY = new Line();
            startingLineY.StrokeThickness = 2f;
            startingLineY.Stroke = Brushes.Black;
            startingLineY.X1 = CV_Graph.Width / 2;
            startingLineY.Y1 = 0;
            startingLineY.X2 = CV_Graph.Width / 2;
            startingLineY.Y2 = CV_Graph.Height;

            CV_Graph.Children.Add(startingLineX);
            CV_Graph.Children.Add(startingLineY);
        }

        public void ShowForces()
        {
            CV_Graph.Children.Clear();

            DrawGraph();

            L_Force1.Content = "F₁: " + z.force1;
            L_Force2.Content = "F₂: " + z.force2;
            L_Force3.Content = "F₃: " + z.force3;

            Line force1L = new Line();
            force1L.StrokeThickness = 2f;
            force1L.Stroke = Brushes.Red;
            force1L.X1 = CV_Graph.Width / 2;
            force1L.Y1 = CV_Graph.Height / 2;
            Point force1Point = CalculateGraphs(z.force1);
            force1L.X2 = force1Point.X;
            force1L.Y2 = force1Point.Y;

            Line force2L = new Line();
            force2L.StrokeThickness = 2f;
            force2L.Stroke = Brushes.Blue;
            force2L.X1 = CV_Graph.Width / 2;
            force2L.Y1 = CV_Graph.Height / 2;
            Point force2Point = CalculateGraphs(z.force2);
            force2L.X2 = force2Point.X;
            force2L.Y2 = force2Point.Y;

            Line force3L = new Line();
            force3L.StrokeThickness = 2f;
            force3L.Stroke = Brushes.Green;
            force3L.X1 = CV_Graph.Width / 2;
            force3L.Y1 = CV_Graph.Height / 2;
            Point force3Point = CalculateGraphs(z.force3);
            force3L.X2 = force3Point.X;
            force3L.Y2 = force3Point.Y;

            CV_Graph.Children.Add(force1L);
            CV_Graph.Children.Add(force2L);
            CV_Graph.Children.Add(force3L);

        }

        private Point CalculateGraphs(Force force)
        {
            double middleX =  CV_Graph.Width / 2;
            double middleY =  CV_Graph.Height / 2;
            double x = 0, y = 0;

            if(force.angle <= 90 && force.angle >= 0)
            {
                if(force.angle != 0)
                {
                    x = (length * Math.Cos((Math.PI / 180) * (force.angle)) + middleX);
                }
                else
                {
                    x = middleX;
                }
                if(force.angle != 90)
                {
                    y = (length * Math.Sin((Math.PI / 180) * (force.angle)));
                }
                else
                {
                    y = middleY;
                }
            }
            else if (force.angle > 90 && force.angle <= 180)
            {
                if(force.angle != 180)
                {
                    y = (length * Math.Sin((Math.PI / 180) * (force.angle)));
                }
                else
                {
                    y = middleY;
                }
                x = (length * -Math.Cos((Math.PI / 180) * (force.angle)));
            }
            else if (force.angle > 180 && force.angle <= 270)
            {
                if(force.angle != 270)
                {
                    x = (length * -Math.Cos((Math.PI / 180) * (force.angle)));                    
                }
                else
                {
                    x = middleX;
                }
                y = (length * -Math.Sin((Math.PI / 180) * (force.angle)) + middleY);
            }
            else
            {
                if(force.angle != 360)
                {
                    x = (length * Math.Cos((Math.PI / 180) * (force.angle)) + middleX);
                }
                else
                {
                    x = middleX;
                }
                y = (length * -Math.Sin((Math.PI / 180) * (force.angle)) + middleY);
            }

            return new Point(x,y);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string force1s = TB_Kraft1.Text;
            string angle1s = TB_Winkel1.Text;
            string angle2s = TB_Winkel2.Text;
            string angle3s = TB_Winkel3.Text;

            try
            {
                force1 = double.Parse(force1s);
                angle1 = double.Parse(angle1s);
                angle2 = double.Parse(angle2s);
                angle3 = double.Parse(angle3s);

                z = new ZentralesKraefteSystem(new Force(force1, angle1), angle2, angle3);
                
                ShowForces();
            }
            catch (Exception)
            {
                return;
            }

            
        }

        private void CV_Graph_MouseMove(object sender, MouseEventArgs e)
        {
            int mouseX = (int)(e.GetPosition(CV_Graph).X);
            int mouseY = (int)(e.GetPosition(CV_Graph).Y);
            L_Coords.Content = $"X:{mouseX} Y:{mouseY}";
        }
    }
}
