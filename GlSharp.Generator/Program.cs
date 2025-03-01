using System.Text;
using System.Xml;

namespace GlSharp.Generator;

internal static class Program
{
	private static void Main()
	{
		var document = new XmlDocument
		{
			PreserveWhitespace = true
		};

		document.Load("gl.xml");

		var constantsBuilder = new StringBuilder()
			.AppendLine("namespace GlSharp;")
			.AppendLine()
			.AppendLine("public static class GlConstants")
			.Append('{').AppendLine();

		var methodsBuilder = new StringBuilder()
			.AppendLine("using GLenum = uint;")
			.AppendLine("using GLboolean = bool;")
			.AppendLine("using GLbitfield = uint;")
			.AppendLine("using GLbyte = sbyte;")
			.AppendLine("using GLubyte = byte;")
			.AppendLine("using GLshort = short;")
			.AppendLine("using GLushort = ushort;")
			.AppendLine("using GLint = int;")
			.AppendLine("using GLuint = uint;")
			.AppendLine("using GLclampx = int;")
			.AppendLine("using GLsizei = int;")
			.AppendLine("using GLfloat = float;")
			.AppendLine("using GLclampf = float;")
			.AppendLine("using GLdouble = double;")
			.AppendLine("using GLclampd = double;")
			.AppendLine("using GLeglClientBufferEXT = nuint;")
			.AppendLine("using GLeglImageOES = nuint;")
			.AppendLine("using GLchar = byte;")
			.AppendLine("using GLcharARB = byte;")
			.AppendLine("using GLhandleARB = nuint; // Size??")
			.AppendLine("using GLhalf = ushort;")
			.AppendLine("using GLhalfARB = ushort;")
			.AppendLine("using GLfixed = int;")
			.AppendLine("using GLintptr = nint;")
			.AppendLine("using GLintptrARB = nint;")
			.AppendLine("using GLsizeiptr = nint;")
			.AppendLine("using GLsizeiptrARB = nint;")
			.AppendLine("using GLint64 = long;")
			.AppendLine("using GLint64EXT = long;")
			.AppendLine("using GLuint64 = ulong;")
			.AppendLine("using GLuint64EXT = ulong;")
			.AppendLine("using GLsync = nuint; // typedef struct __GLsync *GLsync;")
			.AppendLine()
			.AppendLine("using _cl_context = nuint; // struct _cl_context;")
			.AppendLine("using _cl_event = nuint; // struct _cl_event;")
			.AppendLine("using GLDEBUGPROC = nuint;")
			.AppendLine("using GLDEBUGPROCARB = nuint;")
			.AppendLine("using GLDEBUGPROCKHR = nuint;")
			.AppendLine()
			.AppendLine("// Vendor extension types")
			.AppendLine("using GLDEBUGPROCAMD = nuint;")
			.AppendLine("using GLhalfNV = ushort;")
			.AppendLine("using GLvdpauSurfaceNV = nint; // typedef GLintptr GLvdpauSurfaceNV;")
			.AppendLine("using GLVULKANPROCNV = nuint;")
			.AppendLine()
			.AppendLine("namespace GlSharp;")
			.AppendLine()
			.AppendLine("unsafe partial class Gl")
			.Append('{').AppendLine();

		foreach (XmlNode node in document.DocumentElement?.ChildNodes ?? throw new("FIXME"))
		{
			if (node.NodeType is XmlNodeType.Comment or XmlNodeType.Whitespace)
				continue;

			if (node.NodeType != XmlNodeType.Element)
				throw new NotSupportedException($"Unexpected enum child node '{node.Name}' of type '{node.NodeType}'");

			switch (node.Name)
			{
				case "comment":
				case "types": // TODO
				case "kinds": // TODO
					break;
				case "enums":
					GenerateEnums(node, constantsBuilder);
					break;
				case "commands":
				{
					string? ns = null;
					foreach (XmlAttribute attr in node.Attributes ?? throw new NotSupportedException())
					{
						switch (attr.Name)
						{
							case "namespace":
								ns = attr.Value;
								break;
							default:
								throw new NotSupportedException($"Unknown commands attribute value '{attr.Name}' = '{attr.Value}'");
						}
					}

					foreach (XmlNode commandNode in node.ChildNodes)
					{
						if (commandNode.NodeType is XmlNodeType.Comment or XmlNodeType.Whitespace)
							continue;

						if (commandNode.NodeType != XmlNodeType.Element)
							throw new NotSupportedException($"Unexpected enum child node '{commandNode.Name}' of type '{commandNode.NodeType}'");

						if (commandNode.Name != "command")
							throw new NotSupportedException($"Unexpected enum child element '{commandNode.Name}'");

						foreach (XmlAttribute attr in commandNode.Attributes ?? throw new NotSupportedException())
						{
							switch (attr.Name)
							{
								case "comment":
									break;
								default:
									throw new NotSupportedException($"Unknown command attribute value '{attr.Name}' = '{attr.Value}'");
							}
						}

						string? proto = null;
						var param = new List<string>();

						foreach (XmlNode n in commandNode.ChildNodes)
						{
							if (n.NodeType is XmlNodeType.Whitespace)
								continue;

							if (n.NodeType != XmlNodeType.Element)
								throw new NotSupportedException($"Unexpected command child node '{n.Name}' of type '{n.NodeType}'");

							switch (n.Name)
							{
								case "proto":
									proto = n.InnerText;
									break;
								case "param":
									param.Add(n.InnerText);
									break;
								case "glx":
								case "alias":
								case "vecequiv":
									break;
								default:
									throw new NotSupportedException($"Unknown command child element value '{n.Name}' = '{n.InnerText}'");
							}
						}

						if (proto == null)
							throw new NotSupportedException();

						if (proto.StartsWith("const "))
							proto = proto[6..];

						var splitIndex = proto.IndexOf('*');
						if (splitIndex < 0)
							splitIndex = proto.IndexOf(' ');
						splitIndex++;
						var returnType = proto[..splitIndex].Replace(" *", "*").Trim();
						for (var i = 0; i < param.Count; i++)
						{
							var changed = true;
							while (changed)
							{
								changed = false;
								if (param[i].StartsWith("struct "))
								{
									param[i] = param[i][7..];
									changed = true;
								}

								if (param[i].StartsWith("const "))
								{
									param[i] = param[i][6..];
									changed = true;
								}
							}

							var index = param[i].IndexOf('*');
							if (index < 0)
								index = param[i].IndexOf(' ');
							index++;
							param[i] = param[i][..index].Replace(" *", "*").Trim();
						}

						var name = proto[splitIndex..].Trim();
						param.Add(returnType);
						var type = $"delegate* unmanaged[Stdcall]<{string.Join(", ", param)}>";
						methodsBuilder.Append('\t').Append("private readonly ").Append(type).Append(" _").Append(name).Append(" = (").Append(type).Append(")getProcAddress(\"")
							.Append(name).Append("\");").AppendLine();
						//methodsBuilder.Append('\t').Append(proto).Append('(').Append(string.Join(", ", param)).Append(");").AppendLine();
					}

					break;
				}
				case "feature": // TODO
				case "extensions": // TODO
					break;
				default:
					throw new NotSupportedException($"Unexpected element '{node.Name}'");

					break;
			}
		}

		constantsBuilder.Append('}').AppendLine();
		methodsBuilder.Append('}').AppendLine();

		File.WriteAllText("GlConstants.cs", constantsBuilder.ToString());
		File.WriteAllText("Gl.Imports.cs", methodsBuilder.ToString());
	}

	private static void GenerateEnums(XmlNode node, StringBuilder builder)
	{
		string? group = null;
		var isBitmask = false;
		foreach (XmlAttribute attr in node.Attributes ?? throw new NotSupportedException())
		{
			switch (attr.Name)
			{
				case "comment":
				case "start":
				case "end":
				case "vendor":
					break;
				case "namespace":
					if (attr.Value != "GL")
						throw new("FIXME");

					break;
				case "group":
					group = attr.Value;
					break;
				case "type":
					if (attr.Value != "bitmask")
						throw new("FIXME");

					isBitmask = true;
					break;
				default:
					throw new NotSupportedException($"Unknown enums attribute value '{attr.Name}' = '{attr.Value}'");
			}
		}

		foreach (XmlNode enumNode in node.ChildNodes)
		{
			if (enumNode.NodeType is XmlNodeType.Comment or XmlNodeType.Whitespace)
				continue;

			if (enumNode.NodeType != XmlNodeType.Element)
				throw new NotSupportedException($"Unexpected enum child node '{enumNode.Name}' of type '{enumNode.NodeType}'");

			if (enumNode.Name == "unused")
				continue;

			if (enumNode.Name != "enum")
				throw new NotSupportedException($"Unexpected enum child element '{enumNode.Name}'");

			if (enumNode.ChildNodes.Count != 0)
				throw new NotSupportedException();


			string? enumMemberValue = null;
			string? enumMemberName = null;
			string? enumMemberAlias = null;
			string? enumMemberGroup = null;
			var enumMemberType = "int";
			string? api = null;

			foreach (XmlAttribute attr in enumNode.Attributes ?? throw new NotSupportedException())
			{
				switch (attr.Name)
				{
					case "comment":
						break;
					case "api":
						api = attr.Value;
						break;
					case "value":
						enumMemberValue = attr.Value;
						break;
					case "name":
						enumMemberName = attr.Value;
						break;
					case "group":
						enumMemberGroup = attr.Value;
						break;
					case "alias":
						enumMemberAlias = attr.Value;
						break;
					case "type":
						switch (attr.Value)
						{
							case "u":
								enumMemberType = "uint";
								break;
							case "ull":
								enumMemberType = "ulong";
								break;
							default:
								throw new("FIXME");
						}

						break;
					default:
						throw new NotSupportedException($"Unknown enum attribute value '{attr.Name}' = '{attr.Value}'");
				}
			}

			if (api == null)
			{
				if (enumMemberName != null)
					builder.Append('\t').Append("public const ").Append(enumMemberType).Append(' ').Append(enumMemberName).Append(" = unchecked((")
						.Append(enumMemberType)
						.Append(')')
						.Append(enumMemberValue).AppendLine(");");
			}
		}
	}
}
