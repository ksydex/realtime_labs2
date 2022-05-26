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

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            // base.OnMouseMove(e);

            var pointToWindow = Mouse.GetPosition(this);
            var pointToScreen = PointToScreen(pointToWindow);
            
            if (pointToScreen.X < 100 && pointToScreen.Y < 100) MessageBox.Show("Курсор в левом верхнем углу!");
        }
    }
}