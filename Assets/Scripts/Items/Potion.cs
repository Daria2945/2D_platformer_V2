using UnityEngine;

public class Potion : Item 
{
    [SerializeField] private int _regenerationUnits;

    public int RegenerationUnits => _regenerationUnits;
}