using System.Collections.Immutable;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
namespace Modul9_HW
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> People = new List<Person>
            {
                new Person {LastName = "Петров" },
                new Person {LastName = "Сидоров"},
                new Person {LastName = "Куликов"},
                new Person {LastName = "Алиев"},
                new Person {LastName = "Ялуев"},
                new Person {LastName = ""}
            };
            
            SortLastName sortLastName = new SortLastName();
            sortLastName.SortLastNameEvent += ShowNumber;

            while (true)
            {
                try
                {
                    sortLastName.Enter();

                    if (People.Any(person => string.IsNullOrWhiteSpace(person.LastName)))
                    {
                        throw new MyCustomException("Некорректное значение фамилии.");
                    }
                }
                catch (Exception ex) when (ex is MyCustomException)
                {
                    Console.WriteLine("Ошибка: В списке обнаружена некорректная фамилия (пустая или содержит только пробелы).");

                }
                catch (Exception ex) when (ex is RankException)
                {
                    Console.WriteLine("В метод передается массив с неправильным числом измерений.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено не коректное значение!");
                }
                catch (Exception ex) when (ex is IndexOutOfRangeException)
                {
                    Console.WriteLine("Индекс находится за пределами границ массива или коллекции.");
                }

                catch (Exception ex) when (ex is ArgumentOutOfRangeException)
                {
                    throw new MyCustomException("Ошибка: введено отрицательное число.");
                     
                }

            }
            void ShowNumber(int number)
            {
                switch (number)
                {
                    case 1:
                        Console.WriteLine("Введено значение 1. Выполняем процедуру...");
                        People = People.OrderBy(x => x.LastName).ToList();

                        foreach (Person person in People)
                        {
                            Console.WriteLine(person.LastName);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Введено значение 2. Выполняем процедуру...");
                        People = People.OrderBy(x => x.LastName).ToList();
                        People.Reverse();

                        foreach (Person person in People)
                        {
                            Console.WriteLine(person.LastName);
                        }
                        break;
                }
            }
        }

    }
    public class SortLastName
    {
        public delegate void SortLastNameDelegate(int number);
        public event SortLastNameDelegate SortLastNameEvent;

        public void Enter()
        {
            Console.WriteLine();
            Console.WriteLine("Введите число 1: (сортировка фамилий А-Я), либо число 2: (сортировка фамилий Я-А).");

            int number = Convert.ToInt32(Console.ReadLine());
            if (number != 1 && number != 2) throw new FormatException();

            EnteredNumber(number);
        }
        internal virtual void EnteredNumber(int number)
        {
            SortLastNameEvent?.Invoke(number);
        }
    }

}


