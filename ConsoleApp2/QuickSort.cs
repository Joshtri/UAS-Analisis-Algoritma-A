using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class QuickSort
    {
        public virtual void SortAlgorithm(int[,] matrix, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(matrix, left, right);
                SortAlgorithm(matrix, left, pivot - 1);
                SortAlgorithm(matrix, pivot + 1, right);
            }
        }

        int Partition(int[,] matrix, int left, int right)
        {
            const int N = 100;
            int pivot = matrix[left / N, left % N];
            int i = left - 1;
            int j = right + 1;
            while (true)
            {
                do
                {
                    i++;
                } while (matrix[i / N, i % N] < pivot);
                do
                {
                    j--;
                } while (matrix[j / N, j % N] > pivot);
                if (i >= j)
                {
                    return j;
                }
                int temp = matrix[i / N, i % N];
                matrix[i / N, i % N] = matrix[j / N, j % N];
                matrix[j / N, j % N] = temp;
            }
        }

        public virtual void PrintMatrix( int[,]matrix)
        {
            const int N = 100;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
