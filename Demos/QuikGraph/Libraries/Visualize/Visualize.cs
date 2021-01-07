//
// Visualize.Visualizer: Methods to demonstrate usage of the QuikGraph.Graphviz NuGet package.
//

using QuikGraph;
using QuikGraph.Graphviz;
using QuikGraph.Graphviz.Dot;
using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;

namespace Visualizers
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

    public class Visualize
    {
        private GraphvizVertexShape _VertexShape = GraphvizVertexShape.Ellipse;
        private GraphvizVertexStyle _VertexStyle = GraphvizVertexStyle.Rounded;

        public Visualize(GraphvizVertexShape vertexShape = GraphvizVertexShape.Ellipse, GraphvizVertexStyle vertexStyle = GraphvizVertexStyle.Rounded)
        {
            _VertexShape = vertexShape;
            _VertexStyle = vertexStyle;
        }

        /// <summary>
        /// FileDotEngine: Interface to the IDotEngine
        /// Modification to the default implementation to allow exporting dot and image files
        /// </summary>
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

            /// <summary>
            /// Run: Run the FileDotEngine
            /// Parameter fileInfo contains the output filepath and optionally the image layout.
            /// The filepath and image layout are separated by a space ' '.
            /// For example: "{imageFilepath} {layout}" where
            /// outputFilepath = "D:\\Samples\\QuikGraph\\QuikSample\\Graphs\\filename"
            /// layout = ImageLayout.circo
            /// </summary>
            /// <param name="imageType"></param>
            /// <param name="dotContents"></param>
            /// <param name="fileInfo"></param>
            /// <returns></returns>
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

        /// <summary>
        /// ExportDot: Export Graphviz Dot file of graph
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="filepath"></param>
        public void ExportDot(AdjacencyGraph<int, Edge<int>> graph, string filepath)
        {
            var viz = new GraphvizAlgorithm<int, Edge<int>>(graph);
            viz.Generate(new FileDotEngine(), filepath);
        }

        public void ExportDot(BidirectionalGraph<int, Edge<int>> graph, string filepath)
        {
            var viz = new GraphvizAlgorithm<int, Edge<int>>(graph);
            viz.Generate(new FileDotEngine(), filepath);
        }

        public void ExportDot(UndirectedGraph<int, Edge<int>> graph, string filepath)
        {
            var viz = new GraphvizAlgorithm<int, Edge<int>>(graph);
            viz.Generate(new FileDotEngine(), filepath);
        }

        /// <summary>
        /// ExportDot: Export Graphviz Dot file of graph
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="filepath"></param>
        public void ExportDot(AdjacencyGraph<string, TaggedEdge<string, string>> graph, string filepath)
        {
            var viz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(graph);
            viz.Generate(new FileDotEngine(), filepath);
        }

        public void ExportDot(BidirectionalGraph<string, TaggedEdge<string, string>> graph, string filepath)
        {
            var viz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(graph);
            viz.Generate(new FileDotEngine(), filepath);
        }

        public void ExportDot(UndirectedGraph<string, TaggedEdge<string, string>> graph, string filepath)
        {
            var viz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(graph);
            viz.Generate(new FileDotEngine(), filepath);
        }

        /// <summary>
        /// ExportImageFile:
        /// Export image file with GraphvizImageType and ImageLayout to filepath.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="imageType"></param>
        /// <param name="filepath"></param>
        /// <param name="layout"></param>
        /// <returns></returns>
        public string ExportImageFile(AdjacencyGraph<int, Edge<int>> graph, GraphvizImageType imageType, string filepath, ImageLayout layout)
        {
            var graphviz = new GraphvizAlgorithm<int, Edge<int>>(graph) { ImageType = imageType };

            graphviz.FormatVertex += VertexFormatter;

            string fileInfo = $"{filepath} {layout}";
            graphviz.Generate(new FileDotEngine(), fileInfo);
            return filepath;
        }

        public string ExportImageFile(BidirectionalGraph<int, Edge<int>> graph, GraphvizImageType imageType, string filepath, ImageLayout layout)
        {
            var graphviz = new GraphvizAlgorithm<int, Edge<int>>(graph) { ImageType = imageType };

            graphviz.FormatVertex += VertexFormatter;

            string fileInfo = $"{filepath} {layout}";
            graphviz.Generate(new FileDotEngine(), fileInfo);
            return filepath;
        }

        public string ExportImageFile(UndirectedGraph<int, Edge<int>> graph, GraphvizImageType imageType, string filepath, ImageLayout layout)
        {
            var graphviz = new GraphvizAlgorithm<int, Edge<int>>(graph) { ImageType = imageType };

            graphviz.FormatVertex += VertexFormatter;

            string fileInfo = $"{filepath} {layout}";
            graphviz.Generate(new FileDotEngine(), fileInfo);
            return filepath;
        }

        /// <summary>
        /// ExportImageFile:
        /// Export image file with GraphvizImageType and ImageLayout to filepath.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="imageType"></param>
        /// <param name="filepath"></param>
        /// <param name="layout"></param>
        /// <returns></returns>
        public string ExportImageFile(AdjacencyGraph<string, TaggedEdge<string, string>> graph, GraphvizImageType imageType, string imageFilepath, ImageLayout layout)
        {
            var graphviz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(graph) { ImageType = imageType };

            graphviz.FormatVertex += FormatVertexHandler;
            graphviz.FormatEdge += EdgeFormatter;

            string fileInfo = $"{imageFilepath} {layout}";
            graphviz.Generate(new FileDotEngine(), fileInfo);
            return imageFilepath;
        }

        public string ExportImageFile(BidirectionalGraph<string, TaggedEdge<string, string>> graph, GraphvizImageType imageType, string imageFilepath, ImageLayout layout)
        {
            var graphviz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(graph) { ImageType = imageType };

            graphviz.FormatVertex += FormatVertexHandler;
            graphviz.FormatEdge += EdgeFormatter;

            string fileInfo = $"{imageFilepath} {layout}";
            graphviz.Generate(new FileDotEngine(), fileInfo);
            return imageFilepath;
        }

        public string ExportImageFile(UndirectedGraph<string, TaggedEdge<string, string>> graph, GraphvizImageType imageType, string imageFilepath, ImageLayout layout)
        {
            var graphviz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(graph) { ImageType = imageType };

            graphviz.FormatVertex += FormatVertexHandler;
            graphviz.FormatEdge += EdgeFormatter;

            string fileInfo = $"{imageFilepath} {layout}";
            graphviz.Generate(new FileDotEngine(), fileInfo);
            return imageFilepath;
        }

        ////////////////////////////////////////////////////////////////
        private void FormatVertexHandler(object sender, FormatVertexEventArgs<string> e)
        {
            Contract.Requires(e != null);

            e.VertexFormat.Label = e.Vertex;
            e.VertexFormat.Shape = _VertexShape;
            e.VertexFormat.Style = _VertexStyle;
        }

        private void VertexFormatter(object sender, FormatVertexEventArgs<int> e)
        {
            Contract.Requires(e != null);

            e.VertexFormat.Label = e.Vertex.ToString();
            e.VertexFormat.Shape = _VertexShape;
            e.VertexFormat.Style = _VertexStyle;
        }

        private void EdgeFormatter(object sender, FormatEdgeEventArgs<string, TaggedEdge<string, string>> e)
        {
            GraphvizEdgeLabel label = new GraphvizEdgeLabel
            {
                Value = e.Edge.Tag,
            };
            e.EdgeFormat.Label = label;
            //            e.EdgeFormat.StrokeColor = GraphvizColor.DarkRed;
        }
    }
}