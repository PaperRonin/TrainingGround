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

namespace AsyncMockDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private async void Wait(Task task, string waitingStatus, string finishedStatus)
        {
            DbDisconnectButton.IsEnabled = false;
            DbConnectButton.IsEnabled = false;
            int dotCounter = 0;
            while (task.Status != TaskStatus.RanToCompletion)
            {
                dotCounter = dotCounter == 3 ? 1 : ++dotCounter;
                StatusBlock.Text = waitingStatus + new string('.', dotCounter);
                await Task.Delay(500);
            }
            await task;
            DbDisconnectButton.IsEnabled = true;
            DbConnectButton.IsEnabled = true;
            StatusBlock.Text = finishedStatus;
        }

        public MockDb Db { get; }
        public MainWindow()
        {
            InitializeComponent();
            Db = new MockDb();
        }

        private void DbConnect_OnClick(object sender, RoutedEventArgs e)
        {

            Wait(Db.Connect(), "Connecting", "Connected");

        }

        private void DbDisconnect_OnClick(object sender, RoutedEventArgs e)
        {
            Wait(Db.Disconnect(), "Disconnecting", "Disconnected");
        }
    }
}
