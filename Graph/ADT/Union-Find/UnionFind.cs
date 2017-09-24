using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Union_Find
{
    class UnionFind<T> where T : class
    {
        public Dictionary<T, int> _id;
        private int _count;
        public UnionFind()
        {
            _id = new Dictionary<T, int>();
        }
    }
}
