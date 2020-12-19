using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibMas;
using Lib_11;

namespace Практическая_работа___3
{
    public partial class Form1 : Form
    {
       
        Task1 Arry = new Task1();
        Class1 Job = new Class1();
        public Form1()
        {
            InitializeComponent();
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(this.numericUpDown1, "Количество строк");
            toolTip1.SetToolTip(this.numericUpDown2, "Количество столбцов");
            toolTip1.SetToolTip(this.textBox1, "Сумма в четных столбцах таблицы");
            toolTip1.SetToolTip(this.button4, "Жми");
            toolStripStatusLabel1.Text = "Размер таблицы " + dataGridView1.RowCount.ToString() + "x" + dataGridView1.ColumnCount.ToString();
        }

        /// <summary>
        /// Получает массив из таблицы
        /// </summary>
        /// <returns>двумерный массив</returns>
        private int[,] GetArray()
        {
            int columns = dataGridView1.ColumnCount;
            int rows = dataGridView1.RowCount;

            int[,] array = new int[rows, columns];

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    array[j, i] = (int)dataGridView1[i, j].Value;
                }
            }

            return array;
            
        }

        /// <summary>
        /// Выводим массив в таблицу
        /// </summary>
        /// <returns>двумерный массив</returns>
        private void PrintArray(int[,] array)
        {

            int columns = dataGridView1.ColumnCount;
            int rows = dataGridView1.RowCount;

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    dataGridView1[i, j].Value = array[j, i];
                }
            }

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Серегин Денис.\n" +
                "группа ИСП-31.\n" +
                "Вариант 13.\n" +
                "Дана матрица размера M × N. Для каждого столбца матрицы с четным номером (2, 4, …) найти сумму его элементов." +
                " Условный оператор не использовать.\n");

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void заполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int rows = (int)numericUpDown1.Value;
                int columns = (int)numericUpDown2.Value;
                dataGridView1.ColumnCount = columns;
                dataGridView1.RowCount = rows;
                PrintArray(Arry.Rand(rows, columns));
                int[,] array = GetArray();
                // listBox1.Items.Clear();
                textBox1.Clear();
                foreach (int summaElementov in Job.JobArrey(array))
                {
                    // listBox1.Items.Add(summaElementov);
                    textBox1.Text += summaElementov.ToString() + " ";
                }
                toolStripStatusLabel1.Text = "Размер таблицы " + dataGridView1.RowCount.ToString() + "x" + dataGridView1.ColumnCount.ToString();
            }
            catch
            {

                MessageBox.Show("Введите значение таблицы");
            }


        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e) // очистка таблицы
        {

            int[,] array = GetArray();
            Arry.ClearMass(ref array);
            PrintArray(array);
            textBox1.Clear();

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e) // Сохранение таблицы 
        {
            //Создание объекта диалогового окна для сохранения
            using (SaveFileDialog save = new SaveFileDialog
            {
                //Установка стандартных свойств
                DefaultExt = ".txt",
                Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt",
                FilterIndex = 2,
                Title = "Сохранение таблицы"
            })
            {
                //Если пользователь нажал ОК
                if (save.ShowDialog() == DialogResult.OK)
                {
                    //Сохранить массив
                    Arry.SaveArray(GetArray(), save.FileName);
                }
            }

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e) // Открытие файла с таблицей 
        {
            //Создание объекта диалогового окна для открытия
            using (OpenFileDialog open = new OpenFileDialog
            {
                //Установка стандартных свойств
                DefaultExt = ".txt",
                Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt",
                FilterIndex = 2,
                Title = "Открытие таблицы"
            })
            {
                //Если пользователь нажал ОК
                if (open.ShowDialog() == DialogResult.OK)
                {

                    int[,] arry = GetArray();
                    Arry.OpenArray(arry, open.FileName);
                    PrintArray(arry);

                }
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)// панел инструментов
        {
            //Создание объекта диалогового окна для сохранения
            using (SaveFileDialog save = new SaveFileDialog
            {
                //Установка стандартных свойств
                DefaultExt = ".txt",
                Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt",
                FilterIndex = 2,
                Title = "Сохранение таблицы"
            })
            {
                //Если пользователь нажал ОК
                if (save.ShowDialog() == DialogResult.OK)
                {
                    //Сохранить массив
                    Arry.SaveArray(GetArray(), save.FileName);
                }
            }
        }
    }
}
