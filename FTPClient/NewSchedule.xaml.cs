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
    /// Interaction logic for NewSchedule.xaml
    /// </summary>
    public partial class NewSchedule : Window
    {
        int Id;
        PACSystemEntities _db = new PACSystemEntities();
        public NewSchedule( int soundId)
        {
            InitializeComponent();
            Id = soundId;
            soundInfo selectData = (from s in _db.soundInfoes
                                    where s.C_id == soundId
                                    select s).Single();
            string soundTitle = selectData.soundTitle;
        }
    }
}
