using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_2
{
    public class MyList<T>
    {
        public int Count
        {
            get => _count;
        }

        private int _count;
        private int _allocated;
        private T[]? data;

        public MyList() {
            _count = 0;
            _allocated = 1;
            data = new T[1];
        }

        public void Add(T val)
        {
            if(_count + 1 > _allocated)
            {
                T[] newData = new T[_allocated * 2];
                _allocated *= 2;
                data.CopyTo((Memory<T>)newData);
                data = newData;
            }

            data[_count] = val;
            ++_count;
        }

        public T this[int idx]
        {
            get
            {
                return data[idx];
            }
        }
    }
}
