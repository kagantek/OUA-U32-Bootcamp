using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleZone : MonoBehaviour
{
    public MusicManager musicManager;
    public EnemyManager enemyManager;
    private bool isPlayerInZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;
            musicManager.StartBattleMusic();
            enemyManager.OnBattleZoneEntered();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
            musicManager.StopBattleMusic();
           
        }
    }

    public void CheckAndStopBattleMusic()
    {
        if (!isPlayerInZone || enemyManager.AllEnemiesDead())
        {
            musicManager.StopBattleMusic();
        }
    }
}
