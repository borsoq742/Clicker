using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickButton : MonoBehaviour
{
    [SerializeField] int money;
    public Text moneyText;
    public int total_money;
    public GameObject effect;
    public GameObject button;
    public AudioSource audioSource;
    [SerializeField] int upgradeClickMoney=1;
    private void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
        bool isFirst = PlayerPrefs.GetInt("isFirst") == 1 ? true : false;
        if (isFirst)
        {
            StartCoroutine(IdleFarm());
        }
        OfflineTime();
    }
    public void ToShop()
    {
        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
        SceneManager.LoadScene(2);

    }
    public void buttonClick()
    {
        money+=upgradeClickMoney;
        total_money++;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("total_money", total_money);
        PlayerPrefs.SetInt("upgradeClickMoney", upgradeClickMoney);
        Instantiate(effect, button.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
        button.GetComponent<RectTransform>().localScale = new Vector3(0.95f, 0.95f, 0);
        audioSource.Play();
    }
    //возвращаем скеил в норм состояние 
    public void OnClickUp()

    {
        button.GetComponent<RectTransform>().localScale = new Vector3(1f,1f,0);
    }
    
    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        money++;
        Debug.Log(money);
        PlayerPrefs.SetInt("money", money);
        StartCoroutine(IdleFarm());

    }
    private void OfflineTime()
    {
        TimeSpan ts;
        if (PlayerPrefs.HasKey("LastSession"))
        {
            ts = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            Debug.Log(string.Format("Вас не было {0} дней,{1} часов, {2} минут, {3} секунд", ts.Days, ts.Hours, ts.Minutes, ts.Seconds));
            money += (int)ts.TotalSeconds;
            PlayerPrefs.SetInt("money", money);
        }
    }
    #if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());

        }
    }
#else

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
    }
#endif
    public void ToAchieve()
    {
        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        moneyText.text = money.ToString();
        upgradeClickMoney = PlayerPrefs.GetInt("upgradeClickMoney");
    }
}
