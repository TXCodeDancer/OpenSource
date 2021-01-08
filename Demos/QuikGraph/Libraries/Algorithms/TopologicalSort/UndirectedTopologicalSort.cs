using QuikGraph;
using QuikGraph.Algorithms.TopologicalSort;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.TopologicalSort
{
    public static class UndirectedTopologicalSort
    {
        public static (int[], string) Get(UndirectedGraph<int, Edge<int>> graph)
        {
            var algorithm = new UndirectedTopologicalSortAlgorithm<int, Edge<int>>(graph);

            try
            {
                algorithm.Compute();
                return (algorithm.SortedVertices, null);
            }
            catch (System.Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public static (string[], string) Get(UndirectedGraph<string, TaggedEdge<string, string>> graph)
        {
            var algorithm = new UndirectedTopologicalSortAlgorithm<string, TaggedEdge<string, string>>(graph);

            try
            {
                algorithm.Compute();
                return (algorithm.SortedVertices, null);
            }
            catch (System.Exception ex)
            {
                return (null, ex.Message);
            }
        }
    }
}
