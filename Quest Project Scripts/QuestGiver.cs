using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{

    public Quest quest;
    public Player player;
    public Text titleText;
    public Text descriptionText;
    public GameObject questWindow;

    public void OpenQuest()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
      
    }

    
}
