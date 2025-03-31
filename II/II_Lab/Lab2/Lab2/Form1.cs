using System.Reflection;
using System.Text;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Ex1
        private async void btLogin_Click(object sender, EventArgs e)
        {
            var username = tbUsername.Text;
            var password = tbPassword.Text;

            using (FileStream stream = File.OpenRead("users.txt"))
            {
                var buffer = new byte[stream.Length];
                await stream.ReadAsync(buffer);
                var users = Encoding.UTF8.GetString(buffer).Split('\n');
                foreach (var user in users)
                {
                    var parts = user.Split(' ');
                    if (parts[0] == username && parts[1] == password)
                    {
                        this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                        {
                            new Login(username).Show();
                        });
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!");
                    }
                }
            }
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tpEx2)
            {
                lbRead.Items.Clear();
                using (FileStream stream = File.OpenRead("ex2_objects.txt"))
                {
                    var buffer = new byte[stream.Length];
                    stream.Read(buffer);
                    var objects = Encoding.UTF8.GetString(buffer).Split('\n');
                    foreach (var obj in objects)
                    {
                        lbRead.Items.Add(obj.ToString());
                    }
                }
            }
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            lbCopy.Items.Clear();
            lbCopy.Items.AddRange(lbRead.Items.Cast<string>().ToArray());
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            lbCopy.Items.Remove(lbCopy.SelectedItem);
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBinaryOperators_SelectedIndexChanged(object sender, EventArgs e)
        {
            var num1 = tbNum1.Text;
            var num2 = tbNum2.Text;
            if (num1 == "" || num2 == "")
            {
                MessageBox.Show("Please enter both numbers!");
                return;
            }
            var op = tsBinaryOperators.SelectedItem.ToString();

            switch (op)
            {
                case "+":
                    tbResult.Text = (int.Parse(num1) + int.Parse(num2)).ToString();
                    break;
                case "-":
                    tbResult.Text = (int.Parse(num1) - int.Parse(num2)).ToString();
                    break;
                case "*":
                    tbResult.Text = (int.Parse(num1) * int.Parse(num2)).ToString();
                    break;
                case "/":
                    tbResult.Text = (int.Parse(num1) / int.Parse(num2)).ToString();
                    break;
                case "%":
                    tbResult.Text = (int.Parse(num1) % int.Parse(num2)).ToString();
                    break;
            }
        }

        private void lbCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            var path = "Ex4_Cars\\";
            switch (lbCars.SelectedItem.ToString())
            {
                case "BMW M4":
                    pbCar.Image = Image.FromFile(path + "BMW_M4.jpg");
                    break;
                case "Bugatti Divo":
                    pbCar.Image = Image.FromFile(path + "Bugatti_Divo.jpg");
                    break;
                case "Volkswagen Passat":
                    pbCar.Image = Image.FromFile(path + "Volkswagen_Passat.jpg");
                    break;
                case "Peugeot 207 2011 1.4 HDI 70hp":
                    pbCar.Image = Image.FromFile(path + "Peugeot_207.jpg");
                    break;
            }
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            string color = "";
            string animal = "";

            if (rbRed.Checked) color = "Red";
            else if (rbBlue.Checked) color = "Blue";
            else if (rbGreen.Checked) color = "Green";

            if (rbCar.Checked) animal = "Car";
            else if (rbHorse.Checked) animal = "Horse";
            else if (rbDog.Checked) animal = "Dog";

            MessageBox.Show($"{color} {animal}");
        }
    }
}
