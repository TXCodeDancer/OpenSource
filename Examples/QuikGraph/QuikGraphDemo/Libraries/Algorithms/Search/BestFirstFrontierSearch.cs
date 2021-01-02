using QuikGraph;
using QuikGraph.Algorithms;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System.Collections.Generic;

namespace Algorithms.Search
{
    public static class BestFirstFrontierSearch
    {
        public static IDictionary<int, Edge<int>> GetVertexPredecessor(IBidirectionalGraph<int, Edge<int>> g, int root, int target)
        {
            IDistanceRelaxer distanceRelaxer = DistanceRelaxers.EdgeShortestDistance;
            var algorithm = new BestFirstFrontierSearchAlgorithm<int, Edge<int>>(g, edgeWeights => 1.0, distanceRelaxer);

            var recorder = new VertexPredecessorRecorderObserver<int, Edge<int>>();
            using (recorder.Attach(algorithm))
                algorithm.Compute(root, target);

            return recorder.VerticesPredecessors;
        }

        public static IDictionary<string, TaggedEdge<string, string>> GetVertexPredecessor(IBidirectionalGraph<string, TaggedEdge<string, string>> g, string root, string target)
        {
            IDistanceRelaxer distanceRelaxer = DistanceRelaxers.EdgeShortestDistance;
            var algorithm = new BestFirstFrontierSearchAlgorithm<string, TaggedEdge<string, string>>(g, edgeWeights => double.Parse(edgeWeights.Tag), distanceRelaxer);

            var recorder = new VertexPredecessorRecorderObserver<string, TaggedEdge<string, string>>();
            using (recorder.Attach(algorithm))
                algorithm.Compute(root, target);

            return recorder.VerticesPredecessors;
        }

        public static bool FoundTarget<TVertex, TEdge>(IBidirectionalGraph<TVertex, TEdge> g, TVertex root, TVertex target) where TEdge : IEdge<TVertex>
        {
            IDistanceRelaxer distanceRelaxer = DistanceRelaxers.EdgeShortestDistance;
            var algorithm = new BestFirstFrontierSearchAlgorithm<TVertex, TEdge>(g, edgeWeights => 1.0, distanceRelaxer);
            bool targetReached = false;
            algorithm.TargetReached += (sender, args) => targetReached = true;

            var recorder = new VertexPredecessorRecorderObserver<TVertex, TEdge>();
            using (recorder.Attach(algorithm))
                algorithm.Compute(root, target);

            return targetReached;
        }
    }
}