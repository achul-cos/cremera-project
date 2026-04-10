using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RegionEnemy
{
    [AllowNesting][Expandable] public Enemy enemy;
    [AllowNesting][MinValue(0f), MaxValue(1f)] public float enemySpawnChance;
    [AllowNesting][ReadOnly] public float enemySpawnChanceDistribution;
}
