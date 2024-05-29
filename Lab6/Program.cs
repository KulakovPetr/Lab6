using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static int ID;
        static DateTime RecordTime;
        static string FIO;
        static int Age;
        static int Height;
        static DateTime DateBirth;
        static string PlaceBirth;
        static void Main(string[] args)
        {            
            Console.WriteLine("Введите имя файла");
            string FileName = Console.ReadLine();

            AddRecordToFile(FileName);
            Console.WriteLine("Запись добавлена в файл");
            Console.ReadKey();

            Console.WriteLine("Содержимое файла");
            ReadFile(FileName);
            Console.ReadKey();
        }
        static void AddRecordToFile(string FileName)
        {
            if(File.Exists(FileName))
            {
                ID = File.ReadAllLines(FileName).Length+1;
            }
            else
            {
                ID = 1;
            }
            Console.WriteLine("Введите ФИО");
            FIO = Console.ReadLine();
            Console.WriteLine("Введите возраст");
            Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост");
            Height = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите дату рождения");
            DateBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите место рождения");
            PlaceBirth = Console.ReadLine();
            RecordTime = DateTime.Now;
            File.AppendAllLines(FileName, new string[]{ $"{ID}#{RecordTime}#{FIO}#{Age}#{Height}#{DateBirth.ToShortDateString()}#{PlaceBirth}" });
        }
        static void ReadFile(string FileName)
        {
            string[] Result = File.ReadAllLines(FileName);
            foreach(var e in Result)
            {
                string[] emploee = e.Split('#');
                Console.WriteLine($"Номер записи {emploee[0]}");
                Console.WriteLine($"Дата и время записи {emploee[1]}");
                Console.WriteLine($"ФИО {emploee[2]}");
                Console.WriteLine($"Возраст {emploee[3]}");
                Console.WriteLine($"Рост {emploee[4]}");
                Console.WriteLine($"Дата рождения {DateTime.Parse(emploee[5]).ToShortDateString()}");
                Console.WriteLine($"Место рождения {emploee[6]}");
            }            
        }        
    }
}
