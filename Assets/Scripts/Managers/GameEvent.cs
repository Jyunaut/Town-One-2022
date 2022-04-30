public static class GameEvent
{
    public delegate void GameStart();
    public static event GameStart OnGameStart;
    public static void StartGame() => OnGameStart?.Invoke();

    public delegate void GameLose();
    public static event GameLose OnGameLose;
    public static void LoseGame() => OnGameLose?.Invoke();

    public delegate void GameWin();
    public static event GameWin OnGameWin;
    public static void WinGame() => OnGameWin?.Invoke();
}
