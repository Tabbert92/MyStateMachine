using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStateMachine
{
    public class StateMachineControl
    {
        
        private List<State> listOfStates;
        private string userAnswer;
        public static State CurrentState { get; set; }
        public static bool TurningOffApplicationFlag { get; set; } = false;

        public StateMachineControl()
        {
            listOfStates = new List<State>();
            StateMachineConfiguration.StateMachineStartupConfiguration(listOfStates);
        }

        public void runApp()
        {
            Console.WriteLine();
            while (!TurningOffApplicationFlag)
            {
                Console.WriteLine($"Current state: {CurrentState.Description}");
                Console.WriteLine("Available commands:");
                foreach (var act in CurrentState.AvalibalActions)
                {
                    Console.WriteLine($"{CurrentState.AvalibalActions.IndexOf(act) + 1}. {act.Description}");
                }
                userAnswer = Console.ReadLine().ToLower();
                var action = CurrentState.AvalibalActions.Find(x => x.Command == userAnswer);
                if (action != null)
                {
                    action.Execute();
                }
                else Console.WriteLine("Wrong command!");

                Console.WriteLine();
            }
        }
    }
}
