using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace module3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Выберите задачу (1-15)"); Console.WriteLine("   BONUS -- -16");
            int taskNumber = int.Parse(Console.ReadLine());

            switch (taskNumber)
            {
                case 1:
                    Expl1();
                    break;
                case 2:
                    Expl2();
                    break;
                case 3:
                    Expl3();
                    break;
                case 4:
                    Expl4();
                    break;
                case 5:
                    Expl5();
                    break;
                case 6:
                    Expl6();
                    break;
                case 7:
                    Expl7();
                    break;
                case 8:
                    Expl8();
                    break;
                case 9:
                    Expl9();
                    break;
                case 10:
                    Expl10();
                    break;
                case 11:
                    Expl11();
                    break;
                case 12:
                    Expl12();
                    break;
                case 13:
                    Expl13();
                    break;
                case 14:
                    Expl14();
                    break;
                case 15:
                    Expl15();
                    break;
                case 16:  //Bonus
                    ExplBonus();
                    break;
                default:
                    Console.WriteLine("Неверный номер задачи.");
                    break;
            }
        }

        // Задача 1: Напечатать весь массив целых чисел
        static void Expl1()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
        }

        // Задача 2: Найти индекс максимального значения в массиве
        static void Expl2()
        {
            int[] arr = { 5, 2, 8, 1, 7 };
            int maxIndex = Array.IndexOf(arr, arr.Max());
            Console.WriteLine("Индекс максимального значения: " + maxIndex);
        }

        // Задача 3: Удалить те элементы массива, которые встречаются в нем ровно два раза
        static void Expl3()
        {
            int[] arr = { 1, 2, 2, 3, 4, 4, 5, 6, 6 };
            var counts = arr.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            arr = arr.Where(x => counts[x] != 2).ToArray();
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
        }

        // Задача 4: В строке все слова, которые начинаются и заканчиваются одной буквой, выделить квадратными скобками
        static void Expl4()
        {
            string input = "apple banana cherry naaan";
            string[] words = input.Split(' ');
            foreach (string word in words)
            {
                if (word.Length >= 2 && word[0] == word[word.Length - 1])
                {
                    Console.Write("[" + word + "] ");
                }
                else
                {
                    Console.Write(word + " ");
                }
            }
        }

        // Задача 5: Написать программу, которая считывает символы с клавиатуры, пока не будет введена точка.
        // Программа должна сосчитать количество введенных пользователем пробелов
        static void Expl5()
        {
            int spaceCount = 0;
            char inputChar;
            do
            {
                inputChar = Console.ReadKey().KeyChar;
                if (inputChar == ' ')
                {
                    spaceCount++;
                }
            } while (inputChar != '.');
            Console.WriteLine("\nКоличество пробелов: " + spaceCount);
        }

        // Задача 6: Ввести с клавиатуры номер трамвайного билета (6-значное число) и проверить, является ли
        // данный билет счастливым (если на билете напечатано шестизначное число, и сумма первых трёх цифр
        // равна сумме последних трёх, то этот билет считается счастливым).
        static void Expl6()
        {
            Console.WriteLine("Введите номер трамвайного билета (6 цифр):");
            string input = Console.ReadLine();
            if (input.Length != 6)
            {
                Console.WriteLine("Некорректный номер билета.");
                return;
            }

            int sumFirstThreeDigits = 0;
            int sumLastThreeDigits = 0;

            for (int i = 0; i < 6; i++)
            {
                int digit = int.Parse(input[i].ToString());
                if (i < 3)
                {
                    sumFirstThreeDigits += digit;
                }
                else
                {
                    sumLastThreeDigits += digit;
                }
            }

            if (sumFirstThreeDigits == sumLastThreeDigits)
            {
                Console.WriteLine("Этот билет счастливый!");
            }
            else
            {
                Console.WriteLine("Этот билет не счастливый.");
            }
        }

        // Задача 7: Дан двумерный массив размерностью 5×5, заполненный случайными числами
        // из диапазона от –100 до 100. Определить сумму элементов массива, расположенных между минимальным и максимальным элементами
        static void Expl7()
        {
            int[,] matrix = new int[5, 5];
            Random rnd = new Random();

            // Заполняем матрицу случайными числами от -100 до 100
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = rnd.Next(-100, 101);
                }
            }

            int min = matrix[0, 0];
            int max = matrix[0, 0];
            int minRowIndex = 0;
            int maxRowIndex = 0;
            int sum = 0;

            // Находим минимальный и максимальный элементы и их индексы
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minRowIndex = i;
                    }
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxRowIndex = i;
                    }
                }
            }

            // Суммируем элементы между минимальным и максимальным элементами
            int startRow = Math.Min(minRowIndex, maxRowIndex);
            int endRow = Math.Max(minRowIndex, maxRowIndex);

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sum += matrix[i, j];
                }
            }

            Console.WriteLine("Сумма элементов между минимальным и максимальным элементами: " + sum);
        }

        // Задача 8: Дан текст. Определить, содержит ли он символы, отличающиеся от букв и цифр
        static void Expl8()
        {
            string text = "Пример текста 123!";
            bool containsSpecialCharacters = text.Any(c => !char.IsLetterOrDigit(c));
            if (containsSpecialCharacters)
            {
                Console.WriteLine("Текст содержит символы, отличающиеся от букв и цифр.");
            }
            else
            {
                Console.WriteLine("Текст не содержит символов, отличающихся от букв и цифр.");
            }
        }

        // Задача 9: Нужно ввести текст и определить, на какую букв начинается больше всего слов в тексте.
        static void Expl9()
        {
            string text = "Этот текст начинается с буквы А, а это - с буквы В. Вот и все!";
            string[] words = text.Split(' ');
            Dictionary<char, int> startingLetterCount = new Dictionary<char, int>();

            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    char firstLetter = char.ToUpper(word[0]);
                    if (char.IsLetter(firstLetter))
                    {
                        if (startingLetterCount.ContainsKey(firstLetter))
                        {
                            startingLetterCount[firstLetter]++;
                        }
                        else
                        {
                            startingLetterCount[firstLetter] = 1;
                        }
                    }
                }
            }

            char mostCommonStartingLetter = startingLetterCount.OrderByDescending(kvp => kvp.Value).First().Key;
            int count = startingLetterCount[mostCommonStartingLetter];
            Console.WriteLine($"Наибольшее количество слов начинается с буквы '{mostCommonStartingLetter}', их количество: {count}");
        }

        // Задача 10: Объявить одномерный (5 элементов ) массив с именем A и двумерный массив (3 строки, 4 столбца) дробных чисел с именем B.
        // Заполнить одномерный массив А числами, введенными с клавиатуры пользователем, а двумерный массив В случайными числами с помощью циклов.
        // Вывести на экран значения массивов: массива А в одну строку, массива В — в виде матрицы. Найти в данных массивах общий максимальный элемент,
        // минимальный элемент, общую сумму всех элементов, общее произведение всех элементов, сумму четных элементов массива А, сумму нечетных столбцов массива В.
        static void Expl10()
        {
            int[] A = new int[5];
            double[,] B = new double[3, 4];
            Random rnd = new Random();

            Console.WriteLine("Введите 5 чисел для массива A:");
            for (int i = 0; i < 5; i++)
            {
                A[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Массив A:");
            foreach (int num in A)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine("\nМассив B:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = rnd.NextDouble();
                    Console.Write(B[i, j] + " ");
                }
                Console.WriteLine();
            }

            int maxA = A.Max();
            int minA = A.Min();
            int sumA = A.Sum();
            double productB = 1.0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    productB *= B[i, j];
                }
            }

            int sumEvenA = A.Where(x => x % 2 == 0).Sum();

            double sumOddColumnsB = 0.0;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    sumOddColumnsB += B[i, j];
                }
            }

            Console.WriteLine("Максимальный элемент в массиве A: " + maxA);
            Console.WriteLine("Минимальный элемент в массиве A: " + minA);
            Console.WriteLine("Сумма элементов в массиве A: " + sumA);
            Console.WriteLine("Произведение элементов в массиве B: " + productB);
            Console.WriteLine("Сумма четных элементов в массиве A: " + sumEvenA);
            Console.WriteLine("Сумма элементов нечетных столбцов в массиве B: " + sumOddColumnsB);
        }

        // Задача 11: Найти индекс максимального четного значения в массиве
        static void Expl11()
        {
            int[] arr = { 3, 8, 12, 5, 10, 6 };
            int maxEven = arr.Where(x => x % 2 == 0).Max();
            int maxEvenIndex = Array.IndexOf(arr, maxEven);
            Console.WriteLine("Индекс максимального четного значения: " + maxEvenIndex);
        }

        // Задача 12: Удалить элемент из массива по индексу.
        static void Expl12()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int indexToRemove = 2; // Индекс элемента для удаления
            List<int> list = arr.ToList();
            list.RemoveAt(indexToRemove);
            arr = list.ToArray();
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
        }

        // Задача 13: Вставить элемент в массив по индексу
        static void Expl13()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int elementToInsert = 6;
            int indexToInsert = 2;
            List<int> list = arr.ToList();
            list.Insert(indexToInsert, elementToInsert);
            arr = list.ToArray();
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
        }

        // Задача 14: Ввести небольшой текст (с пробелами) в строку S. Подсчитать количество слов в строке и вывести все слова в столбик
        static void Expl14()
        {
            string input = "Это пример текста для подсчета слов";
            string[] words = input.Split(' ');
            int wordCount = words.Length;

            Console.WriteLine("Количество слов в строке: " + wordCount);
            Console.WriteLine("Слова в столбик:");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }

        // Задача 15: Дана строка символов. Группы символов, разделенные пробелами и не содержащие пробелов внутри себя, будем называть словами.
        // Найти количество слов, у которых первый и последний символы совпадают между собой
        static void Expl15()
        {
            string input = "apple banana level wow kayak";
            string[] words = input.Split(' ');
            int count = 0;

            foreach (string word in words)
            {
                if (word.Length >= 2 && word[0] == word[word.Length - 1])
                {
                    count++;
                }
            }

            Console.WriteLine("Количество слов с совпадающими первым и последним символами: " + count);
        }


        //BONUS 
        static void ExplBonus()
        {
            Console.WriteLine("Введите строку символов, состоящую из цифр от 0 до 9 и пробелов:");
            string input = Console.ReadLine();

            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;

            foreach (string word in words)
            {
                if (word.EndsWith("3") || word.EndsWith("4"))
                {
                    if (int.TryParse(word, out int number))
                    {
                        sum += number;
                    }
                }
            }

            Console.WriteLine("Сумма чисел, оканчивающихся на цифры 3 или 4: " + sum);

        }
    }

}
