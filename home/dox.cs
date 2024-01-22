using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using iText.Layout;
using iText.Layout.Element;
using System.Diagnostics;

namespace home
{
    public partial class dox : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public dox()
        {
            InitializeComponent();
            this.Load += dox_Load;
        }
        private Label labelUsername;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Инициализация Label
            labelUsername = new Label();
            labelUsername.Text = "Логин: ";
            labelUsername.Dock = DockStyle.Right; // Закрепляем в правом углу
            Controls.Add(labelUsername); // Добавляем на форму
        }
        private void Form_Load(object sender, EventArgs e)
        {
            // Отображаем логин на форме
            labelUsername.Text = "Логин: " + CurrentUser.Username;

        }
        private void dox_Load (object sender, EventArgs e)
        {
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Путь к документу Word
                string docxFilePath = "C:\\Users\\shchi\\source\\repos\\home\\home\\bin\\Debug\\Квитанция_новый.docx";

                // Проверяем, существует ли файл
                if (System.IO.File.Exists(docxFilePath))
                {
                    // Открываем документ Word с помощью программы, ассоциированной с .docx файлами
                    Process.Start(docxFilePath);
                }
                else
                {
                    MessageBox.Show("Документ не найден.", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Путь к текстовому документу
                string txtFilePath = "C:\\Users\\shchi\\source\\repos\\home\\home\\bin\\Debug\\Договор_новый.txt";

                // Проверяем, существует ли файл
                if (System.IO.File.Exists(txtFilePath))
                {
                    // Открываем текстовый документ с помощью программы, ассоциированной с .txt файлами
                    Process.Start(txtFilePath);
                }
                else
                {
                    MessageBox.Show("Документ не найден.", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Путь к документу Word
                string docxFilePath = "C:\\Users\\shchi\\source\\repos\\home\\home\\bin\\Debug\\Договор_новый.docx";

                // Проверяем, существует ли файл
                if (System.IO.File.Exists(docxFilePath))
                {
                    // Открываем документ Word с помощью программы, ассоциированной с .docx файлами
                    Process.Start(docxFilePath);
                }
                else
                {
                    MessageBox.Show("Документ не найден.", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка");
            }
            
        }
    }

    
    }
  
    
