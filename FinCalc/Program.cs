using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            //This app is a special software to make investment decisions 
            // На сколько корректно все переменные ставить double? Я сделал так, чтоб не заморачиваться пока на конвертацию одних форматов в другие
            // 

            double amountInvested;
            
            double investmentPeriodInYears;
            string userInput = "";
            decimal finalIncome;
            decimal allManagerialFees;


            // итак, калькулятор работает пока пользователь не ввел 00. Хм,а если подобрать какой-то другой вариант
            while (userInput != "00")
            {
                // Информируем пользователя, что он должен ввести сумму, которую готов инвестировать
                Console.WriteLine("Welcome to the FinCalc investment. Enter the amount you are ready to invest (thousands of dollar): ");
                // затем читаем эту сумму в строковую переменную
                userInput = Console.ReadLine();

                // а теперь конвертируем строку в дробь
                if (double.TryParse(userInput, out amountInvested) && amountInvested >= 100) // читается "получилось сделать цифру и она больше или равна 100"...
                {
                    //amountInvested = amountInvested * 1000; Не работает! На finalIncome это действие не влияет. Потому закомментил.
                    amountInvested = Convert.ToDouble(userInput); // строго говоря, TryParse уже произвел результат, но так наверное понятнее? :)
                }
                else
                {
                    Console.WriteLine("Sorry, you can invest not less then USD 100K! Starting over...\n\n");
                    continue;
                }

                // Спрашиваем пользователя,на какой период он готов разместить деньги
                Console.WriteLine("Enter the period your are ready to invest (years): ");
                // затем читаем ширину в строковую переменную
                userInput = Console.ReadLine();
                // а теперь конвертируем строку в дробь

                if (double.TryParse(userInput, out investmentPeriodInYears) && investmentPeriodInYears >= 1)
                {
                    investmentPeriodInYears = Convert.ToDouble(userInput);
                }
                else
                {
                    Console.WriteLine("Incorrect input, investment period must be 1 year or more! Starting over...\n\n");
                    continue;
                }

                // Теперь мы вызываем функцию из класса EstimateIncomeAndFees и...
                // сохраняем результат в нашу переменную:
                finalIncome = EstimateIncomeAndFees.CalculateIncome(amountInvested, investmentPeriodInYears);

                // если вдруг мы таки получили -1, что сейчас невозможно, но вдруг?
                if (finalIncome <= 0)
                {
                    Console.WriteLine("Something went terribly wrong, try to start over!");
                    continue;
                }

                allManagerialFees = EstimateIncomeAndFees.CalculateManagerialFees(amountInvested, investmentPeriodInYears);
                

                // у нас есть цена и мы выводим ее на экран
                Console.WriteLine("You can earn " + finalIncome + "$. Managerial fees are " + allManagerialFees + "$.");

            }
            Console.ReadKey();
        }
    }
}
