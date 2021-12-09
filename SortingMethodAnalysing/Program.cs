using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace SortingMethodAnalysing
{
    public static class SortArray
    {
        static private void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        //метод возвращающий индекс опорного элемента
        static private int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        static private int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        //Метод быстрой сортировки
        static public void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        //Метод сортировки вставками
        static public void InsertionSort(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while ((j > 1) && (array[j - 1] > key))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key;
            }
        }
        //Метод сортировки пузырьком
        static public void BubbleSort(int[] array, bool inverseSort = false)
        {
            if (!inverseSort)
            {
                var len = array.Length;
                for (var i = 1; i < len; i++)
                {
                    for (var j = 0; j < len - i; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }
            }
        }
        //Метод пирамидальной сортировки
        static public void HeapSort(int[] array)
        {
            int n = array.Length;

            // Построение кучи (перегруппируем массив)
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);

            // Один за другим извлекаем элементы из кучи
            for (int i = n - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                // вызываем процедуру heapify на уменьшенной куче
                Heapify(array, i, 0);
            }
        }
        static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            // Инициализируем наибольший элемент как корень
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2

            // Если левый дочерний элемент больше корня
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // Если самый большой элемент не корень
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                Heapify(arr, n, largest);
            }
        }
        //Метод сортировки Шэлла
        static public void ShellSort(int[] array)
        {
            //расстояние между элементами, которые сравниваются
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }
                d = d / 2;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Stopwatch stopwatch = new Stopwatch();
            int[] array = new int[2048];
            for (int k = 0; k < array.Length; k++)
            {
                array[k] = random.Next(20000) - 10000;
            }
            int i = 1;
            while (i < 257)
            {

                Console.WriteLine($"Result for array n  = {2048 / i}");

                stopwatch.Start();
                SortArray.BubbleSort(GetAray(array, i));
                stopwatch.Stop();
                Console.WriteLine("Buble " + stopwatch.ElapsedTicks);
                stopwatch.Reset();

                stopwatch.Start();
                SortArray.InsertionSort(GetAray(array, i));
                stopwatch.Stop();
                Console.WriteLine("InsertionSort " + stopwatch.ElapsedTicks);
                stopwatch.Reset();

                stopwatch.Start();
                SortArray.ShellSort(GetAray(array, i));
                stopwatch.Stop();
                Console.WriteLine("ShellSort " + stopwatch.ElapsedTicks);
                stopwatch.Reset();

                stopwatch.Start();
                SortArray.HeapSort(GetAray(array, i));
                stopwatch.Stop();
                Console.WriteLine("HeapSort " + stopwatch.ElapsedTicks);
                stopwatch.Reset();

                stopwatch.Start();
                SortArray.QuickSort(GetAray(array, i));
                stopwatch.Stop();
                Console.WriteLine("QuickSort " + stopwatch.ElapsedTicks);
                stopwatch.Reset();

                i *= 2;
            }

            #region Excel
            //Excel.Application excelApp = new Excel.Application();
            //Excel.Workbook workBook = excelApp.Workbooks.Open($"{Environment.CurrentDirectory}\\input.xlsx");
            //Excel.Worksheet workSheet = workBook.Worksheets[1];
            //object[,] range = workSheet.Range["A2", "B10"].Value2;
            //Dictionary<string, string> illcure = new Dictionary<string, string>();
            //for (int i = 1; i <= range.GetLength(0); i++)
            //{
            //    illcure.Add(range[i, 1].ToString().ToLower(), range[i, 2].ToString());
            //}
            //workBook.Close();
            //workBook = excelApp.Workbooks.Open($"{Environment.CurrentDirectory}\\output.xlsx");
            //workSheet = workBook.Worksheets[1];
            //range = workSheet.Range["G2", "G35"].Value2;
            //for (int i = 1; i <= range.Length; i++)
            //{
            //    //Изменяем массив 
            //    string stringExcel = range[i, 1].ToString().ToLower();
            //    foreach (var pair in illcure)
            //    {
            //        if (stringExcel.Contains(pair.Key))
            //        {
            //            range[i, 1] = pair.Value;
            //            break;
            //        }
            //    }
            //}
            //workSheet.Range["H2", "H35"].Value2 = range;
            //workBook.Save();
            //workBook.Close();
            //excelApp.Quit();
            #endregion
        }
        static int[] GetAray(int[] array, int i)
        {
            int[] array2 = new int[array.Length / i];
            //array.CopyTo(array2, 2048 - 2048 / i);
            Array.Copy(array, array2, array2.Length);
            return array2;
        }
    }
}
