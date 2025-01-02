using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Offer
{
    [field: SerializeField] [field: Min(0)] public int ID { get; private set; }
    [field: SerializeField] [field: Min(0)] public int Cost { get; private set; }
    [field: SerializeField] [field: Min(0)] public int Count { get; set; }
    [field: SerializeField] public UnityEvent Work { get; private set; }
    public object Goods { get; private set; }
}
