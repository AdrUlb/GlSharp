using GLint = int;
using GLuint = uint;
using GLsizei = uint;
using GLfloat = float;
using GLenum = int;
using GLboolean = bool;

namespace GlSharp;

unsafe partial class Gl
{
	private readonly delegate* unmanaged[Stdcall]<GLuint, GLuint, void> _glAttachShader = (delegate* unmanaged[Stdcall]<GLuint, GLuint, void>)getProcAddress("glAttachShader");
	private readonly delegate* unmanaged[Stdcall]<GLuint, void> _glCompileShader = (delegate* unmanaged[Stdcall]<GLuint, void>)getProcAddress("glCompileShader");
	private readonly delegate* unmanaged[Stdcall]<GLuint> _glCreateProgram = (delegate* unmanaged[Stdcall]<GLuint>)getProcAddress("glCreateProgram");
	private readonly delegate* unmanaged[Stdcall]<GLenum, GLuint> _glCreateShader = (delegate* unmanaged[Stdcall]<GLenum, GLuint>)getProcAddress("glCreateShader");
	private readonly delegate* unmanaged[Stdcall]<GLuint, void> _glDeleteProgram = (delegate* unmanaged[Stdcall]<GLuint, void>)getProcAddress("glDeleteProgram");
	private readonly delegate* unmanaged[Stdcall]<GLuint, void> _glDeleteShader = (delegate* unmanaged[Stdcall]<GLuint, void>)getProcAddress("glDeleteShader");
	private readonly delegate* unmanaged[Stdcall]<GLuint, GLuint, void> _glDetachShader = (delegate* unmanaged[Stdcall]<GLuint, GLuint, void>)getProcAddress("glDetachShader");
	private readonly delegate* unmanaged[Stdcall]<GLuint, GLenum, GLint*, void> _glGetProgramiv = (delegate* unmanaged[Stdcall]<GLuint, GLenum, GLint*, void>)getProcAddress("glGetProgramiv");
	private readonly delegate* unmanaged[Stdcall]<GLuint, GLenum, GLint*, void> _glGetShaderiv = (delegate* unmanaged[Stdcall]<GLuint, GLenum, GLint*, void>)getProcAddress("glGetShaderiv");

	private readonly delegate* unmanaged[Stdcall]<GLuint, GLsizei, GLsizei*, void*, void> _glGetShaderInfoLog =
		(delegate* unmanaged[Stdcall]<GLuint, GLsizei, GLsizei*, void*, void>)getProcAddress("glGetShaderInfoLog");

	private readonly delegate* unmanaged[Stdcall]<GLuint, void*, GLint> _glGetUniformLocation = (delegate* unmanaged[Stdcall]<GLuint, void*, GLint>)getProcAddress("glGetUniformLocation");
	private readonly delegate* unmanaged[Stdcall]<GLuint, void> _glLinkProgram = (delegate* unmanaged[Stdcall]<GLuint, void>)getProcAddress("glLinkProgram");
	private readonly delegate* unmanaged[Stdcall]<GLuint, GLsizei, void**, GLint*, void> _glShaderSource = (delegate* unmanaged[Stdcall]<GLuint, GLsizei, void**, GLint*, void>)getProcAddress("glShaderSource");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLfloat, void> _glUniform1f = (delegate* unmanaged[Stdcall]<GLint, GLfloat, void>)getProcAddress("glUniform1f");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLfloat, GLfloat, void> _glUniform2f = (delegate* unmanaged[Stdcall]<GLint, GLfloat, GLfloat, void>)getProcAddress("glUniform2f");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLfloat, GLfloat, GLfloat, void> _glUniform3f = (delegate* unmanaged[Stdcall]<GLint, GLfloat, GLfloat, GLfloat, void>)getProcAddress("glUniform3f");

	private readonly delegate* unmanaged[Stdcall]<GLint, GLfloat, GLfloat, GLfloat, GLfloat, void> _glUniform4f =
		(delegate* unmanaged[Stdcall]<GLint, GLfloat, GLfloat, GLfloat, GLfloat, void>)getProcAddress("glUniform4f");

	private readonly delegate* unmanaged[Stdcall]<GLint, GLint, void> _glUniform1i = (delegate* unmanaged[Stdcall]<GLint, GLint, void>)getProcAddress("glUniform1i");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLint, GLint, void> _glUniform2i = (delegate* unmanaged[Stdcall]<GLint, GLint, GLint, void>)getProcAddress("glUniform2i");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLint, GLint, GLint, void> _glUniform3i = (delegate* unmanaged[Stdcall]<GLint, GLint, GLint, GLint, void>)getProcAddress("glUniform3i");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLint, GLint, GLint, GLint, void> _glUniform4i = (delegate* unmanaged[Stdcall]<GLint, GLint, GLint, GLint, GLint, void>)getProcAddress("glUniform4i");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLuint, void> _glUniform1ui = (delegate* unmanaged[Stdcall]<GLint, GLuint, void>)getProcAddress("glUniform1ui");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLuint, GLuint, void> _glUniform2ui = (delegate* unmanaged[Stdcall]<GLint, GLuint, GLuint, void>)getProcAddress("glUniform2ui");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLuint, GLuint, GLuint, void> _glUniform3ui = (delegate* unmanaged[Stdcall]<GLint, GLuint, GLuint, GLuint, void>)getProcAddress("glUniform3ui");

	private readonly delegate* unmanaged[Stdcall]<GLint, GLuint, GLuint, GLuint, GLuint, void> _glUniform4ui =
		(delegate* unmanaged[Stdcall]<GLint, GLuint, GLuint, GLuint, GLuint, void>)getProcAddress("glUniform4ui");

	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLfloat*, void> _glUniform1fv = (delegate* unmanaged[Stdcall]<GLint, GLsizei, GLfloat*, void>)getProcAddress("glUniform1fv");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLfloat*, void> _glUniform2fv = (delegate* unmanaged[Stdcall]<GLint, GLsizei, GLfloat*, void>)getProcAddress("glUniform2fv");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLfloat*, void> _glUniform3fv = (delegate* unmanaged[Stdcall]<GLint, GLsizei, GLfloat*, void>)getProcAddress("glUniform3fv");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLfloat*, void> _glUniform4fv = (delegate* unmanaged[Stdcall]<GLint, GLsizei, GLfloat*, void>)getProcAddress("glUniform4fv");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLint*, void> _glUniform1iv = (delegate* unmanaged[Stdcall]<GLint, GLsizei, GLint*, void>)getProcAddress("glUniform1iv");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLint*, void> _glUniform2iv = (delegate* unmanaged[Stdcall]<GLint, GLsizei, GLint*, void>)getProcAddress("glUniform2iv");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLint*, void> _glUniform3iv = (delegate* unmanaged[Stdcall]<GLint, GLsizei, GLint*, void>)getProcAddress("glUniform3iv");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLint*, void> _glUniform4iv = (delegate* unmanaged[Stdcall]<GLint, GLsizei, GLint*, void>)getProcAddress("glUniform4iv");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLuint*, void> _glUniform1uiv = (delegate* unmanaged[Stdcall]<GLint, GLsizei, GLuint*, void>)getProcAddress("glUniform1uiv");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLuint*, void> _glUniform2uiv = (delegate* unmanaged[Stdcall]<GLint, GLsizei, GLuint*, void>)getProcAddress("glUniform2uiv");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLuint*, void> _glUniform3uiv = (delegate* unmanaged[Stdcall]<GLint, GLsizei, GLuint*, void>)getProcAddress("glUniform3uiv");
	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLuint*, void> _glUniform4uiv = (delegate* unmanaged[Stdcall]<GLint, GLsizei, GLuint*, void>)getProcAddress("glUniform4uiv");

	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void> _glUniformMatrix2fv =
		(delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void>)getProcAddress("glUniformMatrix2fv");

	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void> _glUniformMatrix3fv =
		(delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void>)getProcAddress("glUniformMatrix3fv");

	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void> _glUniformMatrix4fv =
		(delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void>)getProcAddress("glUniformMatrix4fv");

	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void> _glUniformMatrix2x3fv =
		(delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void>)getProcAddress("glUniformMatrix2x3fv");

	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void> _glUniformMatrix3x2fv =
		(delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void>)getProcAddress("glUniformMatrix3x2fv");

	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void> _glUniformMatrix2x4fv =
		(delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void>)getProcAddress("glUniformMatrix2x4fv");

	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void> _glUniformMatrix4x2fv =
		(delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void>)getProcAddress("glUniformMatrix4x2fv");

	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void> _glUniformMatrix3x4fv =
		(delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void>)getProcAddress("glUniformMatrix3x4fv");

	private readonly delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void> _glUniformMatrix4x3fv =
		(delegate* unmanaged[Stdcall]<GLint, GLsizei, GLboolean, void*, void>)getProcAddress("glUniformMatrix4x3fv");

	private readonly delegate* unmanaged[Stdcall]<GLuint, void> _glUseProgram = (delegate* unmanaged[Stdcall]<GLuint, void>)getProcAddress("glUseProgram");
}
