using NaughtyAttributes;
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

    [Header("Prefabs")]
    [Tooltip("Objek atau sprite dari senjata")] public GameObject weaponPrefab;
}
