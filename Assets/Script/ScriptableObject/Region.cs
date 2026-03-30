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

    [Header("Enemy Small Settings")]
    [ValidateInput("IsEnemySmall", "Enemy jenis ini wajib menggunakan enemy type SMALL")] [Expandable] public Enemy regionEnemySmall;
    [Min(0)] public int regionEnemySmallQty;

    [Header("Enemy Medium Settings")]
    [ValidateInput("IsEnemyMedium", "Enemy jenis ini wajib menggunakan enemy type MEDIUM")] [Expandable] public Enemy regionEnemyMedium;
    [Min(0)] public int regionEnemyMediumQty;

    [Header("Enemy Big Settings")] 
    [ValidateInput("IsEnemyBig", "Enemy jenis ini wajib menggunakan enemy type BIG")] [Expandable] public Enemy regionEnemyBig;
    [Min(0)] public int regionEnemyBigQty;

    [Header("CheckPoints")]
    public List<CheckPoints> regionCheckPoints;

    private bool IsEnemySmall(Enemy enemy)
    {
        if (enemy == null) return true;
        return enemy.enemyType == EnemyType.SMALL;
    }
    private bool IsEnemyMedium(Enemy enemy)
    {
        if (enemy == null) return true;
        return enemy.enemyType == EnemyType.MEDIUM;
    }
    private bool IsEnemyBig(Enemy enemy)
    {
        if (enemy == null) return true;
        return enemy.enemyType == EnemyType.BIG;
    }
}
