using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CheckPoints
{
    [AllowNesting][HideInInspector] public string name;
    public List<RoadPoints> roadPoints;
    public List<Transform> enemySpawnPoints;
}
