using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Main, Inv }

public class GameStateManager : MonoBehaviour
{
    // the game should start in the "main" (walk around) state
    // we will change this when opening a menu, loading, etc
    public GameState state = GameState.Main;
}
