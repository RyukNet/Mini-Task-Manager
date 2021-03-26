using System;
using System.Windows;
using System.Diagnostics;

namespace MiniTaskManager
{
    /// <summary>
    /// Interaction logic for LaunchProcessWindow.xaml
    /// </summary>
    public partial class LaunchProcessWindow : Window
    {
        public LaunchProcessWindow()
        {
            InitializeComponent();
        }

        private void RunByProcessName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(ProcessNameTextBox.Text);
            }
            catch(Exception ex)
            {
                
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
