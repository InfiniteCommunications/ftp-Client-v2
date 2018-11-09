using MahApps.Metro.Controls;
using NAudio.Wave;
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
        List<System.Windows.Media.MediaPlayer> sounds = new List<System.Windows.Media.MediaPlayer>();
        WaveIn wi;
        WaveFileWriter wfw;
        Polyline pl;

        double canH = 0;
        double canW = 0;
        double plH = 0;
        double plW = 0;
        //int time = 0;
        //double seconds = 0;



        List<byte> totalbytes;
        Queue<Point> displaypts;
        //Queue<short> displaysht;
        Queue<Int32> displaysht;


        long count = 0;
        int numtodisplay = 2205;

        //Datagrid 
        PACSystemEntities _db = new PACSystemEntities();
        public static DataGrid gridData;
        public static DataGrid dataGridSchedule;

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
            scheduleTable.ItemsSource = _db.playSchedules.ToList();
            dataGridSchedule = scheduleTable;
        }

        #region buttonFunction
        private void startRecording(object sender, RoutedEventArgs e)
        {
            var dialogSave = new SaveFileNameAs();
            if (dialogSave.ShowDialog() == true)
            {
                string title = dialogSave._title;
                string todayDate = DateTime.Now.ToString("yyyyMMdd");
                string saveAsName = "c:\\Uploaded\\"+todayDate+"_"+title+".wav";
                StartRecording(saveAsName);
            }
        }

        private void stopRecording(object sender, RoutedEventArgs e)
        {
            wi.StopRecording();
            canH = 0;
            count = 0;
            canW = 0;
            plH = 0;
            plW = 0;

            this.waveCanvas.Children.Clear();
            pl.Points.Clear();
            recordTable.ItemsSource = _db.soundInfoes.ToList();
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

        private void deleteScheduleClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to delete the schedule?", "Alert", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                int Id = (scheduleTable.SelectedItem as playSchedule).id;
                var deleteSchedule = _db.playSchedules.Where(m => m.id == Id).Single();
                _db.playSchedules.Remove(deleteSchedule);
                _db.SaveChanges();
                scheduleTable.ItemsSource = _db.playSchedules.ToList();
            }
            else
            {
                scheduleTable.ItemsSource = _db.playSchedules.ToList();
            }

        }

        private void editScheduleClick(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region recording function
        void StartRecording(string name)
        {
            wi = new WaveIn();
            wi.DataAvailable += new EventHandler<WaveInEventArgs>(wi_DataAvailable);
            wi.RecordingStopped += new EventHandler<StoppedEventArgs>(wi_RecordingStopped);
            wi.WaveFormat = new WaveFormat(44100, 32, 2);


            wfw = new WaveFileWriter(name, wi.WaveFormat);


            canH = waveCanvas.Height;
            canW = waveCanvas.Width;


            pl = new Polyline();
            pl.Stroke = Brushes.Blue;
            pl.Name = "waveform";
            pl.StrokeThickness = 1;
            pl.MaxHeight = canH - 4;
            pl.MaxWidth = canW - 4;


            plH = pl.MaxHeight;
            plW = pl.MaxWidth;


           // this.time = time;


            displaypts = new Queue<Point>();
            totalbytes = new List<byte>();
            displaysht = new Queue<Int32>();


            wi.StartRecording();
        }

        void wi_RecordingStopped(object sender, EventArgs e)
        {
            wi.Dispose();
            wi = null;
            wfw.Close();
            wfw.Dispose();


            wfw = null;
        }


        void wi_DataAvailable(object sender, WaveInEventArgs e)
        {
            //seconds += (double)(1.0 * e.BytesRecorded / wi.WaveFormat.AverageBytesPerSecond * 1.0);
            //if (seconds > time)
            //{
            //    wi.StopRecording();


            //    canH = 0;
            //    count = 0;
            //    canW = 0;
            //    plH = 0;
            //    plW = 0;
            //    time = 0;
            //    seconds = 0;
            //}


            wfw.Write(e.Buffer, 0, e.BytesRecorded);
            totalbytes.AddRange(e.Buffer);


            //byte[] shts = new byte[2];
            byte[] shts = new byte[4];


            for (int i = 0; i < e.BytesRecorded - 1; i += 100)
            {
                shts[0] = e.Buffer[i];
                shts[1] = e.Buffer[i + 1];
                shts[2] = e.Buffer[i + 2];
                shts[3] = e.Buffer[i + 3];
                if (count < numtodisplay)
                {
                    displaysht.Enqueue(BitConverter.ToInt32(shts, 0));
                    ++count;
                }
                else
                {
                    displaysht.Dequeue();
                    displaysht.Enqueue(BitConverter.ToInt32(shts, 0));
                }
            }
            this.waveCanvas.Children.Clear();
            pl.Points.Clear();
            //short[] shts2 = displaysht.ToArray();
            Int32[] shts2 = displaysht.ToArray();
            for (Int32 x = 0; x < shts2.Length; ++x)
            {
                pl.Points.Add(Normalize(x, shts2[x]));
            }



            this.waveCanvas.Children.Add(pl);


        }


        Point Normalize(Int32 x, Int32 y)
        {
            Point p = new Point();


            p.X = 1.0 * x / numtodisplay * plW;
            //p.Y = plH/2.0 - y / (short.MaxValue*1.0) * (plH/2.0);
            p.Y = plH / 2.0 - y / (Int32.MaxValue * 1.0) * (plH / 2.0);
            return p;
        }
        #endregion
    }
}
