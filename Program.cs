using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge1;

namespace problem1LAB1
{
    internal class Program
    {
        static int Menu()
        {
            Console.WriteLine("1. Add Student.");
            Console.WriteLine("2. Show Students.");
            Console.WriteLine("3. Calculate Aggregate.");
            Console.WriteLine("4. Top Students.");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            return -1;
        }

        static Student InputData()
        {
            Console.WriteLine("Enter Student Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Student Matric Marks");
            float matricMarks = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter Student FSC Marks");
            float fscMarks = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter Student ECAT Marks");
            float ecatMarks = float.Parse(Console.ReadLine());

            return new Student(name, matricMarks, fscMarks, ecatMarks);
        }

        static void PrintData(Student[] studentsData)
        {
            Console.WriteLine("Name\t Matric Marks \t FSC Marks \t Ecat Marks \t Aggregate");
            for (int i = 0; i < studentsData.Length; i++)
            {
                Console.WriteLine($"{studentsData[i].Name}\t {studentsData[i].MatricMarks}\t\t {studentsData[i].FscMarks}\t \t{studentsData[i].EcatMarks}\t\t {studentsData[i].Aggregate}");
            }
        }

        static void AggregateCalculator(Student[] studentsData)
        {
            for (int i = 0; i < studentsData.Length; i++)
            {
                studentsData[i].Aggregate = (studentsData[i].FscMarks * 0.6F) + (studentsData[i].EcatMarks * 0.7F) + (studentsData[i].MatricMarks * 0.85F);
            }
        }

        static void DisplayTopStudents(Student[] studentsData, int topCount)
        {
            Console.WriteLine($"Top {topCount} Students:");
            for (int i = 0; i < studentsData.Length - 1; i++)
            {
                for (int j = 0; j < studentsData.Length - 1 - i; j++)
                {
                    if (studentsData[j].Aggregate < studentsData[j + 1].Aggregate)
                    {
                        Student temp = studentsData[j];
                        studentsData[j] = studentsData[j + 1];
                        studentsData[j + 1] = temp;
                    }
                }
            }

            // Display Top Students
            for (int i = 0; i < topCount && i < studentsData.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {studentsData[i].Name} - Aggregate: {studentsData[i].Aggregate}");
            }
        }

        static void Main(string[] args)
        {
            Student[] studentsData = new Student[3];
            int choice;

            while (true)
            {
                choice = Menu();

                switch (choice)
                {
                    case 1:
                        for (int i = 0; i < studentsData.Length; i++)
                        {
                            studentsData[i] = InputData();
                        }
                        AggregateCalculator(studentsData);
                        break;

                    case 2:
                        PrintData(studentsData);
                        break;

                    case 3:
                        //AggregateCalculator(studentsData);
                        PrintData(studentsData);
                        break;

                    case 4:
                        DisplayTopStudents(studentsData, 3);
                        break;

                    case 5:
                        Console.WriteLine("Exiting the program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}

