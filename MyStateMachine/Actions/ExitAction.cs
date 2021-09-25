namespace MyStateMachine.Actions
{
    public class ExitAction : Action
    {
        public override void Execute()
        {
            StateMachineControl.TurningOffApplicationFlag = true;
        }
    }
}
