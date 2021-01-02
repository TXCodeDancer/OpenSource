using QuikGraph;
using QuikGraph.Algorithms;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System.Collections.Generic;

namespace Algorithms.Search
{
    public static class BestFirstFrontierSearch
    {
        public static IDictionary<int, Edge<int>> GetPath(IBidirectionalGraph<int, Edge<int>> g, int root, int target)
        {
            IDistanceRelaxer distanceRelaxer = DistanceRelaxers.EdgeShortestDistance;
            var algorithm = new BestFirstFrontierSearchAlgorithm<int, Edge<int>>(g, edgeWeights => 1.0, distanceRelaxer);

            var recorder = new VertexPredecessorRecorderObserver<int, Edge<int>>();
            using (recorder.Attach(algorithm))
                algorithm.Compute(root, target);

            return recorder.VerticesPredecessors;
        }

        public static IDictionary<string, TaggedEdge<string, string>> GetPath(IBidirectionalGraph<string, TaggedEdge<string, string>> g, string root, string target)
        {
            IDistanceRelaxer distanceRelaxer = DistanceRelaxers.EdgeShortestDistance;
            var algorithm = new BestFirstFrontierSearchAlgorithm<string, TaggedEdge<string, string>>(g, edgeWeights => double.Parse(edgeWeights.Tag), distanceRelaxer);

            var recorder = new VertexPredecessorRecorderObserver<string, TaggedEdge<string, string>>();
            using (recorder.Attach(algorithm))
                algorithm.Compute(root, target);

            return recorder.VerticesPredecessors;
        }
    }
}