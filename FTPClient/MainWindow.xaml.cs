using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace FTPClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        System.Timers.Timer timer1 = new System.Timers.Timer();
        List<System.Windows.Media.MediaPlayer> sounds = new List<System.Windows.Media.MediaPlayer>();


        //Datagrid 
        PACSystemEntities _db = new PACSystemEntities();
        public static DataGrid gridData;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += onLoad;
        }

        private void onLoad(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
            ResizeMode = ResizeMode.NoResize;
            Loaded -= onLoad;
            recordTable.ItemsSource = _db.soundInfoes.ToList();
            gridData = recordTable;
        }

        #region buttonFunction
        private void startRecording(object sender, RoutedEventArgs e)
        {
            mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
            mciSendString("record recsound", "", 0, 0);
        }

        private void stopRecording(object sender, RoutedEventArgs e)
        {
            var dialogSave = new SaveFileNameAs();
            if (dialogSave.ShowDialog() == true)
            {
                string title = dialogSave._title;
                string todayDate = DateTime.Now.ToString("yyyyMMdd");


                mciSendString("save recsound c:\\Uploaded\\" + todayDate + "_" + title + ".wav", "", 0, 0);
                mciSendString("close recsound ", "", 0, 0);
            }
        }

        private void browseFile_Click(object sender, RoutedEventArgs e)
        {

        }


        private void editClick(object sender, RoutedEventArgs e)
        {
            int id = (recordTable.SelectedItem as soundInfo).C_id;
            EditRecord edit = new EditRecord(id);
            edit.ShowDialog();
        }

        private void addClick(object sender, RoutedEventArgs e)
        {
            int id = (recordTable.SelectedItem as soundInfo).C_id;
            NewSchedule addSchedule = new NewSchedule(id);
            addSchedule.ShowDialog();
        }

        private void deleteClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to delete the record?", "Alert", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                int Id = (recordTable.SelectedItem as soundInfo).C_id;
                var deleteSound = _db.soundInfoes.Where(m => m.C_id == Id).Single();
                _db.soundInfoes.Remove(deleteSound);
                _db.SaveChanges();
                recordTable.ItemsSource = _db.soundInfoes.ToList();
            }
            else
            {
                recordTable.ItemsSource = _db.soundInfoes.ToList();
            }

        }
        #endregion

    }
}
