//
// Main: Method to demonstrate usage of the Visualize.Visualizer library.
//

using QuikGraph;
using QuikGraph.Graphviz.Dot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Visualize;

namespace Main
{
    public class EdgeModel
    {
        public EdgeModel(NodeModel v, long w = 1, string tag = "")
        {
            V = v;
            Tag = tag;
            Weight = w;
        }

        public NodeModel V { get; set; }
        public string Tag { get; set; }
        public long Weight { get; set; }
    }

    public class NodeModel
    {
        public NodeModel(string input)
        {
            var tokens = input.Split(' ');
            ID = int.Parse(tokens[0]);
            if (tokens.Length > 0)
                Name = tokens[1];
        }

        public NodeModel(int iD, string name = "")
        {
            ID = iD;
            Edges = new List<EdgeModel>();
            Name = name;
        }

        public int ID { get; set; }
        public List<EdgeModel> Edges { get; set; }
        public string Name { get; set; }

        public void AddDirectedEdge(NodeModel v, int weight, string tag)
        {
            Edges.Add(new EdgeModel(v, weight, tag));
        }
    }

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

        private static void Main(string[] args)
        {
            string filepath = @"ManualInput";
            var nodes = Console.ReadLine().Split(' ').ToList(); // First line is a space delimited list of node names: "1 2 3" or "a b c"
            List<List<string>> edges = new List<List<string>>();
            string edge;
            while ((edge = Console.ReadLine()) != null && edge != "")
            {
                edges.Add(edge.Split(' ').ToList());
            }

            GraphVisualizerHelper(nodes, edges, filepath);
        }
    }
}