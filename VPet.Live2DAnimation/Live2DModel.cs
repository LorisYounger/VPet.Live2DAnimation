using Live2DCSharpSDK.App;
using OpenTK.Mathematics;
using OpenTK.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OpenTK.Graphics.OpenGL4;
using System.IO;
using Live2DCSharpSDK.Framework.Motion;
using Live2DCSharpSDK.Framework;
using static Live2DCSharpSDK.Framework.ModelSettingObj.FileReference;

namespace VPet.Live2DAnimation
{
    /// <summary>
    /// Live2D模型控件
    /// </summary>
    public class Live2DModel
    {
        /// <summary>
        /// 模型名字
        /// </summary>
        public string Name;
        /// <summary>
        /// 当前动画是否正在播放
        /// </summary>
        public bool IsPlaying { get; set; } = false;
        /// <summary>
        /// 附着于的窗体控件
        /// </summary>
        public GLWpfControl GLControl { get; private set; }
        /// <summary>
        /// L2D管理器
        /// </summary>
        public LAppDelegate LAPP { get; private set; }
        /// <summary>
        /// L2D模型
        /// </summary>
        public LAppModel LModel { get; private set; }
        /// <summary>
        /// 新建一个Live2D模型
        /// </summary>
        /// <param name="Path">Live2D模型位置 (moc3)</param>
        public Live2DModel(string Path)
        {
            GLControl.SizeChanged += GLControl_Resized;
            GLControl.Render += GLControl_Render;

            var file = new FileInfo(Path);
            var settings = new GLWpfControlSettings
            {
                MajorVersion = 3,
                MinorVersion = 3
            };
            GLControl.Start(settings);
            LAPP = new(new OpenTKWPFApi(GLControl), Console.WriteLine)
            {
                BGColor = new(0, 0, 0, 0)
            };
            LModel = LAPP.Live2dManager.LoadModel(file.DirectoryName, file.Name.Substring(0, file.Name.Length - file.Extension.Length));
        }
        private void GLControl_Render(TimeSpan obj)
        {
            GL.ClearColor(Color4.Blue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            LAPP.Run((float)obj.TotalSeconds);
        }

        LAppModel model;

        private void GLControl_Resized(object sender, SizeChangedEventArgs e)
        {
            if (LAPP == null || (int)GLControl.ActualWidth == 0 || (int)GLControl.ActualHeight == 0 || IsPlaying)
                return;
            LAPP.Resize();
            GL.Viewport(0, 0, (int)GLControl.ActualWidth, (int)GLControl.ActualHeight);
        }

        //public CubismMotionQueueEntry StartMotion(string MotionName, MotionPriority priority, FinishedMotionCallback onFinishedMotionHandler = null)
        //{
        //    CubismMotion motion;
        //    if (!_motions.TryGetValue(name, out var value))
        //    {
        //        string path = item.File;
        //        path = Path.GetFullPath(_modelHomeDir + path);
        //        if (!File.Exists(path))
        //        {
        //            return null;
        //        }

        //        motion = new CubismMotion(path, onFinishedMotionHandler);
        //        float fadeTime = item.FadeInTime;
        //        if (fadeTime >= 0.0f)
        //        {
        //            motion.FadeInSeconds = fadeTime;
        //        }

        //        fadeTime = item.FadeOutTime;
        //        if (fadeTime >= 0.0f)
        //        {
        //            motion.FadeOutSeconds = fadeTime;
        //        }
        //        motion.SetEffectIds(_eyeBlinkIds, _lipSyncIds);
        //    }
        //    else
        //    {
        //        motion = (value as CubismMotion)!;
        //        motion.OnFinishedMotion = onFinishedMotionHandler;
        //    }

        //    return _motionManager.StartMotionPriority(motion, priority);
        //}
    }
}
