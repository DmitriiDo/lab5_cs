
namespace Lab5_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter M");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter N");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter min value");
            float min = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter max value");
            float max = float.Parse(Console.ReadLine());

            MyMatrix mat = new MyMatrix(m,n, min, max);

            mat.Show();

            Console.WriteLine("Adding 2 more rows and 3 more columns");
            mat.ChangeSize(m + 2, n + 3);
            mat.Show();

            Console.WriteLine("Removing 2 rows and 3 columns");
            mat.ChangeSize(mat.data.Length - 2, mat.data[0].Length - 3);
            mat.Show();

            Console.WriteLine("Showing upper left corner [maybe] minor");
            mat.ShowPartially(0, mat.data.Length - 1, 0, mat.data[0].Length - 1);

            Console.WriteLine("Changing upper left corner value");
            mat[0,0] = 0.1f;
            mat.Show();

            Console.WriteLine("Showing upper left corner value");
            Console.WriteLine(mat[0, 0]);

            Console.ReadKey();
        }
    }
}