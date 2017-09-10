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
            DirectedGraph graph = new DirectedGraph(7);
            Dijkstras djks = new Dijkstras(graph, 0);
            //0 2 5
            //0 3 6
            //0 1 2
            //3 6 3
            //3 4 1
            //1 5 9
            //4 5 2
        }
    }
}
