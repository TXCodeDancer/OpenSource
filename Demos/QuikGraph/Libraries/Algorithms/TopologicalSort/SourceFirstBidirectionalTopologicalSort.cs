using QuikGraph;
using QuikGraph.Algorithms.TopologicalSort;

namespace Algorithms.TopologicalSort
{
    public static class SourceFirstBidirectionalTopologicalSort
    {
        public static (int[], string) Get(BidirectionalGraph<int, Edge<int>> graph)
        {
            var algorithm = new SourceFirstBidirectionalTopologicalSortAlgorithm<int, Edge<int>>(graph);

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

        public static (string[], string) Get(BidirectionalGraph<string, TaggedEdge<string, string>> graph)
        {
            var algorithm = new SourceFirstBidirectionalTopologicalSortAlgorithm<string, TaggedEdge<string, string>>(graph);

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
