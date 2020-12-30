using QuikGraph;
using QuikGraph.Algorithms.MaximumFlow;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.MaximumFlow
{
    public static class EdmondsKarpMaxFlow
    {
        public static double Get(AdjacencyGraph<string, EquatableTaggedEdge<string, double>> graph, string source, string sink)
        {
            // edgeFactory will be used to create the reversed edges to store residual capacities using the ReversedEdgeAugmentorAlgorithm-class.
            // The edgeFactory assigns a capacity of 0.0 for the new edges because the initial (residual) capacity must be 0.0.
            EdgeFactory<string, EquatableTaggedEdge<string, double>> edgeFactory = (sourceNode, targetNode) => new EquatableTaggedEdge<string, double>(sourceNode, targetNode, 0.0);
            var reverseEdgesAlgorithm = new ReversedEdgeAugmentorAlgorithm<string, EquatableTaggedEdge<string, double>>(graph, edgeFactory);
            reverseEdgesAlgorithm.AddReversedEdges();

            var algorithm = new EdmondsKarpMaximumFlowAlgorithm<string, EquatableTaggedEdge<string, double>>(graph, edge => edge.Tag, edgeFactory, reverseEdgesAlgorithm);

            algorithm.Compute(source, sink);
            return algorithm.MaxFlow;
        }

        public static Dictionary<string, EquatableTaggedEdge<string, double>> GetPredecessors(AdjacencyGraph<string, EquatableTaggedEdge<string, double>> graph, string source, string sink)
        {
            // edgeFactory will be used to create the reversed edges to store residual capacities using the ReversedEdgeAugmentorAlgorithm-class.
            // The edgeFactory assigns a capacity of 0.0 for the new edges because the initial (residual) capacity must be 0.0.
            EdgeFactory<string, EquatableTaggedEdge<string, double>> edgeFactory = (sourceNode, targetNode) => new EquatableTaggedEdge<string, double>(sourceNode, targetNode, 0.0);
            var reverseEdgesAlgorithm = new ReversedEdgeAugmentorAlgorithm<string, EquatableTaggedEdge<string, double>>(graph, edgeFactory);
            reverseEdgesAlgorithm.AddReversedEdges();

            var algorithm = new EdmondsKarpMaximumFlowAlgorithm<string, EquatableTaggedEdge<string, double>>(graph, edge => edge.Tag, edgeFactory, reverseEdgesAlgorithm);

            algorithm.Compute(source, sink);
            return algorithm.Predecessors;
        }

        public static Dictionary<EquatableTaggedEdge<string, double>, double> GetResidualCapacities(AdjacencyGraph<string, EquatableTaggedEdge<string, double>> graph, string source, string sink)
        {
            // edgeFactory will be used to create the reversed edges to store residual capacities using the ReversedEdgeAugmentorAlgorithm-class.
            // The edgeFactory assigns a capacity of 0.0 for the new edges because the initial (residual) capacity must be 0.0.
            EdgeFactory<string, EquatableTaggedEdge<string, double>> edgeFactory = (sourceNode, targetNode) => new EquatableTaggedEdge<string, double>(sourceNode, targetNode, 0.0);
            var reverseEdgesAlgorithm = new ReversedEdgeAugmentorAlgorithm<string, EquatableTaggedEdge<string, double>>(graph, edgeFactory);
            reverseEdgesAlgorithm.AddReversedEdges();

            var algorithm = new EdmondsKarpMaximumFlowAlgorithm<string, EquatableTaggedEdge<string, double>>(graph, edge => edge.Tag, edgeFactory, reverseEdgesAlgorithm);

            algorithm.Compute(source, sink);
            return algorithm.ResidualCapacities;
        }
    }
}