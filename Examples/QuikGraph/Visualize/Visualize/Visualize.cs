using QuikGraph;
using QuikGraph.Graphviz;
using QuikGraph.Graphviz.Dot;
using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;

namespace Visualize
{
    public enum ImageLayout
    {
        none = 0,
        dot,
        neato,
        twopi,
        circo,
        fdp,
        sfdp,
        patchwork,
        osage
    }

    public static class Visualizer
    {
        private static GraphvizVertexShape _VertexShape = GraphvizVertexShape.Ellipse;
        private static GraphvizVertexStyle _VertexStyle = GraphvizVertexStyle.Rounded;

        public static GraphvizVertexShape VertexShape
        {
            get { return _VertexShape; }
            set { _VertexShape = value; }
        }

        public static GraphvizVertexStyle VertexStyle
        {
            get { return _VertexStyle; }
            set { _VertexStyle = value; }
        }

        private sealed class FileDotEngine : IDotEngine
        {
            public string Run(GraphvizImageType imageType, string dot, string outputFilePath, ImageLayout layout)
            {
                File.WriteAllText(outputFilePath + ".dot", dot);
                string type = imageType.ToString().ToLower();

                if (layout != ImageLayout.none)
                {
                    // assumes graphviz is on the path:
                    string args = string.Format(CultureInfo.InvariantCulture, $"{outputFilePath}.dot -T{type} -o {outputFilePath}_{layout}.{type}");
                    System.Diagnostics.Process process = System.Diagnostics.Process.Start($"{layout}.exe", args);
                    if (true)
                    {
                        process.WaitForExit();
                    }
                }

                return outputFilePath;
            }

            public string Run(GraphvizImageType imageType, string dotContents, string fileInfo)
            {
                var filepath = fileInfo.Split(' ');
                string filename = filepath[0];
                ImageLayout layout = ImageLayout.none;
                if (filepath.Length > 1)
                {
                    Enum.TryParse(filepath[1], true, out layout);
                }

                return Run(imageType, dotContents, filename, layout);
            }
        }

        public static void ExportDot(AdjacencyGraph<int, Edge<int>> graph, string filepath)
        {
            var viz = new GraphvizAlgorithm<int, Edge<int>>(graph);
            viz.Generate(new FileDotEngine(), filepath);
        }

        public static void ExportDot(AdjacencyGraph<string, TaggedEdge<string, string>> graph, string filepath)
        {
            var viz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(graph);
            viz.Generate(new FileDotEngine(), filepath);
        }

        public static string CreateImageFile(AdjacencyGraph<int, Edge<int>> graph, GraphvizImageType imageType, string imageFilepath, ImageLayout layout)
        {
            var graphviz = new GraphvizAlgorithm<int, Edge<int>>(graph) { ImageType = imageType };

            graphviz.FormatVertex += FormatVertexHandler;

            string fileInfo = $"{imageFilepath} {layout}";
            graphviz.Generate(new FileDotEngine(), fileInfo);
            return imageFilepath;
        }

        public static string CreateImageFile(AdjacencyGraph<string, TaggedEdge<string, string>> graph, GraphvizImageType imageType, string imageFilepath, ImageLayout layout)
        {
            var graphviz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(graph) { ImageType = imageType };

            graphviz.FormatVertex += FormatVertexHandler;
            graphviz.FormatEdge += MyEdgeFormatter;

            string fileInfo = $"{imageFilepath} {layout}";
            graphviz.Generate(new FileDotEngine(), fileInfo);
            return imageFilepath;
        }

        private static void FormatVertexHandler(object sender, FormatVertexEventArgs<string> e)
        {
            Contract.Requires(e != null);

            e.VertexFormat.Label = e.Vertex;
            e.VertexFormat.Shape = _VertexShape;
            e.VertexFormat.Style = _VertexStyle;
        }

        private static void FormatVertexHandler(object sender, FormatVertexEventArgs<int> e)
        {
            Contract.Requires(e != null);

            e.VertexFormat.Label = e.Vertex.ToString();
            e.VertexFormat.Shape = _VertexShape;
            e.VertexFormat.Style = _VertexStyle;
        }

        private static void MyEdgeFormatter(object sender, FormatEdgeEventArgs<string, TaggedEdge<string, string>> e)
        {
            GraphvizEdgeLabel label = new GraphvizEdgeLabel
            {
                Value = e.Edge.Tag,
            };
            e.EdgeFormat.Label = label;
        }
    }
}