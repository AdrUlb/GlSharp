using GLint = int;
using GLuint = uint;
using GLfloat = float;
using GLsizei = uint;
using GLenum = int;

namespace GlSharp;

unsafe partial class Gl
{
	private readonly delegate* unmanaged[Stdcall]<GLenum, void> _glActiveTexture = (delegate* unmanaged[Stdcall]<GLenum, void>)getProcAddress("glActiveTexture");
	private readonly delegate* unmanaged[Stdcall]<GLenum, GLuint, void> _glBindTexture = (delegate* unmanaged[Stdcall]<GLenum, GLuint, void>)getProcAddress("glBindTexture");
	private readonly delegate* unmanaged[Stdcall]<GLsizei, GLuint*, void> _glDeleteTextures = (delegate* unmanaged[Stdcall]<GLsizei, GLuint*, void>)getProcAddress("glDeleteTextures");
	private readonly delegate* unmanaged[Stdcall]<GLsizei, GLuint*, void> _glGenTextures = (delegate* unmanaged[Stdcall]<GLsizei, GLuint*, void>)getProcAddress("glGenTextures");

	private readonly delegate* unmanaged[Stdcall]<GLenum, GLint, GLint, GLsizei, GLsizei, GLint, GLenum, GLenum, void*, void> _glTexImage2D =
		(delegate* unmanaged[Stdcall]<GLenum, GLint, GLint, GLsizei, GLsizei, GLint, GLenum, GLenum, void*, void>)getProcAddress("glTexImage2D");

	private readonly delegate* unmanaged[Stdcall]<GLenum, GLenum, GLfloat, void> _glTexParameterf = (delegate* unmanaged[Stdcall]<GLenum, GLenum, GLfloat, void>)getProcAddress("glTexParameterf");
	private readonly delegate* unmanaged[Stdcall]<GLenum, GLenum, GLint, void> _glTexParameteri = (delegate* unmanaged[Stdcall]<GLenum, GLenum, GLint, void>)getProcAddress("glTexParameteri");

	private readonly delegate* unmanaged[Stdcall]<GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, void*, void> _glTexSubImage2D =
		(delegate* unmanaged[Stdcall]<GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, void*, void>)getProcAddress("glTexSubImage2D");
}
