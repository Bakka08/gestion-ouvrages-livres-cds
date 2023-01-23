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

namespace ouvrage
{
    public partial class Form1 : Form
    {
        string parametres = "SERVER=127.0.0.1; DATABASE=ouvrages; UID=root; PASSWORD=";
        private MySqlConnection maconnexion;
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = new DataTable();
        DataTable dataTable3 = new DataTable();
        int currRowIndex;
        public Form1()
        {
            InitializeComponent();

            button1.Enabled = false;
            button5.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {




                maconnexion = new MySqlConnection(parametres);
                maconnexion.Open();
                MySqlCommand cmd = maconnexion.CreateCommand();
                cmd.CommandText = "INSERT INTO ouv (id, titre,reference,type)" +
                   "VALUES(@id, @titre,@reference,@type )";
                cmd.Parameters.AddWithValue("@id", "null");
                cmd.Parameters.AddWithValue("@titre", textBox1.Text);
                cmd.Parameters.AddWithValue("@reference", textBox2.Text);
                cmd.Parameters.AddWithValue("@type", comboBox1.Text);



                cmd.ExecuteNonQuery();
                maconnexion.Close();
                textBox1.Clear();
                textBox2.Clear();


            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            dataTable1.Clear();
            dataGridView1.Rows.Clear();

            maconnexion = new MySqlConnection(parametres);
            maconnexion.Open();
            string request = "select id, titre,reference,type from ouv ";
            MySqlCommand cmd = new MySqlCommand(request, maconnexion);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable1);

            int i;
            String[] myArray = new String[4];
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                i = 0;
                foreach (var item in dataRow.ItemArray)
                {
                    myArray[i] = item.ToString();
                    i++;
                }
                dataGridView1.Rows.Add(myArray[0], myArray[1], myArray[2], myArray[3]);
            }
            dataTable2.Clear();
            dataGridView2.Rows.Clear();

            maconnexion = new MySqlConnection(parametres);
            maconnexion.Open();
            string request2 = "select id, titre,reference,type from ouv where type='Livre' ";
            MySqlCommand cmd2 = new MySqlCommand(request2, maconnexion);
            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
            da2.Fill(dataTable2);

            int j;
            String[] myArray2 = new String[4];
            foreach (DataRow dataRow in dataTable2.Rows)
            {
                j = 0;
                foreach (var item in dataRow.ItemArray)
                {
                    myArray2[j] = item.ToString();
                    j++;
                }
                dataGridView2.Rows.Add(myArray2[0], myArray2[1], myArray2[2], myArray2[3]);
            }
            dataTable3.Clear();
            dataGridView3.Rows.Clear();

            maconnexion = new MySqlConnection(parametres);
            maconnexion.Open();
            string request3 = "select id, titre,reference,type from ouv where type='CD' ";
            MySqlCommand cmd3 = new MySqlCommand(request3, maconnexion);
            MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
            da3.Fill(dataTable3);

            int k;
            String[] myArray3 = new String[4];
            foreach (DataRow dataRow in dataTable3.Rows)
            {
                k = 0;
                foreach (var item in dataRow.ItemArray)
                {
                    myArray3[k] = item.ToString();
                    k++;
                }
                dataGridView3.Rows.Add(myArray3[0], myArray3[1], myArray3[2], myArray3[3]);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            comboBox1.Text = row.Cells[3].Value.ToString();


            button1.Enabled = true;
            button5.Enabled = true;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row2 = this.dataGridView2.Rows[e.RowIndex];

            currRowIndex = Convert.ToInt32(row2.Cells[0].Value);
            textBox1.Text = row2.Cells[1].Value.ToString();
            textBox2.Text = row2.Cells[2].Value.ToString();
            comboBox1.Text = row2.Cells[3].Value.ToString();


            button1.Enabled = true;
            button5.Enabled = true;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row3 = this.dataGridView3.Rows[e.RowIndex];

            currRowIndex = Convert.ToInt32(row3.Cells[0].Value);
            textBox1.Text = row3.Cells[1].Value.ToString();
            textBox2.Text = row3.Cells[2].Value.ToString();
            comboBox1.Text = row3.Cells[3].Value.ToString();


            button1.Enabled = true;
            button5.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {


            DialogResult dialogDelete = MessageBox.Show("voulez-vous vraiment supprimer cette Périodique", "Supprimer une ouvrage", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {

                button1.Enabled = false;
                button5.Enabled = false;
                maconnexion = new MySqlConnection(parametres);
                maconnexion.Open();
                MySqlCommand cmd = maconnexion.CreateCommand();
                cmd.CommandText = "DELETE FROM ouv WHERE id=" + currRowIndex;
                cmd.ExecuteNonQuery();
                maconnexion.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogUpdate = MessageBox.Show("voulez-vous vraiment modifier les informations sur cette appartement ", "Modifier une ouvrage", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogUpdate == DialogResult.OK)
            {

                if (textBox1.Text == "")
                {
                    DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    maconnexion = new MySqlConnection(parametres);
                    maconnexion.Open();

                    MySqlCommand cmd = maconnexion.CreateCommand();
                    cmd.CommandText = "UPDATE ouv SET titre= @titre , reference=@reference , type=@type WHERE id=" + currRowIndex;
                    cmd.Parameters.AddWithValue("@titre", textBox1.Text);
                    cmd.Parameters.AddWithValue("@reference", textBox2.Text);
                    cmd.Parameters.AddWithValue("@type", comboBox1.Text);

                    cmd.ExecuteNonQuery();
                    maconnexion.Close();
                    textBox1.Clear();
                    textBox2.Clear();
                    button1.Enabled = false;
                    button5.Enabled = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogDelete11 = MessageBox.Show("voulez-vous vraiment supprimer cette liste des ouvrages", "Supprimer la liste", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogDelete11 == DialogResult.Yes)
                
            {

                button1.Enabled = false;
                button5.Enabled = false;
                maconnexion = new MySqlConnection(parametres);
                maconnexion.Open();
                MySqlCommand cmd = maconnexion.CreateCommand();
                cmd.CommandText = "DELETE FROM ouv ";
                cmd.ExecuteNonQuery();
                maconnexion.Close();

                    }


                }


        }
    }
}