using System;
using ReplayProxy.Utilities;

namespace ReplayProxy
{
    public class BehaviourLogItem
    {
        public bool Pass { get; internal set; }
        
        public LoggedCall Call { get; internal set; }

        public object ActualReturnValue { get; internal set; }

        public override string ToString()
        {
            return String.Format("Method: '{0}'\nParams: {1}\nOutcome: {2}\nReturn Value: {3}", 
                Call.MethodName, 
                XmlSerialiser.Serialise(Call.Parameters), 
                Pass ? "Pass" : "Fail",
                Pass ? SerialiseIfNotNull(Call.ReturnValue) : "Expected: " 
                                                                     + SerialiseIfNotNull(Call.ReturnValue) + "\nActual: "
                                                                     + SerialiseIfNotNull(ActualReturnValue));
        }

        private string SerialiseIfNotNull(object returnValue)
        {
            return returnValue != null ? XmlSerialiser.Serialise(returnValue) : "null";
        }
    }
}