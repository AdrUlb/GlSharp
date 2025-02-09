using GLint = int;
using GLint64 = long;
using GLfloat = float;
using GLdouble = double;
using GLsizei = uint;
using GLenum = int;
using GLboolean = bool;

namespace GlSharp;

unsafe partial class Gl
{
	private readonly delegate* unmanaged[Stdcall]<GLenum, GLenum, void> _glBlendFunc = (delegate* unmanaged[Stdcall]<GLenum, GLenum, void>)getProcAddress("glBlendFunc");
	private readonly delegate* unmanaged[Stdcall]<GLenum, void> _glDisable = (delegate* unmanaged[Stdcall]<GLenum, void>)getProcAddress("glDisable");
	private readonly delegate* unmanaged[Stdcall]<GLenum, void> _glEnable = (delegate* unmanaged[Stdcall]<GLenum, void>)getProcAddress("glEnable");
	private readonly delegate* unmanaged[Stdcall]<GLenum, GLboolean*, void> _glGetBooleanv = (delegate* unmanaged[Stdcall]<GLenum, GLboolean*, void>)getProcAddress("glGetBooleanv");
	private readonly delegate* unmanaged[Stdcall]<GLenum, GLdouble*, void> _glGetDoublev = (delegate* unmanaged[Stdcall]<GLenum, GLdouble*, void>)getProcAddress("glGetDoublev");
	private readonly delegate* unmanaged[Stdcall]<GLenum, GLfloat*, void> _glGetFloatv = (delegate* unmanaged[Stdcall]<GLenum, GLfloat*, void>)getProcAddress("glGetFloatv");
	private readonly delegate* unmanaged[Stdcall]<GLenum, GLint*, void> _glGetIntegerv = (delegate* unmanaged[Stdcall]<GLenum, GLint*, void>)getProcAddress("glGetIntegerv");
	private readonly delegate* unmanaged[Stdcall]<GLenum, GLint64*, void> _glGetInteger64v = (delegate* unmanaged[Stdcall]<GLenum, GLint64*, void>)getProcAddress("glGetInteger64v");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLint, GLsizei, GLsizei, void> _glViewport = (delegate* unmanaged[Stdcall]<GLint, GLint, GLsizei, GLsizei, void>)getProcAddress("glViewport");
}
