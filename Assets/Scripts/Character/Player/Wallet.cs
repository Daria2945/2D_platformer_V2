using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _balance;

    public void CollectCoin()
    {
        _balance++;
    }
}