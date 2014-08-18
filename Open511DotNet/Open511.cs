using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Open511DotNet
{
    public static class Open511
    {
        public static string Serialize(object obj)
        {
            var xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Encoding = Encoding.UTF8; // This is probably the default
            var x = new XmlSerializer(obj.GetType());
            var sww = new StringWriter();
            var writer = XmlWriter.Create(sww, xws);
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            x.Serialize(writer, obj, ns);
            return sww.ToString();
        }

        
    }
}
