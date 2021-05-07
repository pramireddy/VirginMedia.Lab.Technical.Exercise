using System.Collections.Generic;
using System.Xml.Serialization;

namespace Lab.Technical.Exercise.Domain.EntityModels
{
    [XmlRoot(ElementName = "Data")]
    public class ScenariosData
    {
        [XmlElement(ElementName = "Scenario")]
        public List<Scenario> Scenarios { get; set; }
    }
}