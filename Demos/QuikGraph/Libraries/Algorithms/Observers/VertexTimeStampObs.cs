using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System.Collections.Generic;

namespace Algorithms.Observers
{
    public static class VertexTimeStampObs
    {
        public static IDictionary<int, int> GetDiscoverTimes(AdjacencyGraph<int, Edge<int>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new VertexTimeStamperObserver<int>();

            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.DiscoverTimes;
            }
        }

        public static IDictionary<string, int> GetDiscoverTimes(AdjacencyGraph<string, TaggedEdge<string, string>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new VertexTimeStamperObserver<string>();
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.DiscoverTimes;
            }
        }

        public static IDictionary<int, int> GetFinishTimes(AdjacencyGraph<int, Edge<int>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new VertexTimeStamperObserver<int>();

            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.FinishTimes;
            }
        }

        public static IDictionary<string, int> GetFinishTimes(AdjacencyGraph<string, TaggedEdge<string, string>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new VertexTimeStamperObserver<string>();
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.FinishTimes;
            }
        }
    }
}