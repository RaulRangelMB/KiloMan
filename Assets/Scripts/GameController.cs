using UnityEngine;

public static class GameController
{
    private static int collectableCount;
    private static int collectedCoins;
    private static bool isPlayerDead;

    public static bool gameOver
    {
        get { return isPlayerDead; }
    }

    public static bool gameWin
    {
        get { return collectableCount <= 0; }
    }

    public static void Init()
    {
        collectableCount = 4;
        collectedCoins = 0;
        isPlayerDead = false;
    }

    public static void Collect()
    {
        collectableCount--;
        collectedCoins++;
    }

    public static int GetCollectedCount() => collectedCoins;

    public static void SpawnCollectable()
    {
        collectableCount++;
    }

    public static void PlayerDied()
    {
        isPlayerDead = true;
    }
}
