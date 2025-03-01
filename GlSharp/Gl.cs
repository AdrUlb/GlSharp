using System.Drawing;
using System.Numerics;
using System.Text;

namespace GlSharp;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global

public unsafe partial class Gl(Gl.GetProcAddress getProcAddress)
{
	public delegate nint GetProcAddress(string proc);

	public void Clear(GlClearFlags mask) => _glClear((uint)mask);
	public void ClearColor(float red, float green, float blue, float alpha) => _glClearColor(red, green, blue, alpha);
	public void ClearColor(Color color) => ClearColor(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f, color.A / 255.0f);

	public void Viewport(int x, int y, int width, int height) => _glViewport(x, y, width, height);

	public uint CreateShader(GlShaderType shaderType) => _glCreateShader((uint)shaderType);
	public void DeleteShader(uint shader) => _glDeleteShader(shader);
	public void ShaderSource(uint shader, int count, byte** str, int* length) => _glShaderSource(shader, count, (byte*)str, length);
	public void CompileShader(uint shader) => _glCompileShader(shader);

	public void ShaderSource(uint shader, string source)
	{
		var length = Encoding.UTF8.GetByteCount(source);
		Span<byte> strBuf = stackalloc byte[length];
		Encoding.UTF8.GetBytes(source, strBuf);

		fixed (byte* strBufPtr = strBuf)
			ShaderSource(shader, 1, &strBufPtr, &length);
	}

	public int GetShader(uint shader, GlShaderParameterName pname)
	{
		int param;
		_glGetShaderiv(shader, (uint)pname, &param);
		return param;
	}

	public string GetShaderInfoLog(uint shader)
	{
		var infoLogLength = GetShader(shader, GlShaderParameterName.InfoLogLength);
		if (infoLogLength == 0)
			return "";

		Span<byte> buffer = stackalloc byte[infoLogLength];
		int length;
		fixed (byte* bufferPtr = buffer)
			_glGetShaderInfoLog(shader, infoLogLength, &length, bufferPtr);

		return Encoding.UTF8.GetString(buffer[..length]);
	}

	public void AttachShader(uint program, uint shader) => _glAttachShader(program, shader);
	public void DetachShader(uint program, uint shader) => _glDetachShader(program, shader);

	public uint CreateProgram() => _glCreateProgram();
	public void DeleteProgram(uint program) => _glDeleteProgram(program);
	public void LinkProgram(uint program) => _glLinkProgram(program);

	public int GetProgram(uint program, GlProgramParameterName pname)
	{
		int param;
		_glGetProgramiv(program, (uint)pname, &param);
		return param;
	}

	public void UseProgram(uint program) => _glUseProgram(program);


	public int GetUniformLocation(uint program, string name)
	{
		var nameLength = Encoding.UTF8.GetByteCount(name);
		Span<byte> nameBuf = stackalloc byte[nameLength + 1];
		Encoding.UTF8.GetBytes(name, nameBuf);
		nameBuf[nameLength] = 0;

		fixed (byte* namePtr = nameBuf)
			return _glGetUniformLocation(program, namePtr);
	}

	public void Uniform1f(int location, float v0) => _glUniform1f(location, v0);
	public void Uniform2f(int location, float v0, float v1) => _glUniform2f(location, v0, v1);
	public void Uniform3f(int location, float v0, float v1, float v2) => _glUniform3f(location, v0, v1, v2);
	public void Uniform4f(int location, float v0, float v1, float v2, float v3) => _glUniform4f(location, v0, v1, v2, v3);
	public void Uniform1i(int location, int v0) => _glUniform1i(location, v0);
	public void Uniform2i(int location, int v0, int v1) => _glUniform2i(location, v0, v1);
	public void Uniform3i(int location, int v0, int v1, int v2) => _glUniform3i(location, v0, v1, v2);
	public void Uniform4i(int location, int v0, int v1, int v2, int v3) => _glUniform4i(location, v0, v1, v2, v3);
	public void Uniform1ui(int location, uint v0) => _glUniform1ui(location, v0);
	public void Uniform2ui(int location, uint v0, uint v1) => _glUniform2ui(location, v0, v1);
	public void Uniform3ui(int location, uint v0, uint v1, uint v2) => _glUniform3ui(location, v0, v1, v2);
	public void Uniform4ui(int location, uint v0, uint v1, uint v2, uint v3) => _glUniform4ui(location, v0, v1, v2, v3);

	public void Uniform1fv(int location, ReadOnlySpan<float> values)
	{
		fixed (float* valuesPtr = values)
			_glUniform1fv(location, values.Length, valuesPtr);
	}

	public void Uniform2fv(int location, ReadOnlySpan<float> values)
	{
		fixed (float* valuesPtr = values)
			_glUniform2fv(location, values.Length, valuesPtr);
	}

	public void Uniform3fv(int location, ReadOnlySpan<float> values)
	{
		fixed (float* valuesPtr = values)
			_glUniform3fv(location, values.Length, valuesPtr);
	}

	public void Uniform4fv(int location, ReadOnlySpan<float> values)
	{
		fixed (float* valuesPtr = values)
			_glUniform4fv(location, values.Length, valuesPtr);
	}

	public void Uniform1iv(int location, ReadOnlySpan<int> values)
	{
		fixed (int* valuesPtr = values)
			_glUniform1iv(location, values.Length, valuesPtr);
	}

	public void Uniform2iv(int location, ReadOnlySpan<int> values)
	{
		fixed (int* valuesPtr = values)
			_glUniform2iv(location, values.Length, valuesPtr);
	}

	public void Uniform3iv(int location, ReadOnlySpan<int> values)
	{
		fixed (int* valuesPtr = values)
			_glUniform3iv(location, values.Length, valuesPtr);
	}

	public void Uniform4iv(int location, ReadOnlySpan<int> values)
	{
		fixed (int* valuesPtr = values)
			_glUniform4iv(location, values.Length, valuesPtr);
	}

	public void Uniform1uiv(int location, ReadOnlySpan<uint> value)
	{
		fixed (uint* valuesPtr = value)
			_glUniform1uiv(location, value.Length, valuesPtr);
	}

	public void Uniform2uiv(int location, ReadOnlySpan<uint> value)
	{
		fixed (uint* valuesPtr = value)
			_glUniform2uiv(location, value.Length, valuesPtr);
	}

	public void Uniform3uiv(int location, ReadOnlySpan<uint> value)
	{
		fixed (uint* valuesPtr = value)
			_glUniform3uiv(location, value.Length, valuesPtr);
	}

	public void Uniform4uiv(int location, ReadOnlySpan<uint> value)
	{
		fixed (uint* valuesPtr = value)
			_glUniform4uiv(location, value.Length, valuesPtr);
	}

	public void UniformMatrix4fv(int location, bool transpose, ReadOnlySpan<Matrix4x4> value)
	{
		fixed (Matrix4x4* valuePtr = value)
			_glUniformMatrix4fv(location, value.Length, transpose, (float*)valuePtr);
	}

	public void UniformMatrix4fv(int location, bool transpose, in Matrix4x4 value)
	{
		fixed (Matrix4x4* valuePtr = &value)
			_glUniformMatrix4fv(location, 1, transpose, (float*)valuePtr);
	}

	public void GenBuffers(Span<uint> buffers)
	{
		fixed (uint* buffersPtr = buffers)
			_glGenBuffers(buffers.Length, buffersPtr);
	}

	public uint GenBuffer()
	{
		uint buffer;
		_glGenBuffers(1, &buffer);
		return buffer;
	}

	public void DeleteBuffers(ReadOnlySpan<uint> buffers)
	{
		fixed (uint* buffersPtr = buffers)
			_glDeleteBuffers(buffers.Length, buffersPtr);
	}

	public void DeleteBuffer(uint buffer) => _glDeleteBuffers(1, &buffer);

	public void BindBuffer(GlBufferTarget target, uint buffer) => _glBindBuffer((uint)target, buffer);

	public void BufferData<T>(GlBufferTarget target, ReadOnlySpan<T> data, GlBufferUsage usage) where T : unmanaged
	{
		fixed (T* dataPtr = data)
			_glBufferData((uint)target, data.Length * sizeof(T), dataPtr, (uint)usage);
	}

	public void BufferData(GlBufferTarget target, nint size, GlBufferUsage usage)
	{
		_glBufferData((uint)target, size, null, (uint)usage);
	}

	public void BufferSubData<T>(GlBufferTarget target, nint offset, ReadOnlySpan<T> data) where T : unmanaged
	{
		fixed (T* dataPtr = data)
			_glBufferSubData((uint)target, offset, data.Length * sizeof(T), dataPtr);
	}

	public void GenVertexArrays(Span<uint> arrays)
	{
		fixed (uint* arraysPtr = arrays)
			_glGenVertexArrays(arrays.Length, arraysPtr);
	}

	public uint GenVertexArray()
	{
		uint array;
		_glGenVertexArrays(1, &array);
		return array;
	}

	public void DeleteVertexArrays(ReadOnlySpan<uint> arrays)
	{
		fixed (uint* arraysPtr = arrays)
			_glDeleteVertexArrays(arrays.Length, arraysPtr);
	}

	public void DeleteVertexArray(uint array) => _glDeleteVertexArrays(1, &array);
	public void BindVertexArray(uint array) => _glBindVertexArray(array);

	public void VertexAttribPointer(uint index, int size, GlType type, bool normalized, int stride, nuint pointer) =>
		_glVertexAttribPointer(index, size, (uint)type, normalized, stride, (void*)pointer);

	public void VertexAttribIPointer(uint index, int size, GlVertexAttribIType type, int stride, nuint pointer) =>
		_glVertexAttribIPointer(index, size, (uint)type, stride, (void*)pointer);

	public void EnableVertexAttribArray(uint index) => _glEnableVertexAttribArray(index);
	public void DisableVertexAttribArray(uint index) => _glDisableVertexAttribArray(index);
	public void Enable(GlCapability cap) => _glEnable((uint)cap);
	public void Disable(GlCapability cap) => _glDisable((uint)cap);
	public void BlendFunc(GlBlendFactor sfactor, GlBlendFactor dfactor) => _glBlendFunc((uint)sfactor, (uint)dfactor);
	public void DrawArrays(GlDrawMode mode, int first, int count) => _glDrawArrays((uint)mode, first, count);
	public void DrawElements(GlDrawMode mode, int count, GlType type, nuint indices) => _glDrawElements((uint)mode, count, (uint)type, (void*)indices);

	public void GenTextures(Span<uint> textures)
	{
		fixed (uint* texturesPtr = textures)
			_glGenTextures(textures.Length, texturesPtr);
	}

	public uint GenTexture()
	{
		uint texture;
		_glGenTextures(1, &texture);
		return texture;
	}

	public void DeleteTextures(ReadOnlySpan<uint> arrays)
	{
		fixed (uint* arraysPtr = arrays)
			_glDeleteTextures(arrays.Length, arraysPtr);
	}

	public void DeleteTexture(uint texture)
	{
		_glDeleteTextures(1, &texture);
	}

	public void ActiveTexture(uint texture) => _glActiveTexture(texture);
	public void BindTexture(GlTextureTarget target, uint texture) => _glBindTexture((uint)target, texture);

	public void TexImage2D<T>(GlTextureTarget target, int level, GlPixelInternalFormat internalFormat, int width, int height, GlPixelFormat format, GlPixelType type,
		ReadOnlySpan<T> data) where T : unmanaged
	{
		fixed (T* dataPtr = data)
			_glTexImage2D((uint)target, level, (int)internalFormat, width, height, 0, (uint)format, (uint)type, dataPtr);
	}

	public void TexSubImage2D<T>(GlTextureTarget target, int level, int xoffset, int yoffset, int width, int height, GlPixelFormat format, GlPixelType type, ReadOnlySpan<T> data)
		where T : unmanaged
	{
		fixed (T* dataPtr = data)
			_glTexSubImage2D((uint)target, level, xoffset, yoffset, width, height, (uint)format, (uint)type, dataPtr);
	}

	public void TexParameterf(GlTextureTarget target, GlTextureParameterName pname, float param) => _glTexParameterf((uint)target, (uint)pname, param);
	public void TexParameteri(GlTextureTarget target, GlTextureParameterName pname, int param) => _glTexParameteri((uint)target, (uint)pname, param);

	public void GetBooleanv(GlGetParameterName pname, Span<bool> param)
	{
		fixed (bool* paramPtr = param)
			_glGetBooleanv((uint)pname, paramPtr);
	}

	public bool GetBoolean(GlGetParameterName pname)
	{
		bool param;
		_glGetBooleanv((uint)pname, &param);
		return param;
	}

	public void GetDoublev(GlGetParameterName pname, Span<double> param)
	{
		fixed (double* paramPtr = param)
			_glGetDoublev((uint)pname, paramPtr);
	}

	public double GetDouble(GlGetParameterName pname)
	{
		double param;
		_glGetDoublev((uint)pname, &param);
		return param;
	}

	public void GetFloatv(GlGetParameterName pname, Span<float> param)
	{
		fixed (float* paramPtr = param)
			_glGetFloatv((uint)pname, paramPtr);
	}

	public float GetFloat(GlGetParameterName pname)
	{
		float param;
		_glGetFloatv((uint)pname, &param);
		return param;
	}

	public void GetIntegerv(GlGetParameterName pname, Span<int> param)
	{
		fixed (int* paramPtr = param)
			_glGetIntegerv((uint)pname, paramPtr);
	}

	public int GetInteger(GlGetParameterName pname)
	{
		int param;
		_glGetIntegerv((uint)pname, &param);
		return param;
	}

	public void GetInteger64v(GlGetParameterName pname, Span<long> param)
	{
		fixed (long* paramPtr = param)
			_glGetInteger64v((uint)pname, paramPtr);
	}

	public long GetInteger64(GlGetParameterName pname)
	{
		long param;
		_glGetInteger64v((uint)pname, &param);
		return param;
	}
}

// ReSharper restore InconsistentNaming
// ReSharper restore MemberCanBePrivate.Global
