using Microsoft.VisualBasic.ApplicationServices;
using System.Web;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Register_page
{
    public partial class Register : Form
    {

        private SqlCommand cmd;
        private SqlConnection cn;
        private SqlDataReader dr;
        public Register()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text) ||
                string.IsNullOrEmpty(comboBox1.Text) ||
                string.IsNullOrEmpty(comboBox2.Text) ||
                string.IsNullOrEmpty(comboBox3.Text) ||
                string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please fill all gaps!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                using (cn = new SqlConnection(@"Data Source=LAB109PC03\SQLEXPRESS; Initial Catalog=aaa; Integrated Security=True;Encrypt=False;"))
                {
                    cn.Open();

                    // Checking if the username already exists
                    using (cmd = new SqlCommand("SELECT COUNT(1) FROM Users Where username = @Username", cn))
                    {
                        cmd.Parameters.AddWithValue("@username", textBox1.Text);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 1)
                        {
                            MessageBox.Show("Username already exists, please try another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            string DOB = comboBox1.SelectedItem.ToString() + comboBox2.SelectedItem.ToString() + comboBox3.SelectedItem.ToString();
                            // Inserting user information into the database
                            using (cmd = new SqlCommand("INSERT INTO Users (username, password, email, first_name,last_name, DOB)\r\nVALUES (@username, @password, @email, @first_name, @last_name , @DOB)", cn))
                            {
                                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                                cmd.Parameters.AddWithValue("@email", textBox2.Text);
                                cmd.Parameters.AddWithValue("@password", textBox3.Text);
                                cmd.Parameters.AddWithValue("@first_name", textBox5.Text);
                                cmd.Parameters.AddWithValue("@last_name", textBox4.Text);
                                cmd.Parameters.AddWithValue("@DOB", DOB);
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Your Account is created.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                this.Hide();
                            }
                        }

                    }
                }


            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}