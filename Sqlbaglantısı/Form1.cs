using System.Data.SqlClient;

namespace Sqlbaglantısı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source=DESKTOP-1E1FE4Q\SQLEXPRESS;Initial Catalog=ogrenci;Integrated Security=True;TrustServerCertificate=True");
                baglanti.Open();

                SqlCommand sqlKomut = new SqlCommand("SELECT OgrenciID, OgrenciAdı, not1, not2 ,sehir FROM tablee", baglanti);
                SqlDataReader sqlDR = sqlKomut.ExecuteReader();

                while (sqlDR.Read())
                {
                    string OgrenciID = sqlDR[0].ToString();
                    string OgrenciAdı = sqlDR[1].ToString();
                    string not1 = sqlDR[2].ToString();
                    string not2 = sqlDR[3].ToString();
                    string sehir = sqlDR[4].ToString();

                    richTextBox1.Text = richTextBox1.Text + OgrenciID + " " + OgrenciAdı + " " + " " + "Not1 : " + not1 + " " + "Not2 : " + " " + " " + not2 + " " + " " + "Şehir : " + " " + sehir + "\n";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("SQL Query Sırasında bir hata oluştur !" + Ex.ToString());
            }
            finally
            {
                if (baglanti != null)
                    baglanti.Close();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source=DESKTOP-1E1FE4Q\SQLEXPRESS;Initial Catalog=ogrenci;Integrated Security=True;TrustServerCertificate=True");
                baglanti.Open();

                SqlCommand sqlKomut = new SqlCommand("SELECT * FROM tablee WHERE genelnot > 50;", baglanti);
                SqlDataReader sqlDR = sqlKomut.ExecuteReader();

                while (sqlDR.Read())
                {
                    string OgrenciID = sqlDR[1].ToString();
                    string OgrenciAdı = sqlDR[2].ToString();
                    string not1 = sqlDR[3].ToString();
                    string not2 = sqlDR[4].ToString();
                    string sehir = sqlDR[5].ToString();
                    string genelnot = sqlDR[6].ToString();
                   

                    richTextBox1.Text = richTextBox1.Text+ "Not Ortalaması : " + genelnot +"\n";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("SQL Query Sırasında bir hata oluştur !" + Ex.ToString());
            }
            finally
            {
                if (baglanti != null)
                    baglanti.Close();
            }
        }
    }
}
