
using VPet_Simulator.Windows.Interface;

namespace VPet.Plugin.Live2DAnimation
{
    public class Live2DPlugin : MainPlugin
    {
        public Live2DPlugin(IMainWindow mainwin) : base(mainwin)
        {

        }

        public override string PluginName => "Live2DAnimation";
    }

}
