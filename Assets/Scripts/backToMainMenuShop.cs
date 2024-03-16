using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backToMainMenuShop : MonoBehaviour
{
    [SerializeField] int money;
    public Text moneyText;
    
    public int upgradeClickMoney;
    public Text upgradeClick;
    public void Update()
    {
        moneyText.text = money.ToString();
        upgradeClick.text = "За клик " + upgradeClickMoney;
    }
    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
        upgradeClickMoney = PlayerPrefs.GetInt("upgradeClickMoney");
    }
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void clickCost()
    {
        upgradeClickMoney++;

        PlayerPrefs.SetInt("upgradeClickMoney", upgradeClickMoney);
    }
}
