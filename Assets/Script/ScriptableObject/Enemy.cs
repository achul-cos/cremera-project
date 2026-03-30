using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    [Header("General")]
    [Tooltip("enemyName adalah nama dari Enemy")] public string enemyName;
    [Tooltip("enemyType adalah tipe dari Enemy berdasarkan ukuran antara lain: SMALL, MEDIUM, BIG")] public EnemyType enemyType;
    [Tooltip("attackType adalah tipe dari Enemy berdasarkan cara dia menyerang Cart, antara lain: MELEE, RANGE")] public AttackType attackType;

    [Header("Stats")]
    [Tooltip("enemyHealthPoint yaitu jumlah total nilai serangan Weapon (weaponAttackPoint) yang dapat diterima oleh Enemy sebelum mati.")] [Min(0)] public int enemyHealthPoint;
    [Tooltip("enemyMovementSpeed yaitu jarak tempuh Enemy saat bergerak per detik.")] [Min(0f)] public float enemyMovementSpeed;
    [Tooltip("enemyAttackPoint yaitu jumlah pengurangan playerHealthPoint jika serangan Enemy terkena cart.")] [Min(0)] public int enemyAttackPoint;
    [Tooltip("enemyAttackSpeed yaitu jeda serangan Enemy terhadap cart sekarang dengan serangan selanjutnya.")] [Min(0f)] public float enemyAttackSpeed;
    [Tooltip("enemyGold yaitu jumlah penambahan playerGold yang didapatkan Player jika berhasil membunuh musuh.")] [Min(0)] public int enemyGold;

    [Header("Prefabs")]
    [Tooltip("enemyPrefab adalah objek visual dari Enemy")] public GameObject enemyPrefab;

    [Tooltip("enemyAttackArea pada musuh tipe MELEE, yaitu sebagai jarak minimal Enemy terhadap Cart untuk dapat menyerang Cart.")] [ShowIf("attackType", AttackType.MELEE)] [Header("Melee Stats")] [Min(0.1f)] public float enemyAttackArea;

    [Tooltip("enemyAttackRange pada musuh tipe RANGE, yaitu sebagai jarak maksimal Enemy terhadap Cart untuk dapat menyerang dan dapat terus menyerang Cart.")] [ShowIf("attackType", AttackType.RANGE)][Header("Range Stats")] [Min(0.1f)] public float enemyAttackRange;
    [Tooltip("enemyDisctanceAttacking pada musuh tipe RANGE, yaitu sebagai batas jarak Enemy terhadap Cart ketika Enemy mengejar cart dan memulai menyerang Cart.")] [ShowIf("attackType", AttackType.RANGE)] [Min(0.1f)] [ValidateInput("IsSmallerThanEnemyAttackRange", "Nilai enemyDisctanceAttacking tidak boleh lebih besar dari nilai enemyAttackRange")] public float enemyDisctanceAttacking;
    [Tooltip("projectilePrefab pada musuh tipe RANGE, yaitu sebagai objek visual dari serangan Projektil.")] [ShowIf("attackType", AttackType.RANGE)] public GameObject enemyProjectilePrefab;
    [Tooltip("projectileSpeed pada musuh tipe RANGE, yaitu sebagai nilai kecepatan Projektil untuk bergerak dari titik Enemy menuju Cart untuk menyerang Cart.")] [ShowIf("attackType", AttackType.RANGE)] [Min(0.1f)] public float enemyProjectileSpeed;
    [Tooltip("projectileDistanceCancel pada musuh tipe RANGE, yaitu sebagai batas jarak Projektil terhadap Cart untuk membatalkan serangan projektil.")][ShowIf("attackType", AttackType.RANGE)] [Min(0.1f)] [ValidateInput("IsGreaterThanEnemyAttackRange", "Nilai projectileDistanceCancel tidak boleh lebih kecil dari nilai enemyAttackRange")] public float enemyProjectileDistanceCancel;

    private bool IsSmallerThanEnemyAttackRange(float e)
    {
        if (e == 0) return true;
        return e < this.enemyAttackRange;
    }
    private bool IsGreaterThanEnemyAttackRange(float e)
    {
        if (e == 0) return true;
        return e > this.enemyAttackRange;
    }
}
