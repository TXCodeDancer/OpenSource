using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System.Collections.Generic;

namespace Algorithms.Search
{
    public static class BidirectionalDepthFirstSearch
    {
        public static IDictionary<TVertex, TEdge> GetVertexPredecessor<TVertex, TEdge>(IBidirectionalGraph<TVertex, TEdge> g) where TEdge : IEdge<TVertex>
        {
            var algorithm = new BidirectionalDepthFirstSearchAlgorithm<TVertex, TEdge>(g);

            var recorder = new VertexPredecessorRecorderObserver<TVertex, TEdge>();
            using (recorder.Attach(algorithm))
                algorithm.Compute();

            return recorder.VerticesPredecessors;
        }
    }
}