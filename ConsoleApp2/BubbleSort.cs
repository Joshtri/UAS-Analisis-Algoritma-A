using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class BubbleSort : QuickSort
    {
        public override void SortAlgorithm(int[,] matrix, int left, int right)
        {
            const int N = 100;
            int n = matrix.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (matrix[j / N, j % N] > matrix[(j + 1) / N, (j + 1) % N])
                    {
                        int temp = matrix[j / N, j % N];
                        matrix[j / N, j % N] = matrix[(j + 1) / N, (j + 1) % N];
                        matrix[(j + 1) / N, (j + 1) % N] = temp;
                    }
                }
            }
        }
        public override void PrintMatrix(int[,] matrix)
        {
            base.PrintMatrix(matrix);
        }

        //METHOD UNTUK BUBBLE SORT PARALELL PROCESS. 
        public void BubbleSortParalel(int[,] matrix)
        {
            // Menyortir matrix menggunakan bubble sort paralel
            Parallel.For(0, matrix.GetLength(0), i => {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = j + 1; k < matrix.GetLength(1); k++)
                    {
                        if (matrix[i, j] > matrix[i, k])
                        {
                            int temp = matrix[i, j];
                            matrix[i, j] = matrix[i, k];
                            matrix[i, k] = temp;
                        }
                    }
                }
            });
        }


    }
}
