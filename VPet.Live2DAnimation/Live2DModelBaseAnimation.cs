
using LinePutScript;
using Live2DCSharpSDK.WPF;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using VPet_Simulator.Core;
using static VPet_Simulator.Core.IGraph;
using static VPet_Simulator.Core.Picture;

namespace VPet.Live2DAnimation
{
    /// <summary>
    /// Live2D动画 核心MOC文件
    /// </summary>
    public class Live2DModelBaseAnimation : AILive2DAnimation
    {
        public static void LoadGraph(GraphCore graph, FileSystemInfo path, ILine info)
        {
            if (!(path is FileInfo f) || !f.Extension.Equals(".moc3", StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }
            bool isLoop = info[(gbol)"loop"];
            string modelname = info[(gstr)"modelname"];
            var gi = new GraphInfo(path, info);
            if (string.IsNullOrWhiteSpace(modelname))
            {
                modelname = gi.Name;
            }
            graph.AddGraph(new Live2DModelBaseAnimation(graph, f,gi, modelname, isLoop));
        }
        private GraphCore GraphCore;
        public Live2DWPFModel Model { get; set; }
        public Live2DModelBaseAnimation(GraphCore graphCore, FileInfo path, GraphInfo graphinfo, string modelname, bool isLoop = false)
        {
            IsLoop = isLoop;
            GraphInfo = graphinfo;
            GraphCore = graphCore;
            try
            {
                Model = new Live2DWPFModel(path.FullName);
                ModelName = modelname;
                GraphCore.CommConfig["L2D" + ModelName] = Model;
                IsReady = true;
            }
            catch (Exception e)
            {
                IsFail = true;
                FailMessage = e.ToString();
            }
        }

        public int Length { get; set; } = 1000;

        public override void Run(Decorator parant, Action EndAction = null)
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
            Control = new TaskControl(EndAction);
            Live2DWPFModel model = (Live2DWPFModel)GraphCore.CommConfig["L2D" + ModelName];
            Control = new TaskControl(EndAction);
            parant.Dispatcher.Invoke(() =>
            {
                if (parant.Tag != this)
                {
                    if (!Equals(parant.Tag))
                    {
                        parant.Tag = model;
                        if (model.GLControl.Parent != null)
                        {
                            ((Decorator)model.GLControl.Parent).Child = null;
                        }
                        parant.Child = model.GLControl;
                    }
                    parant.Tag = this;
                }
                Task.Run(() => Run(Control));
            });
        }
        /// <summary>
        /// 通过控制器运行
        /// </summary>
        /// <param name="Control"></param>
        public void Run(TaskControl Control)
        {
            Thread.Sleep(Length);
            //判断是否要下一步
            switch (Control.Type)
            {
                case TaskControl.ControlType.Stop:
                    Control.EndAction?.Invoke();
                    return;
                case TaskControl.ControlType.Status_Stoped:
                    return;
                case TaskControl.ControlType.Continue:
                    Control.Type = TaskControl.ControlType.Status_Quo;
                    Run(Control);
                    return;
                case TaskControl.ControlType.Status_Quo:
                    if (IsLoop)
                    {
                        Task.Run(() => Run(Control));
                    }
                    else
                    {
                        Control.Type = TaskControl.ControlType.Status_Stoped;
                        Control.EndAction?.Invoke(); //运行结束动画时事件
                    }
                    return;
            }
        }
    }

}
