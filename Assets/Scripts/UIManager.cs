using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private CanvasGroup stageClearGroup;
    [SerializeField] private CanvasGroup gameOverGroup;

    private void OnEnable()
    {
        gameManager.OnPickupChanged += UpdatePickupUI;
        gameManager.OnStageCleared += ShowStageClear;
        gameManager.OnGameOver += ShowGameOver;
    }

    private void OnDisable()
    {
        gameManager.OnPickupChanged -= UpdatePickupUI;
        gameManager.OnStageCleared -= ShowStageClear;
        gameManager.OnGameOver -= ShowGameOver;
    }

    private void UpdatePickupUI(int collected, int total)
    {
        countText.text = $"Coins: {collected}/{total}";
    }

    private void ShowStageClear()
    {
        stageClearGroup.alpha = 1f;
        stageClearGroup.interactable = true;
        stageClearGroup.blocksRaycasts = true;
    }

    private void ShowGameOver()
    {
        gameOverGroup.alpha = 1f;
        gameOverGroup.interactable = true;
        gameOverGroup.blocksRaycasts = true;
    }
}
