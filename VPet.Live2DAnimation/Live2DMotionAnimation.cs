
using LinePutScript;
using Live2DCSharpSDK.WPF;
using System.IO;
using System.Windows.Controls;
using VPet_Simulator.Core;
using static VPet_Simulator.Core.Picture;

namespace VPet.Live2DAnimation
{
    /// <summary>
    /// Live2D动画 动作文件
    /// </summary>
    public class Live2DMotionAnimation : IImageRun
    {
        public static void LoadGraph(GraphCore graph, FileSystemInfo path, ILine info)
        {
            if (!(path is FileInfo f) || f.Name.ToLower().EndsWith(".model3.json"))
            {
                return;
            }
            bool isLoop = info[(gbol)"loop"];
            graph.AddGraph(new Live2DMOCAnimation(graph, f, new GraphInfo(path, info), isLoop));
        }
        private GraphCore GraphCore;
        /// <summary>
        /// Json地址
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 模型名称
        /// </summary>
        public string ModelName { get; set; }
        public Live2DMotionAnimation(GraphCore graphCore, FileInfo path, GraphInfo graphinfo, bool isLoop = false)
        {
            IsLoop = isLoop;
            GraphInfo = graphinfo;
            GraphCore = graphCore;
            Path = path.FullName;

            ModelName = path.Name.Split('.')[0];
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
