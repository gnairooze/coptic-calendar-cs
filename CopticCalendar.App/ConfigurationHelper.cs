using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;

namespace CopticCalendar.App
{
    internal class ConfigurationHelper
    {
        private const string CONFIG_FILE = "coptic-calendar-mapping.json";

        public List<CopticCalendarMapping> Mappings { get; private set; }

        public ConfigurationHelper()
        {
            this.Mappings = new List<CopticCalendarMapping>();

            string jsontext = File.ReadAllText(CONFIG_FILE);
            JsonNode? json = JsonNode.Parse(jsontext);

            JsonArray? mappings = (JsonArray?)json?["coptic_calendar_mapping"];
            if(mappings == null)
            {
                return;
            }

            foreach (var mapping in mappings)
            {
                if (mapping == null) continue;

                var id = mapping["id"];
                var copticDay = mapping["coptic_day"];
                var copticMonth = mapping["coptic_month"];
                var dayType = mapping["type"];
                var gregorianDay = mapping["gregorian_day"];
                var gregorianMonth = mapping["gregorian_month"];

                if (mapping == null 
                    || id == null 
                    || copticDay == null 
                    || copticMonth == null 
                    || dayType == null 
                    || gregorianDay == null 
                    || gregorianMonth == null)
                {
                    continue;
                }

                Mappings.Add(new CopticCalendarMapping() { 
                    Id = (int)id.AsValue(),
                    CopticDay = (int)copticDay.AsValue(),
                    CopticMonth = (int)copticMonth.AsValue(),
                    DayType = (DayTypes)Enum.Parse(typeof(DayTypes),dayType.AsValue().ToString()),
                    GregorianDay = (int)gregorianDay.AsValue(),
                    GregorianMonth = (int)gregorianMonth.AsValue(),
                });
            }
        }
       
        
    }
}
