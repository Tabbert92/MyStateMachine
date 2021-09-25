using System;
using System.Linq;

namespace MyStateMachine
{
    public class StateMachineControl
    {
        private string _userAnswer;
        public static State CurrentState { get; set; }
        public static bool TurningOffApplicationFlag { get; set; } = false;

        public StateMachineControl()
        {
            CurrentState = StateMachineConfiguration.StateMachineStartupConfiguration();
        }

        public void RunApp()
        {
            Console.WriteLine();
            while (!TurningOffApplicationFlag)
            {
                Console.WriteLine($"Current state: {CurrentState.Description}");
                Console.WriteLine("Available commands:");
                for (var i = 0; i < CurrentState.AvalibalActions.Count; i++)
                {
                    var act = CurrentState.AvalibalActions[i];
                    Console.WriteLine($"{i + 1}. {act.Description}");
                }

                _userAnswer = Console.ReadLine();
                if (_userAnswer == null)
                    continue;
                
                _userAnswer = _userAnswer?.ToLower();
                var action = CurrentState.AvalibalActions.FirstOrDefault(x => x.Command == _userAnswer);
                if (action != null)
                    action.Execute();
                else
                    Console.WriteLine("Wrong command!");

                Console.WriteLine();
            }
        }
    }
}
