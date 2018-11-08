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
using System.Windows.Shapes;

namespace FTPClient
{
    /// <summary>
    /// Interaction logic for EditRecord.xaml
    /// </summary>
    public partial class EditRecord : Window
    {
        PACSystemEntities _db = new PACSystemEntities();
        int Id = 0;
       
        public EditRecord(int soundId)
        {
            InitializeComponent();
            Id = soundId;
            soundInfo selectData = (from s in _db.soundInfoes
                                   where s.C_id == soundId
                                   select s).Single();

            soundTitle.Text = selectData.soundTitle;
            soundDesc.Text = selectData.soundDescription;
            recordBy.Text = selectData.recordedBy;
        }

        private void updateData(object sender, RoutedEventArgs e)
        {
            soundInfo editSound = (from s in _db.soundInfoes
                                   where s.C_id == Id
                                   select s).Single();
            editSound.soundDescription = soundDesc.Text;
            _db.SaveChanges();
            MainWindow.gridData.ItemsSource = _db.soundInfoes.ToList();
            this.Hide();
        }
    }
}
