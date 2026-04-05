using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponUpgrade
{
    [AllowNesting][HideInInspector] public string weaponUpgradeName;
    public bool weaponIslocked;

    [Header("Weapon Upgrade Aditional Information")]
    [AllowNesting][MinValue(1)] public int weaponUpgradeRegionLock; 
    [AllowNesting][HideIf("weaponIslocked")] public List<WeaponUpgradeAttributes> weaponUpgradeAttributes;

    // Weapon Information
    [AllowNesting][HideInInspector] public WeaponType weaponType;

    // Waeapon Buff Information
    [Header("Damage Buff")]
    [AllowNesting][HideIf("weaponIslocked")] public float weaponDamageBuffScale;
    [AllowNesting][HideIf("weaponIslocked")][ReadOnly] public float weaponDamageBuffPreview;

    [Header("Cooldown Reduction")]
    [AllowNesting][HideIf("weaponIslocked")] public float weaponCooldownReductionScale;
    [AllowNesting][HideIf("weaponIslocked")][ReadOnly] public float weaponCooldownReductionPreview;

    [Header("Critical Chance Buff")]
    [AllowNesting][HideIf("weaponIslocked")] public float WeaponCriticalChanceBuffScale;
    [AllowNesting][HideIf("weaponIslocked")][ReadOnly] public float WeaponCriticalChanceBuffPreview;

    [Header("Critical Damage Buff")]
    [AllowNesting][HideIf("weaponIslocked")] public float WeaponCriticalDamageBuffScale;
    [AllowNesting][HideIf("weaponIslocked")][ReadOnly] public float WeaponCriticalDamageBuffPreview;

    [AllowNesting][HideIf(EConditionOperator.Or, "weaponIslocked", "IsWeaponTypeProjectile")][Header("Attack Area Buff")] public float weaponAttackAreaBuffScale;
    [AllowNesting][HideIf(EConditionOperator.Or, "weaponIslocked", "IsWeaponTypeProjectile")][ReadOnly] public float weaponAttackAreaBuffPreview;

    [AllowNesting][HideIf(EConditionOperator.Or, "weaponIslocked", "IsWeaponTypeArea")][Header("Projectile Range Buff")] public float weaponProjectileRangeBuffScale;
    [AllowNesting][HideIf(EConditionOperator.Or, "weaponIslocked", "IsWeaponTypeArea")][ReadOnly] public float weaponProjectileRangeBuffPreview;

    [AllowNesting][HideIf(EConditionOperator.Or, "weaponIslocked", "IsWeaponTypeArea")][Header("Attack Range Buff")] public float weaponAttackRangeBuffScale;
    [AllowNesting][HideIf(EConditionOperator.Or, "weaponIslocked", "IsWeaponTypeArea")][ReadOnly] public float weaponAttackRangeBuffPreview;

    [Header("Weapon Stats Critical")]
    [AllowNesting][HideIf("weaponIslocked")][ReadOnly] public float weaponCriticalChancePreview;
    [AllowNesting][HideIf("weaponIslocked")][ReadOnly] public float weaponCriticalDamagePreview;
    [AllowNesting][HideIf("weaponIslocked")][ReadOnly] public int weaponIdleAttackCriticalPointPreview;
    [AllowNesting][HideIf("weaponIslocked")][ReadOnly] public int weaponManualAttackCriticalPointPreview;

    [Header("Weapon Stats Idle Mode")]
    [AllowNesting][HideIf("weaponIslocked")][ReadOnly] public int weaponIdleAttackPointBuffPreview;
    [AllowNesting][HideIf("weaponIslocked")][ReadOnly] public float weaponIdleCooldownBuffPreview;
    [AllowNesting][HideIf(EConditionOperator.Or, "weaponIslocked", "IsWeaponTypeProjectile")][ReadOnly] public float weaponIdleAttackAreaBuffPreview;
    [AllowNesting][HideIf(EConditionOperator.Or, "weaponIslocked", "isWeaponTypeArea")][ReadOnly] public float weaponIdleProjectileRangeBuffPreview;
    [AllowNesting][HideIf(EConditionOperator.Or, "weaponIslocked", "IsWeaponTypeArea")][ReadOnly] public float weaponIdleAttackRangeBuffPreview;

    [Header("Weapon Stats Manual Mode")]
    [AllowNesting][HideIf("weaponIslocked")][ReadOnly] public int weaponManualAttackPointBuffPreview;
    [AllowNesting][HideIf("weaponIslocked")][ReadOnly] public float weaponManualCooldownBuffPreview;
    [AllowNesting][HideIf(EConditionOperator.Or, "weaponIslocked", "IsWeaponTypeProjectile")][ReadOnly] public float weaponManualAttackAreaBuffPreview;
    [AllowNesting][HideIf(EConditionOperator.Or, "weaponIslocked", "IsWeaponTypeArea")][ReadOnly] public float weaponManualProjectileRangeBuffPreview;
    [AllowNesting][HideIf(EConditionOperator.Or, "weaponIslocked", "IsWeaponTypeArea")][ReadOnly] public float weaponManualAttackRangeBuffPreview;

    [Header("Weapon New Prefab")]
    [AllowNesting][HideIf("weaponIslocked")] public GameObject weaponUpgradeNewPrefab;
    [AllowNesting][HideIf(EConditionOperator.Or, "weaponIslocked", "IsWeaponTypeArea")] public GameObject weaponUpgradeNewProjectilePrefab;

    [Header("Weapon Price")]
    [AllowNesting][HideIf("weaponIslocked")][MinValue(1)] public int weaponUpgradeCost;
    [AllowNesting][HideIf("weaponIslocked")][MinValue(1)] public int weaponIngamePrice;

    [Header("Weapon Upgrade Element")]
    [AllowNesting][HideIf("weaponIslocked")] public bool weaponUpgradeElementI;
    [AllowNesting][HideIf(EConditionOperator.Or, "weaponIslocked", "IsWeaponUpgradeElementI")] public bool weaponUpgradeElementII;

    private bool IsWeaponTypeArea()
    {
        return weaponType == WeaponType.AREA;
    }
    private bool IsWeaponTypeProjectile()
    {
        return weaponType == WeaponType.PROJECTILE;
    }
    private bool IsWeaponUpgradeElementI()
    {
        return !weaponUpgradeElementI;
    }
}
