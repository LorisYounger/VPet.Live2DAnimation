using OpenTK.Graphics.OpenGL4;
using Live2DCSharpSDK.Framework.Rendering.OpenGL;
using OpenTK.Wpf;

namespace VPet.Live2DAnimation
{
    public class OpenTKWPFApi : OpenGLApi
    {
        private readonly GLWpfControl Window;

        public override bool IsES2 => false;

        public override bool IsPhoneES2 => false;

        public override bool AlwaysClear => false;

        public OpenTKWPFApi(GLWpfControl window)
        {
            Window = window;
        }

        public override void GetWindowSize(out int w, out int h)
        {
            w = (int)Window.ActualWidth;
            h = (int)Window.ActualHeight;
        }

        public override void ActiveTexture(int bit)
        {
            GL.ActiveTexture((TextureUnit)bit);
        }

        public override void AttachShader(int a, int b)
        {
            GL.AttachShader(a, b);
        }

        public override void BindBuffer(int bit, int index)
        {
            GL.BindBuffer((BufferTarget)bit, index);
        }

        public override void BindFramebuffer(int type, int data)
        {
            GL.BindFramebuffer((FramebufferTarget)type, data);
        }

        public override void BindTexture(int bit, int index)
        {
            GL.BindTexture((TextureTarget)bit, index);
        }

        public override void BindVertexArrayOES(int data)
        {
            //TODO ES2
            GL.BindVertexArray(data);
        }

        public override void BlendFunc(int a, int b)
        {
            GL.BlendFunc((BlendingFactor)a, (BlendingFactor)b);
        }

        public override void BlendFuncSeparate(int a, int b, int c, int d)
        {
            GL.BlendFuncSeparate((BlendingFactorSrc)a, (BlendingFactorDest)b, (BlendingFactorSrc)c, (BlendingFactorDest)d);
        }

        public override void Clear(int bit)
        {
            GL.Clear((ClearBufferMask)bit);
        }

        public override void ClearColor(float r, float g, float b, float a)
        {
            GL.ClearColor(r, g, b, a);
        }

        public override void ClearDepthf(float data)
        {
            GL.ClearDepth(data);
        }

        public override void ColorMask(bool a, bool b, bool c, bool d)
        {
            GL.ColorMask(a, b, c, d);
        }

        public override void CompileShader(int index)
        {
            GL.CompileShader(index);
        }

        public override int CreateProgram()
        {
            return GL.CreateProgram();
        }

        public override int CreateShader(int type)
        {
            return GL.CreateShader((ShaderType)type);
        }

        public override void DeleteFramebuffer(int data)
        {
            GL.DeleteFramebuffer(data);
        }

        public override void DeleteProgram(int index)
        {
            GL.DeleteProgram(index);
        }

        public override void DeleteShader(int index)
        {
            GL.DeleteShader(index);
        }

        public override void DeleteTexture(int data)
        {
            GL.DeleteTexture(data);
        }

        public override void DetachShader(int index, int data)
        {
            GL.DetachShader(index, data);
        }

        public override void Disable(int bit)
        {
            GL.Disable((EnableCap)bit);
        }

        public override void DisableVertexAttribArray(int index)
        {
            GL.DisableVertexAttribArray(index);
        }

        public override unsafe void DrawElements(int type, int count, int type1, nint arry)
        {
            GL.DrawElements((PrimitiveType)type, count, (DrawElementsType)type1, (int)arry);
        }

        public override void Enable(int bit)
        {
            GL.Enable((EnableCap)bit);
        }

        public override void EnableVertexAttribArray(int index)
        {
            GL.EnableVertexAttribArray(index);
        }

        public override void FramebufferTexture2D(int a, int b, int c, int buff, int offset)
        {
            GL.FramebufferTexture2D((FramebufferTarget)a, (FramebufferAttachment)b,
                (TextureTarget)c, buff, offset);
        }

        public override void FrontFace(int data)
        {
            GL.FrontFace((FrontFaceDirection)data);
        }

        public override void GenerateMipmap(int a)
        {
            GL.GenerateMipmap((GenerateMipmapTarget)a);
        }

        public override int GenFramebuffer()
        {
            return GL.GenFramebuffer();
        }

        public override int GenTexture()
        {
            return GL.GenTexture();
        }

        public override int GetAttribLocation(int index, string attr)
        {
            return GL.GetAttribLocation(index, attr);
        }

        public override void GetBooleanv(int bit, bool[] data)
        {
            GL.GetBoolean((GetPName)bit, data);
        }

        public override void GetIntegerv(int bit, out int data)
        {
            GL.GetInteger((GetPName)bit, out data);
        }

        public override void GetIntegerv(int bit, int[] data)
        {
            GL.GetInteger((GetPName)bit, data);
        }

        public override void GetProgramInfoLog(int index, out string log)
        {
            GL.GetProgramInfoLog(index, out log);
        }

        public override unsafe void GetProgramiv(int index, int type, int* length)
        {
            GL.GetProgram(index, (GetProgramParameterName)type, length);
        }

        public override void GetShaderInfoLog(int index, out string log)
        {
            GL.GetShaderInfoLog(index, out log);
        }

        public override unsafe void GetShaderiv(int index, int type, int* length)
        {
            GL.GetShader(index, (ShaderParameter)type, length);
        }

        public override int GetUniformLocation(int index, string uni)
        {
            return GL.GetUniformLocation(index, uni);
        }

        public override unsafe void GetVertexAttribiv(int index, int bit, out int data)
        {
            GL.GetVertexAttrib(index, (VertexAttribParameter)bit, out data);
        }

        public override bool IsEnabled(int bit)
        {
            return GL.IsEnabled((EnableCap)bit);
        }

        public override void LinkProgram(int index)
        {
            GL.LinkProgram(index);
        }

        public override void ShaderSource(int a, string source)
        {
            GL.ShaderSource(a, source);
        }

        public override void TexImage2D(int type, int a, int type1, int w, int h, int size, int type2, int type3, nint data)
        {
            GL.TexImage2D((TextureTarget)type, a, (PixelInternalFormat)type1, w, h, size, (PixelFormat)type2, (PixelType)type3, data);
        }

        public override void TexParameterf(int type, int type1, float value)
        {
            GL.TexParameter((TextureTarget)type, (TextureParameterName)type1, value);
        }

        public override void TexParameteri(int a, int b, int c)
        {
            GL.TexParameter((TextureTarget)a, (TextureParameterName)b, c);
        }

        public override void Uniform1i(int index, int data)
        {
            GL.Uniform1(index, data);
        }

        public override void Uniform4f(int index, float a, float b, float c, float d)
        {
            GL.Uniform4(index, a, b, c, d);
        }

        public override void UniformMatrix4fv(int index, int length, bool b, float[] data)
        {
            GL.UniformMatrix4(index, length, b, data);
        }

        public override void UseProgram(int index)
        {
            GL.UseProgram(index);
        }

        public override void ValidateProgram(int index)
        {
            GL.ValidateProgram(index);
        }

        public override unsafe void VertexAttribPointer(int index, int length, int type, bool b, int size, nint arr)
        {
            GL.VertexAttribPointer(index, length, (VertexAttribPointerType)type, b, size, arr);
        }

        public override void Viewport(int x, int y, int w, int h)
        {
            GL.Viewport(x, y, w, h);
        }

        public override int GetError()
        {
            return (int)GL.GetError();
        }

        public override int GenBuffer()
        {
            return GL.GenBuffer();
        }

        public override void BufferData(int type, int v1, nint v2, int type1)
        {
            GL.BufferData((BufferTarget)type, v1, v2, (BufferUsageHint)type1);
        }

        public override int GenVertexArray()
        {
            return GL.GenVertexArray();
        }

        public override void BindVertexArray(int vertexArray)
        {
            GL.BindVertexArray(vertexArray);
        }
    }

}
