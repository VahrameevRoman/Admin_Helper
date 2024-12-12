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
                ShowSolution(selectedProblemId);
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
        private void ShowSolution(int problemId)
        {
            db.OpenConnection();
            string query = "SELECT SolutionDescription FROM solutions WHERE ProblemID = @ProblemID";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            command.Parameters.AddWithValue("@ProblemID", problemId);

            string solution = command.ExecuteScalar()?.ToString();
            textBoxSolution.Visible = true;
            textBoxSolution.Text = solution ?? "Решение не найдено";

            // Сделать кнопку редактирования доступной
            btnEditSolution.Visible = true;

            db.CloseConnection();
        }

        // Обработчик для кнопки редактирования решения
        private void btnEditSolution_Click(object sender, EventArgs e)
        {
            textBoxSolution.ReadOnly = false; // Разрешаем редактирование
            btnSaveEdit.Visible = true; // Показываем кнопку сохранения
        }

        // Обработчик для кнопки сохранения решения
        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            db.OpenConnection();
            string query = "UPDATE solutions SET SolutionDescription = @SolutionDescription WHERE ProblemID = @ProblemID";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            command.Parameters.AddWithValue("@SolutionDescription", textBoxSolution.Text);
            command.Parameters.AddWithValue("@ProblemID", selectedProblemId);

            command.ExecuteNonQuery(); // Выполнили обновление решения
            db.CloseConnection();

            textBoxSolution.ReadOnly = true;
            btnSaveEdit.Visible = false;
        }

        private void btnAddProblem_Click(object sender, EventArgs e)
        {
            using (AddProblemForm addProblemForm = new AddProblemForm())
            {
                addProblemForm.ShowDialog(); // Открыть форму как диалог
            }
            LoadProblems();
        }

        private void btnDeleteProblem_Click(object sender, EventArgs e)
        {
            // Проверка, выбрана ли проблема
            if (listBoxProblems.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите проблему для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Подтверждение удаления
            var confirmationResult = MessageBox.Show("Вы уверены, что хотите удалить выбранную проблему и её решение?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmationResult == DialogResult.Yes)
            {
                // Удалите проблему и её решение
                DeleteProblemAndSolution(selectedProblemId);

                // Обновите список проблем
                LoadProblems();
            }
        }
        private void DeleteProblemAndSolution(int problemId)
        {
            try
            {
                db.OpenConnection();

                // Начинаем транзакцию
                using (var transaction = db.GetConnection().BeginTransaction())
                {
                    // Удаляем решение, связанное с проблемой
                    string deleteSolutionQuery = "DELETE FROM solutions WHERE ProblemID = @ProblemID";
                    MySqlCommand deleteSolutionCommand = new MySqlCommand(deleteSolutionQuery, db.GetConnection(), transaction);
                    deleteSolutionCommand.Parameters.AddWithValue("@ProblemID", problemId);
                    deleteSolutionCommand.ExecuteNonQuery();

                    // Затем удаляем саму проблему
                    string deleteProblemQuery = "DELETE FROM problems WHERE ProblemID = @ProblemID";
                    MySqlCommand deleteProblemCommand = new MySqlCommand(deleteProblemQuery, db.GetConnection(), transaction);
                    deleteProblemCommand.Parameters.AddWithValue("@ProblemID", problemId);
                    deleteProblemCommand.ExecuteNonQuery();

                    // Подтверждаем транзакцию
                    transaction.Commit();
                }

                MessageBox.Show("Проблема и её решение успешно удалены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении проблемы: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.CloseConnection();
            }
            finally
            {
                db.CloseConnection();
            }
            LoadProblems();
            textBoxSolution.Text = string.Empty;
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
