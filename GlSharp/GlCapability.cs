using static GlSharp.GlConstants;

namespace GlSharp;

public enum GlCapability
{
	Blend = GL_BLEND,
	ClipDistance0 = GL_CLIP_DISTANCE0,
	ClipDistance1 = GL_CLIP_DISTANCE1,
	ClipDistance2 = GL_CLIP_DISTANCE2,
	ClipDistance3 = GL_CLIP_DISTANCE3,
	ClipDistance4 = GL_CLIP_DISTANCE4,
	ClipDistance5 = GL_CLIP_DISTANCE5,
	ClipDistance6 = GL_CLIP_DISTANCE6,
	ClipDistance7 = GL_CLIP_DISTANCE7,
	ColorLogicOp = GL_COLOR_LOGIC_OP,
	CullFace = GL_CULL_FACE,
	DepthClamp = GL_DEPTH_CLAMP,
	DepthTest = GL_DEPTH_TEST,
	Dither = GL_DITHER,
	FramebufferSrgb = GL_FRAMEBUFFER_SRGB,
	LineSmooth = GL_LINE_SMOOTH,
	Multisample = GL_MULTISAMPLE,
	PolygonOffsetFill = GL_POLYGON_OFFSET_FILL,
	PolygonOffsetLine = GL_POLYGON_OFFSET_LINE,
	PolygonOffsetPoint = GL_POLYGON_OFFSET_POINT,
	PolygonSmooth = GL_POLYGON_SMOOTH,
	PrimitiveRestart = GL_PRIMITIVE_RESTART,
	SampleAlphaToCoverage = GL_SAMPLE_ALPHA_TO_COVERAGE,
	SampleAlphaToOne = GL_SAMPLE_ALPHA_TO_ONE,
	SampleCoverage = GL_SAMPLE_COVERAGE,
	ScissorTest = GL_SCISSOR_TEST,
	StencilTest = GL_STENCIL_TEST,
	TextureCubeMapSeamless = GL_TEXTURE_CUBE_MAP_SEAMLESS,
	ProgramPointSize = GL_PROGRAM_POINT_SIZE
}
