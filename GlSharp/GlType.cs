using static GlSharp.GlConstants;

namespace GlSharp;

public enum GlType
{
	Byte = GL_BYTE,
	UnsignedByte = GL_UNSIGNED_BYTE,
	Short = GL_SHORT,
	UnsignedShort = GL_UNSIGNED_SHORT,
	Int = GL_INT,
	UnsignedInt = GL_UNSIGNED_INT,
	HalfFloat = GL_HALF_FLOAT,
	Float = GL_FLOAT,
	Double = GL_DOUBLE,
	Int2101010Rev = GL_INT_2_10_10_10_REV,
	UnsignedInt2101010Rev = GL_UNSIGNED_INT_2_10_10_10_REV
}
