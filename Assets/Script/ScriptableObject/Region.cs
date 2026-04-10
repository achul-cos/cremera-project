using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Region", menuName = "Region")]
public class Region : ScriptableObject
{
    [Header("General")]
    public string regionName;
    [TextArea(3, 10)] public string regionDescription;
    public GameObject regionPrefabs;

    [Header("Enemy Spawn General Setting")]
    [MinValue(0)] public int enemySpawnFrequency;
    [MinValue(0f)] public float enemySpawnRadius;
    [Space]

    [ValidateInput("IsRegionEnemySmall", "Tidak ada enemy yang diisi, atau enemy yang diisi bukan jenis SMALL")] public List<RegionEnemy> regionEnemySmallList;
    [Space]

    [ValidateInput("IsRegionEnemyMedium", "Tidak ada enemy yang diisi, atau enemy yang diisi bukan jenis MEDIUM")] public List<RegionEnemy> regionEnemyMediumList;
    [Space]

    [ValidateInput("IsRegionEnemyBig", "Tidak ada enemy yang diisi, atau enemy yang diisi bukan jenis BIG")] public List<RegionEnemy> regionEnemyBigList;
    [Space]

    public List<CheckPoints> regionCheckPoints;

    private bool IsRegionEnemySmall (List<RegionEnemy> list)
    {
        if (list == null || list.Count == 0) return false;
        foreach (var item in list)
        {
            if (item.enemy == null || item.enemy.enemyType != EnemyType.SMALL)  return false;
        }
        return true;
    }
    private bool IsRegionEnemyMedium (List<RegionEnemy> list)
    {
        if (list == null || list.Count == 0) return true;
        foreach (var item in list)
        {
            if (item.enemy == null || item.enemy.enemyType != EnemyType.MEDIUM) return false;
        }
        return true;
    }
    private bool IsRegionEnemyBig (List<RegionEnemy> list)
    {
        if (list == null || list.Count == 0) return true;
        foreach (var item in list)
        {
            if (item.enemy == null || item.enemy.enemyType != EnemyType.BIG) return false;
        }
        return true;
    }

    private void OnValidate()
    {
        ValidateRegionEnemySpawnValue(regionEnemySmallList);
        ValidateRegionEnemySpawnValue(regionEnemyMediumList);
        ValidateRegionEnemySpawnValue(regionEnemyBigList);
    }
    private void ValidateRegionEnemySpawnValue(List<RegionEnemy> regionEnemies)
    {
        if (regionEnemies == null || regionEnemies.Count == 0) return;
        
        float totalSpawnChance = 0f;
        foreach (var enemy in regionEnemies)
        {
            totalSpawnChance += enemy.enemySpawnChance;
        }
        foreach (var enemy in regionEnemies)
        {
            if (totalSpawnChance > 1)
            {
                enemy.enemySpawnChanceDistribution = enemy.enemySpawnChance / totalSpawnChance;
            }
            else if (totalSpawnChance < 1)
            {
                enemy.enemySpawnChanceDistribution = enemy.enemySpawnChance;
            }
            else if (totalSpawnChance == 0)
            {
                enemy.enemySpawnChanceDistribution = 0f;
            }
        }
    }
}
