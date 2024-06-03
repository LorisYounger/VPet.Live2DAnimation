
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
    public class Live2DMotionAnimation : IGraph
    {
        public static void LoadGraph(GraphCore graph, FileSystemInfo path, ILine info)
        {
            if (!(path is FileInfo f) || !f.Name.ToLower().EndsWith(".motion3.json", StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }
            bool isLoop = info[(gbol)"loop"];
            string modelname = info[(gstr)"modelname"];
            if (string.IsNullOrWhiteSpace(modelname))
            {
                modelname = path.Name.Split('.')[0];
            }
            graph.AddGraph(new Live2DMotionAnimation(graph, f, new GraphInfo(path, info), modelname, isLoop));
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
        public Live2DMotionAnimation(GraphCore graphCore, FileInfo path, GraphInfo graphinfo, string modelname, bool isLoop = false)
        {
            IsLoop = isLoop;
            GraphInfo = graphinfo;
            GraphCore = graphCore;
            Path = path.FullName;
            ModelName = modelname;
        }
        public bool IsLoop { get; set; }

        public bool IsReady => true;

        public bool IsFail => false;

        public string FailMessage => "";

        public GraphInfo GraphInfo { get; set; }

        public IGraph.TaskControl Control { get; set; }

        public void Run(Decorator parant, Action EndAction = null)
        {
            if (!IsReady || !GraphCore.CommConfig.ContainsKey("L2D" + ModelName))
            {
                EndAction?.Invoke();
                return;
            }
            if (Control?.PlayState == true)
            {//如果当前正在运行,重置状态
                Control.Stop(() => Run(parant, EndAction));
                return;
            }
            Live2DWPFModel model = (Live2DWPFModel)GraphCore.CommConfig["L2D" + ModelName];
            parant.Dispatcher.Invoke(() =>
            {
                if (parant.Tag != model)
                {
                    parant.Tag = model;
                    if (model.GLControl.Parent != null)
                    {
                        ((Decorator)model.GLControl.Parent).Child = null;
                    }
                    parant.Child = model.GLControl;
                }
            });
        }
        public override bool Equals(object obj)
        {
            if (!IsReady || !GraphCore.CommConfig.ContainsKey("L2D" + ModelName))
            {
                return false;
            }
            return GraphCore.CommConfig["L2D" + ModelName] == obj;
        }
    }

}
