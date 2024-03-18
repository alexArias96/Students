using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Students
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connection.Conn();

            MessageBox.Show("Successfully conection");
            dataGridView1.DataSource = ShowDataUsers();
        }

        public DataTable ShowDataUsers()
        {
            Connection.Conn();
            DataTable dt = new DataTable();
            string query = "Exec Show_Users";
            SqlCommand command = new SqlCommand(query, Connection.Conn());

            SqlDataAdapter da = new SqlDataAdapter(command);

            da.Fill(dt);

            return dt;
        }

        public void Clear()
        {
            txt_Id.Clear();
            txt_Name.Clear();
            txt_LastName.Clear();
            txt_Phone.Clear();
            txt_Address.Clear();

            txt_Id.Focus();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Connection.Conn();
            string query = "Exec Insert_Users @iduser, @name ,@lastName, @phone, @email";
            SqlCommand cmd = new SqlCommand(query, Connection.Conn());
            cmd.Parameters.AddWithValue("@iduser", txt_Id.Text);
            cmd.Parameters.AddWithValue("@name", txt_Name.Text);
            cmd.Parameters.AddWithValue("@lastName", txt_LastName.Text);
            cmd.Parameters.AddWithValue("@phone", txt_Phone.Text);
            cmd.Parameters.AddWithValue("@email", txt_Address.Text);
            Connection.Conn().Close();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Save success!");
            Clear();
            dataGridView1.DataSource = ShowDataUsers();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_Id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_LastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_Phone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_Address.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            catch
            {

            }

        }

        private void btn_Mod_Click(object sender, EventArgs e)
        {
            Connection.Conn();
            string update = "Exec Edit_Users @iduser, @name ,@lastName, @phone, @email";
            SqlCommand cmd = new SqlCommand(update, Connection.Conn());
            cmd.Parameters.AddWithValue("@iduser", txt_Id.Text.ToString());
            cmd.Parameters.AddWithValue("@name", txt_Name.Text.ToString());
            cmd.Parameters.AddWithValue("@lastName", txt_LastName.Text.ToString());
            cmd.Parameters.AddWithValue("@phone", txt_Phone.Text.ToString());
            cmd.Parameters.AddWithValue("@email", txt_Address.Text.ToString());
            Connection.Conn().Close();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Update successs!");
            Clear();
            dataGridView1.DataSource = ShowDataUsers();
            

        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            Connection.Conn();
            string delete = "Exec Delete_Users @iduser";
            SqlCommand cmd = new SqlCommand(delete, Connection.Conn());
            cmd.Parameters.AddWithValue("@iduser", txt_Id.Text.ToString());

            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Deleted successfully");

            dataGridView1.DataSource = ShowDataUsers();
        }
    }
}
