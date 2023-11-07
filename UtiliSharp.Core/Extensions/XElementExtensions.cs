using System.Xml.Linq;
namespace UtiliSharp.Core.Extensions;

public static class XElementExtensions
{
	// Adds a new child element with the specified XName and value, and returns the parent element for chaining
	public static XElement AddElement(this XElement parentElement, XName name, string value)
	{
		XElement newElement = new XElement(name, value);
		parentElement.Add(newElement);
		return newElement; // Returning the new child element to allow chaining on it
	}

	// Sets the value of an attribute, adds the attribute if it does not exist, and returns the element for chaining
	public static XElement SetAttribute(this XElement element, XName attributeName, string value)
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
		return element; // Returning the element to allow chaining
	}

	// Upserts (adds or updates) a child element's value and returns the parent element for chaining
	public static XElement UpsertElementValue(this XElement parentElement, XName elementName, string value)
	{
		XElement? element = parentElement.Element(elementName);
		if (element == null)
		{
			XElement newElement = new XElement(elementName, value);
			parentElement.Add(newElement);
			return newElement; // Returning the new child element to allow chaining on it
		}
		else
		{
			element.Value = value;
			return element; // Returning the updated child element to allow chaining
		}
	}

	// Gets the value of a child element with the specified XName
	public static string GetElementValue(this XElement element, XName name)
	{
		return element.Element(name)?.Value;
	}

	// Sets the value of a child element with the specified XName, adds the element if it does not exist
	public static void SetElementValue(this XElement element, XName name, string value)
	{
		XElement? child = element.Element(name);
		if (child != null)
		{
			child.Value = value;
		}
		else
		{
			element.Add(new XElement(name, value));
		}
	}

	// Gets the value of an attribute
	public static string GetAttributeValue(this XElement element, XName attributeName)
	{
		return element.Attribute(attributeName)?.Value;
	}

	// Removes this element from its parent
	public static void Remove(this XElement element)
	{
		element.Remove();
	}

	// Add more element-specific methods as needed
}

