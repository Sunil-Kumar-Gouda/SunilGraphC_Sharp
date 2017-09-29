using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Union_Find
{
    public class UnionFind
    {
        private int _count;
        private int []id;
        private int[] size;
        private int N;
        public int[] ComponentArray { get { return id; } }
        public UnionFind(int n)
        {
            id = new int[n];
            size = new int[n];
            N = n;
            _count = N;
            for (int i=0;i< N;i++)
            {
                id[i] = i;
                size[i] = 1;
            }
        }
        public bool Union(int u,int v)
        {
            int comU = Find(u);
            int comV = Find(v);
            int changeTo;
            int changeVertex;
            if (comU == comV)
                return false;
            if(size[comU] <=size[comV])
            {
                id[comU] = v;
                size[comV] +=size[comU];
                size[comU] = 0;
            }
            else
            {
                id[comV] = u;
                size[comU] += size[comV];
                size[comV] = 0;
            }
            _count--;
            return true;
        }
        public int Find(int u)
        {
            if (u >= N)
                return -999;
            int component = u;
            while(component!=id[component])
            {
                component = id[component];
            }
            return component;
        }
        public bool Connected(int u,int v)
        {
            return Find(u) == Find(v);
        }




        //public Dictionary<T, int> _id;
        //public Dictionary<T, int> _size;
        //public int Count
        //{
        //    get { return _count; }
        //    set { _count = value; }
        //}
        //public int this[T key]
        //{
        //    get { return _id[key]; }
        //    private set
        //    {
        //        _id[key] = value;
        //    }
        //}
        //public UnionFind()
        //{
        //    _id = new Dictionary<T, int>();
        //}
        //public bool AddData(T data)
        //{
        //    if (!_id.ContainsKey(data))
        //    {
        //        _id.Add(data, Count++);
        //        return true;
        //    }
        //    return false;
        //}
        //public int Find(T data)
        //{
        //    return this[data];
        //}
    }
}
