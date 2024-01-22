using iTextSharp.text.pdf;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Xceed.Words.NET;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;



namespace home

{
    public partial class Clients : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private string loggedInUser;
        private Label labelUsername;



        public Clients(string username)
        {

            InitializeComponent();
            loggedInUser = username;
          

            // Вызовем метод для загрузки данных
            this.Load += Clients_Load;
        }
       
        private void Clients_Load(object sender, EventArgs e)
        {
            //Statement 2
            var cs = "Host=localhost;Username=postgres;Password=1111;Database=hOMEWORK";

            //Statement 3
            NpgsqlConnection con = new NpgsqlConnection(cs);
            con.Open();

            //Statement 4
            var sql = "Select * from individual";

            //Statement 5
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            //Statement 6
            var dataReader = cmd.ExecuteReader();

            //Statement 7
            DataTable dt = new DataTable();
            dt.Load(dataReader);

            //Statement 8
            con.Close();
            dataGridView1.DataSource = dt;
        }

        public int i;
        public string lastname;
        public string firstname;
        public string middlename;
        public string residenceaddress;
        public string birthdate;
        public string passportserialnumber;
        public string emale;
        public string phonenumber;
        public string position;
        public string workplace;
        public string column;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            column = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            i = e.RowIndex;

        }
      


      

        private void button1_Click(object sender, EventArgs e)
        {

            lastname = dataGridView1[1, i].Value.ToString();

            firstname = dataGridView1[2, i].Value.ToString();

            middlename = dataGridView1[3, i].Value.ToString();

            birthdate = dataGridView1[4, i].Value.ToString();

            passportserialnumber = dataGridView1[5, i].Value.ToString();

            residenceaddress = dataGridView1[6, i].Value.ToString();


            emale = dataGridView1[7, i].Value.ToString();

            phonenumber = dataGridView1[8, i].Value.ToString();

            position = dataGridView1[9, i].Value.ToString();

            workplace = dataGridView1[10, i].Value.ToString();
           
            {
                try
                {


                    // Путь к существующему файлу Word
                    string templateFilePath = "C:\\Users\\shchi\\source\\repos\\home\\home\\bin\\Debug\\Договор.docx";

                    // Проверяем, существует ли файл-шаблон
                    if (File.Exists(templateFilePath))
                    {
                        // Создаем новый путь для нового файла
                        string newFilePath = "C:\\Users\\shchi\\source\\repos\\home\\home\\bin\\Debug\\Договор_новый.docx";

                        // Копируем существующий файл-шаблон
                        File.Copy(templateFilePath, newFilePath, true);

                        // Открываем новый документ Word
                        using (DocX doc = DocX.Load(newFilePath))
                        {
                            // Заменяем переменные в тексте на реальные значения
                            doc.ReplaceText("#workplace#", workplace);
                    
                            doc.ReplaceText("#lastname#", lastname);
                            doc.ReplaceText("#firstname#", firstname);
                            doc.ReplaceText("#middlename#", middlename);
                            doc.ReplaceText("#birthdate#", birthdate);
                            doc.ReplaceText("#residenceaddress#", residenceaddress);
                            doc.ReplaceText("#passportserialnumber#", passportserialnumber);
                            doc.ReplaceText("#phonenumber#", phonenumber);
                        

                            // Сохраняем изменения в новый документ Word
                            doc.Save();
                        }
                    }
                    
                }



                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка");
                }
            }
            try
            {
                // Путь к существующему текстовому файлу (шаблону)
                string templateFilePath = "C:\\Users\\shchi\\source\\repos\\home\\home\\bin\\Debug\\Договор.txt";

                // Проверяем, существует ли файл-шаблон
                if (File.Exists(templateFilePath))
                {
                    // Создаем новый путь для нового текстового файла
                    string newTxtFilePath = "C:\\Users\\shchi\\source\\repos\\home\\home\\bin\\Debug\\Договор_новый.txt";

                    // Читаем содержимое шаблона
                    string templateContent = File.ReadAllText(templateFilePath);

                    // Заменяем переменные в тексте на реальные значения
                    templateContent = templateContent.Replace("#workplace#", workplace);
                    templateContent = templateContent.Replace("#lastname#", lastname);
                    templateContent = templateContent.Replace("#firstname#", firstname);
                    templateContent = templateContent.Replace("#middlename#", middlename);
                    templateContent = templateContent.Replace("#birthdate#", birthdate);
                    templateContent = templateContent.Replace("#residenceaddress#", residenceaddress);
                    templateContent = templateContent.Replace("#passportserialnumber#", passportserialnumber);
                    templateContent = templateContent.Replace("#phonenumber#", phonenumber);

                    // Создаем новый текстовый файл и записываем в него измененное содержимое
                    File.WriteAllText(newTxtFilePath, templateContent);

                  
                }
                else
                {
                    MessageBox.Show("Шаблон не найден.", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка");
            }
        

            try
            {


                // Путь к существующему файлу Word
                string templateFilePath = "C:\\Users\\shchi\\source\\repos\\home\\home\\bin\\Debug\\Квитанция.docx" ;

                // Проверяем, существует ли файл-шаблон
                if (File.Exists(templateFilePath))
                {
                    // Создаем новый путь для нового файла
                    string newFilePath = "C:\\Users\\shchi\\source\\repos\\home\\home\\bin\\Debug\\Квитанция_новый.docx";

                    // Копируем существующий файл-шаблон
                    File.Copy(templateFilePath, newFilePath, true);

                    // Открываем новый документ Word
                    using (DocX doc = DocX.Load(newFilePath))
                    {
                        // Заменяем переменные в тексте на реальные значения
                      

                        doc.ReplaceText("#lastname#", lastname);
                        doc.ReplaceText("#firstname#", firstname);
                        doc.ReplaceText("#middlename#", middlename);
                    
                        doc.ReplaceText("#residenceaddress#", residenceaddress);
                      
              


                        // Сохраняем изменения в новый документ Word
                        doc.Save();
                    }
                }

            }



            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка");
            }
        
          

            this.Hide();
                        educational f3 = new educational();
                        f3.ShowDialog();
                    }

        private void Clients_Load_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }



            }
        
   

      