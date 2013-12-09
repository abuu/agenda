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
using System.Data;
using System.Data.SqlClient;


namespace WpfApplication11
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> x = new List<string>();
            SqlConnection cnx = new SqlConnection(@"server=.;database=AGENDA;Integrated Security =True");
            SqlCommand cmd = new SqlCommand("informacion", cnx);
            cnx.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@NOMBRE", System.Data.SqlDbType.Text, 50);
            cmd.Parameters["@NOMBRE"].Value = Convert.ToString(listBox1.SelectedItem);
            System.Data.SqlClient.SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                x.Add(DR[0].ToString());
                x.Add(DR[1].ToString());
                x.Add(DR[2].ToString());
                x.Add(DR[3].ToString());
                x.Add(DR[4].ToString());
                x.Add(DR[5].ToString());
                x.Add(DR[6].ToString());
                x.Add(DR[7].ToString());
            }
            DR.Close();
            cnx.Close();
            for (int z = 0; z < 8; z++)
            { 
                switch (z)
                {
                    case 0:
                        {
                            textBox1.Text = x[z];
                            break;
                        }
                    case 1:
                        {
                            textBox2.Text = x[z];
                            break;
                        }
                    case 2:
                        {
                            textBox3.Text = x[z];
                            break;
                        }
                    case 3:
                        {
                            textBox4.Text = x[z];
                            break;
                        }
                    case 4:
                        {
                            textBox5.Text = x[z];
                            break;
                        }
                    case 5:
                        {
                            textBox6.Text =x[z];
                            break;
                        }
                    case 6:
                        {
                            textBox7.Text =x[z];
                            break;
                        }
                    case 7:
                        {
                            textBox8.Text =x[z];
                            break;
                        }
                }
            }
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

        private void ventana4_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection cnx = new SqlConnection("server=.; database=AGENDA; Integrated Security=true");
            SqlCommand cmd = new SqlCommand("ALTERAR_CONTACTO", cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@NOMBRE", System.Data.SqlDbType.Text, 50);
            cmd.Parameters.Add("@APELLIDOS", System.Data.SqlDbType.Text, 100);
            cmd.Parameters.Add("@E_MAIL", System.Data.SqlDbType.Text, 100);
            cmd.Parameters.Add("@FECH_NAC", System.Data.SqlDbType.Date);
            cmd.Parameters.Add("@DNI", System.Data.SqlDbType.Text, 8);
            cmd.Parameters.Add("@TELEFONO", System.Data.SqlDbType.Text, 15);
            cmd.Parameters.Add("@DIRECCION", System.Data.SqlDbType.Text, 100);
            cmd.Parameters.Add("@CELULAR", System.Data.SqlDbType.Text, 15);
            cmd.Parameters["@NOMBRE"].Value = textBox1.Text;
            cmd.Parameters["@APELLIDOS"].Value = textBox2.Text;
            cmd.Parameters["@E_MAIL"].Value = textBox3.Text;
            cmd.Parameters["@FECH_NAC"].Value = textBox4.Text;
            cmd.Parameters["@DNI"].Value = textBox5.Text;
            cmd.Parameters["@TELEFONO"].Value = textBox6.Text;
            cmd.Parameters["@DIRECCION"].Value = textBox7.Text;
            cmd.Parameters["@CELULAR"].Value = textBox8.Text;
            cnx.Open();
            cmd.ExecuteNonQuery();
            cnx.Close();
            ventana4.Close();
        }
    }
}

