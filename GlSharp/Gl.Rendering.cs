using GLclampf = float;
using GLbitfield = uint;

namespace GlSharp;

unsafe partial class Gl
{
	private readonly delegate* unmanaged[Stdcall]<GLbitfield, void> _glClear = (delegate* unmanaged[Stdcall]<GLbitfield, void>)getProcAddress("glClear");

	private readonly delegate* unmanaged[Stdcall]<GLclampf, GLclampf, GLclampf, GLclampf, void> _glClearColor =
		(delegate* unmanaged[Stdcall]<GLclampf, GLclampf, GLclampf, GLclampf, void>)getProcAddress("glClearColor");
}
