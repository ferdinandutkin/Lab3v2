
namespace LR3
{
    public partial class Student
    {
        static string infoTemplate;
        static int currentCount;
        public static string Info
          => string.Format(infoTemplate, typeof(Student).Name, currentCount);


    }
}
