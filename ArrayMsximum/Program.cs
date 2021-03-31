using System;

namespace ArrayMaximum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ввод размера массива
            Console.WriteLine("Введите размер массива");
            int arrayLength = ParseInput();
            //Проверяем, что размер массива > 2, поскольку в противном случае задание не имеет смысла
            while (arrayLength < 2)
            {
                Console.WriteLine("Размер массива должен быть больше 2, введите другой размер");
                arrayLength = ParseInput();
            }

            //Считываем массив
            int[] userArray = new int[arrayLength];
            for (int i=0; i<arrayLength; i++)
            {
                Console.WriteLine($"Введите элемент массива номер {i}");
                userArray[i] = ParseInput();
            }

            //Ищем второй наибольший элемент
            int max, max2;
            if (userArray[0] > userArray[1])
            {
                max = userArray[0];
                max2 = userArray[1];
            }
            else
            {
                max = userArray[1];
                max2 = userArray[0];
            }
            for (int i = 2; i < arrayLength; i++)
            {
                if (userArray[i] > max2)
                {
                    if (userArray[i] >= max)
                    {
                        max2 = max;
                        max = userArray[i];
                    }
                    else
                    {
                        max2 = userArray[i];
                    }
                }
            }

            //Выводим найденные результаты
            if (max2 == max)
            {
                Console.WriteLine($"Массив содержит несколько равных элементов, и максимальный второй элемент равен максимальному первому {max2}");
            }
            else
            {
                Console.WriteLine($"Второе максимальное число {max2}, оно меньше максимального {max}");
            }
        }

        //Метод для парсинга введенной строки в целое число
        static int ParseInput()
        {
            int result;
            while (!int.TryParse(Console.ReadLine().Trim(), out result))
            {
                Console.WriteLine("Допустимо введение только целых чисел. Пожалуйста, повторите ввод.");
            }
            return result;
        }
    }
}