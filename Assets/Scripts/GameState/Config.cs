using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameState
{

    public static class Config
    {
        public static VoteState<EGameState> CurrentState { get; } = new VoteState<EGameState>(EGameState.PLAYING);
    }
}
