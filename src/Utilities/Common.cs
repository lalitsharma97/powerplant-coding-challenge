using System.ComponentModel;
using System.Reflection;

namespace Powerplant_Unit_Measurement.Utilities
{
    public class Common
    {
        /// <summary>
        /// Get enum constant description 
        /// Create by: Lalit Kumar
        /// Created on : 17-Oct-23
        /// Updated by : NA
        /// Updated on : NA
        /// </summary>
        /// <param name="enumVal">enum valur to get description</param>
        public static string GetEnumDescription(Enum enumVal)
        {
            System.Reflection.MemberInfo[] memInfo = enumVal.GetType().GetMember(enumVal.ToString());
            DescriptionAttribute attribute = CustomAttributeExtensions.GetCustomAttribute<DescriptionAttribute>(memInfo[0]);
            return attribute.Description;
        }

        /// <summary>
        /// Enum to filter 
        /// Create by: Lalit Kumar
        /// Created on : 17-Oct-23
        /// Updated by : NA
        /// Updated on : NA
        /// </summary>
        public enum FuelFilter
        {
            [Description("gas (euro/MWh) gasfired")]
            gas,
            [Description("kerosine (euro/MWh)")]
            kerosine,
            [Description("co2 (euro/ton) turbojet")]
            co2,
            [Description("wind (%) windturbine")]
            wind
        }

        /// <summary>
        /// Enum to Measure 
        /// Create by: Lalit Kumar
        /// Created on : 17-Oct-23
        /// Updated by : NA
        /// Updated on : NA
        /// </summary>
        public enum FuelMeasure
        {
            [Description("gas(euro/MWh)")]
            gas,
            [Description("kerosine(euro/MWh)")]
            kerosine,
            [Description("co2(euro/ton)")]
            co2,
            [Description("wind(%)")]
            wind
        }
    }
}
