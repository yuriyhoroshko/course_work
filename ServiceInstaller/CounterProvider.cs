using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ServiceInstaller
{
    public class CounterProvider
    {
        private PerformanceCounter counter;

        public List<string> GetCategoriesList(string searchPattern)
        {
            var cats = PerformanceCounterCategory.GetCategories().Select(c => c.CategoryName)
                .Concat(AddNotDiscoverableCategories()).Where(c => c.Contains(searchPattern) || string.IsNullOrEmpty(searchPattern)).ToList();

            return cats;
        }

        public List<string> GetCountersList(string category, string instance)
        {
            return new PerformanceCounterCategory(category).GetCounters(instance).Select(c => c.CounterName).ToList();
        }

        public List<string> GetInstancesList(string category)
        {
            return new PerformanceCounterCategory(category).GetInstanceNames().ToList();
        }

        public void ChooseCounter(string category, string counter, string instance)
        {
            this.counter = new PerformanceCounter(category, counter, instance);
        }

        public float GetNextCounterValue()
        {
            return counter.NextValue();
        }

        private List<string> AddNotDiscoverableCategories()
        {
            return new List<string>()
            {
                "Processor",
                "PhysicalDisk",
                "Network Interface",
                "Memory",
                "GPU Adapter Memory"
            };
        }
    }
}
