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
        public const int length = 30;
        private double force1;
        private double angle1;
        private double angle2;
        private double angle3;

        public MainWindow()
        {
            InitializeComponent();

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
            Line force1L = new Line();
            force1L.StrokeThickness = 2f;
            force1L.Stroke = Brushes.Red;
            force1L.X1 = CV_Graph.Width / 2;
            force1L.Y1 = CV_Graph.Height / 2;
            force1L.X2 = 0;
            force1L.Y2 = 0;

            Line force2L = new Line();
            force2L.StrokeThickness = 2f;
            force2L.Stroke = Brushes.Blue;
            force2L.X1 = CV_Graph.Width / 2;
            force2L.Y1 = CV_Graph.Height / 2;
            force2L.X2 = 0;
            force2L.Y2 = 0;

            Line force3L = new Line();
            force3L.StrokeThickness = 2f;
            force3L.Stroke = Brushes.Green;
            force3L.X1 = CV_Graph.Width / 2;
            force3L.Y1 = CV_Graph.Height / 2;
            force3L.X2 = 0;
            force3L.Y2 = 0;
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
            }
            catch (Exception)
            { }

            ShowForces();
        }
    }
}
