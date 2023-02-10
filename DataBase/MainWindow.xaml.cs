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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Windows.Markup;
using System.Runtime.Remoting.Messaging;

namespace DataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;


        public MainWindow()
        {
            InitializeComponent();

            cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Employee.accdb");

            cn.Open();
        }

        private void See_Assets_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";

            OleDbCommand cmd = new OleDbCommand(query, cn);


            OleDbDataReader reader = cmd.ExecuteReader();

            string data = "";

             while (reader.Read())
            {

                data += "Item ID: " + reader[0].ToString() + "\n";
                data += "Name: " + reader[1] + "\n";
                data += "Employee ID (Owner): " + reader[2].ToString() + "\n";
                data += "Description: " + reader[3] + "\n\n";

                Textbox1.Text = data;
             }


        }

        private void See_Employee_Click(object sender, RoutedEventArgs e)
        {
            int fieldNum = 0;

            string query = "select * from Employees";

            OleDbCommand cmd = new OleDbCommand(query, cn);

            OleDbDataReader reader = cmd.ExecuteReader();

            string data = "";

            while (reader.Read())
            {

                data += "Employee ID: " + reader[0].ToString() + "\n";
                data += "Name: " + reader[1] + ", " + reader[2] + "\n\n";

                Textbox2.Text = data;
            }
        }
    }
}
