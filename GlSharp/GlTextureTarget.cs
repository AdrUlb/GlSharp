using static GlSharp.GlConstants;

namespace GlSharp;

public enum GlTextureTarget
{
	Texture1D = GL_TEXTURE_1D,
	Texture2D = GL_TEXTURE_2D,
	Texture3D = GL_TEXTURE_3D,
	Texture1DArray = GL_TEXTURE_1D_ARRAY,
	Texture2DArray = GL_TEXTURE_2D_ARRAY,
	TextureRectangle = GL_TEXTURE_RECTANGLE,
	TextureCubeMap = GL_TEXTURE_CUBE_MAP,
	TextureBuffer = GL_TEXTURE_BUFFER,
	Texture2DMultisample = GL_TEXTURE_2D_MULTISAMPLE,
	Texture2DMultisampleArray = GL_TEXTURE_2D_MULTISAMPLE_ARRAY,
	ProxyTexture2D = GL_PROXY_TEXTURE_2D,
	ProxyTexture1DArray = GL_PROXY_TEXTURE_1D_ARRAY,
	ProxyTextureRectangle = GL_PROXY_TEXTURE_RECTANGLE,
	TextureCubeMapPositiveX = GL_TEXTURE_CUBE_MAP_POSITIVE_X,
	TextureCubeMapNegativeX = GL_TEXTURE_CUBE_MAP_NEGATIVE_X,
	TextureCubeMapPositiveY = GL_TEXTURE_CUBE_MAP_POSITIVE_Y,
	TextureCubeMapNegativeY = GL_TEXTURE_CUBE_MAP_NEGATIVE_Y,
	TextureCubeMapPositiveZ = GL_TEXTURE_CUBE_MAP_POSITIVE_Z,
	TextureCubeMapNegativeZ = GL_TEXTURE_CUBE_MAP_NEGATIVE_Z,
	ProxyTextureCubeMap = GL_PROXY_TEXTURE_CUBE_MAP
}
