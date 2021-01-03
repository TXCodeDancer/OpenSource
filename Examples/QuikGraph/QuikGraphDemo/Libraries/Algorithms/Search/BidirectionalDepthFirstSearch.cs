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
        public static IDictionary<TVertex, TEdge> GetVertexPredecessor<TVertex, TEdge>(IBidirectionalGraph<TVertex, TEdge> g) where TEdge : IEdge<TVertex>
        {
            var algorithm = new BidirectionalDepthFirstSearchAlgorithm<TVertex, TEdge>(g);

            var recorder = new VertexPredecessorRecorderObserver<TVertex, TEdge>();
            using (recorder.Attach(algorithm))
                algorithm.Compute();

            return recorder.VerticesPredecessors;
        }

        //         public static IDictionary<int, Edge<int>> GetVertexPredecessor(IBidirectionalGraph<int, Edge<int>> g)
        //         {
        //             var algorithm = new BidirectionalDepthFirstSearchAlgorithm<int, Edge<int>>(g);
        //
        //             var recorder = new VertexPredecessorRecorderObserver<int, Edge<int>>();
        //             using (recorder.Attach(algorithm))
        //                 algorithm.Compute();
        //
        //             return recorder.VerticesPredecessors;
        //         }
        //
        //         public static IDictionary<string, TaggedEdge<string, string>> GetVertexPredecessor(IBidirectionalGraph<string, TaggedEdge<string, string>> g)
        //         {
        //             var algorithm = new BidirectionalDepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
        //
        //             var recorder = new VertexPredecessorRecorderObserver<string, TaggedEdge<string, string>>();
        //             using (recorder.Attach(algorithm))
        //                 algorithm.Compute();
        //
        //             return recorder.VerticesPredecessors;
        //         }
    }
}