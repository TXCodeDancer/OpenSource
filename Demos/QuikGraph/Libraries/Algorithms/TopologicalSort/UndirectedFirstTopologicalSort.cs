using QuikGraph;
using QuikGraph.Algorithms.TopologicalSort;

namespace Algorithms.TopologicalSort
{
    public static class UndirectedFirstTopologicalSort
    {
        public static (int[], string) Get(UndirectedGraph<int, Edge<int>> graph)
        {
            var algorithm = new UndirectedFirstTopologicalSortAlgorithm<int, Edge<int>>(graph);

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
            var algorithm = new UndirectedFirstTopologicalSortAlgorithm<string, TaggedEdge<string, string>>(graph);

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
