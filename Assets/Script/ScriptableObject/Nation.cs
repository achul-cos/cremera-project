using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nation", menuName = "Nation")]
public class Nation : ScriptableObject
{
    [Header("General")]
    public string nationName;
    [TextArea(3, 10)] public string nationDescription;
    [Space]
    [Expandable] public List<Region> nationRegions;
    private void OnValidate()
    {
     //   
    }
}
