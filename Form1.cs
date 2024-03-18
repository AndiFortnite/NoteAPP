using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Noteform
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(richTextBox1.Text))

            {
                MessageBox.Show("Please fill all gaps!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                using (SqlConnection cn = new SqlConnection(@"Data Source=LAB109PC11\SQLEXPRESS; Initial Catalog=NoteDB; Integrated Security=True; Trusted_Connection=True; Encrypt=False;"))
                {
                    cn.Open();

                    // Checking if the username already exists


                    // Inserting user information into the database
                    using (SqlCommand cmd1 = new SqlCommand("INSERT INTO Table_1 (Noteheader, Note)\r\nVALUES (@noteheader, @note)", cn))
                    {
                        cmd1.Parameters.AddWithValue("@noteheader", textBox1.Text);
                        cmd1.Parameters.AddWithValue("@note", richTextBox1.Text);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Your note is created.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    }



                }


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a note header to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection cn = new SqlConnection(@"Data Source=LAB109PC11\SQLEXPRESS; Initial Catalog=NoteDB; Integrated Security=True; Trusted_Connection=True; Encrypt=False;"))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Table_1 WHERE Noteheader = @Noteheader", cn))
                    {
                        cmd.Parameters.AddWithValue("@Noteheader", textBox1.Text);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Note deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Note with the specified header not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

    private void button3_Click(object sender, EventArgs e)
     {
          
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please enter a note header to view.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (SqlConnection cn = new SqlConnection(@"Data Source=LAB109PC11\SQLEXPRESS; Initial Catalog=NoteDB; Integrated Security=True; Trusted_Connection=True; Encrypt=False;"))
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT Note FROM Table_1 WHERE Noteheader = @Noteheader", cn))
                        {
                            cmd.Parameters.AddWithValue("@Noteheader", textBox1.Text);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    richTextBox1.Text = reader["Note"].ToString();
                                    MessageBox.Show("Note retrieved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Note with the specified header not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
