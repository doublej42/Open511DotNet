using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace Open511DotNet
{
    public class RecurringSchedule : IXmlSerializable
    {
        [XmlElement("start_date")]
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [XmlElement("end_date")]
        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [XmlArray("days")]
        [XmlArrayItem("day")]
        [JsonProperty("days")]
        public List<DayOfWeek> Days { get; set; }

        //[XmlElement("daily_start_time")]
        //[JsonProperty("daily_start_time")]
        //public DateTime DailyStartTime { get; set; }

        //[XmlElement("daily_end_time")]
        //[JsonProperty("daily_end_time")]
        //public DateTime DailyEndTime { get; set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            //var doc = new XmlDocument();
            //doc.Load(reader);
            var xml = XElement.Load(reader.ReadSubtree());
            
            DateTime tmpOut;
            var startDateElement = xml.Element("start_date");
            if (startDateElement != null)
            {
                var startDate = startDateElement.Value;
                
                if(DateTime.TryParse(startDate,out tmpOut))
                {
                    StartDate = tmpOut;
                }
            }
            var endDateElement = xml.Element("end_date");
            if (endDateElement != null)
            {
                var endDate = endDateElement.Value;
                                
                if(DateTime.TryParse(endDate,out tmpOut))
                {
                    EndDate = tmpOut;
                }
            }
            var days = xml.Element("days");
            if (days != null)
            {
                Days = new List<DayOfWeek>();
                foreach (var day in days.Elements("day"))
                {
                    DayOfWeek tmpDay;
                    if (Enum.TryParse(day.Value, out tmpDay))
                    {
                        Days.Add(tmpDay);
                    }
                }
            }


            var startTimeElement = xml.Element("daily_start_time");
            if (startTimeElement != null)
            {
                var startTime = startTimeElement.Value;

                if (DateTime.TryParse(startTime, out tmpOut))
                {
                    StartDate = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day,tmpOut.Hour,tmpOut.Minute,0);
                }
            }


            var endTimeElement = xml.Element("daily_end_time");
            if (endTimeElement != null)
            {
                var endTime = endTimeElement.Value;

                if (DateTime.TryParse(endTime, out tmpOut))
                {
                    EndDate = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, tmpOut.Hour, tmpOut.Minute, 0);
                }
            }
            reader.ReadEndElement();//read the end element and continue;

        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("start_date");
            writer.WriteValue(StartDate.Date);
            writer.WriteEndElement();

            writer.WriteStartElement("end_date");
            writer.WriteValue(EndDate.Date);
            writer.WriteEndElement();
            if (Days != null)
            {
                writer.WriteStartElement("days");
                foreach (var day in Days)
                {
                    writer.WriteStartElement("day");
                    writer.WriteValue((int) day);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteStartElement("daily_start_time");
            writer.WriteValue(StartDate.ToString("HH:mm"));
            writer.WriteEndElement();

            writer.WriteStartElement("daily_end_time");
            writer.WriteValue(EndDate.ToString("HH:mm"));
            writer.WriteEndElement();
            

        }
    }
}
