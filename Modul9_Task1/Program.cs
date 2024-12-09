using System;

namespace Modul9_Task1
{
    class NullLastNameException : ArgumentNullException {}
    class Person{}    
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();

            try
            {
                CheckNullLastName(person1);
            }

            catch (Exception ex) when(ex is NullLastNameException)
                {
                Console.WriteLine("У объекта отсутсвует фамилия");
            }
                catch (Exception ex) when(ex is RankException)
                {
                Console.WriteLine("В метод передается массив с неправильным числом измерений.");
            }
                catch (FormatException)
                {
                Console.WriteLine("Введено не коректное значение!");
            }
                catch (Exception ex) when(ex is IndexOutOfRangeException)
                {
                Console.WriteLine("Индекс находится за пределами границ массива или коллекции.");
            }

                catch (Exception ex) when(ex is ArgumentOutOfRangeException)
                {
                Console.WriteLine("Аргумент находится за пределами диапазона допустимых значений.");
            }
        }

        static void CheckNullLastName(Person person)
        {
            throw new NullLastNameException();
        }
    }
}