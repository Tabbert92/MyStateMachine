using System.Collections.Generic;
using MyStateMachine.Actions;

namespace MyStateMachine
{
    public static class StateMachineConfiguration
    {
        public static void StateMachineStartupConfiguration(List<State> listOfStates)
        {
            {
                var offlineState = new State
                {
                    Description = "Machine is off"
                };
                listOfStates.Add(offlineState);

                var onlineState = new State
                {
                    Description = "Machine is on and waiting to be launched"
                };
                listOfStates.Add(onlineState);

                var workingOnPower50State = new State
                {
                    Description = "Machine is working on 50% power"
                };
                listOfStates.Add(workingOnPower50State);

                var workingOnPower10State = new State
                {
                    Description = "Machine is working on 10% power"
                };
                listOfStates.Add(workingOnPower10State);

                var workingOnPower100State = new State
                {
                    Description = "Machine is working on 100% power"
                };
                listOfStates.Add(workingOnPower100State);

                StateMachineControl.CurrentState = offlineState;

                var turnOnAction = new SwitchStateAction(onlineState)
                {
                    Command = "turn on",
                    Description = "\"turn on\" for turning machine on"
                };

                var turnOffAction = new SwitchStateAction(offlineState)
                {
                    Command = "turn off",
                    Description = "\"turn off\" for turning machine off"
                };

                var launchMachineAction = new SwitchStateAction(workingOnPower50State)
                {
                    Command = "launch machine",
                    Description = "\"launch machine\" for launching machine"
                };

                var shutdownAction = new SwitchStateAction(onlineState)
                {
                    Command = "shutdown",
                    Description = "\"shutdown\" for shutdown machine and switching to waiting state"
                };

                var switchFrom10To50Action = new SwitchStateAction(workingOnPower50State)
                {
                    Command = "switch to 50%",
                    Description = "\"switch to 50%\" for switching power to 50%"
                };

                var switchFrom50To10Action = new SwitchStateAction(workingOnPower10State)
                {
                    Command = "switch to 10%",
                    Description = "\"switch to 10%\" for switching power to 10%"
                };

                var switchFrom50To100Action = new SwitchStateAction(workingOnPower100State)
                {
                    Command = "switch to 100%",
                    Description = "\"switch to 100%\" for switching power to 100%"
                };

                var switchFrom100To50Action = new SwitchStateAction(workingOnPower50State)
                {
                    Command = "switch to 50%",
                    Description = "\"switch to 50%\" for switching power to 50%"
                };

                var exitAction = new ExitAction()
                {
                    Command = "exit",
                    Description = "\"exit\" for exiting app"
                };

                var diagnosticAction = new DiagnosticsAction()
                {
                    Command = "diagnostics",
                    Description = "\"diagnostics\" for starting diagnostics"
                };

                offlineState.AvalibalActions.Add(turnOnAction);
                offlineState.AvalibalActions.Add(diagnosticAction);
                offlineState.AvalibalActions.Add(exitAction);

                onlineState.AvalibalActions.Add(launchMachineAction);
                onlineState.AvalibalActions.Add(turnOffAction);
                onlineState.AvalibalActions.Add(diagnosticAction);

                workingOnPower50State.AvalibalActions.Add(switchFrom50To100Action);
                workingOnPower50State.AvalibalActions.Add(switchFrom50To10Action);
                workingOnPower50State.AvalibalActions.Add(diagnosticAction);
                workingOnPower50State.AvalibalActions.Add(shutdownAction);

                workingOnPower10State.AvalibalActions.Add(switchFrom10To50Action);
                workingOnPower10State.AvalibalActions.Add(diagnosticAction);
                workingOnPower10State.AvalibalActions.Add(shutdownAction);

                workingOnPower100State.AvalibalActions.Add(switchFrom100To50Action);
                workingOnPower100State.AvalibalActions.Add(diagnosticAction);
                workingOnPower100State.AvalibalActions.Add(shutdownAction);
            }
        }
    }
}
