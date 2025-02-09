using GLint = int;
using GLuint = uint;
using GLsizei = uint;
using GLenum = int;
using GLboolean = bool;

namespace GlSharp;

unsafe partial class Gl
{
	private readonly delegate* unmanaged[Stdcall]<GLuint, void> _glBindVertexArray = (delegate* unmanaged[Stdcall]<GLuint, void>)getProcAddress("glBindVertexArray");
	private readonly delegate* unmanaged[Stdcall]<GLsizei, GLuint*, void> _glDeleteVertexArrays = (delegate* unmanaged[Stdcall]<GLsizei, GLuint*, void>)getProcAddress("glDeleteVertexArrays");
	private readonly delegate* unmanaged[Stdcall]<GLsizei, GLuint*, void> _glGenVertexArrays = (delegate* unmanaged[Stdcall]<GLsizei, GLuint*, void>)getProcAddress("glGenVertexArrays");
	
	private readonly delegate* unmanaged[Stdcall]<GLuint, GLint, GLenum, GLboolean, GLsizei, nuint, void> _glVertexAttribPointer =
		(delegate* unmanaged[Stdcall]<GLuint, GLint, GLenum, GLboolean, GLsizei, nuint, void>)getProcAddress("glVertexAttribPointer");

	private readonly delegate* unmanaged[Stdcall]<GLuint, GLint, GLenum, GLsizei, nuint, void> _glVertexAttribIPointer =
		(delegate* unmanaged[Stdcall]<GLuint, GLint, GLenum, GLsizei, nuint, void>)getProcAddress("glVertexAttribIPointer");
}
