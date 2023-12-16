using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public class VoteState<T>
    {
        public T Value
        {
            get => value;
            set
            {
                if (this.value == null)
                    return;
                T old = this.value;
                this.value = value;

                onValueChanged?.Invoke(old, this.value);
            }
        }

        public event System.Action<T, T> OnValueChanged
        {
            add
            {
                onValueChanged -= value;
                onValueChanged += value;
            }
            remove
            {
                onValueChanged -= value;
            }
        }

        private T value = default(T);
        private T defaultValue = default(T);
        private event System.Action<T, T> onValueChanged;

        private Dictionary<T, List<string>> votes = new Dictionary<T, List<string>>();

        public VoteState(T defaultValue)
        {
            this.value = defaultValue;
            this.defaultValue = defaultValue;
        }

        public void Vote(T value, string reason)
        {
            if (!votes.ContainsKey(value))
            {
                votes.Add(value, new List<string>());
            }
            votes[value].Add(reason);
            Value = votes.OrderByDescending(o => o.Value.Count).First().Key;
        }

        public void Revoke(T value, string reason)
        {
            if (!votes.ContainsKey(value))
                return;
            votes[value].Remove(reason);
            if (votes[value].Count == 0)
            {
                votes.Remove(value);
            }
            if (votes.Count == 0)
            {
                Value = defaultValue;
            }
            else
            {
                Value = votes.OrderByDescending(o => o.Value.Count).First().Key;
            }
        }
    }
}
