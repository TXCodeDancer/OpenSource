//
// Main: Method to demonstrate usage of the Visualize.Visualizer library.
//

using QuikGraph;
using QuikGraph.Graphviz.Dot;
using System;
using System.Collections.Generic;
using System.Linq;
using Visualize;

namespace Main
{
    public class Program
    {
        public static void GraphVisualizerHelper(List<string> nodes, List<List<string>> edges, string filepath)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            if (hasTaggedEdges)
            {
                var g = new AdjacencyGraph<string, TaggedEdge<string, string>>();
                g.AddVertexRange(nodes);
                foreach (var e in edges)
                {
                    g.AddEdge(new TaggedEdge<string, string>(e[0], e[1], e[2]));
                }
                Visualizer.ExportDot(g, filepath);
                Visualizer.VertexShape = GraphvizVertexShape.Box;
                Visualizer.VertexStyle = GraphvizVertexStyle.Rounded;
                Visualizer.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.circo);
            }
            else
            {
                var g = new AdjacencyGraph<int, Edge<int>>();
                List<int> intNodes = new List<int>();
                foreach (var v in nodes)
                {
                    intNodes.Add(int.Parse(v));
                }

                g.AddVertexRange(intNodes);
                foreach (var e in edges)
                {
                    g.AddEdge(new Edge<int>(int.Parse(e[0]), int.Parse(e[1])));
                }
                Visualizer.ExportDot(g, filepath);
                Visualizer.VertexShape = GraphvizVertexShape.Circle;
                Visualizer.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.dot);
            }
        }

        private static void Main()
        {
            string filepath = @"ManualInput";
            var nodes = Console.ReadLine().Split(' ').ToList(); // First line is a space delimited list of node names: "1 2 3" or "a b c"
            List<List<string>> edges = new List<List<string>>();
            string edge;
            while ((edge = Console.ReadLine()) != null && edge != "")
            {
                edges.Add(edge.Split(' ').ToList()); // Remaining lines are space delimited list of edges (nodeA nodeB tag(optional)):  "1 2" or "a b 5"
            }

            GraphVisualizerHelper(nodes, edges, filepath);
        }
    }
}