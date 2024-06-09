using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VPet_Simulator.Core;

namespace VPet.Live2DAnimation
{
    public interface ILive2DAnimation : IGraph
    {
        /// <summary>
        /// 模型名称
        /// </summary>
        public string ModelName { get; set; }
    }

    public abstract class AILive2DAnimation : ILive2DAnimation
    {
        public virtual string ModelName { get; set; }
        public virtual bool IsLoop { get; set; }
        public virtual bool IsReady { get; set; }
        public virtual bool IsFail { get; set; }
        public virtual string FailMessage { get; set; }
        public virtual GraphInfo GraphInfo { get; set; }
        public virtual IGraph.TaskControl Control { get; set; }
        public abstract void Run(Decorator parant, Action EndAction = null);

        public override bool Equals(object obj)
        {
            if (!IsReady || obj == null || obj is not AILive2DAnimation al2da)
            {
                return false;
            }
            return al2da.ModelName == ModelName;
        }
        public override int GetHashCode()
        {
            return ModelName.GetHashCode();
        }
    }
}
