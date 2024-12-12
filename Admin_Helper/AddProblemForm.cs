using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Admin_Helper
{
    public partial class AddProblemForm : Form
    {
        private DB db;
        private List<Category> categories = new List<Category>();
        private int selectedCategoryId;

        public AddProblemForm()
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
        }

        private void listBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCategories.SelectedIndex >= 0)
            {
                selectedCategoryId = categories[listBoxCategories.SelectedIndex].CategoryID;
                label3.Visible = true;
                textBoxNaming.Visible = true;
                label4.Visible = true;
                textBoxSolution.Visible = true;
                btnSave.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNaming.Text) || string.IsNullOrWhiteSpace(textBoxSolution.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Открываем соединение
                db.OpenConnection();

                // Начинаем транзакцию
                using (var transaction = db.GetConnection().BeginTransaction())
                {
                    // 1. Добавляем новую проблему
                    string problemQuery = "INSERT INTO problems (CategoryID, ProblemDescription) VALUES (@CategoryID, @ProblemDescription); SELECT LAST_INSERT_ID();";
                    MySqlCommand problemCommand = new MySqlCommand(problemQuery, db.GetConnection());
                    problemCommand.Parameters.AddWithValue("@CategoryID", selectedCategoryId);
                    problemCommand.Parameters.AddWithValue("@ProblemDescription", textBoxNaming.Text);

                    // Получаем ProblemID только что добавленной проблемы
                    int newProblemId = Convert.ToInt32(problemCommand.ExecuteScalar());

                    // 2. Добавляем новое решение, связанное с проблемой
                    string solutionQuery = "INSERT INTO solutions (ProblemID, SolutionDescription) VALUES (@ProblemID, @SolutionDescription)";
                    MySqlCommand solutionCommand = new MySqlCommand(solutionQuery, db.GetConnection());
                    solutionCommand.Parameters.AddWithValue("@ProblemID", newProblemId);
                    solutionCommand.Parameters.AddWithValue("@SolutionDescription", textBoxSolution.Text);

                    // Выполняем запрос на добавление решения
                    solutionCommand.ExecuteNonQuery();

                    // Подтверждаем транзакцию
                    transaction.Commit();
                }

                db.CloseConnection();

                MessageBox.Show("Проблема и решение успешно добавлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Закрываем форму после сохранения
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении проблемы: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.CloseConnection();
            }
        }
    }
}
