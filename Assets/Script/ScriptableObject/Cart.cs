using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cart", menuName = "Cart")]
public class Cart : ScriptableObject
{
    [Header("General")]
    public string cartName;
    public GameObject cartPrefab;
    [TextArea(3, 10)] public string cartDescription;

    [Header("Cart General Stats")]
    public float cartDeceleration = 0.25f;
    public float cartBreakingDisctance = 1.5f;

    [Header("Cart Evolution Stats")]
    public List<CartEvolution> cartEvolutions;
}

[Serializable]
public class CartEvolution
{
    public int cartHealth;
    public float cartMaxSpeed;
    public float cartAcceleration;
    public int cartReparation;
    public float cartPrice;
}