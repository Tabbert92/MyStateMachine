using System;

namespace MyStateMachine.Actions
{
    public class DiagnosticsAction : Action
    {
        public override void Execute()
        {
            Console.WriteLine($"Starting diagnostics:\n Current machine state: {StateMachineControl.CurrentState.Description}");
        }
    }
}