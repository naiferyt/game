namespace System.Xml
{
	public class XmlNodeChangedEventArgs : EventArgs
	{
		private XmlNode _oldParent;

		private XmlNode _newParent;

		private XmlNodeChangedAction _action;

		private XmlNode _node;

		private string _oldValue;

		private string _newValue;

		public XmlNodeChangedEventArgs(XmlNode node, XmlNode oldParent, XmlNode newParent, string oldValue, string newValue, XmlNodeChangedAction action)
		{
		}
	}
}
