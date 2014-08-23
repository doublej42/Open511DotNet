using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Open511DotNet
{
    public class GmlPosList : IXmlSerializable
    {
        [XmlIgnore]
        public List<GmlPos> Points { get; set; }

        public GmlPosList()
        {
            Points = new List<GmlPos>();
        }

        public void FromString(string cords)
        {
            var cordsSplit = cords.Split(new[] { ' ' });
            var processed = 0;
            while (processed < cordsSplit.Length)
            {
                var newPoint = new GmlPos();
                double lat, lon;
                if (double.TryParse(cordsSplit[processed], out lat))
                {
                    newPoint.Latitude = lat;
                }
                processed++;
                //check to make sure there wasn't an odd number of cords. This is to prevent a crash on invalid pairs
                if (processed < cordsSplit.Length && double.TryParse(cordsSplit[processed], out lon))
                {
                    newPoint.Longitude = lon;
                }
                Points.Add(newPoint);
                processed++;
            }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            var cords = reader.ReadElementContentAsString();
            FromString(cords);
        }

        public void WriteXml(XmlWriter writer)
        {
            var started = false;
            foreach (var point in Points)
            {
                if (started)
                {
                    writer.WriteString(" ");
                }
                else
                {
                    started = true;
                }
                writer.WriteString(point.Latitude + " " + point.Longitude);
            }
        }
    }
}
