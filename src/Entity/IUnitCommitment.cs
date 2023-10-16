using Powerplant_Unit_Measurement.Model;

namespace Powerplant_Unit_Measurement.Entity
{
    /// <summary>
    /// Interface to enforce method implementation to the class
    /// Create by: Lalit Kumar
    /// Created on : 17-Oct-23
    /// Updated by : NA
    /// Updated on : NA
    /// </summary>
    /// <param name="payload">json object</param>
    public interface IUnitCommitment
    {
        public List<PowerProduced> CalculateUnitCommitment(dynamic payload);
    }
}
