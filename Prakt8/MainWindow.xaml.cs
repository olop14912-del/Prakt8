using Prakt8;
using System.Windows;

namespace Prakt8
{
    // Главное окно программы
    public partial class MainWindow : Window
    {
        // Массив структур для хранения студентов
        private Student[] students = new Student[100];

        // Текущее количество студентов
        private int studentCount = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Добавление студента в массив
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, введена ли фамилия
            if (txtSurname.Text == "")
            {
                MessageBox.Show("Введите фамилию студента.");
                return;
            }

            // Проверяем правильность стажа
            int experience;

            if (!int.TryParse(txtExperience.Text, out experience) ||
                experience < 0)
            {
                MessageBox.Show("Введите правильный стаж.");
                return;
            }

            // Проверяем наличие свободного места
            if (studentCount >= students.Length)
            {
                MessageBox.Show("Массив студентов заполнен.");
                return;
            }

            // Создаём структуру Student
            Student student = new Student(
                txtSurname.Text,
                chkDormitory.IsChecked == true,
                experience,
                chkWorked.IsChecked == true,
                txtEducation.Text,
                txtLanguage.Text);

            // Добавляем структуру в массив
            students[studentCount] = student;
            studentCount++;

            // Обновляем информацию на экране
            ShowStudents();
            ClearFields();
        }

        // Вывод студентов и подсчёт нуждающихся в общежитии
        private void ShowStudents()
        {
            lstStudents.Items.Clear();

            int dormitoryCount = 0;

            // Перебираем заполненную часть массива
            for (int i = 0; i < studentCount; i++)
            {
                lstStudents.Items.Add(students[i]);

                if (students[i].NeedsDormitory)
                {
                    dormitoryCount++;
                }
            }

            txtDormitoryCount.Text =
                $"Нуждаются в общежитии: {dormitoryCount}";
        }

        // Очистка полей ввода
        private void ClearFields()
        {
            txtSurname.Clear();
            txtExperience.Text = "0";
            txtEducation.Clear();
            txtLanguage.Clear();

            chkDormitory.IsChecked = false;
            chkWorked.IsChecked = false;
        }

        // Очистка массива студентов
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            students = new Student[100];
            studentCount = 0;

            ShowStudents();
            ClearFields();
        }

        // Информация о программе
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Разработчик: Клейменов Никита\n\n" +
                "Практическая работа №8\n" +
                "Работа с типом данных структура\n\n" +
                "Задание: после поступления в ВУЗ о студентах " +
                "собрана информация: фамилия, нуждается ли в " +
                "общежитии, стаж, работал ли, что окончил, " +
                "какой язык изучал. Вывести информацию о студентах " +
                "и определить количество человек, нуждающихся " +
                "в общежитии.",
                "О программе");
        }

        // Завершение программы
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}