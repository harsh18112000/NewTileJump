using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum GameState
{
    MainMenu,
    GamePlay,
    Over,
}

public class StatManager : MonoBehaviour
{
    public GameState gameState = GameState.MainMenu;


    public Action GameMainMenu;
    public Action GamePlay;
    public Action GameOver;
}
