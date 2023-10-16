/// <summary>
/// Model to map with json payload
/// Create by: Lalit Kumar
/// Created on : 17-Oct-23
/// Updated by : NA
/// Updated on : NA
/// </summary>
namespace Powerplant_Unit_Measurement.Model
{
    public class PowerPayload
    {
        public int load { get; set; }
        public Dictionary<string,double> fuels { get; set; }
        public List<Powerplant> powerplants { get; set; }
    }

    public class Powerplant
    {
        public string name { get; set; }
        public string type { get; set; }
        public double efficiency { get; set; }
        public int pmin { get; set; }
        public int pmax { get; set; }
    }
}
