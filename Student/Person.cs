
using System;
using System.Diagnostics;

namespace LR3
{
    public class Person
    {
        private string surname;
        private string name;
        private string patronymic;


        public string Surname
        {
            get => surname;
            set => surname = value.ToNameCase();
        }

        public string Name
        {
            get => name;
            set => name = value.ToNameCase();
        }

        public string Patronymic
        {
            get => patronymic;
            set => patronymic = value.ToNameCase();
        }

        public string FullName => $"{Surname} {Name} {Patronymic}";

        public ushort Age =>
              (ushort)((DateTime.Now.Year - Birthday.Year - 1) + (((DateTime.Now.Month > Birthday.Month)
            || ((DateTime.Now.Month == Birthday.Month) && (DateTime.Now.Day >= Birthday.Day))) ? 1 : 0));

        public Date Birthday { get; protected set; }


        public Person(string surname, string name, string patronymic, Date birthday)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Birthday = birthday;
        }

        //в этом языке не любят copy ctorы поэтому пускай будет protected)))
        protected Person(Person p) : this(p.Surname, p.Name, p.Patronymic, p.Birthday)
        {
        }

        public Person(string personaldata)
        {
            string[] pd = personaldata.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (pd.Length != 4)
            {
                Debug.WriteLine("парсинг личных данных сломался");
            }
            else
            {
                Surname = pd[0];
                Name = pd[1];
                Patronymic = pd[2];
                Birthday = pd[3];

            }

        }


        public override string ToString() => FullName + $" {Birthday}";

        public override bool Equals(object o)
        {
            if ((o == null) || !GetType().Equals(o.GetType()))
            {
                return false;
            }
            else
            {
                var p = (Person)o;
                return (p.Name == Name) && (p.Patronymic == Patronymic) && (p.Surname == Surname) && p.Birthday.Equals(Birthday);
            }
        }

        public override int GetHashCode() => HashCode.Combine(Surname, Name, Patronymic, Birthday);
    }
}
 