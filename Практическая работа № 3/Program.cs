using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практическая_работа___3
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
      
    }

    static class ColumnRows
    {
        public static int Row;
        public static int Col;

        public static void Save()
        {
            StreamWriter file = new StreamWriter("config.ini");
            file.WriteLine(Col);
            file.WriteLine(Row);
            file.Close();
        }
        public static void Open()
        {
            try
            {
                StreamReader file = new StreamReader("config.ini");
                int col = Convert.ToInt32(file.ReadLine());
                int row = Convert.ToInt32(file.ReadLine());
                Col = col;
                Row = row;
                file.Close();
            }
            // если файла нет
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Файл конфигурации не найден!");
                Row = 0;
                Col = 0;
            }
        }
    }
}
