using System.Collections.Generic;

namespace MyStateMachine
{
    public class State
    {
        public string Description { get; set; }

        public List<Action> AvalibalActions { get; set; } = new List<Action>();
    }
}
