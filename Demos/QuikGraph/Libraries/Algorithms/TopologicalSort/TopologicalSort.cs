using QuikGraph;
using QuikGraph.Algorithms.TopologicalSort;

namespace Algorithms.TopologicalSort
{
    public static class TopologicalSort
    {
        public static (int[], string) Get(AdjacencyGraph<int, Edge<int>> graph)
        {
            var algorithm = new TopologicalSortAlgorithm<int, Edge<int>>(graph);

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

        public static (string[], string) Get(AdjacencyGraph<string, TaggedEdge<string, string>> graph)
        {
            var algorithm = new TopologicalSortAlgorithm<string, TaggedEdge<string, string>>(graph);

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
