using System;
using System.Xml.Serialization;

namespace Lab.Technical.Exercise.Domain.EntityModels
{
    [XmlRoot(ElementName = "Scenario")]
    public class Scenario
    {
        [XmlIgnore]
        public DateTime CreationDate { get; set; }

        [XmlIgnore]
        public DateTime SampleDate { get; set; }

        [XmlElement("CreationDate")]
        public string CreationDateString
        {
            get { return this.CreationDate.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { this.CreationDate = DateTime.Parse(value); }
        }

        [XmlElement("SampleDate")]
        public string SampleDateString
        {
            get { return this.SampleDate.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { this.SampleDate = DateTime.Parse(value); }
        }

        [XmlElement(ElementName = "Forename")]
        public string Forename { get; set; }

        [XmlElement(ElementName = "MarketID")]
        public string MarketID { get; set; }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "NetworkLayerID")]
        public string NetworkLayerID { get; set; }

        [XmlElement(ElementName = "NumMonths", DataType = "int")]
        public int NumMonths { get; set; }

        [XmlElement(ElementName = "ScenarioID", DataType = "long")]
        public long ScenarioID { get; set; }

        [XmlElement(ElementName = "Surname")]
        public string Surname { get; set; }

        [XmlElement(ElementName = "UserID")]
        public string UserID { get; set; }
    }
}