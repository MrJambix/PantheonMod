using System;
using System.Collections.Generic;
using TimersTimer = System.Timers.Timer; // Alias for System.Timers.Timer

namespace TheAllKnowingMod
{
    public static class GameLogic
    {
        private static Dictionary<int, TimersTimer> enemyTimers = new Dictionary<int, TimersTimer>();

        public static void RegisterEnemyDeath(int enemyId)
        {
            if (enemyTimers.TryGetValue(enemyId, out TimersTimer existingTimer))
            {
                existingTimer.Stop();
                existingTimer.Dispose();
                enemyTimers.Remove(enemyId);
            }

            TimersTimer timer = new TimersTimer(15 * 60 * 1000)
            {
                AutoReset = false
            };

            timer.Elapsed += (sender, args) => TimerElapsed(enemyId);
            enemyTimers.Add(enemyId, timer);
            timer.Start();

            Console.WriteLine($"Started a 15-minute timer for enemy {enemyId}.");
        }

        private static void TimerElapsed(int enemyId)
        {
            Console.WriteLine($"Enemy {enemyId}'s 15-minute timer has elapsed.");

            if (enemyTimers.TryGetValue(enemyId, out TimersTimer timer))
            {
                timer.Stop();
                timer.Dispose();
                enemyTimers.Remove(enemyId);
            }
        }
    }
}
