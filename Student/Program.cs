using System;
using System.Linq;

namespace LR3
{

    class Program
    {
        static void Main()
        {
            var students = new[]
            {
                new Student("тумаш станислав игоревич 22.08.2001", "улица блаблабла", "+375255377984", "ФИТ", 2, 1),       
                new Student("савельев талан михайлович 03.07.1998", "улица1 блаблабла", "+375445938865", "ХТиТ", 2, 3),         
                new Student("стельмаков константин ЕВГЕНЬЕВИЧ 14.06.2001","улица2 блаблабла", "+375335785843", "ФИТ", 2, 4),
                new Student("василевич владимир павлович 21.03.2000", "улица3 блаблабла", "+375255377994", "ФИТ", 2, 3),
                new Student("удовыдченкова анастасия александровна 12.01.2001", "улица4 блаблабла", "+375334845667", "ФИТ", 2, 9),
                new Student("карпенкин         дмитрий анатольевич 28.04.1999", "улица5 блаблабла", "+375257359612", "ФИТ", 2, 4),
                new Student("пулатов александр егорович 29.12.2001", "улица6 блаблабла", "+375335785968", "ФИТ", 2, 3)
            };


            string faculty = "хтит";
            Console.WriteLine($"Студенты с факультета {faculty}:");
            students.Where(s => string.Equals(s.Faculty, faculty, StringComparison.OrdinalIgnoreCase)).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();

            int group = 4;
            Console.WriteLine($"Студенты с группы {group}:");
            students.Where(s => s.Group == group).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();


          
              (from student in students
            //здесь группируем свойства студентов в новый тип анонимный тип*/
              select new { ФИО = student.FullName, Номер = student.PhoneNumber }).ToList().ForEach(Console.WriteLine);
            //лмао имена на русском

            Console.WriteLine();



            Console.WriteLine(Student.Info);
        }
    }
}
 