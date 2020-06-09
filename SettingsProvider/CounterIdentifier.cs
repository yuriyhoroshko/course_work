using System;

namespace SettingsProvider
{
    [Serializable]
    public class CounterIdentifier
    {
        public string CustomName { get; set; }

        public string Category { get; set; }

        public string Instance { get; set; }

        public string Counter { get; set; }

        public int CustomDivider { get; set; }

        public override string ToString()
        {
            return $"Category: {Category}. Counter: {Counter}. Instance: {Instance}. Name: {CustomName}. Divide by: {CustomDivider}.";
        }
    }
}
