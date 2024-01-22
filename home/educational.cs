using iText.Layout.Element;
using Npgsql;
using System;
using System.IO;
using System.Windows.Forms;
using Xceed.Words.NET;
using iTextSharp.text;

using iTextSharp.text.pdf;

using iText.Layout;
using Paragraph = iText.Layout.Element.Paragraph;
using Document = iText.Layout.Document;
using ConvertApiDotNet;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using static System.Resources.ResXFileRef;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data;
using DataTable = System.Data.DataTable;



namespace home
{
    public partial class educational : Form
    {
    
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        
   
       
        private void Clients_Load(object sender, EventArgs e)
        {
            //Statement 2
            var cs = "Host=localhost;Username=postgres;Password=1111;Database=hOMEWORK";

            //Statement 3
            NpgsqlConnection con = new NpgsqlConnection(cs);
            con.Open();

            //Statement 4
            var sql = "Select * from educational_program";

            //Statement 5
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            //Statement 6
            var dataReader = cmd.ExecuteReader();

            //Statement 7
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Load(dataReader);

            //Statement 8
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private int selectedRowIndex = -1; // Добавляем переменную для хранения текущей выбранной строки
        public int i;
        public string programname;
        public string duration;
        public string qualification;
        public string tuition_cost;
        public string column;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            column = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            i = e.RowIndex;
            selectedRowIndex = e.RowIndex; // Сохраняем текущую выбранную строку
        }


        private void button1_Click(object sender, EventArgs e)
        {
            programname = dataGridView1[1, i].Value.ToString();
            duration = dataGridView1[2, i].Value.ToString();
            qualification = dataGridView1[3, i].Value.ToString();
            tuition_cost = dataGridView1[4, i].Value.ToString();

            try
            {
                // Путь к существующему текстовому файлу
                string filePath = "C:\\Users\\shchi\\source\\repos\\home\\home\\bin\\Debug\\Договор_новый.txt";

                // Проверяем, существует ли файл
                if (File.Exists(filePath))
                {
                    // Читаем содержимое текстового файла
                    string fileContent = File.ReadAllText(filePath);

                    // Заменяем переменные в тексте на реальные значения
                    fileContent = fileContent.Replace("#programname#", programname);




                    // Записываем измененное содержимое обратно в файл
                    File.WriteAllText(filePath, fileContent);


                }
                else
                {
                    MessageBox.Show("Файл не найден.", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка");
            }


            try
            {


                // Путь к существующему файлу Word
                string templateFilePath = "C:\\Users\\shchi\\source\\repos\\home\\home\\bin\\Debug\\Договор_новый.docx";

                if (File.Exists(templateFilePath))
                {
                    using (DocX doc = DocX.Load(templateFilePath))
                    {
                        doc.ReplaceText("#programname#", programname);
                        doc.Save();


                    }
                }
                else
                {
                    MessageBox.Show("Файл-шаблон не найден.", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка");
            }
            try
            {


                // Путь к существующему файлу Word
                string templateFilePath = "C:\\Users\\shchi\\source\\repos\\home\\home\\bin\\Debug\\Квитанция_новый.docx";

                if (File.Exists(templateFilePath))
                {
                    using (DocX doc = DocX.Load(templateFilePath))
                    {
                        doc.ReplaceText("#tuition_cost#", tuition_cost);
                        doc.Save();


                    }
                }
                else
                {
                    MessageBox.Show("Файл-шаблон не найден.", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка");
            }




            this.Hide();
            dox f4 = new dox();
            f4.ShowDialog();

        }
    }
}

