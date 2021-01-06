using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System.Collections.Generic;

namespace Algorithms.Observers
{
    public class VertexDistanceObs
    {
        public static IDictionary<int, double> Get(AdjacencyGraph<int, Edge<int>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new VertexDistanceRecorderObserver<int, Edge<int>>(edgeWeights => 1.0);

            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.Distances;
            }
        }

        public static IDictionary<string, double> Get(AdjacencyGraph<string, TaggedEdge<string, string>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new VertexDistanceRecorderObserver<string, TaggedEdge<string, string>>(edgeWeights => double.Parse(edgeWeights.Tag));

            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.Distances;
            }
        }
    }
}