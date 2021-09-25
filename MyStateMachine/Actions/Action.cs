namespace MyStateMachine.Actions
{
    public abstract class Action
    {
        public string Description { get; set; }

        public string Command { get; set; }

        public abstract void Execute();
    }
}
