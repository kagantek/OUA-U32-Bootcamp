using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies; // Bölgedeki düþmanlar
    public BattleZone battleZone;

    public void OnBattleZoneEntered()
    {
        StartCoroutine(CheckEnemies());
    }

    private IEnumerator CheckEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f); // 1 saniye aralýklarla kontrol et

            if (AllEnemiesDead())
            {
                battleZone.CheckAndStopBattleMusic();
                break;
            }
        }
    }

    public bool AllEnemiesDead()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                return false;
            }
        }
        return true;
    }
}
