using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public static class GameLogic
{
    private static Dictionary<int, System.Timers.Timer> enemyTimers = new Dictionary<int, System.Timers.Timer>();

    // Our "Update" function that will be called manually from GameLogicUpdater
    public static void Update()
    {
        // Add any per-frame logic here
        Debug.Log("GameLogic Update is running!");
    }

    public static void RegisterEnemyDeath(int enemyId)
    {
        if (enemyTimers.TryGetValue(enemyId, out System.Timers.Timer existingTimer))
        {
            existingTimer.Stop();
            existingTimer.Dispose();
            enemyTimers.Remove(enemyId);
        }

        System.Timers.Timer timer = new System.Timers.Timer(15 * 60 * 1000)
        {
            AutoReset = false
        };

        timer.Elapsed += (sender, args) => TimerElapsed(enemyId);
        enemyTimers.Add(enemyId, timer);
        timer.Start();

        Debug.Log($"Started a 15-minute timer for enemy {enemyId}.");
    }

    private static void TimerElapsed(int enemyId)
    {
        Debug.Log($"Enemy {enemyId}'s 15-minute timer has elapsed.");

        if (enemyTimers.TryGetValue(enemyId, out System.Timers.Timer timer))
        {
            timer.Stop();
            timer.Dispose();
            enemyTimers.Remove(enemyId);
        }
    }
}
