using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Union_Find
{
    class UnionFind<T> where T : struct
    {
        private int _count;
        private int  _id;





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
