using Newtonsoft.Json;
using Powerplant_Unit_Measurement.Entity;
using Powerplant_Unit_Measurement.Model;

namespace Powerplant_Unit_Measurement.Utilities
{
    public class UnitCommitment : IUnitCommitment
    {
        /// <summary>
        /// Calculate unit commitment
        /// Create by: Lalit Kumar
        /// Created on : 17-Oct-23
        /// Updated by : NA
        /// Updated on : NA
        /// </summary>
        /// <param name="payload">json object</param>
        public List<PowerProduced> CalculateUnitCommitment(dynamic payload)
        {
            try
            {
                PowerPayload objPowerPayload = JsonConvert.DeserializeObject<PowerPayload>(Convert.ToString(payload));

                objPowerPayload.powerplants.ForEach(t => t.type = (
                                                                        Common.GetEnumDescription(Common.FuelFilter.gas).Contains(t.type) ? Common.GetEnumDescription(Common.FuelMeasure.gas) :
                                                                        Common.GetEnumDescription(Common.FuelFilter.kerosine).Contains(t.type) ? Common.GetEnumDescription(Common.FuelMeasure.kerosine) :
                                                                        Common.GetEnumDescription(Common.FuelFilter.co2).Contains(t.type) ? Common.GetEnumDescription(Common.FuelMeasure.co2) :
                                                                        Common.GetEnumDescription(Common.FuelFilter.wind).Contains(t.type) ? Common.GetEnumDescription(Common.FuelMeasure.wind) : ""
                                                                  ));

                // Sort power plants by cost
                var sortedPowerplants = objPowerPayload.powerplants.OrderBy(p => p.efficiency * p.pmin * objPowerPayload.fuels[p.type]);

                var unitCommitment = new List<PowerProduced>();

                // Initialize the load to be met
                double remainingLoad = objPowerPayload.load;

                // Iterate through the power plants and commit them one by one
                foreach (var powerplant in sortedPowerplants)
                {
                    var name = powerplant.name;
                    var pmin = powerplant.pmin;
                    var pmax = powerplant.pmax;
                    var efficiency = powerplant.efficiency;

                    // Calculate the maximum power we can produce with this power plant
                    var maxPower = Math.Min(pmax, remainingLoad);

                    // Calculate the power to commit based on efficiency and load
                    var committedPower = maxPower * efficiency;

                    // Deduct the committed power from the remaining load
                    remainingLoad -= committedPower;

                    unitCommitment.Add(new PowerProduced { name = name, p = committedPower });

                    // If the load is met, break the loop
                    if (remainingLoad <= 0)
                        break;
                }
                return unitCommitment;
            }
            catch
            {
                throw;
            }
        }
    }
}
