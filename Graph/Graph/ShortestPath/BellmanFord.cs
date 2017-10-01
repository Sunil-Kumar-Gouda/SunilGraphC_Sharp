using GraphADT.Directed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.ShortestPath
{
    public class BellmanFord
    {
        DirectedGraph G;
        int[] _distance;
        public IReadOnlyCollection<int> Distance { get { return Array.AsReadOnly(_distance); } }
        public BellmanFord(DirectedGraph G,int s)
        {
            this.G = G;
            MST(G, s);
        }
        private void MST(DirectedGraph G,int s)
        {
            if (G == null || G.V <= 1)
                return;
            _distance = Enumerable.Repeat(int.MaxValue, G.V).ToArray();
            _distance[s] = 0;
            for (int i = 0; i < G.V - 1; i++)
            {
                for(int j=0;j<G.V;j++)
                {
                    foreach (DirectedEdge edge in G[j])
                    {
                        if(_distance[edge.To]>_distance[edge.From]+edge.Weight)
                        {
                            _distance[edge.To] = _distance[edge.From] + edge.Weight;
                        }
                    }
                }
            }
        }
    }
}
