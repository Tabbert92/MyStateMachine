using System;

namespace MyStateMachine
{
    public class SwitchStateAction : Action
    {
        private State resultState;

        public SwitchStateAction(State resultState)
        {
            this.resultState = resultState;
        }
        public override void Execute() //тут можно реализовать дополнительную логику переключения машины, предполагается что она будет что-то делать а не только в консоль печатать
        {
            SwitchState();
        }

        protected void SwitchState()
        {
            StateMachineControl.CurrentState = resultState;
        }
    }
}
