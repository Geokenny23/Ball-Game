using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int TotalPickups { get; private set; }
    public int CollectedPickups { get; private set; }

    public event Action<int, int> OnPickupChanged;
    public event Action OnStageCleared;
    public event Action OnGameOver;

    private void Awake()
    {
        TotalPickups = GameObject.FindGameObjectsWithTag("PickUp").Length;
        CollectedPickups = 0;
    }

    private void Start()
    {
        OnPickupChanged?.Invoke(CollectedPickups, TotalPickups);
    }

    public void PickupCollected()
    {
        CollectedPickups++;

        OnPickupChanged?.Invoke(CollectedPickups, TotalPickups);

        if (CollectedPickups >= TotalPickups)
        {
            OnStageCleared?.Invoke();
        }
    }

      public void GameOver()
    {
        Debug.Log("Game Over!");
        OnGameOver?.Invoke();
    }
}
