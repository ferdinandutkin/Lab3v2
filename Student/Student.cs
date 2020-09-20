using System;
using System.Diagnostics;

namespace LR3
{
    public partial class Student : Person
    {
        public readonly int id;


     
        private string phoneNumber;

      

        static Student()
        {
            currentCount = 0;
            infoTemplate = "Класс {0}, на данный момент насчитывающий {1} объектов";
        }

        public override string ToString() => base.ToString() + $" {Faculty} {Course} {Group}";

        //  Адрес,  Телефон, Факультет, Курс, Группа.


        public string Address
        {
            get; set;
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                var toSet = value.Trim();
                if (toSet.Length != 13)
                {
                    Debug.WriteLine("номер должен быть 13 символов");
                }
                else
                {
                    phoneNumber = toSet;
                }

            }
        }

        public string Faculty
        {
            get; set;
        }
        public int Course
        {
            get; set;
        }

        public int Group
        {
            get; set;
        }

        public override bool Equals(object o)
        {

            if ((o == null) || !GetType().Equals(o.GetType()))
            {
                return false;
            }
            else
            {
                var s = (Student)o;
                return base.Equals(s) && (s.Address == Address) && (s.PhoneNumber == PhoneNumber) && (s.Faculty == Faculty) && (s.Course == Course) && (s.Group == Group);
            }
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(base.GetHashCode());
            hash.Add(Address);
            hash.Add(PhoneNumber);
            hash.Add(Faculty);
            hash.Add(Course);
            hash.Add(Group);
            return hash.ToHashCode();
        }

        private Student(Person p, string address, string phonenumber, string faculty, int course = 1, int group = 1) : base(p)
        {
            Address = address;
            PhoneNumber = phonenumber;
            Faculty = faculty;
            Course = course;
            Group = group;
            currentCount++;
            id = Math.Abs(GetHashCode());
        }
        //аргументы по умолчанию есть! приватный конструктор есть!
        public Student(string personaldata, string address, string phonenumber, string faculty, int course, int group) :
            this(new Person(personaldata), address, phonenumber, faculty, course, group)
        {
        }

        public Student() : this(new Person("Неизвестно Неизвестно Неизвестно 01.01.1970"), "Неизвестно", "Неизвестно", "Неизвестно")
        {
        }

        ~Student() => currentCount--;
        
    }
}
 