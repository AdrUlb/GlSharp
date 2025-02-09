using System.Text;
using System.Xml;

namespace GlSharp.Generator;

internal static class Program
{
	private static void Main()
	{
		var doc = new XmlDocument();
		doc.Load("gl.xml");

		var sb = new StringBuilder();

		sb
			.AppendLine("namespace GlSharp;")
			.AppendLine()
			.AppendLine("public static class GlConstants")
			.Append('{').AppendLine();

		foreach (XmlNode node in doc.DocumentElement?.ChildNodes ?? throw new("FIXME"))
		{
			if (node.NodeType == XmlNodeType.Comment)
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
					{
						string? group = null;
						var isBitmask = false;
						foreach (XmlAttribute attr in node.Attributes ?? throw new("FIXME"))
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
									throw new NotSupportedException($"Unknown enums attribute value {attr.Name} = {attr.Value}");
							}
						}

						foreach (XmlNode enumNode in node.ChildNodes)
						{
							if (enumNode.NodeType == XmlNodeType.Comment)
								continue;

							if (enumNode.NodeType != XmlNodeType.Element)
								throw new NotSupportedException($"Unexpected enum child node '{enumNode.Name}' of type '{enumNode.NodeType}'");

							if (enumNode.Name == "unused")
								continue;

							if (enumNode.Name != "enum")
							{
								throw new NotSupportedException($"Unexpected enum child element '{enumNode.Name}'");
							}

							if (enumNode.ChildNodes.Count != 0)
								throw new NotSupportedException();


							string? enumMemberValue = null;
							string? enumMemberName = null;
							string? enumMemberAlias = null;
							string? enumMemberGroup = null;
							var enumMemberType = "int";
							string? api = null;

							foreach (XmlAttribute attr in enumNode.Attributes ?? throw new("FIXME"))
							{
								switch (attr.Name)
								{
									case "comment":
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
										throw new NotSupportedException($"Unknown enum attribute value {attr.Name} = {attr.Value}");
								}
							}

							if (api == null)
							{

								if (enumMemberName != null)
									sb.Append('\t').Append("public const ").Append(enumMemberType).Append(' ').Append(enumMemberName).Append(" = unchecked((").Append(enumMemberType).Append(')')
										.Append(enumMemberValue).AppendLine(");");
							}
						}
					}
					break;
				case "commands": // TODO
				case "feature": // TODO
				case "extensions": // TODO
					break;
				default:
					throw new NotSupportedException($"Unexpected element '{node.Name}'");

					break;
			}
		}

		sb.Append('}').AppendLine();

		File.WriteAllText("GlConstants.cs", sb.ToString());
	}
}
