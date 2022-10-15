using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temat_07pd
{
    class Student
    {
        int[][] lessons = new int[3][];
        private string _initials;

        public Student()
        {
            _initials = "Student name";
            for (int i = 0; i < lessons.Length; i++)
            {
                lessons[i] = new int[0];
            }
        }
        public Student(string name)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                _initials = name;
                for (int i = 0; i < lessons.Length; i++)
                {
                    lessons[i] = new int[0];
                }
            }
            else
            {
                Console.WriteLine("\tName setting error!");
                _initials = "Student name";
            }
        }
        public string Initials
        {
            get { return _initials; }
            set { _initials = value; }
        }
        public void SetMark(int lesson, int mark)
        {
            if (lesson >= 1 && lesson <= 3 && mark > 0 && mark <= 12)
            {
                Array.Resize(ref lessons[lesson - 1], lessons[lesson - 1].Length + 1); // Увеличиваем ячейку нужного массива на + 1
                lessons[lesson - 1][lessons[lesson - 1].Length - 1] = mark; // в выделенную ячейку записываем оценку
            }
            else
            {
                Console.WriteLine("\tWrong mark or ID!");
            }
        }
        public void SetMark(int lesson) // Перегрузка = случайное выставление оценки
        {
            if (lesson >= 1 && lesson <= 3)
            {
                Random r = new Random();
                Array.Resize(ref lessons[lesson - 1], lessons[lesson - 1].Length + 1);
                lessons[lesson - 1][lessons[lesson - 1].Length - 1] = r.Next(1, 13);
            }
            else
            {
                Console.WriteLine("\tWrong lesson ID!");
            }
        }
        public void ShowStudent()
        {
            Console.WriteLine($"\nName: {_initials}\n");
            for (int i = 0; i < lessons.Length; i++)
            {
                Console.WriteLine($"Lesson # {i + 1}");
                for (int j = 0; j < lessons[i].Length; j++)
                {
                    Console.Write($"{lessons[i][j]} | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void ShowCurrentLesson(int lesson)
        {
            Console.WriteLine($"\nLesson #{lesson}");
            for (int j = 0; j < lessons[lesson-1].Length; j++)
            {
                Console.Write($"{lessons[lesson - 1][j]} | ");
            }
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Необходимо создать класс Student.

             Реализовать в нем следующую функциональность:

             + массив оценок по трем предметам (jagged);
             + метод выставления оценок;
             + метод показа оценок по определенному предмету;
             + метод вывода информации о студенте.
             */

            /*student.SetMark(1, 10);
            student.SetMark(1, 12);
            student.SetMark(1, 11);
            student.SetMark(1, 10);
            student.SetMark(1, 12);
            student.SetMark(1, 11);

            student.SetMark(2, 11);
            student.SetMark(2, 12);
            student.SetMark(2, 11);

            student.SetMark(3, 12);
            student.SetMark(3, 11);
            student.SetMark(3, 10);
            student.SetMark(3, 12);
            student.SetMark(3, 11);

            student.ShowStudent();*/

            int menu, mark, lesson;
            Console.Write("Student's name: ");
            string name = Console.ReadLine();

            Student student = new Student(name);


            do
            {
                Console.WriteLine("\n1. Set mark to student");
                Console.WriteLine("2. Set random mark to student");
                Console.WriteLine("3. Show student's info");
                Console.WriteLine("4. Show student's certain lesson");
                Console.WriteLine("5. Change student's initials");
                Console.Write("0. Exit\nChoice: ");
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.Write("Input lesson: ");
                        lesson = int.Parse(Console.ReadLine());
                        Console.Write("Input a mark for the lesson on a 12-point system: ");
                        mark = int.Parse(Console.ReadLine());

                        student.SetMark(lesson, mark);
                        Console.WriteLine("\tMark set succesfully!");
                        break;

                    case 2:
                        Console.Write("Input lesson: ");
                        lesson = int.Parse(Console.ReadLine());

                        student.SetMark(lesson);
                        Console.WriteLine("\tRandom mark set succesfully!");
                        break;

                    case 3:
                        student.ShowStudent();
                        break;

                    case 4:
                        Console.Write("Input lesson: ");
                        lesson = int.Parse(Console.ReadLine());

                        student.ShowCurrentLesson(lesson);
                        break;

                    case 5:
                        Console.Write("Input name: ");
                        name = Console.ReadLine();

                        student.Initials = name;
                        Console.WriteLine("\tInitials changed succesfully!");
                        break;

                    default:
                        if (menu > 5 || menu != 0 || menu < 0) Console.WriteLine("\tWrong menu item selected.\n");
                        break;
                }
            } while (menu != 0);

            Console.ReadKey();
        }
    }
}
