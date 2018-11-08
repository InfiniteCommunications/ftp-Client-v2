using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for SaveFileNameAs.xaml
    /// </summary>
    public partial class SaveFileNameAs : Window
    {
        public SaveFileNameAs()
        {
            InitializeComponent();
        }
        private string _connStr = Properties.Settings.Default.PACSystemConnectionString;
        private string dateSave = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
        private string recordPerson = "wan chin";
        string idSound = "3";

        //get and set value from input
        public string _id
        {
            get { return idSound; }
            set { idSound = value; }
        }
        public string _title
        {
            get { return titleName.Text; }
            set { titleName.Text = value; }
        }
        public string _description
        {
            get { return descInfo.Text; }
            set { descInfo.Text = value; }
        }

        public string _recordby
        {
            get { return recordPerson; }
            set { recordPerson = value; }
        }
        public string _dateCreate
        {
            get { return dateSave; }
            set { dateSave = value; }
        }

        public void InsertSoundInfo()
        {
            string queryStr = " INSERT INTO soundInfo (_id, soundTitle, soundDescription, " +
                              " recordedBy, dateCreate) " +
                              " VALUES('" +
                    _id + "', '" +
                    _title + "', '" +
                    _description + "', '" +
                    _recordby + "', '" +
                    _dateCreate + "') ";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();
        }
        private void submitInfo(object sender, RoutedEventArgs e)
        {
            InsertSoundInfo();
            DialogResult = true;
        }
    }
}
