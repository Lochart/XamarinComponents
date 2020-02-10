using System;

using Xamarin.Forms;

namespace XamarinComponents
{
    /// <summary>
    /// Компонент видов сортировок
    /// </summary>
    public class ComponentViewSortered 
    {
        /// <summary>
        /// Метод быстрой сортировки
        /// </summary>
        public int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
                return array;

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        private int[] QuickSort(int[] array) => QuickSort(array, 0, array.Length - 1);

        /// <summary>
        /// Метод возвращающий индекс опорного элемента
        /// </summary>
        /// <param name="array"></param>
        /// <param name="minIndex"></param>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
        private int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        /// <summary>
        /// Метод для обмена элементов массива
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }
    }
}

