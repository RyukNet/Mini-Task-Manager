using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows;

namespace MiniTaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LaunchProcessWindow LPWindow = new LaunchProcessWindow();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ProcessesViewModel();
        }

        private void endProcess(object sender, RoutedEventArgs e)
        {
            var listBoxItem = listBox.SelectedItem;
            Process process;
            process = (Process)listBoxItem;
            try
            {
                
                process.Kill();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show(process.ProcessName + " Kiled succefully");
        }

        private void NewProcessButton_Click(object sender, RoutedEventArgs e)
        {
            if (LPWindow.IsVisible)
            {
                LPWindow.Activate();
            }
            else
            {
                LPWindow.Show();
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
