using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_3
{
    public class DictEntry<TKey, TValue>
    {
        public TKey key;
        public TValue val;
    }

    public class MyDictionary<TKey, TValue> : IEnumerable
    {
        private const int kBucketCount = 12;
        // change to MyList if needed
        private List<DictEntry<TKey,TValue>>[] buckets;


        public MyDictionary()
        {
            buckets = new List<DictEntry<TKey, TValue>>[kBucketCount];
            for(int i = 0; i < kBucketCount; ++i)
            {
                buckets[i] = new List<DictEntry<TKey,TValue>>();
            }
        }

        public int Length
        {
            get 
            {
                int res = 0;
                for(int i = 0; i < kBucketCount; ++i)
                {
                    res += buckets[i].Count;
                }
                return res;
            }
        }

        public void Add(TKey key, TValue val)
        {
            int bucket = Math.Abs(key.GetHashCode() % kBucketCount);
            buckets[bucket].Add(new DictEntry<TKey, TValue> { key = key, val = val });
        }

        public MyDictionaryEnumerator<TKey, TValue> GetEnumerator()
        {
            return new MyDictionaryEnumerator<TKey, TValue>(buckets);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TValue? this[TKey key]
        {
            get
            {
                int hash = key.GetHashCode();
                int bucket = hash % kBucketCount;
                foreach(var entry in buckets[bucket])
                {
                    if(entry.key.Equals(key))
                    {
                        return entry.val;
                    }
                }
                return default;
            }
        }
    }

    public class MyDictionaryEnumerator<TKey,TValue> : IEnumerator
    {
        object IEnumerator.Current => Current;
        public DictEntry<TKey, TValue> Current {
            get {
                if (buckets != null) {
                    return buckets[curBucket][curPosition];
                }
                return null;
            }
        }

        private readonly List<DictEntry<TKey, TValue>>[] buckets;

        private int curBucket = 0;
        private int curPosition = 0;
        private List<DictEntry<TKey, TValue>> curList = null;

        public MyDictionaryEnumerator(List<DictEntry<TKey, TValue>>[] buckets)
        {
            this.buckets = buckets;
            curPosition = 0;
            curList = buckets[0];
        }

        public bool MoveNext()
        {
            curPosition++;
            if(curPosition >= curList.Count)
            {
                curPosition = 0;
                curBucket++;

                curList = buckets[curBucket];
                while (curList.Count <= 0)
                {
                    ++curBucket;

                    if (curBucket >= buckets.Length) return false;
                    curList = buckets[curBucket];
                }

                if (curBucket >= buckets.Length) return false;

            }
            return true;
        }

        public void Reset()
        {
            curBucket = 0;
            curPosition = 0;
            curList = buckets[0];
        }
    }
}
