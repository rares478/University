using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateComboBoxes();
            LoadStudents();  // Load students when the form loads
            LoadTab2();

        }

        private void LoadTab2()
        {
            var service = new ServiceReference1.WebService1SoapClient();

            lbRandom.DataSource = service.GetRandom();
            tbCtoF.Text = service.CtoF(0).ToString();
            tbFtoC.Text = service.FtoC(0).ToString();
            tbData.Text = service.GetDate().ToString();
            tbRontoEuro.Text = service.RonToEuro(1000).ToString();

            Console.Write("Random Numbers: ");
            foreach (var item in service.GetRandom())
            {
                Console.Write(item.ToString()+ " " );
            }
            Console.Write("\n");
            Console.WriteLine("Temperature C to F: " + service.CtoF(0).ToString());
            Console.WriteLine("Temperature F to C: " + service.FtoC(0).ToString());
            Console.WriteLine("Date and Time now: " + service.GetDate().ToString());
            Console.WriteLine("Ron to Euro: " + service.RonToEuro(1000).ToString());

        }

        private void LoadStudents()
        {
            try
            {
                // Assuming GetStudents is a method exposed by your Web Service
                var service = new ServiceReference1.WebService1SoapClient();
                var students = service.GetStudents();  // Get students from the service

                // Convert the students list to DataTable and bind it to DataGridView
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Surname");
                dt.Columns.Add("University");
                dt.Columns.Add("Class");

                foreach (var student in students)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = student.Id;
                    row["Name"] = student.Name;
                    row["Surname"] = student.Surname;
                    row["University"] = student.UniversityName;  // Assuming you have the university name in the response
                    row["Class"] = student.ClassName;  // Assuming you have the class name in the response
                    dt.Rows.Add(row);
                }

                dataGridView1.DataSource = dt;  // Bind to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the student data from TextBoxes and ComboBoxes
                int id = int.Parse(tbId.Text);
                string name = tbName.Text;
                string surname = tbSurname.Text;
                int uId = int.Parse(cbUniversity.SelectedValue.ToString());
                int cId = int.Parse(cbClass.SelectedValue.ToString());

                var service = new ServiceReference1.WebService1SoapClient();

                // Call the AddStudent method from the Web Service
                service.AddStudent(id, name, surname, uId, cId);

                // Refresh DataGridView
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding student: " + ex.Message);
            }
        }

        private void PopulateComboBoxes()
        {
            try
            {
                // Create a service client instance
                var service = new ServiceReference1.WebService1SoapClient();

                // Fetch the universities and classes
                var universities = service.GetUniversities(); // Assuming GetUniversities() returns a list of universities
                var classes = service.GetClasses(); // Assuming GetClasses() returns a list of classes

                // Bind the university data to the comboBoxUniversity
                cbUniversity.DataSource = universities;
                cbUniversity.DisplayMember = "Name"; // Change to the actual property name of the university object
                cbUniversity.ValueMember = "Id";    // Change to the actual property name for the university ID

                // Bind the class data to the comboBoxClass
                cbClass.DataSource = classes;
                cbClass.DisplayMember = "ClassName"; // Change to the actual property name of the class object
                cbClass.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading combo box data: {ex.Message}");
            }
        }



    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UniversityName { get; set; }
        public string ClassName { get; set; }
    }
}

