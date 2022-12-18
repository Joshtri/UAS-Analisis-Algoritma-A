

/*
 * NAMA - NAMA KELOMPOK B :
 *  
 *          Analisis Algoritma A
 * 
 *  1. Archangela Zita Hardin (2006080019)
 *  2.Ariel Syaloom Toi  (2006080057)
 *  3.Arpakhsad Joshtri Sugiatma Lenggu (2006080010)
 * 
 * 
 */


//menggunakan file dan library diagnostics.
using ConsoleApp2;
using System.Linq;
using System.Diagnostics;


//instansiasi class quicksort dan bubblesort.
QuickSort quick = new QuickSort();
BubbleSort bubble = new BubbleSort();
QuickSortParallel quickParalell = new QuickSortParallel();

const int N = 5000;

//inisialisasi matrix dengan array multidimensional
int[,] matrix = new int[N,N];
Random random = new Random();

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        matrix[i, j] = random.Next();
    }
}


mainmenu:
Console.WriteLine("Selamat datang ditampilan console, silahkan memilih algoritma sorting yang diinginkan : \n");
Console.WriteLine("1. Quick Sort");
Console.WriteLine("2. Bubble Sort");
Console.WriteLine("3. Quick Sort Paralell Process ");
Console.WriteLine("4. Bubble Sort Paralell Process");

Console.Write("\n\nINPUT : (input number) : ");
var selectOption = int.Parse(Console.In.ReadLine()!);


if (selectOption == 1 || selectOption == 2 || selectOption == 3 || selectOption == 4)
{
    switch (selectOption)
    {
        case 1:
            Console.WriteLine("\"MENGGUNAKAN QUICK SORT\"\n");

            //Matriks sblm di sorting
            Console.WriteLine("Matriks Sebelum di sorting\n");
            quick.PrintMatrix(matrix);

            Stopwatch stopwatch = Stopwatch.StartNew();
        
            quick.SortAlgorithm(matrix, 0, matrix.Length - 1);

            stopwatch.Stop();
            Console.Beep();
            //Matriks setelah di sorting
            Console.WriteLine("\n\nMatriks setelah di sorting\n");
            Console.ForegroundColor = ConsoleColor.Green;
            quick.PrintMatrix(matrix);
            Console.ResetColor();

            Console.WriteLine("\n");
            // Menampilkan waktu kompleksitas
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine($"Lama waktu yang dikerjakan : {stopwatch.Elapsed.TotalSeconds} detik");
            Console.Beep();
            Console.ResetColor();
            stopwatch.Reset();

            break;
        case 2:
                
            Console.WriteLine("\"MENGGUNAKAN BUBBLE SORT\"\n");


            //Matriks sblm di sorting
            Console.WriteLine("Matriks Sebelum di sorting\n");
            bubble.PrintMatrix(matrix);

            Stopwatch stopwatch2 = Stopwatch.StartNew();

            //quick.SortAlgorithm(matrix, 0, matrix.Length - 1);
            bubble.SortAlgorithm(matrix, 0, 0);

            stopwatch2.Stop();

            //Matriks setelah di sorting
            Console.WriteLine("\n\nMatriks setelah di sorting\n");
            Console.ForegroundColor = ConsoleColor.Green;
            bubble.PrintMatrix(matrix);
            Console.ResetColor();

            Console.WriteLine("\n");
            // Menampilkan waktu kompleksitas
            Console.ForegroundColor = ConsoleColor.DarkBlue;


            Console.WriteLine($"Lama waktu yang dikerjakan : {stopwatch2.Elapsed.TotalSeconds} detik");

            Console.ResetColor();
            stopwatch2.Reset();
            break;
        case 3:
            Console.WriteLine("\"MENGGUNAKAN QUICK SORT PARALELL PROCESS\"\n");

            //Matriks sblm di sorting
            Console.WriteLine("Matriks Sebelum di sorting\n");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }


            Stopwatch stopwatch3 = Stopwatch.StartNew();

            // Sortir matriks menggunakan quick sort dengan proses paralel
            Parallel.For(0, N, i =>
            {
                QuickSort(matrix, i, 0, 4999);
            });

    

            stopwatch3.Stop();

            //Matriks setelah di sorting
            Console.WriteLine("\n\nMatriks setelah di sorting\n");
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ResetColor();

            Console.WriteLine("\n");
            // Menampilkan waktu kompleksitas
            Console.ForegroundColor = ConsoleColor.DarkBlue;


            Console.WriteLine($"Lama waktu yang dikerjakan : {stopwatch3.Elapsed.TotalSeconds} detik");

            Console.ResetColor();
            stopwatch3.Reset();

            break;

        case 4:
            Console.WriteLine("\"MENGGUNAKAN BUBBLE SORT PARALELL PROCESS\"\n");

            //Matriks sblm di sorting
            Console.WriteLine("Matriks Sebelum di sorting\n");
            bubble.PrintMatrix(matrix);

            Stopwatch stopwatch4 = Stopwatch.StartNew();

            //quick.SortAlgorithm(matrix, 0, matrix.Length - 1);
            bubble.BubbleSortParalel(matrix);

            stopwatch4.Stop();

            //Matriks setelah di sorting
            Console.WriteLine("\n\nMatriks setelah di sorting\n");
            Console.ForegroundColor = ConsoleColor.Green;
            bubble.PrintMatrix(matrix);
            Console.ResetColor();

            Console.WriteLine("\n");
            // Menampilkan waktu kompleksitas
            Console.ForegroundColor = ConsoleColor.DarkBlue;


            Console.WriteLine($"Lama waktu yang dikerjakan : {stopwatch4.Elapsed.TotalSeconds} detik");

            Console.ResetColor();
            stopwatch4.Reset();

            break;


        default:
            break;
    }
}

else
{
    Console.Clear();
    Console.Beep();
    Console.WriteLine("Inputan salah");
    goto mainmenu;
}



static void QuickSort(int[,] matrix, int row, int left, int right)
{
    if (left < right)
    {
        int pivotIndex = Partition(matrix, row, left, right);
        QuickSort(matrix, row, left, pivotIndex - 1);
        QuickSort(matrix, row, pivotIndex + 1, right);
    }
}

static int Partition(int[,] matrix, int row, int left, int right)
{
    int pivot = matrix[row, right];
    int i = left - 1;
    for (int j = left; j < right; j++)
    {
        if (matrix[row, j] <= pivot)
        {
            i++;
            Swap(matrix, row, i, j);
        }
    }
    Swap(matrix, row, i + 1, right);
    return i + 1;
}

static void Swap(int[,] matrix, int row, int i, int j)
{
    int temp = matrix[row, i];
    matrix[row, i] = matrix[row, j];
    matrix[row, j] = temp;
}










