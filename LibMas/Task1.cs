using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibMas
{
    public class Task1
    {

        /// <summary>
        /// Находит количество столбцов и строк двумерного массива
        /// </summary>
        /// <param name="array">двумерный массив</param>
        /// <returns>Кортеж состоящий из количество столбцов и строк</returns>
        private static (int columns, int rows) GetSizeArray(int[,] array)
        {
            //Нахождение строк массива
            //Получает номер последнего индекса
            //+1 так как нумерация начинается с 0
            int rows = array.GetUpperBound(0) + 1;
            //Нахождение столбцов массива
            //Общие количество элементов делится на количество строк
            int columns = array.Length / rows;

            return (columns, rows);
        }

        /// <summary>
        /// Генерирует числа распределенные в диапазоне от 0 до 20.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public  int[,] Rand(int rows, int columns )
        {
            Random Rnd = new Random();
            int[,] mas = new int[rows,columns];

            for (int i = 0; i <rows; i++)
                for (int j = 0; j <columns; j++)
                {
                    mas[i, j] = Rnd.Next(0,20);
                }
            return mas;

        }

        /// <summary>
        /// Очищает двумерный массив случайными значениями
        /// </summary>
        /// <param name="mas">очищаемый одномерный массив</param>
        public  void ClearMass(ref int[,] array)
        {
            var size = GetSizeArray(array);
            for (int i = 0; i < size.columns; i++)
                for (int j = 0; j < size.rows; j++)
                {
                        array[j,i] = 0;
                }
        }
        /// <summary>
        /// Сохранение двумерного массива в файл
        /// </summary>
        /// <param name="mas">сохраняемый одномерный массив</param>
        /// <param name="path">путь к файлу</param>
        public  void SaveArray(int[,] arry, string path)
        {
            //Кортеж из кол-во строк и столбцов
            var size = GetSizeArray(arry);

            //Создание потока для работы с файлом, на запись
            using (StreamWriter saveFile = new StreamWriter(path))
            {
                //Запись кол-во столбцов
                saveFile.WriteLine(size.columns);
                //Запись кол-во строк
                saveFile.WriteLine(size.rows);
                //Запись элемнтов массива
                for (int i = 0; i < size.rows; i++)
                {
                    for (int j = 0; j < size.columns; j++)
                    {
                        saveFile.WriteLine(arry[i, j]);
                    }
                }
            }
            
        }

        /// <summary>
        /// Открытие двумерного масиива из файла
        /// </summary>
        /// <param name="mas">открываемый одномерный массив</param>
        /// <param name="path">путь к файлу</param>
        public int[,] OpenArray(int[,]arry, string path)
        {
            //Создание потока для работы с файлом, на чтение
            using (StreamReader readFile = new StreamReader(path))
            {
                //Чтение кол-во столбцов из файла
                int columns = Convert.ToInt32(readFile.ReadLine());
                //Чтение кол-во строк из файла
                int rows = Convert.ToInt32(readFile.ReadLine());
                //Чтение элемнтов из файла
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        arry[i, j] = Convert.ToInt32(readFile.ReadLine());
                    }
                }
            }
            return arry;
            
        }


    }
}

