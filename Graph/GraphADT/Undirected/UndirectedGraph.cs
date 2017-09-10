using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphADT.Undirected
{
    class UndirectedGraph
    {
        private int _v;
        private int _e;
        private List<int>[] _edges;
        public int V
        {
            get { return _v; }
            set { _v = value; }
        }
        public int E
        {
            get { return _e; }
            set { _e = value; }
        }
        public List<int> this[int i]
        {
            get { return _edges[i]; }
            set { _edges[i] = value; }
        }
        public UndirectedGraph(int v)
        {
            V = v;
            for (int i = 0; i < v; i++)
            {
                this[i] = new List<int>();
            }
            Console.Write("Enter the number of edges: ");
            E = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter source  followed by destination with space as delimeter:");
            for (int i = 0; i < E; i++)
            {
                String[] s = Console.ReadLine().Split(new char[] { ' ' });
                this[int.Parse(s[0])].Add( int.Parse(s[1]));
            }
        }
    }
    class UndirectedEdge
    {
        private int _to;
        private int _from;
        private int _weight;
        public int To
        {
            get { return _to; }
            set { _to = value; }
        }
        public int From
        {
            get { return _from; }
            set { _from = value; }
        }
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

    }
}
