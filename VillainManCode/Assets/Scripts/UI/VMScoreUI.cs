using TMPro;
using UnityEngine;

public class VMScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update()
    {
        if (scoreText == null || VMGameManager.Instance == null)
            return;

        scoreText.text = $"Destruction: {VMGameManager.Instance.DestructionScore}";
    }
}
