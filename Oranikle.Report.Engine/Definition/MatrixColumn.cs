/* ====================================================================
   

   
	
   
   
   

       

   
   
   
   
   


   
   
*/

using System;
using System.Xml;

namespace Oranikle.Report.Engine
{
	///<summary>
	/// Handle a Matrix column.
	///</summary>
	[Serializable]
	public class MatrixColumn : ReportLink
	{
		RSize _Width;		// Width of each detail cell in this column
	
		public MatrixColumn(ReportDefn r, ReportLink p, XmlNode xNode) : base(r, p)
		{
			_Width=null;

			// Loop thru all the child nodes
			foreach(XmlNode xNodeLoop in xNode.ChildNodes)
			{
				if (xNodeLoop.NodeType != XmlNodeType.Element)
					continue;
				switch (xNodeLoop.Name)
				{
					case "Width":
						_Width = new RSize(r, xNodeLoop);
						break;
					default:
						// don't know this element - log it
						OwnerReport.rl.LogError(4, "Unknown MatrixColumn element '" + xNodeLoop.Name + "' ignored.");
						break;
				}
			}
		}
		
		override public void FinalPass()
		{
			return;
		}

		public RSize Width
		{
			get { return  _Width; }
			set {  _Width = value; }
		}
	}
}
