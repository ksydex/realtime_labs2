using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            new Thread(Loop).Start();
        }
        
        public void Loop()
        {
            var semaphore = new Semaphore(0, 3, Sync.SemaphoreName);
            while (true)
            {
                if(semaphore.WaitOne(500))
                    Dispatcher.Invoke(new Action<string>(value => TextBlockValue.Text = value), Sync.Read());
            }
        }

        private void Btn_OnClick(object sender, RoutedEventArgs e)
        {
            var incV = int.TryParse(TextBoxValue.Text, out var vvv) ? vvv : 1;
            var v = (int.TryParse(Sync.Read(), out var vv) ? vv : 0) + incV;
            Sync.Write(v.ToString());
            var sem = Semaphore.OpenExisting(Sync.SemaphoreName);
            sem.Release();
            TextBlockValue.Text = v.ToString();
        }
    }
}