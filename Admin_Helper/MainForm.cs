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

namespace Admin_Helper
{
    public partial class MainForm : Form
    {
        private DB db;
        private List<Category> categories = new List<Category>();
        private int selectedCategoryId;
        private int selectedProblemId;

        public MainForm()
        {
            InitializeComponent();
            db = new DB();
            LoadCategories();
        }
        private void LoadCategories()
        {
            db.OpenConnection();
            string query = "SELECT CategoryID, CategoryName FROM categories";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                categories.Add(new Category(id, name));
                listBoxCategories.Items.Add(name);
            }

            db.CloseConnection();
            listBoxCategories.SelectedIndexChanged += ListBoxCategories_SelectedIndexChanged;
        }
        private void ListBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCategories.SelectedIndex >= 0)
            {
                selectedCategoryId = categories[listBoxCategories.SelectedIndex].CategoryID;
                LoadProblems();
            }
        }
        private void LoadProblems()
        {
            listBoxProblems.Items.Clear();
            db.OpenConnection();
            string query = "SELECT ProblemID, ProblemDescription FROM problems WHERE CategoryID = @CategoryID";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            command.Parameters.AddWithValue("@CategoryID", selectedCategoryId);

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string description = reader.GetString(1);
                listBoxProblems.Items.Add(description);
            }

            db.CloseConnection();
            listBoxProblems.SelectedIndexChanged += ListBoxProblems_SelectedIndexChanged;
        }
        private void ListBoxProblems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxProblems.SelectedIndex >= 0)
            {
                selectedProblemId = GetSelectedProblemId(listBoxProblems.SelectedIndex);
            }
        }
        private int GetSelectedProblemId(int index)
        {
            db.OpenConnection();
            string query = "SELECT ProblemID FROM problems WHERE CategoryID = @CategoryID";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            command.Parameters.AddWithValue("@CategoryID", selectedCategoryId);

            MySqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i <= index; i++)
            {
                reader.Read();
            }

            int id = reader.GetInt32(0);
            db.CloseConnection();
            return id;
        }

        private void btnShowSolution_Click(object sender, EventArgs e)
        {
            ShowSolution(selectedProblemId);
        }
        private void ShowSolution(int problemId)
        {
            db.OpenConnection();
            string query = "SELECT SolutionDescription FROM solutions WHERE ProblemID = @ProblemID";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            command.Parameters.AddWithValue("@ProblemID", problemId);

            string solution = command.ExecuteScalar()?.ToString();
            textBoxSolution.Visible = true;
            textBoxSolution.Text = solution ?? "Решение не найдено";

            db.CloseConnection();
        }
    }
    public class Category
    {
        public int CategoryID { get; }
        public string CategoryName { get; }

        public Category(int id, string name)
        {
            CategoryID = id;
            CategoryName = name;
        }
    }
}
