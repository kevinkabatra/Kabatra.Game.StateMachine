namespace Kabatra.Game.StateMachine.UnitTests.StateMachines
{
    using Kabatra.Game.StateMachine.StateMachines;
    using Kabatra.Game.StateMachine.StateMachines.States;
    using Kabatra.Game.StateMachine.StateMachines.Triggers;
    using Moq;
    using Xunit;

    /// <summary>
    ///     Unit tests that exercise the Game State state machine.
    /// </summary>
    public class GameStateStateMachineTests : StateMachineTestAbstract
    {
        [Fact]
        public void CanCreateStateMachine()
        {
            var displayHandler = MockDisplayHandler.Object;
            const GameState gameState = GameState.None;

            var stateMachine = new StateMachineGameState(gameState, displayHandler);

            Assert.NotNull(stateMachine);
        }

        [Fact]
        public void CanTransitionStateMachineFromNoneToPlaying()
        {
            var displayHandler = MockDisplayHandler.Object;
            const GameState gameState = GameState.None;

            var stateMachine = new StateMachineGameState(gameState, displayHandler);
            stateMachine.Fire(GameStateTrigger.StartGame);

            const GameState expectedState = GameState.Playing;
            var actualState = stateMachine.State;

            Assert.Equal(expectedState, actualState);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CanTransitionStateMachineFromPayingToGameOver()
        {
            var displayHandler = MockDisplayHandler.Object;
            const GameState gameState = GameState.Playing;

            var stateMachine = new StateMachineGameState(gameState, displayHandler);
            stateMachine.Fire(GameStateTrigger.StopGame);

            const GameState expectedState = GameState.GameOver;
            var actualState = stateMachine.State;

            Assert.Equal(expectedState, actualState);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }
    }
}
