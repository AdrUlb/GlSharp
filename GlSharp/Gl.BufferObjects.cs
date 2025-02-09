using GLint = int;
using GLuint = uint;
using GLintptr = nint;
using GLsizei = uint;
using GLsizeiptr = nuint;
using GLenum = int;

namespace GlSharp;

unsafe partial class Gl
{
	private readonly delegate* unmanaged[Stdcall]<GLenum, GLuint, void> _glBindBuffer = (delegate* unmanaged[Stdcall]<GLenum, GLuint, void>)getProcAddress("glBindBuffer");
	private readonly delegate* unmanaged[Stdcall]<GLenum, GLsizeiptr, void*, GLenum, void> _glBufferData = (delegate* unmanaged[Stdcall]<GLenum, GLsizeiptr, void*, GLenum, void>)getProcAddress("glBufferData");

	private readonly delegate* unmanaged[Stdcall]<GLenum, GLintptr, GLsizeiptr, void*, void> _glBufferSubData =
		(delegate* unmanaged[Stdcall]<GLenum, GLintptr, GLsizeiptr, void*, void>)getProcAddress("glBufferSubData");

	private readonly delegate* unmanaged[Stdcall]<GLsizei, GLuint*, void> _glDeleteBuffers = (delegate* unmanaged[Stdcall]<GLsizei, GLuint*, void>)getProcAddress("glDeleteBuffers");
	private readonly delegate* unmanaged[Stdcall]<GLuint, void> _glDisableVertexAttribArray = (delegate* unmanaged[Stdcall]<GLuint, void>)getProcAddress("glDisableVertexAttribArray");
	private readonly delegate* unmanaged[Stdcall]<GLenum, GLint, GLsizei, void> _glDrawArrays = (delegate* unmanaged[Stdcall]<GLenum, GLint, GLsizei, void>)getProcAddress("glDrawArrays");
	private readonly delegate* unmanaged[Stdcall]<GLenum, GLsizei, GLenum, nuint, void> _glDrawElements = (delegate* unmanaged[Stdcall]<GLenum, GLsizei, GLenum, nuint, void>)getProcAddress("glDrawElements");
	private readonly delegate* unmanaged[Stdcall]<GLuint, void> _glEnableVertexAttribArray = (delegate* unmanaged[Stdcall]<GLuint, void>)getProcAddress("glEnableVertexAttribArray");
	private readonly delegate* unmanaged[Stdcall]<GLsizei, GLuint*, void> _glGenBuffers = (delegate* unmanaged[Stdcall]<GLsizei, GLuint*, void>)getProcAddress("glGenBuffers");
}
