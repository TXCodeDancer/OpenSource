using QuikGraph;
using QuikGraph.Algorithms;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Search
{
    public static class BestFirstFrontierSearch
    {
        public static IBidirectionalIncidenceGraph<int, Edge<int>> Get(IBidirectionalGraph<int, Edge<int>> g)
        {
            IDistanceRelaxer distanceRelaxer = DistanceRelaxers.EdgeShortestDistance;
            var algorithm = new BestFirstFrontierSearchAlgorithm<int, Edge<int>>(g, edgeWeights => 1.0, distanceRelaxer);

            algorithm.Compute();
            return algorithm.VisitedGraph;
        }

        public static IBidirectionalIncidenceGraph<string, TaggedEdge<string, string>> Get(IBidirectionalGraph<string, TaggedEdge<string, string>> g)
        {
            IDistanceRelaxer distanceRelaxer = DistanceRelaxers.EdgeShortestDistance;
            var algorithm = new BestFirstFrontierSearchAlgorithm<string, TaggedEdge<string, string>>(g, edgeWeights => double.Parse(edgeWeights.Tag), distanceRelaxer);

            algorithm.Compute();
            return algorithm.VisitedGraph;
        }

        public static IBidirectionalIncidenceGraph<int, Edge<int>> Get(IBidirectionalGraph<int, Edge<int>> g, int root)
        {
            IDistanceRelaxer distanceRelaxer = DistanceRelaxers.EdgeShortestDistance;
            var algorithm = new BestFirstFrontierSearchAlgorithm<int, Edge<int>>(g, edgeWeights => 1.0, distanceRelaxer);

            algorithm.Compute(root);
            return algorithm.VisitedGraph;
        }

        public static IBidirectionalIncidenceGraph<string, TaggedEdge<string, string>> Get(IBidirectionalGraph<string, TaggedEdge<string, string>> g, string root)
        {
            IDistanceRelaxer distanceRelaxer = DistanceRelaxers.EdgeShortestDistance;
            var algorithm = new BestFirstFrontierSearchAlgorithm<string, TaggedEdge<string, string>>(g, edgeWeights => double.Parse(edgeWeights.Tag), distanceRelaxer);

            algorithm.Compute(root);
            return algorithm.VisitedGraph;
        }

        public static IBidirectionalIncidenceGraph<int, Edge<int>> Get(IBidirectionalGraph<int, Edge<int>> g, int root, int target)
        {
            IDistanceRelaxer distanceRelaxer = DistanceRelaxers.EdgeShortestDistance;
            var algorithm = new BestFirstFrontierSearchAlgorithm<int, Edge<int>>(g, edgeWeights => 1.0, distanceRelaxer);

            algorithm.Compute(root, target);
            return algorithm.VisitedGraph;
        }

        public static IBidirectionalIncidenceGraph<string, TaggedEdge<string, string>> Get(IBidirectionalGraph<string, TaggedEdge<string, string>> g, string root, string target)
        {
            IDistanceRelaxer distanceRelaxer = DistanceRelaxers.EdgeShortestDistance;
            var algorithm = new BestFirstFrontierSearchAlgorithm<string, TaggedEdge<string, string>>(g, edgeWeights => double.Parse(edgeWeights.Tag), distanceRelaxer);

            algorithm.Compute(root, target);
            return algorithm.VisitedGraph;
        }
    }
}