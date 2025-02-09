using static GlSharp.GlConstants;

namespace GlSharp;

[Flags]
public enum GlClearFlags
{
	ColorBufferBit = GL_COLOR_BUFFER_BIT,
	DepthBufferBit = GL_DEPTH_BUFFER_BIT,
	StencilBufferBit = GL_STENCIL_BUFFER_BIT
}
