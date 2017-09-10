using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphADT.Directed
{
    public class DirectedGraph
    {
        private int _v;
        private int _e;
        private List<DirectedEdge>[] _adjacency;
        private List<DirectedEdge> _edges;
        #region Properties
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
        public List<DirectedEdge> Edges
        {
            get { return _edges; }
        }
        public List<DirectedEdge> this[int i]
        {
            get { return _adjacency[i]; }
            set { _adjacency[i] = value; }
        }
        #endregion
        #region Instance Method
        public void AddEdge(int s,DirectedEdge edge)
        {
            this[s].Add(edge);
        }
        #endregion
        #region static methods
        public static int Degree(DirectedGraph G,int v)
        {
            int indegree=0;
           
            foreach(DirectedEdge edge in G.Edges)
            {
                if(edge.To==v)
                    indegree++;
            }
           return (G[v].Count+indegree);
        }
        public static int SelfLoop(DirectedGraph G)
        {
            int loopCount = 0;
            foreach(DirectedEdge edge in G.Edges)
            {
                if (edge.From == edge.To)
                    loopCount++;
            }
            return loopCount;
        }
        #endregion
        #region Constructor
        public DirectedGraph(int v)
        {
            V = v;
            _adjacency = new List<DirectedEdge>[v];
            for (int i=0;i< v;i++)
            {
                this[i] = new List<DirectedEdge>();
            }
            Console.Write("Enter the number of edges");
            E = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter source  followed by destination followed by weight with space as delimeter");
            for(int i=0;i< E;i++)
            {
                String []s=Console.ReadLine().Split(new char[] {' '});
                AddEdge(int.Parse(s[0]),new DirectedEdge()
                        {
                            To = int.Parse(s[1]), From = int.Parse(s[0]), Weight = int.Parse(s[2])
                        }
                    );
            }
        }
        #endregion
    }
    public class DirectedEdge
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
