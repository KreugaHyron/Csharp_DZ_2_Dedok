using System;

namespace Csharp_DZ_2_Dedok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task_1 - Пользователь вводит число от 1 до 9999 (сумму выдачи в банкомате). Необходимо вывести на экран введенную сумму и в
            //конце написать название валюты с правильным окончанием. Например: 1 доллар, 70 долларов. 
            //Для решения этой задачи вам необходимо будет применять оператор % (остаток от деления).
            Console.Write("Введите сумму (от 1 до 9999): ");
            int amount = int.Parse(Console.ReadLine());
            string currency = "доллар";
            int lastDigit = amount % 10;
            int lastTwoDigits = amount % 100;

            if (lastTwoDigits >= 11 && lastTwoDigits <= 19)
            {
                currency = "долларов";
            }
            else
            {
                switch (lastDigit)
                {
                    case 1:
                        currency = "доллар";
                        break;
                    case 2:
                    case 3:
                    case 4:
                        currency = "доллара";
                        break;
                    default:
                        currency = "долларов";
                        break;
                }
            }
            Console.WriteLine($"{amount} {currency}");

            //Task_2 - Пользователь вводит число с клавиатуры. С использованием цикла for проверить, является ли это число простым.
            Console.Write("Введите число: ");
            int number = int.Parse(Console.ReadLine());
            bool isPrime = true;
            if (number <= 1)
            {
                isPrime = false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            if (isPrime)
            {
                Console.WriteLine($"{number} является простым числом.");
            }
            else
            {
                Console.WriteLine($"{number} не является простым числом.");
            }

            //Task_3 - Пользователь вводит число с клавиатуры. С помощью цикла while вывести все его цифры справа налево.
            Console.Write("Введите число: ");
            int number_1 = int.Parse(Console.ReadLine());

            if (number_1 < 0)
            {
                number_1 = -number_1;
                Console.Write("-");
            }
            Console.Write("Цифры числа справа налево: ");
            while (number_1 > 0)
            {
                int digit = number_1 % 10;
                Console.Write(digit);
                number_1 /= 10;
            }
            Console.WriteLine();

            //Task_4 - Пользователь вводит число с клавиатуры. С использованием цикла for проверить, является ли это число числом Армстронга.
            Console.Write("Введите число: ");
            int number_2 = int.Parse(Console.ReadLine());
            int originalNumber = number_2;
            int numberOfDigits = number_2.ToString().Length;
            int sum = 0;
            
            for (int temp = number; temp > 0; temp /= 10)
            {
                int digit = temp % 10;
                sum += (int)Math.Pow(digit, numberOfDigits);
            }
            if (sum == originalNumber)
            {
                Console.WriteLine($"{originalNumber} является числом Армстронга.");
            }
            else
            {
                Console.WriteLine($"{originalNumber} не является числом Армстронга.");
            }

            //Task_5 - Начальный вклад в банке равен 10000 грн. Через каждый месяц размер вклада увеличивается на P процентов от имеющейся суммы
            //(P — вещественное число, 0 < P < 25). Значение Р программа должна получать у пользователя. По данному P определить,
            //через сколько месяцев размер вклада превысит 11000 грн., и вывести найденное количество месяцев K (целое число) и
            //итоговый размер вклада S (вещественное число).
            double initialDeposit = 10000.0;
            double targetDeposit = 11000.0;
            Console.Write("Введите значение P (в процентах, от 0 до 25): ");
            double P = double.Parse(Console.ReadLine());

            if (P <= 0 || P >= 25)
            {
                Console.WriteLine("Ошибка: значение P должно быть в пределах (0, 25).");
                return;
            }
            int months = 0;
            double currentDeposit = initialDeposit;
            while (currentDeposit <= targetDeposit)
            {
                currentDeposit += currentDeposit * (P / 100);
                months++;
            }
            Console.WriteLine($"Количество месяцев: {months}");
            Console.WriteLine($"Итоговый размер вклада: {currentDeposit:F2} грн.");
        }
    }
}
