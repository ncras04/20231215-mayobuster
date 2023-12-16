using Helpers;

namespace GameState
{

    public static class Config
    {
        public static VoteState<EGameState> CurrentState { get; } = new VoteState<EGameState>(EGameState.PLAYING);
    }
}
