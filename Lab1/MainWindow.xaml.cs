using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace Labs2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly List<string> ProcessNames = new() { "notepad", "mspaint" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessNames.ForEach(name =>
            {
                var p = new Process();
                p.StartInfo.FileName = name;
                p.Exited += (o, ea) =>
                    Dispatcher.Invoke(() => { Process.Start("calc"); });
                p.EnableRaisingEvents = true;
                p.Start();
            });
        }
    }
}