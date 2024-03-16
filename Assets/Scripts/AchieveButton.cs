using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveButton : MonoBehaviour
{
    public EAchieveType achieveType;

    private Button button;
    private Image image;

    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        button.onClick.AddListener(OnAchieveButtonClick);
    }

    private void OnAchieveButtonClick()
    {
        Debug.Log(achieveType);
        image.color = Color.blue;
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners(); // Отписать всех подписчиков с кнопки, если не отписываться, могут быть баги
    }
}
