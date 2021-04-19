using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Task1_Solvery
{
    class Program
    {
        static void Main(string[] args)
        {
            LogIn();
        }

        static void Beep()
        {
            Random rnd = new Random();
            int firstValue = rnd.Next(37, 32767);
            int secondValue = rnd.Next(1000, 1500);
            Console.Beep(firstValue, secondValue);
            Start();
        }

        static void YouTube()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.youtube.com/");
            Start();
        }

        static void Exit()
        {
            Environment.Exit(0);
        }

        static void ConsolePoem()
        {
            char[] alphabet = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ', 'э', 'ю', 'я', ' ' };
            Random rnd = new Random();

            Console.WriteLine("Введите длину текста");
            int check = 0;
            check = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < check; i++)
            {
                sb.Append(alphabet[rnd.Next(0, alphabet.Length)]);
            }
            string result = sb.ToString();
            Console.WriteLine(result);
            Console.ForegroundColor = ConsoleColor.White;
            Start();
        }

        static void Start()
        {
            Console.WriteLine("choose your destiny: 1-системный звук. 2-вывод текста в консоль. 3-открыть ютюб. 4-закрыть программу");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    {
                        Beep();
                        break;
                    }
                case "2":
                    {
                        ConsolePoem();
                        break;
                    }
                case "3":
                    {
                        YouTube();
                        break;
                    }
                case "4":
                    {
                        Exit();
                        break;
                    }
                default:
                    Console.WriteLine("choose your destiny: 1-системный звук. 2-вывод текста в консоль. 3-открыть ютюб. 4-закрыть программу");
                    break;
            }
        }
        static void LogIn()
        {

            var stringJson = File.ReadAllText("user.json");
            User userJson = JsonSerializer.Deserialize<User>(stringJson);
            int ring = 0;

            Console.WriteLine("Введите логин");
            string name = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();
            User user = new User(name, password);

            while (!user.Equals(userJson))
            {
                ring++;
                LogIn();
                if (ring == 3)
                {
                    Console.Beep(15000, 1500);
                    Environment.Exit(0);
                }
            }
            Start();
        }
    }
}