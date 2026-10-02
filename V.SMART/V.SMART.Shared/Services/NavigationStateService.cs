using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.Services
{
    public class NavigationStateService
    {
        private readonly Dictionary<string, object?> _states = new();

        public void Set<T>(string key, T value)
        {
            _states[key] = value;
        }

        public T? Get<T>(string key)
        {
            if (_states.TryGetValue(key, out var value) &&
                value is T typedValue)
            {
                return typedValue;
            }

            return default;
        }

        public bool Contains(string key)
        {
            return _states.ContainsKey(key);
        }

        public void Clear(string key)
        {
            _states.Remove(key);
        }

        public void ClearAll()
        {
            _states.Clear();
        }
    }
}
