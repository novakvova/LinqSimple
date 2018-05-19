using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayLinq();
            //ArrayObjectLinq();
            //ListToLinq();
            List<Student> students = new List<Student>
            {
                new Student
                {
                    Name="Лодочкін Іван",
                    Group="39",
                    MarkArg=3.5F
                },
                new Student
                {
                    Name="Лодочкін Семен",
                    Group="28",
                    MarkArg=3.5F
                },
                new Student
                {
                    Name="Підкаблучник Семен",
                    Group="28",
                    MarkArg=3.0F
                },
                new Student
                {
                    Name="Петрик Пятачкін",
                    Group="28",
                    MarkArg=2.0F
                }
            };
            students.Add(new Student
            {
                Name = "Валік Семенов",
                Group = "28",
                MarkArg = 5.0F
            });
            Console.WriteLine("Вкажіть ім'я: ");
            string strNameSearch= Console.ReadLine();
            var query = from s in students select s;
            //IEnumerable<Student> temp=null;
            if (!string.IsNullOrEmpty(strNameSearch))
            {
                query = from s in query
                        where s.Name.Contains(strNameSearch)
                        select s;
            }
            
            Console.WriteLine("Вкажіть групу: ");
            string strGroupSearch = Console.ReadLine();
            if (!string.IsNullOrEmpty(strGroupSearch))
            {
                query = from s in query
                       where s.Group== strGroupSearch
                       select s;
            }
            //foreach (var stud in temp)
            //{
            //    Console.WriteLine($"{stud.Name} {stud.Group} {stud.MarkArg}");
            //}
            Console.WriteLine("Вкажіть середню оцінку: ");
            string strMarkSearch = Console.ReadLine();
            if (!string.IsNullOrEmpty(strMarkSearch))
            {
                float mark = float.Parse(strMarkSearch);
                query = from s in query
                        where s.MarkArg == mark
                        select s;
            }
            //var search

            if (query.Count() > 0)
            {
                Console.WriteLine("Результат пошуку: ");
                foreach (var stud in query)
                {
                    Console.WriteLine($"{stud.Name} {stud.Group} {stud.MarkArg}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Не знайдено жодного студента.");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        static void ArrayLinq()
        {
            int[] mass = new int[]
            { 1,2,3,6,8,9,0,12,9,5,3,2,0,9 };
            Console.WriteLine("All element array: ");
            for (int i = 0; i < mass.Length; i++)
            {
                Console.Write($"{mass[i]}\t");
            }
            Console.WriteLine();
            int find;
            Console.WriteLine("Enter elemtn find: ");
            find = int.Parse(Console.ReadLine());
            int[] result;
            result = (from item in mass
                      where item == find
                      select item).ToArray();
            //result = 
            Console.WriteLine("Результат пошуку: ");
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write($"{result[i]}\t");
            }
            Console.WriteLine();
        }
        static void ArrayObjectLinq()
        {
            Student[] students =
            {
                new Student
                {
                    Name="Лодочік Іван",
                    Group="39",
                    MarkArg=3.5F
                },
                new Student
                {
                    Name="Підкаблучник Семен",
                    Group="28",
                    MarkArg=3.0F
                },
                new Student
                {
                    Name="Петрик Пятачкін",
                    Group="28",
                    MarkArg=2.0F
                }
            };
            Console.WriteLine("Вкажіть назву групи(39/28)");
            string group = Console.ReadLine();
            var listStudents = from s in students
                               where s.Group == @group
                               select s;
            if (listStudents.Count() > 0)
            {
                Console.WriteLine("Результат пошуку: ");
                foreach (var stud in listStudents)
                {
                    Console.WriteLine($"{stud.Name} {stud.Group} {stud.MarkArg}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Не знайдено жодного студента.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void ListToLinq()
        {
            List<Student> students = new List<Student>
            {
                new Student
                {
                    Name="Лодочік Іван",
                    Group="39",
                    MarkArg=3.5F
                },
                new Student
                {
                    Name="Підкаблучник Семен",
                    Group="28",
                    MarkArg=3.0F
                },
                new Student
                {
                    Name="Петрик Пятачкін",
                    Group="28",
                    MarkArg=2.0F
                }
            };
            students.Add(new Student
            {
                Name = "Валік Семенов",
                Group = "28",
                MarkArg = 5.0F
            });
            IEnumerable<string> list = from s in students
                                       where s.MarkArg > 3.0
                                       select s.Name;
            Console.WriteLine("List student > 3.0");
            foreach (string i in list)
            {
                Console.WriteLine($"{i}");
            }
        }
    }
}
