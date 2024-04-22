
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

namespace Watched_page
{
    public partial class Watched : Form
    {

       // UserID =
        public Watched()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void azCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter();
        }
        void Watched_Load(object sender, EventArgs e)
        {
            PopulateGenreComboBox();
            filter();
        }
        private void GenreCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void PopulateGenreComboBox()
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC03\SQLEXPRESS; Initial Catalog=aaa; Integrated Security=True; Trusted_Connection=True; Encrypt=False;"))
            {
                try
                {
                    sqlCon.Open(); // Open SQL connection

                    string query = "SELECT DISTINCT genre FROM Movies";

                    SqlCommand cmd = new SqlCommand(query, sqlCon);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string genre = reader.GetString(0);
                            GenreCbox.Items.Add(genre);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void filter()
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC03\SQLEXPRESS; Initial Catalog=aaa; Integrated Security=True; Trusted_Connection=True; Encrypt=False;"))
            {
                sqlCon.Open(); // Open SQL connection

                bool A_Z = true;

                if (azCBox.SelectedItem == "Z-A")
                {
                    A_Z = false;
                }

                string genre = GenreCbox.SelectedItem?.ToString();

                string query = "SELECT WatchList.movieID, Movies.title, Movies.genre, Movies.duration_min, Movies.year, Movies.director, Movies.language  From WatchList INNER JOIN Movies ON WatchList.movieID = Movies.movieID WHERE WatchList.userID=@userID AND WatchList.status='watched' AND (genre IS NULL OR genre = @genre)";

                // Set the order by clause based on the A_Z flag
                if (!A_Z)
                {
                    query += " ORDER BY title DESC";
                }
                else
                {
                    query += " ORDER BY title ASC";
                }

                SqlCommand cmd = new SqlCommand(query, sqlCon);
               // cmd.Parameters.AddWithValue("@userID", userID);

                if (!string.IsNullOrEmpty(genre))
                {
                    cmd.Parameters.AddWithValue("@genre", genre);
                    
                }
                else
                {
                    if (A_Z)
                    {
                        query = "SELECT WatchList.movieID, Movies.title, Movies.genre, Movies.duration_min, Movies.year, Movies.director, Movies.language  From WatchList INNER JOIN Movies ON WatchList.movieID = Movies.movieID WHERE WatchList.userID=1 AND WatchList.status='wacthed'  Order by title ASC";
                    }
                    else
                    {
                        query = "SELECT WatchList.movieID, Movies.title, Movies.genre, Movies.duration_min, Movies.year, Movies.director, Movies.language  From WatchList INNER JOIN Movies ON WatchList.movieID = Movies.movieID WHERE WatchList.userID=1 AND WatchList.status='wacthed'  Order by title DESC";
                    }

                }

                cmd.CommandText = query; // Set the final query text

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }




    }
}
