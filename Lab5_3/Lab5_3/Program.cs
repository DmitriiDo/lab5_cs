namespace Lab5_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<string, float> dict = new();
            dict.Add("hello", 5);
            dict.Add("world", 10f);

            foreach(var dpair in dict)
            {
                Console.WriteLine($"Key : {dpair.key} Value : {dpair.val}");
            }
        }
    }
}