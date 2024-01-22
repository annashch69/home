using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace home
{
    public partial class Form1 : Form
    {
        private bool isResetPasswordFormShown;
        private string loggedInUser; //  поле для хранения логина пользователя

        public bool IsResetPasswordFormShown
        {
            get { return isResetPasswordFormShown; }
            set { isResetPasswordFormShown = value; }
        }
    
        // Добавьте поле для хранения передаваемого аргумента
        private SqlConnection connection;

        // Конструктор с аргументом
        public Form1(SqlConnection connection)
        {
            InitializeComponent();

            // Инициализация поля connection
            this.connection = connection;

        }
       
    
        public Form1()
        {
            InitializeComponent();
        }

        private const int MaxAttempts = 3; // Добавьте эту строку для объявления MaxAttempts

        private int loginAttempts = 0;
        private Label labelUsername;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Инициализация Label
            labelUsername = new Label();
            labelUsername.Text = "Логин: ";
            labelUsername.Dock = DockStyle.Right; // Закрепляем в правом углу
            Controls.Add(labelUsername); // Добавляем на форму
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          

            string username = textBox1.Text;
            string password = textBox2.Text;

            if (AuthenticateUser(username, password))
            {
                // Успешная аутентификация
                MessageBox.Show("Вход выполнен успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loginAttempts = 0; // Сбрасываем количество попыток после успешного входа
                   this.Hide();
                loggedInUser = username; // сохранение логина пользователя
                Clients f2 = new Clients(loggedInUser); // передача логина в конструктор формы 
                f2.ShowDialog();
            }
           
              
            
            else
            {
                // Неверный логин или пароль
                loginAttempts++;

                if (loginAttempts >= MaxAttempts)
                {
                    // Предлагаем сбросить пароль после трех неудачных попыток
                    MessageBox.Show("Вы ввели неверный пароль 3 раза. Пожалуйста, сбросьте пароль.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    OpenResetPasswordForm();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool AuthenticateUser(string username, string password)
        {
            // Реализуйте проверку логина и пароля здесь.
            // В этом примере просто используем заглушку.
            return username == "admin" && IsValidPassword(password);
        }

        private bool IsValidPassword(string password)
        {
            // Проверка требований к паролю
            const string passwordPattern = @"^(?=.*[a-zA-Z]{5})(?=.*\d{3})(?=.*[@#%)(.<>]).*$";
            return Regex.IsMatch(password, passwordPattern);
        }

        private void OpenResetPasswordForm()
        {
            // Открываем форму сброса пароля
            Form2 resetPasswordForm = new Form2();
            resetPasswordForm.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
    }



        
         

       
