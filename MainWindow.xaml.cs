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
using System.Windows.Threading;

namespace gamePhonk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int x = 1, y = 100; // coordinat Racquet
        int xAI = 888, yAI = 100; // coordinat AI
        int xB = 200, yB = 200; // coordinat Ball
        Rectangle rect = new Rectangle();
        Rectangle rectAI = new Rectangle();
        Ellipse el = new Ellipse();
        bool upD = true, rightD = true;
        public MainWindow()
        {
            InitializeComponent();
            el.Visibility = Visibility.Hidden;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            paintRac();
            paintRacAI();
            paintBall();

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Key k = e.Key;
            switch (k)
            {
                case Key.Space: timer.Start(); break;
                case Key.W: if (y < win.Height - 135) y += 50; break;
                case Key.S: if (y > 0) y -= 50; break;
                case Key.Up: if (yAI < win.Height - 135) yAI += 50; break;
                case Key.Down: if (yAI > 0) yAI -= 50; break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (upD) yB += 5;
            else yB -= 5;
            if (rightD) xB += 5;
            else xB -= 5;
            if (xB > win.Width - 25) rightD = false;
            if (xB < 0) rightD = true;
            if (yB > win.Height - 25) upD = false;
            if (yB < 0) upD = true;
            el.Visibility = Visibility.Visible;
            paintRac();
            paintRacAI();
            paintBall();
        }

        private void paintRac()
        {
            map.Children.Remove(rect);
            rect.Width = 7;
            rect.Height = 100;
            rect.StrokeThickness = 1;
            rect.Stroke = Brushes.Black;
            rect.Fill = Brushes.Crimson;
            Canvas.SetLeft(rect, x);
            Canvas.SetBottom(rect, y);
            map.Children.Add(rect);
        }

        private void paintRacAI()
        {
            map.Children.Remove(rectAI);
            rectAI.Width = 7;
            rectAI.Height = 100;
            rectAI.StrokeThickness = 1;
            rectAI.Stroke = Brushes.Black;
            rectAI.Fill = Brushes.Crimson;
            Canvas.SetLeft(rectAI, xAI);
            Canvas.SetBottom(rectAI, yAI);
            map.Children.Add(rectAI);
        }

        private void paintBall()
        {
            map.Children.Remove(el);
            el.Width = 20;
            el.Height = 20;
            el.StrokeThickness = 1;
            el.Stroke = Brushes.Black;
            el.Fill = Brushes.Green;
            Canvas.SetLeft(el, xB);
            Canvas.SetBottom(el, yB);
            map.Children.Add(el);
        }
    }
}