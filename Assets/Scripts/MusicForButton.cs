using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicForButton : MonoBehaviour
{
        public Sprite pic1;
        public Sprite pic2;
        private Button button;
        private Image im;
    
        public newScriptDEL intance;
        private void Awake()
        {
        
            button = GetComponent<Button>();
            im = GetComponent<Image>();
            im.sprite = pic1;
            button.onClick.AddListener(Swap);

        
        }
   
        public void Swap()
        { 
            if (im.sprite == pic1)
            {
                im.sprite = pic2;
                intance.audioPirat.volume = 0;
                return;
            }

            if (im.sprite == pic2)
            {
                im.sprite = pic1;
                intance.audioPirat.volume = 0;

            }
        }
        private void OnDestroy()
        {

            button.onClick.RemoveAllListeners(); // Отписать всех подписчиков с кнопки, если не отписываться, могут быть баги
        }

  
}
