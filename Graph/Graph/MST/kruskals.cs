using ADT.Union_Find;
using GraphADT.Directed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.MST
{
    class Kruskals
    {
        DirectedGraph G;
        public UnionFind uf;
        //Returns readonly array which contain the component in which the vertex belongs
        public IReadOnlyCollection<int> VertexComponent { get { return Array.AsReadOnly(uf.ComponentArray); } }
        //Contains the edges which will form the Minimus Spanning Tree
        public Queue<DirectedEdge> treeEdges;
        public Kruskals(DirectedGraph g)
        {
            G = g;
            if (G.Edges == null || G.Edges.Count == 0)
                return;
            uf = new UnionFind(G.V);
            treeEdges = new Queue<DirectedEdge>();
            FindMst();
        }
        private void FindMst()
        {
            //Marker which marks whether the vertex have already been included in the MST
            bool[] marked = Enumerable.Repeat<bool>(false, G.V).ToArray<bool>();
            List<DirectedEdge> sortedEdges = new List<DirectedEdge>(G.Edges);
            //Sort the edges in acsending order of their weight. Because we will start creating MST by picking the smallest vertex first.
            sortedEdges.Sort();

            foreach(DirectedEdge tempEdge in sortedEdges)
            {
                if (!uf.Connected(tempEdge.From, tempEdge.To))
                {
                    treeEdges.Enqueue(tempEdge);
                    uf.Union(tempEdge.From, tempEdge.To);
                }
            }//end of for
        }
        /// <summary>
        /// Add the adjacency vertices of the vertex
        /// </summary>
        /// <param name="set">SortedSet to which adjacency vertices will be added</param>
        /// <param name="v">Vertex whose adjacency list will be added</param>
        private void AddAdjancency(SortedSet<DirectedEdge> set, int v)
        {
            foreach (DirectedEdge edge in G[v])
            {
                set.Add(edge);
            }
        }
    }
}
