using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationWindowSystem : MonoBehaviour
{
    public static ConfirmationWindowSystem Instance { get; private set; }
    
    [SerializeField] private GameObject canvas;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button declineButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There is more than 1 ConfirmationWindowSystem");
            Destroy(gameObject);
        }
    }
    
    public void Show(string message, Action confirm, Action decline = null)
    {
        messageText.text = message;
        confirmButton.onClick.AddListener(() =>
        {
            confirm?.Invoke();
            Hide();
        });
        declineButton.onClick.AddListener(() =>
        {
            decline?.Invoke();
            Hide();
        });
        canvas.SetActive(true);
    }

    private void Hide()
    {
        canvas.SetActive(false);
    }
}
