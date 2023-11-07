using System.Xml.Linq;
namespace UtiliSharp.Core.Extensions;
public static class XDocumentExtensions
{
	public static async Task<XDocument> LoadAsync(string path)
	{
		using FileStream stream = File.OpenRead(path);
		return await XDocument.LoadAsync(stream, LoadOptions.None, cancellationToken: default);
	}

	public static IEnumerable<XElement> FindElementsWithAttribute(this XDocument doc, XName xName)
	{
		// Check if the document is not null
		if (doc == null)
		{
			throw new System.ArgumentNullException(nameof(doc));
		}

		// Use LINQ to XML to find all elements with a 'name' attribute
		return doc.Descendants().Where(el => el.Attribute(xName) != null);
	}

	public static async Task SaveAsync(this XDocument document, string path)
	{
		using FileStream stream = File.OpenWrite(path);
		await document.SaveAsync(stream, SaveOptions.None, cancellationToken: default);
	}

	public static string ToSerializedString(this XDocument document)
	{
		return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + document;
	}

	public static T Deserialize<T>(this XDocument document)
	{
		using System.Xml.XmlReader reader = document.CreateReader();
		System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
		return (T)serializer.Deserialize(reader);
	}

	public static XDocument SerializeToXDocument<T>(this T value)
	{
		System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
		XDocument document = new XDocument();
		using (System.Xml.XmlWriter writer = document.CreateWriter())
		{
			serializer.Serialize(writer, value);
		}
		return document;
	}
	public static string GetElementValue(this XDocument document, XName name)
	{
		return document.Descendants(name).Select(e => e.Value).FirstOrDefault();
	}

	// Sets the value of the first element with the specified XName, adds the element if it does not exist
	public static void SetElementValue(this XDocument document, XName name, string value)
	{
		XElement? element = document.Descendants(name).FirstOrDefault();
		if (element != null)
		{
			element.Value = value;
		}
		else
		{
			document.Root.Add(new XElement(name, value));
		}
	}

	// Gets all elements with the specified XName
	public static IEnumerable<XElement> GetElements(this XDocument document, XName name)
	{
		return document.Descendants(name);
	}

	// Adds a new element with the specified XName and value to the document's root
	public static void AddElement(this XDocument document, XName name, string value)
	{
		document.Root.Add(new XElement(name, value));
	}

	// Gets the value of an attribute of the first element with the specified XName
	public static string GetAttributeValue(this XDocument document, XName elementName, XName attributeName)
	{
		return document.Descendants(elementName).Attributes(attributeName).Select(a => a.Value).FirstOrDefault();
	}

	// Sets the value of an attribute of the first element with the specified XName
	public static void SetAttributeValue(this XDocument document, XName elementName, XName attributeName, string value)
	{
		XElement? element = document.Descendants(elementName).FirstOrDefault();
		if (element != null)
		{
			XAttribute? attribute = element.Attribute(attributeName);
			if (attribute != null)
			{
				attribute.Value = value;
			}
			else
			{
				element.Add(new XAttribute(attributeName, value));
			}
		}
	}

	// Removes all elements with the specified XName
	public static void RemoveElements(this XDocument document, XName name)
	{
		document.Descendants(name).Remove();
	}

	// Removes an attribute from all elements with the specified XName
	public static void RemoveAttribute(this XDocument document, XName elementName, XName attributeName)
	{
		document.Descendants(elementName).Attributes(attributeName).Remove();
	}

	// Example method to add or update (upsert) an element's value
	public static void UpsertElementValue(this XDocument document, XName elementName, string value)
	{
		XElement? element = document.Descendants(elementName).FirstOrDefault();
		if (element == null)
		{
			document.Root.Add(new XElement(elementName, value));
		}
		else
		{
			element.Value = value;
		}
	}
}