using Graph.MST;
using Graph.ShortestPath;
using GraphADT.Directed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedGraph graph = new DirectedGraph(7);//7 vertices
            //Dijkstras djks = new Dijkstras(graph, 0);
            //Prims mst = new Prims(graph);
            Kruskals mst = new Kruskals(graph);
            DirectedEdge [] edge = mst.treeEdges.ToArray();
//0 6 1
//0 2 5
//0 3 6
//0 1 2
//3 6 3
//3 4 1
//1 5 9
//1 2 3
//4 5 2
        }
    }
}
