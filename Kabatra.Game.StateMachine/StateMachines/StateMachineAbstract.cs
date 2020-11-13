namespace Kabatra.Game.StateMachine.StateMachines
{
    using Kabatra.Common.LabelRetriever;
    using Kabatra.Game.StateMachine.Handlers.Displays;
    using Stateless;

    public abstract class StateMachineAbstract<TState, TTrigger> : StateMachine<TState, TTrigger>
    {
        protected internal IDisplayHandler DisplayHandler;
        protected internal LabelRetriever LabelRetriever;

        /// <summary>
        ///     Default constructor.
        /// </summary>
        /// <param name="initialState">Initial state to set the state machine to.</param>
        /// <param name="displayHandler">Handler that will display the messages from the state machine.</param>
        protected StateMachineAbstract(TState initialState, IDisplayHandler displayHandler) : base(initialState)
        {
            Initialize(displayHandler);
        }

        /// <summary>
        ///     Handles initialization for any instance variables of this class.
        /// </summary>
        /// <param name="displayHandler">The display handler to use.</param>
        private void Initialize(IDisplayHandler displayHandler)
        {
            DisplayHandler = displayHandler;
            LabelRetriever = LabelRetriever.GetLabelRetriever();
        }

        /// <summary>
        ///     Sets up the state machine.
        /// </summary>
        protected internal abstract void SetupStateMachine();
    }
}
