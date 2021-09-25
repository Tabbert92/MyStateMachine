using System.Collections.Generic;
using MyStateMachine.Actions;

namespace MyStateMachine
{
    public class State
    {
        public string Description { get; set; }

        public List<Action> AvalibalActions { get; set; } = new ();
    }
}
