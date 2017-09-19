using GraphADT.Directed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.MST
{
    class kruskals
    {
        DirectedGraph G;
        //Contains the edges which will form the Minimus Spanning Tree
        public Queue<DirectedEdge> treeEdges;
        public kruskals(DirectedGraph g)
        {
            G = g;
            if (G.Edges == null || G.Edges.Count == 0)
                return;
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
            DirectedEdge tempEdge;
            //Store the unique vertex in sorted order
            //SortedSet<DirectedEdge> sortedEdges = new SortedSet<DirectedEdge>(temp);

            //Add To vertex's adjacency edges to sortedEdges Set
            //AddAdjancency(sortedEdges, temp[0].To);
            //Add From vertex's adjacency edges to sortedEdges Set
            //AddAdjancency(sortedEdges, temp[0].From);

            for (int i = 0; i < G.V - 1 && sortedEdges.Count != 0; i++)
            {
                bool notAdded = true;
                while (notAdded)
                {
                    tempEdge = sortedEdges.FirstOrDefault();
                    if (tempEdge == null)
                        break;
                    sortedEdges.RemoveAt(0);
                    if (!marked[tempEdge.To])
                    {
                        treeEdges.Enqueue(tempEdge);
                        notAdded = false;
                        marked[tempEdge.To] = true;
                        marked[tempEdge.From] = true;
                        //AddAdjancency(sortedEdges, tempEdge.To);
                    }
                }//end of while
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
