using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommonElementsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Зчитування чисел з файлів та збереження їх у множинах
            HashSet<int> nums1 = ReadNumbersFromFile("Num_1.txt");
            HashSet<int> nums2 = ReadNumbersFromFile("Num_2.txt");

            // Знаходження перетину множин
            HashSet<int> commonElements = new HashSet<int>(nums1.Intersect(nums2));

            // Виведення результату на екран
            if (commonElements.Count == 0)
            {
                Console.WriteLine("У файлів немає спільних елементів.");
            }
            else
            {
                Console.WriteLine("Спільні елементи:");
                foreach (int element in commonElements)
                {
                    Console.WriteLine(element);
                }
            }
        }

        static HashSet<int> ReadNumbersFromFile(string filename)
        {
            HashSet<int> numbers = new HashSet<int>();

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int number))
                        {
                            numbers.Add(number);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Помилка читання файлу {filename}: {e.Message}");
            }

            return numbers;
        }
    }
}

