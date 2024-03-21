using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveButton : MonoBehaviour
{
    public EAchieveType achieveType;

    private Button button;
    private Image image;
    private Color color;
    private int money;
    private int upgradeClickMoney;
    private int playerPrefsAchColor=0;
    
    void Start()
    {
        ColorUtility.TryParseHtmlString("#09FF0064", out color);
        
    }
    private void Update()
    {
      PlayerPrefs.GetInt("money", money);
        PlayerPrefs.GetInt("upgradeClickMoney", upgradeClickMoney);
    }
    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        button.onClick.AddListener(OnAchieveButtonClick);
    }

    private void OnAchieveButtonClick()
    {
        if (achieveType == EAchieveType.clickCountOneHundredThousand &&money<=100000)
        {
            image.color = color;
           
        }
        else if (achieveType == EAchieveType.clickCountOneMil && money <= 1000000)
        {
            image.color = color;
        }
        else if(achieveType==EAchieveType.upgradingClickToThousand&& upgradeClickMoney>=1000)
        {
            image.color = color;
        }
        else
        {
            Debug.Log("аыаа");
        }
        
    }

    private void OnDestroy()
    {
       
        button.onClick.RemoveAllListeners(); // Отписать всех подписчиков с кнопки, если не отписываться, могут быть баги
    }
}
