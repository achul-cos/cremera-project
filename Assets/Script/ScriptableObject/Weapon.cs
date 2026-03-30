using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{

    [Header("General")]
    [Tooltip("Nama dari senjata")] public string weaponName;
    [Tooltip("Deskripsi atau cerita latar belakang senjata")] [TextArea(3, 10)] public string weaponDescription;
    [Tooltip("Tipe dari senjata:\n\nAREA : Senjata jarak dekat yang memberikan serangan dengan area seluas radius dari senjata.\n\nPROJECTILE : Senjata jarak jauh yang memberikan serangan pada musuh berupa objek yang dilemparkan dengan jarak jangkauan yang cukup luas.")] 
    public WeaponType weaponType;

    [Header("Weapon Stats")]
    [Tooltip("Nilai peluang sebuah serangan menjadi serangan critical (ditingkatkan)")] [Range(0f, 1f)] public float weaponCriticalChance;
    [Min(1.0f)] [Tooltip("Nilai pengkali atau peningkat pada serangan critical")] public float weaponCriticalDamage;

    [Header("Idle Mode")]
    [Tooltip("Jumlah nilai pengurangan healthPoint yang diterima oleh musuh saat terkena serangan, dan pada mode Idle")] [Min(1)] public int weaponIdleAttackPoint;
    [Tooltip("Waktu jeda senjata untuk melakukan serangan selanjutnya, dan pada mode Idle.")] [Min(0.1f)] public float weaponIdleCooldown;
    [Tooltip("Panjang jari-jari radius area serangan senjata bertipe Area, pada mode Idle.")] [Min(0.1f)][ShowIf("weaponType", WeaponType.AREA)] public float weaponIdleAttackArea;
    [Tooltip("Panjang jari-jari radius area projektil yang mengenai musuh, pada mode Idle.")] [Min(0.1f)][ShowIf("weaponType", WeaponType.PROJECTILE)] public float weaponIdleProjectileRange;
    [Tooltip("Panjang jari-jari radius area jangkauan senjata untuk melucuti seranganya pada musuh yang berada didalam area, pada mode Idle.")] [Min(0.1f)][ShowIf("weaponType", WeaponType.PROJECTILE)] public float weaponIdleAttackRange;

    [Header("Manual Mode")]
    [Tooltip("Jumlah nilai pengurangan healthPoint yang diterima oleh musuh saat terkena serangan, dan pada mode Manual")] [Min(1)] public int weaponManualAttackPoint;
    [Tooltip("Waktu jeda senjata untuk melakukan serangan selanjutnya, dan pada mode Manual.")] [Min(0.1f)] public float weaponManualCooldown;
    [Tooltip("Panjang jari-jari radius area serangan senjata bertipe Area, pada mode Manual.")] [Min(0.1f)][ShowIf("weaponType", WeaponType.AREA)] public float weaponManualAttackArea;
    [Tooltip("Panjang jari-jari radius area projektil yang mengenai musuh, pada mode Manual.")] [Min(0.1f)][ShowIf("weaponType", WeaponType.PROJECTILE)] public float weaponManualProjectileRange;
    [Tooltip("Panjang jari-jari radius area jangkauan senjata untuk melucuti seranganya pada musuh yang berada didalam area, pada mode Manual.")] [Min(0.1f)][ShowIf("weaponType", WeaponType.PROJECTILE)] public float weaponManualAttackRange;

    [ShowIf("weaponType", WeaponType.AREA)]
    [Header("Max Weapon Area Buff")] [ReadOnly] public float weaponAreaMaxDamageBuff = 3.0f;
    [ShowIf("weaponType", WeaponType.AREA)][ReadOnly] public float weaponAreaMaxCooldownReduction = 0.6f;
    [ShowIf("weaponType", WeaponType.AREA)][ReadOnly] public float weaponAreaMaxCriticalChance = 0.6f;
    [ShowIf("weaponType", WeaponType.AREA)][ReadOnly] public float weaponAreaMaxCriticalDamage = 3.0f;
    [ShowIf("weaponType", WeaponType.AREA)][ReadOnly] public float weaponAreaMaxAttackAreaBuff = 2.0f;

    [ShowIf("weaponType", WeaponType.PROJECTILE)]
    [Header("Max Weapon Projectile Buff")][ReadOnly] public float weaponProjectileMaxDamageBuff = 2.0f;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][ReadOnly] public float weaponProjectileMaxCooldownReduction = 0.8f;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][ReadOnly] public float weaponProjectileMaxCriticalChance = 0.8f;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][ReadOnly] public float weaponProjectileMaxCriticalDamage = 2.0f;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][ReadOnly] public float weaponProjectileMaxAttackRangeBuff = 2.0f;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][ReadOnly] public float weaponProjectileMaxProjectileRangeBuff = 2.5f;

    [ShowIf("weaponType", WeaponType.AREA)]
    [Header("Normal Weapon Area Buff")][Min(0.1f)] public float weaponAreaNormalDamageBuff;
    [ShowIf("weaponType", WeaponType.AREA)][Min(0.1f)] public float weaponAreaNormalCooldownReduction;
    [ShowIf("weaponType", WeaponType.AREA)][Min(0.1f)] public float weaponAreaNormalCriticalChance;
    [ShowIf("weaponType", WeaponType.AREA)][Min(0.1f)] public float weaponAreaNormalCriticalDamage;
    [ShowIf("weaponType", WeaponType.AREA)][Min(0.1f)] public float weaponAreaNormalAttackAreaBuff;

    [ShowIf("weaponType", WeaponType.PROJECTILE)]
    [Header("Normal Weapon Projectile Buff")][Min(0.1f)] public float weaponProjectileNormalDamageBuff;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][Min(0.1f)] public float weaponProjectileNormalCooldownReduction;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][Min(0.1f)] public float weaponProjectileNormalCriticalChance;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][Min(0.1f)] public float weaponProjectileNormalCriticalDamage;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][Min(0.1f)] public float weaponProjectileNormalAttackRangeBuff;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][Min(0.1f)] public float weaponProjectileNormalProjectileRangeBuff;

    [Header("Phase Weapon Upgrade")]
    public List<WeaponUpgrade> weaponUpgrade = new List<WeaponUpgrade>();

    [Header("Prefabs")]
    [Tooltip("Objek atau sprite dari senjata")] public GameObject weaponPrefab;
}
