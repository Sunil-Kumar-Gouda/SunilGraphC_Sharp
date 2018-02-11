using GraphADT.Directed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.ShortestPath
{
    class Dijkstras
    {
        private bool[] _visited;
        private int[] _distance;
        private bool this[char c,int i] {//Indexer is private which is the very strict specifier
            get { return _visited[i]; }//So the get and set should have more strict access specifier than private.
            set { _visited[i] = value; }// Since no specifier is more strict then private so we cant use any other specifer.(Protected indexer and private get/set allowed)
        }
        public int this[int index]
        {
            get { return _distance[index]; }
            private set { _distance[index] = value; }
        }
        public Dijkstras(DirectedGraph G,int s)
        {
            _visited = new bool[G.V];
            _distance = Enumerable.Repeat(int.MaxValue, G.V).ToArray();
            SPT(G, s);
        }
        public void SPT(DirectedGraph G,int s)
        {
            this['v',s] = false;
            this[s] = 0;
            int vertex = MinimumVertex(G) ;
            while (vertex != -1)
            {
                //Update all the reachable vertex from the selected vertex to the minmimum weight upto now + wight of the edge.
                foreach(DirectedEdge edge in G[vertex])
                {
                    if(this[vertex] +edge.Weight<this[edge.To])
                    {
                        this[edge.To] = this[vertex] + edge.Weight;
                    }
                }
                this['v',vertex] = true;
                //Find the updated minimum vertex which was updated just before
                vertex = MinimumVertex(G);
            }  
        }
        private int MinimumVertex(DirectedGraph G)
        {
            int min = int.MaxValue;
            int minVertex = -1;
            for(int i=0;i<G.V;i++)
            {
                if(!this['v',i]&&this[i]<min)
                {
                    min = this[i];
                    minVertex = i;
                }
            }
            return minVertex;
        }
    }
}
