using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int[] sizes = { 1000, 10000, 100000 }; // Farklı dizi boyutları
        int k = 10; // K. en küçük eleman

        foreach (var size in sizes)
        {
            Console.WriteLine($"Dizi Boyutu: {size}");

            // Rastgele bir dizi oluştur
            int[] array = GenerateRandomArray(size);

            // Yöntem 1: Diziyi sıralayıp k. elemanı bul
            Stopwatch stopwatch = Stopwatch.StartNew();
            int result1 = FindKthSmallestUsingSort(array, k);
            stopwatch.Stop();
            Console.WriteLine($"Yöntem 1: {result1}, Zaman: {stopwatch.ElapsedMilliseconds} ms");

            // Yöntem 2: Diziyi sıralayıp, kalanları insertion sort ile karşılaştır
            stopwatch = Stopwatch.StartNew();
            int result2 = FindKthSmallestUsingInsertionSort(array, k);
            stopwatch.Stop();
            Console.WriteLine($"Yöntem 2: {result2}, Zaman: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
        }
    }

    // Yöntem 1: Diziyi sıralayıp k. en küçük elemanı bul
    static int FindKthSmallestUsingSort(int[] array, int k)
    {
        Array.Sort(array);
        return array[k - 1];
    }

    // Yöntem 2: Diziyi sıralayıp kalanları insertion sort ile karşılaştır
    static int FindKthSmallestUsingInsertionSort(int[] array, int k)
    {
        // Diziyi sıralıyoruz
        Array.Sort(array);

        // Insertion sort ile kalan elemanları karşılaştırıyoruz
        for (int i = k; i < array.Length; i++)
        {
            for (int j = i; j > 0 && array[j] < array[j - 1]; j--)
            {
                int temp = array[j];
                array[j] = array[j - 1];
                array[j - 1] = temp;
            }
        }
        return array[k - 1];
    }

    // Rastgele bir dizi oluştur
    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(1, 10000); // Rastgele 1 ile 10000 arasında değerler
        }
        return array;
    }
}