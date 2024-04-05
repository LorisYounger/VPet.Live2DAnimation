
using System.Windows.Controls;
using VPet_Simulator.Core;
using static VPet_Simulator.Core.Picture;

namespace VPet.Live2DAnimation
{
    /// <summary>
    /// Live2D¶¯»­
    /// </summary>
    public class Live2DAnimation : IImageRun
    {
        public bool PlayState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsLoop { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsContinue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsReady => throw new NotImplementedException();

        public GraphInfo GraphInfo => throw new NotImplementedException();

        public Task Run(Image img, Action? EndAction = null)
        {
            throw new NotImplementedException();
        }

        public void Run(Border parant, Action? EndAction = null)
        {
            throw new NotImplementedException();
        }

        public void Stop(bool StopEndAction = false)
        {
            throw new NotImplementedException();
        }
    }

}
