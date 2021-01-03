using QuikGraph;
using QuikGraph.Algorithms;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Search
{
    public static class BidirectionalDepthFirstSearch
    {
        public static IDictionary<int, Edge<int>> GetVertexPredecessor(IBidirectionalGraph<int, Edge<int>> g, int root)
        {
            var algorithm = new BidirectionalDepthFirstSearchAlgorithm<int, Edge<int>>(g);

            var recorder = new VertexPredecessorRecorderObserver<int, Edge<int>>();
            using (recorder.Attach(algorithm))
                algorithm.Compute(root);

            return recorder.VerticesPredecessors;
        }

        public static IDictionary<string, TaggedEdge<string, string>> GetVertexPredecessor(IBidirectionalGraph<string, TaggedEdge<string, string>> g, string root)
        {
            var algorithm = new BidirectionalDepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);

            var recorder = new VertexPredecessorRecorderObserver<string, TaggedEdge<string, string>>();
            using (recorder.Attach(algorithm))
                algorithm.Compute(root);

            return recorder.VerticesPredecessors;
        }
    }
}