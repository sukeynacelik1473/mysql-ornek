using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace örnek
{
    public partial class fromFilmElestiri : Form
    {
        string baglantiMetin = "Server=localhost;Database=film_arsiv;Uid=root;Pwd='';";
        public fromFilmElestiri()
        {
            InitializeComponent();
        }

        private void fromFilmElestiri_Load(object sender, EventArgs e)
        {

            using (MySqlConnection baglan = new MySqlConnection(baglantiMetin))
            {
                baglan.Open();//veritabanı bağlantısı aç
                string sorgu = "SELECT filmler.film_id,film_ad,tur,elestiri_metin,elestirmen FROM elestiriler \r\nJOIN filmler ON filmler.film_id = elestiriler.film_id\r\nORDER BY filmler.film_id ASC;";//sorgu

                MySqlCommand cmd = new MySqlCommand(sorgu, baglan);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
