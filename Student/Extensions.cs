
namespace LR3
{
    static class StringExtensions
    {
        public static string ToNameCase(this string source) => source.ToLower().Remove(0, 1)
                    .Insert(0, source.Substring(0, 1).ToUpper());

    }


    static class RwordedAssignmenRequirements
    {
        public static void DoSmthng(this Student s, ref int i) => i = s.Age;
        public static void DoSmthngElse(this Student s, out int i) => i = s.Birthday.Year;

    }
}
