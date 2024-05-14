
using LinePutScript;
using Live2DCSharpSDK.WPF;
using System.IO;
using System.Windows.Controls;
using VPet_Simulator.Core;
using static VPet_Simulator.Core.Picture;

namespace VPet.Live2DAnimation
{
    /// <summary>
    /// Live2D动画 核心MOC文件
    /// </summary>
    public class Live2DMOCAnimation : IImageRun
    {
        public static void LoadGraph(GraphCore graph, FileSystemInfo path, ILine info)
        {
            if (!(path is FileInfo f) || f.Extension.Equals(".moc3", StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }
            bool isLoop = info[(gbol)"loop"];
            graph.AddGraph(new Live2DMOCAnimation(graph, f, new GraphInfo(path, info), isLoop));
        }
        private GraphCore GraphCore;
        public Live2DWPFModel Model { get; set; }
        public string ModelName { get; set; }
        public Live2DMOCAnimation(GraphCore graphCore, FileInfo path, GraphInfo graphinfo, bool isLoop = false)
        {
            IsLoop = isLoop;
            GraphInfo = graphinfo;
            GraphCore = graphCore;
            try
            {
                Model = new Live2DWPFModel(path.FullName);
                ModelName = path.Name[..^path.Extension.Length];
                GraphCore.CommConfig["L2D" + ModelName] = Model;
                IsReady = true;
            }
            catch (Exception e)
            {
                IsFail = true;
                FailMessage = e.Message;
            }
        }
        public bool IsLoop { get; set; }

        public bool IsReady { get; set; } = false;

        public bool IsFail { get; set; } = false;

        public string FailMessage { get; set; } = "";

        public GraphInfo GraphInfo { get; set; }

        public IGraph.TaskControl Control { get; set; }

        public Task Run(Image img, Action EndAction = null)
        {
            throw new NotImplementedException();
        }

        public void Run(Decorator parant, Action EndAction = null)
        {
            throw new NotImplementedException();
        }
    }

}
