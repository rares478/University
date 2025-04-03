using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Faculta\II\II_Lab\Lab3\Lab3\Database1.mdf;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.facultatiTableAdapter.Fill(this.database1DataSet.Facultati);

        }

        private void AddUniversity(string nameUniv, string city, int code)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Universitati (NameUniv, City, Code) VALUES (@NameUniv, @City, @Code)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NameUniv", nameUniv);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@Code", code);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        private void RemoveUniversity(int code)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Universitati WHERE Code = @Code";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Code", code);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ModifyUniversity(string nameUniv, string city, int code)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Universitati SET NameUniv = @NameUniv, City = @City WHERE Code = @Code";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NameUniv", nameUniv);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@Code", code);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        private void btAdd_Click(object sender, EventArgs e)
        {
            AddUniversity(tbUniName.Text, tbCity.Text, Int32.Parse(tbCode.Text));
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            ModifyUniversity(tbUniName.Text, tbCity.Text, Int32.Parse(tbCode.Text));
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            RemoveUniversity(Int32.Parse(tbCode.Text));
        }

        private void btDeleteFaculta_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            int code = (int)database1DataSet.Facultati.Rows[selectedRowIndex]["Code"];

            database1DataSet.Facultati.Rows[selectedRowIndex].Delete();
            facultatiTableAdapter.Update(database1DataSet.Facultati);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Facultati WHERE Code = @Code";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Code", code);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
