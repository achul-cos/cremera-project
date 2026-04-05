using NaughtyAttributes;
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    [Header("General")]
    [Tooltip("Nama dari senjata")] public string weaponName;
    [Tooltip("Deskripsi atau cerita latar belakang senjata")][TextArea(3, 10)] public string weaponDescription;
    [Space]
    [Tooltip("Tipe dari senjata:\n\nAREA : Senjata jarak dekat yang memberikan serangan dengan area seluas radius dari senjata.\n\nPROJECTILE : Senjata jarak jauh yang memberikan serangan pada musuh berupa objek yang dilemparkan dengan jarak jangkauan yang cukup luas.")]
    public WeaponType weaponType;

    [Header("Weapon Stats")]
    [Tooltip("Nilai peluang sebuah serangan menjadi serangan critical (ditingkatkan)")][Range(0f, 1f)] public float weaponCriticalChance;
    [Min(1.0f)][Tooltip("Nilai pengkali atau peningkat pada serangan critical")] public float weaponCriticalDamage;

    [Header("Idle Mode")]
    [Tooltip("Jumlah nilai pengurangan healthPoint yang diterima oleh musuh saat terkena serangan, dan pada mode Idle")][Min(1)] public int weaponIdleAttackPoint;
    [Tooltip("Waktu jeda senjata untuk melakukan serangan selanjutnya, dan pada mode Idle.")][Min(0.1f)] public float weaponIdleCooldown;
    [Tooltip("Panjang jari-jari radius area serangan senjata bertipe Area, pada mode Idle.")][Min(0.1f)][ShowIf("weaponType", WeaponType.AREA)] public float weaponIdleAttackArea;
    [Tooltip("Panjang jari-jari radius area projektil yang mengenai musuh, pada mode Idle.")][Min(0.1f)][ShowIf("weaponType", WeaponType.PROJECTILE)] public float weaponIdleProjectileRange;
    [Tooltip("Panjang jari-jari radius area jangkauan senjata untuk melucuti seranganya pada musuh yang berada didalam area, pada mode Idle.")][Min(0.1f)][ShowIf("weaponType", WeaponType.PROJECTILE)] public float weaponIdleAttackRange;

    [Header("Manual Mode")]
    [Tooltip("Jumlah nilai pengurangan healthPoint yang diterima oleh musuh saat terkena serangan, dan pada mode Manual")][Min(1)] public int weaponManualAttackPoint;
    [Tooltip("Waktu jeda senjata untuk melakukan serangan selanjutnya, dan pada mode Manual.")][Min(0.1f)] public float weaponManualCooldown;
    [Tooltip("Panjang jari-jari radius area serangan senjata bertipe Area, pada mode Manual.")][Min(0.1f)][ShowIf("weaponType", WeaponType.AREA)] public float weaponManualAttackArea;
    [Tooltip("Panjang jari-jari radius area projektil yang mengenai musuh, pada mode Manual.")][Min(0.1f)][ShowIf("weaponType", WeaponType.PROJECTILE)] public float weaponManualProjectileRange;
    [Tooltip("Panjang jari-jari radius area jangkauan senjata untuk melucuti seranganya pada musuh yang berada didalam area, pada mode Manual.")][Min(0.1f)][ShowIf("weaponType", WeaponType.PROJECTILE)] public float weaponManualAttackRange;

    [ShowIf("weaponType", WeaponType.AREA)]
    [Header("Max Weapon Area Buff")][ReadOnly] public float weaponAreaMaxDamageBuff = 2.0f;
    [ShowIf("weaponType", WeaponType.AREA)][ReadOnly] public float weaponAreaMaxCooldownReduction = 0.6f;
    [ShowIf("weaponType", WeaponType.AREA)][ReadOnly] public float weaponAreaMaxCriticalChance = 0.6f;
    [ShowIf("weaponType", WeaponType.AREA)][ReadOnly] public float weaponAreaMaxCriticalDamage = 3.0f;
    [ShowIf("weaponType", WeaponType.AREA)][ReadOnly] public float weaponAreaMaxAttackAreaBuff = 1.0f;

    [ShowIf("weaponType", WeaponType.PROJECTILE)]
    [Header("Max Weapon Projectile Buff")][ReadOnly] public float weaponProjectileMaxDamageBuff = 1.0f;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][ReadOnly] public float weaponProjectileMaxCooldownReduction = 0.8f;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][ReadOnly] public float weaponProjectileMaxCriticalChance = 0.8f;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][ReadOnly] public float weaponProjectileMaxCriticalDamage = 2.0f;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][ReadOnly] public float weaponProjectileMaxAttackRangeBuff = 2.0f;
    [ShowIf("weaponType", WeaponType.PROJECTILE)][ReadOnly] public float weaponProjectileMaxProjectileRangeBuff = 1.75f;

    //---------------------------------------------------------------------------------------------------------------------//

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
    [ShowIf("weaponType", WeaponType.PROJECTILE)] public GameObject weaponProjectilePrefab;

    private void OnValidate()
    {
        WeaponUpgradeValidate();
    }

    private void WeaponUpgradeValidate()
    {
        if (weaponUpgrade == null) return;
        // Validasi dan Pembatasan Nilai dari nilai buff senjata pada upgrade level senjata
        foreach (var (upgrade, i) in weaponUpgrade.Select((value, index) => (value, index)))
        {
            if (upgrade != null)
            {
                // Pembatasan, Nilai buff senjata pada level selanjutnya tidak boleh lebih kecil dari level sebelumnya. Kan namanya upgrade yakk kok malah bisa turun atribut senjata
                if (i > 0)
                {
                    WeaponUpgrade previousLevel = weaponUpgrade[i - 1];

                    upgrade.weaponUpgradeRegionLock = Mathf.Max(upgrade.weaponUpgradeRegionLock, previousLevel.weaponUpgradeRegionLock);

                    // Jika level sebelumnya memiliki upgrade elemen I atau elemen I dan elemen II, maka level selanjutnya juga harus memiliki upgrade elemen I atau elemen I dan elemen II
                    if (previousLevel.weaponUpgradeElementI == true) upgrade.weaponUpgradeElementI = true;
                    if (previousLevel.weaponUpgradeElementII == true) upgrade.weaponUpgradeElementII = true;

                    if (upgrade.weaponUpgradeElementI == false) upgrade.weaponUpgradeElementII = false;

                    // Validasi bahwa nilai damage buff scale pada level selanjutnya tidak boleh lebih kecil dari level sebelumnya, jika lebih besar maka tambahkan atribut upgrade pada list atribut upgrade senjata, jika tidak maka hapus atribut upgrade pada list atribut upgrade senjata
                    upgrade.weaponDamageBuffScale = Mathf.Max(upgrade.weaponDamageBuffScale, previousLevel.weaponDamageBuffScale);
                    if (upgrade.weaponDamageBuffScale > previousLevel.weaponDamageBuffScale) 
                    {
                        if (!upgrade.weaponUpgradeAttributes.Contains(WeaponUpgradeAttributes.ATTACK_POINT)) upgrade.weaponUpgradeAttributes.Add(WeaponUpgradeAttributes.ATTACK_POINT);
                    }
                    else 
                    { 
                        upgrade.weaponUpgradeAttributes.Remove(WeaponUpgradeAttributes.ATTACK_POINT); 
                    }

                    // Validasi bahwa nilai cooldown reduction scale pada level selanjutnya tidak boleh lebih kecil dari level sebelumnya, jika lebih besar maka tambahkan atribut upgrade pada list atribut upgrade senjata, jika tidak maka hapus atribut upgrade pada list atribut upgrade senjata
                    upgrade.weaponCooldownReductionScale = Mathf.Max(upgrade.weaponCooldownReductionScale, previousLevel.weaponCooldownReductionScale);
                    if (upgrade.weaponCooldownReductionScale > previousLevel.weaponCooldownReductionScale)
                    {
                        if (!upgrade.weaponUpgradeAttributes.Contains(WeaponUpgradeAttributes.COOLDOWN)) upgrade.weaponUpgradeAttributes.Add(WeaponUpgradeAttributes.COOLDOWN);
                    }
                    else
                    {
                        upgrade.weaponUpgradeAttributes.Remove(WeaponUpgradeAttributes.COOLDOWN);
                    }

                    // Validasi bahwa nilai critical chance buff scale pada level selanjutnya tidak boleh lebih kecil dari level sebelumnya, jika lebih besar maka tambahkan atribut upgrade pada list atribut upgrade senjata, jika tidak maka hapus atribut upgrade pada list atribut upgrade senjata
                    upgrade.WeaponCriticalChanceBuffScale = Mathf.Max(upgrade.WeaponCriticalChanceBuffScale, previousLevel.WeaponCriticalChanceBuffScale);
                    if (upgrade.WeaponCriticalChanceBuffScale > previousLevel.WeaponCriticalChanceBuffScale)
                    {
                        if (!upgrade.weaponUpgradeAttributes.Contains(WeaponUpgradeAttributes.CRITICAL_CHANCE)) upgrade.weaponUpgradeAttributes.Add(WeaponUpgradeAttributes.CRITICAL_CHANCE);
                    }
                    else
                    {
                        upgrade.weaponUpgradeAttributes.Remove(WeaponUpgradeAttributes.CRITICAL_CHANCE);
                    }

                    // Validasi bahwa nilai critical damage buff scale pada level selanjutnya tidak boleh lebih kecil dari level sebelumnya, jika lebih besar maka tambahkan atribut upgrade pada list atribut upgrade senjata, jika tidak maka hapus atribut upgrade pada list atribut upgrade senjata
                    upgrade.WeaponCriticalDamageBuffScale = Mathf.Max(upgrade.WeaponCriticalDamageBuffScale, previousLevel.WeaponCriticalDamageBuffScale);
                    if (upgrade.WeaponCriticalDamageBuffScale > previousLevel.WeaponCriticalDamageBuffScale)
                    {
                        if (!upgrade.weaponUpgradeAttributes.Contains(WeaponUpgradeAttributes.CRITICAL_DAMAGE)) upgrade.weaponUpgradeAttributes.Add(WeaponUpgradeAttributes.CRITICAL_DAMAGE);
                    }
                    else
                    {
                        upgrade.weaponUpgradeAttributes.Remove(WeaponUpgradeAttributes.CRITICAL_DAMAGE);
                    }

                    if (weaponType == WeaponType.AREA)
                    {
                        // Validasi bahwa nilai attack area buff scale pada level selanjutnya tidak boleh lebih kecil dari level sebelumnya, jika lebih besar maka tambahkan atribut upgrade pada list atribut upgrade senjata, jika tidak maka hapus atribut upgrade pada list atribut upgrade senjata
                        upgrade.weaponAttackAreaBuffScale = Mathf.Max(upgrade.weaponAttackAreaBuffScale, previousLevel.weaponAttackAreaBuffScale);
                        if (upgrade.weaponAttackAreaBuffScale > previousLevel.weaponAttackAreaBuffScale)
                        {
                            if (!upgrade.weaponUpgradeAttributes.Contains(WeaponUpgradeAttributes.ATTACK_AREA)) upgrade.weaponUpgradeAttributes.Add(WeaponUpgradeAttributes.ATTACK_AREA);
                        }
                        else
                        {
                            upgrade.weaponUpgradeAttributes.Remove(WeaponUpgradeAttributes.ATTACK_AREA);
                        }
                    }
                    else if (weaponType == WeaponType.PROJECTILE)
                    {
                        // Validasi bahwa nilai projectile range buff scale pada level selanjutnya tidak boleh lebih kecil dari level sebelumnya, jika lebih besar maka tambahkan atribut upgrade pada list atribut upgrade senjata, jika tidak maka hapus atribut upgrade pada list atribut upgrade senjata
                        upgrade.weaponProjectileRangeBuffScale = Mathf.Max(upgrade.weaponProjectileRangeBuffScale, previousLevel.weaponProjectileRangeBuffScale);
                        if (upgrade.weaponProjectileRangeBuffScale > previousLevel.weaponProjectileRangeBuffScale)
                        {
                            if (!upgrade.weaponUpgradeAttributes.Contains(WeaponUpgradeAttributes.PROJECTILE_RANGE)) upgrade.weaponUpgradeAttributes.Add(WeaponUpgradeAttributes.PROJECTILE_RANGE);
                        }
                        else
                        {
                            upgrade.weaponUpgradeAttributes.Remove(WeaponUpgradeAttributes.PROJECTILE_RANGE);
                        }

                        // Validasi bahwa nilai attack range buff scale pada level selanjutnya tidak boleh lebih kecil dari level sebelumnya, jika lebih besar maka tambahkan atribut upgrade pada list atribut upgrade senjata, jika tidak maka hapus atribut upgrade pada list atribut upgrade senjata
                        upgrade.weaponAttackRangeBuffScale = Mathf.Max(upgrade.weaponAttackRangeBuffScale, previousLevel.weaponAttackRangeBuffScale);
                        if (upgrade.weaponAttackRangeBuffScale > previousLevel.weaponAttackRangeBuffScale)
                        {
                            if (!upgrade.weaponUpgradeAttributes.Contains(WeaponUpgradeAttributes.ATTACK_RANGE)) upgrade.weaponUpgradeAttributes.Add(WeaponUpgradeAttributes.ATTACK_RANGE);
                        }
                        else
                        {
                            upgrade.weaponUpgradeAttributes.Remove(WeaponUpgradeAttributes.ATTACK_RANGE);
                        }
                    }
                }
                // Deklarasi, nilai buff pada level 0 bernilai 0
                else if (i == 0)
                {
                    upgrade.weaponDamageBuffScale = 0f;
                    upgrade.weaponCooldownReductionScale = 0f;
                    upgrade.WeaponCriticalChanceBuffScale = 0f;
                    upgrade.WeaponCriticalDamageBuffScale = 0f;
                    upgrade.weaponAttackAreaBuffScale = 0f;
                    upgrade.weaponProjectileRangeBuffScale = 0f;
                    upgrade.weaponAttackRangeBuffScale = 0f;
                    upgrade.weaponUpgradeRegionLock = 0;
                    upgrade.weaponUpgradeElementI = false;
                    upgrade.weaponUpgradeElementII = false;
                }

                upgrade.weaponUpgradeName = "Level " + i;
                upgrade.weaponType = weaponType;

                // ------- Weapon Area -------//
                if (weaponType == WeaponType.AREA)
                {
                    //------- Damage Buff -------//
                    if (upgrade.weaponDamageBuffScale < 0) upgrade.weaponDamageBuffScale = 0;
                    if (upgrade.weaponDamageBuffScale > 1.0f) upgrade.weaponDamageBuffScale = 1.0f;
                    upgrade.weaponDamageBuffPreview = weaponAreaNormalDamageBuff * upgrade.weaponDamageBuffScale;
                    upgrade.weaponIdleAttackPointBuffPreview = weaponIdleAttackPoint + Mathf.RoundToInt(weaponIdleAttackPoint * upgrade.weaponDamageBuffPreview);
                    upgrade.weaponManualAttackPointBuffPreview = weaponManualAttackPoint + Mathf.RoundToInt(weaponManualAttackPoint * upgrade.weaponDamageBuffPreview);

                    //------- Cooldown Reduction -------//
                    if (upgrade.weaponCooldownReductionScale < 0) upgrade.weaponCooldownReductionScale = 0;
                    if (upgrade.weaponCooldownReductionScale > 1.0f) upgrade.weaponCooldownReductionScale = 1.0f;
                    upgrade.weaponCooldownReductionPreview = weaponAreaNormalCooldownReduction * upgrade.weaponCooldownReductionScale;
                    upgrade.weaponIdleCooldownBuffPreview = weaponIdleCooldown - (weaponIdleCooldown * upgrade.weaponCooldownReductionPreview);
                    upgrade.weaponManualCooldownBuffPreview = weaponManualCooldown - (weaponManualCooldown * upgrade.weaponCooldownReductionPreview);

                    // ------- Critical Chance Buff -------//
                    if (upgrade.WeaponCriticalChanceBuffScale < 0) upgrade.WeaponCriticalChanceBuffScale = 0;
                    if (upgrade.WeaponCriticalChanceBuffScale > 1.0f) upgrade.WeaponCriticalChanceBuffScale = 1.0f;
                    upgrade.WeaponCriticalChanceBuffPreview = weaponAreaNormalCriticalChance * upgrade.WeaponCriticalChanceBuffScale;
                    upgrade.weaponCriticalChancePreview = weaponCriticalChance + upgrade.WeaponCriticalChanceBuffPreview;
                    if (upgrade.weaponCriticalChancePreview > 1.0f) upgrade.weaponCriticalChancePreview = 1.0f;

                    // ------- Critical Damage Buff -------//
                    if (upgrade.WeaponCriticalDamageBuffScale < 0) upgrade.WeaponCriticalDamageBuffScale = 0;
                    if (upgrade.WeaponCriticalDamageBuffScale > 1.0f) upgrade.WeaponCriticalDamageBuffScale = 1.0f;
                    upgrade.WeaponCriticalDamageBuffPreview = weaponAreaNormalCriticalDamage * upgrade.WeaponCriticalDamageBuffScale;
                    upgrade.weaponCriticalDamagePreview = weaponCriticalDamage + upgrade.WeaponCriticalDamageBuffPreview;
                    upgrade.weaponIdleAttackCriticalPointPreview = Mathf.RoundToInt(upgrade.weaponIdleAttackPointBuffPreview * upgrade.weaponCriticalDamagePreview);
                    upgrade.weaponManualAttackCriticalPointPreview = Mathf.RoundToInt(upgrade.weaponManualAttackPointBuffPreview * upgrade.weaponCriticalDamagePreview);

                    // ------- Attack Area Buff -------//
                    if (upgrade.weaponAttackAreaBuffScale < 0) upgrade.weaponAttackAreaBuffScale = 0;
                    if (upgrade.weaponAttackAreaBuffScale > 1.0f) upgrade.weaponAttackAreaBuffScale = 1.0f;
                    upgrade.weaponAttackAreaBuffPreview = weaponAreaNormalAttackAreaBuff * upgrade.weaponAttackAreaBuffScale;
                    upgrade.weaponIdleAttackAreaBuffPreview = weaponIdleAttackArea + (weaponIdleAttackArea * upgrade.weaponAttackAreaBuffPreview);
                    upgrade.weaponManualAttackAreaBuffPreview = weaponManualAttackArea + (weaponManualAttackArea * upgrade.weaponAttackAreaBuffPreview);

                    // ------- Projectile Range Buff -------//
                    upgrade.weaponProjectileRangeBuffScale = 0;
                    upgrade.weaponProjectileRangeBuffPreview = 0;
                    upgrade.weaponIdleProjectileRangeBuffPreview = 0;
                    upgrade.weaponManualProjectileRangeBuffPreview = 0;

                    // ------- Attack Range Buff -------//
                    upgrade.weaponAttackRangeBuffScale = 0;
                    upgrade.weaponAttackRangeBuffPreview = 0;
                    upgrade.weaponIdleAttackRangeBuffPreview = 0;
                    upgrade.weaponManualAttackRangeBuffPreview = 0;
                }
                else if (weaponType == WeaponType.PROJECTILE)
                {
                    //------- Damage Buff -------//
                    if (upgrade.weaponDamageBuffScale < 0) upgrade.weaponDamageBuffScale = 0;
                    if (upgrade.weaponDamageBuffScale > 1.0f) upgrade.weaponDamageBuffScale = 1.0f;
                    upgrade.weaponDamageBuffPreview = weaponProjectileNormalDamageBuff * upgrade.weaponDamageBuffScale;
                    upgrade.weaponIdleAttackPointBuffPreview = weaponIdleAttackPoint + Mathf.RoundToInt(weaponIdleAttackPoint * upgrade.weaponDamageBuffPreview);
                    upgrade.weaponManualAttackPointBuffPreview = weaponManualAttackPoint + Mathf.RoundToInt(weaponManualAttackPoint * upgrade.weaponDamageBuffPreview);

                    //------- Cooldown Reduction -------//
                    if (upgrade.weaponCooldownReductionScale < 0) upgrade.weaponCooldownReductionScale = 0;
                    if (upgrade.weaponCooldownReductionScale > 1.0f) upgrade.weaponCooldownReductionScale = 1.0f;
                    upgrade.weaponCooldownReductionPreview = weaponProjectileNormalCooldownReduction * upgrade.weaponCooldownReductionScale;
                    upgrade.weaponIdleCooldownBuffPreview = weaponIdleCooldown - (weaponIdleCooldown * upgrade.weaponCooldownReductionPreview);
                    upgrade.weaponManualCooldownBuffPreview = weaponManualCooldown - (weaponManualCooldown * upgrade.weaponCooldownReductionPreview);

                    // ------- Critical Chance Buff -------//
                    if (upgrade.WeaponCriticalChanceBuffScale < 0) upgrade.WeaponCriticalChanceBuffScale = 0;
                    if (upgrade.WeaponCriticalChanceBuffScale > 1.0f) upgrade.WeaponCriticalChanceBuffScale = 1.0f;
                    upgrade.WeaponCriticalChanceBuffPreview = weaponProjectileNormalCriticalChance * upgrade.WeaponCriticalChanceBuffScale;
                    upgrade.weaponCriticalChancePreview = weaponCriticalChance + upgrade.WeaponCriticalChanceBuffPreview;
                    if (upgrade.weaponCriticalChancePreview > 1.0f) upgrade.weaponCriticalChancePreview = 1.0f;

                    // ------- Critical Damage Buff -------//
                    if (upgrade.WeaponCriticalDamageBuffScale < 0) upgrade.WeaponCriticalDamageBuffScale = 0;
                    if (upgrade.WeaponCriticalDamageBuffScale > 1.0f) upgrade.WeaponCriticalDamageBuffScale = 1.0f;
                    upgrade.WeaponCriticalDamageBuffPreview = weaponProjectileNormalCriticalDamage * upgrade.WeaponCriticalDamageBuffScale;
                    upgrade.weaponCriticalDamagePreview = weaponCriticalDamage + upgrade.WeaponCriticalDamageBuffPreview;
                    upgrade.weaponIdleAttackCriticalPointPreview = Mathf.RoundToInt(upgrade.weaponIdleAttackPointBuffPreview * upgrade.weaponCriticalDamagePreview);
                    upgrade.weaponManualAttackCriticalPointPreview = Mathf.RoundToInt(upgrade.weaponManualAttackPointBuffPreview * upgrade.weaponCriticalDamagePreview);

                    // ------- Attack Area Buff -------//
                    upgrade.weaponAttackAreaBuffScale = 0;
                    upgrade.weaponAttackAreaBuffPreview = 0;
                    upgrade.weaponIdleAttackAreaBuffPreview = 0;
                    upgrade.weaponManualAttackAreaBuffPreview = 0;

                    // ------- Projectile Range Buff -------//
                    if (upgrade.weaponProjectileRangeBuffScale < 0) upgrade.weaponProjectileRangeBuffScale = 0;
                    if (upgrade.weaponProjectileRangeBuffScale > 1.0f) upgrade.weaponProjectileRangeBuffScale = 1.0f;
                    upgrade.weaponProjectileRangeBuffPreview = weaponProjectileNormalProjectileRangeBuff * upgrade.weaponProjectileRangeBuffScale;
                    upgrade.weaponIdleProjectileRangeBuffPreview = weaponIdleProjectileRange + (weaponIdleProjectileRange * upgrade.weaponProjectileRangeBuffPreview);
                    upgrade.weaponManualProjectileRangeBuffPreview = weaponManualProjectileRange + (weaponManualProjectileRange * upgrade.weaponProjectileRangeBuffPreview);

                    // ------- Attack Range Buff -------//
                    if (upgrade.weaponAttackRangeBuffScale < 0) upgrade.weaponAttackRangeBuffScale = 0;
                    if (upgrade.weaponAttackRangeBuffScale > 1.0f) upgrade.weaponAttackRangeBuffScale = 1.0f;
                    upgrade.weaponAttackRangeBuffPreview = weaponProjectileNormalAttackRangeBuff * upgrade.weaponAttackRangeBuffScale;
                    upgrade.weaponIdleAttackRangeBuffPreview = weaponIdleAttackRange + (weaponIdleAttackRange * upgrade.weaponAttackRangeBuffPreview);
                    upgrade.weaponManualAttackRangeBuffPreview = weaponManualAttackRange + (weaponManualAttackRange * upgrade.weaponAttackRangeBuffPreview);
                }
            }
        }
    }
}
