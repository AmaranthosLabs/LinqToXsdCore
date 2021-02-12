using System.Diagnostics;

namespace Xml.Schema.Linq
{
    [DebuggerTypeProxy(typeof(XListDebugVisualizer))]
    [DebuggerDisplay("Count = {((ICountAndCopy)((object)this)).Count}")]
    public abstract class XListVisualizable
    {
        internal class XListDebugVisualizer
        {
            object _xList = null;

            public XListDebugVisualizer(object xList)
            {
                _xList = xList;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public XTypedElement[] Items
            {
                get
                {
                    XTypedElement[] tArray = new XTypedElement[((ICountAndCopy) _xList).Count];
                    ((ICountAndCopy) _xList).CopyTo(tArray, 0);
                    return tArray;
                }
            }
        }
    }
}