using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_1
{
    public class MyMatrix
    {
        public float[][] data;
        public float min, max;

        private int m, n;
        public MyMatrix(int m, int n, float min, float max)
        {
            this.m = m;
            this.n = n;

            data = new float[m][];
            for (int i = 0; i < m; ++i)
            {
                data[i] = new float[n];
            }
            this.min = min;
            this.max = max;
            Fill();
        }

        public void Fill()
        {

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    data[i][j] = min + (max - min) * Random.Shared.NextSingle();
                }
            }
        }

        public void ChangeSize(int newM, int newN)
        {
            if (newM == m && newN == n) return;

            float[][] newdata = new float[newM][];

            for(int i = 0; i < newM; ++i)
            {
                newdata[i] = new float[newN];
            }
            
            for(int i = 0; i < newM; ++i)
            {
                for(int j = 0; j < newN; ++j)
                {
                    if (i >= m || j >= n)
                    {
                        newdata[i][j] = min + (max - min) * Random.Shared.NextSingle();
                    }
                    else
                    {
                        newdata[i][j] = data[i][j];
                    }
                }
            }

            m = newM;
            n = newN;
            data = newdata;
        }
    
        public void ShowPartially(int startM, int endM, int startN, int endN)
        {
            for(int i = startM; i < endM; ++i)
            {
                for(int j = startN; j < endN; ++j)
                {
                    Console.Write($"{data[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        public void Show()
        {
            ShowPartially(0, m, 0, n);
        }

        public float this[int i, int j]
        {
            get
            {
                return data[i][j];
            }
            set
            {
                data[i][j] = value;
            }
        }
    }
}
