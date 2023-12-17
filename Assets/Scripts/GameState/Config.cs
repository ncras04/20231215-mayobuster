using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameState
{
    public static class Config
    {
        public static int LineSpeed { get; set; } = 10;
        public static VoteState<bool> IsCursorVisible { get; } = new VoteState<bool>(true);
    }
}
