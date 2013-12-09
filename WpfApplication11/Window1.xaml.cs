using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfApplication11
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void listBox1_Loaded(object sender, RoutedEventArgs e)
        {
            System.Data.SqlClient.SqlConnection cnx = new System.Data.SqlClient.SqlConnection(@"server=.;database=AGENDA;Integrated Security =True");
            cnx.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select nombre from dbo.PERSONAS", cnx);
            System.Data.SqlClient.SqlDataReader DR = cmd.ExecuteReader();
            //DR = cmd.ExecuteReader();
            listBox1.Items.Clear();
            while (DR.Read())
            {
                listBox1.Items.Add(DR[0].ToString());
            }
            DR.Close();
            cnx.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            SqlConnection cnx = new SqlConnection(@"server=.;database=AGENDA;Integrated Security =True");
            //SqlCommand cmd = new SqlCommand("REPORTE", cnx);
            SqlCommand cmd = new SqlCommand("ELIMINAR", cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@NOMBRE", System.Data.SqlDbType.Text, 50);
            cmd.Parameters["@NOMBRE"].Value = Convert.ToString(listBox1.SelectedItem);
            cnx.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("ELIMINACION CORRECTA");
            cnx.Close();
            ventana2.Close();
        }
    }
}
