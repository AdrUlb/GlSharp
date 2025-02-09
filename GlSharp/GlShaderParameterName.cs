using static GlSharp.GlConstants;

namespace GlSharp;

public enum GlShaderParameterName
{
	ShaderType = GL_SHADER_TYPE,
	DeleteStatus = GL_DELETE_STATUS,
	CompileStatus = GL_COMPILE_STATUS,
	InfoLogLength = GL_INFO_LOG_LENGTH,
	ShaderSourceLength = GL_SHADER_SOURCE_LENGTH
}
