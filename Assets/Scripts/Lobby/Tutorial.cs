using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] CrawlZombieController tutorialCrawlZombieGO;
    [SerializeField] Text tutorialText;
    [SerializeField] Text tutorialSubText;
    [SerializeField] GameObject[] tutorialDoors;
    [SerializeField] GameObject tutorialBat;
    [SerializeField] Inventory[] handSlots;

    private bool isDoorOpend = false;
    bool isWaterUsed = false;
    bool isFoodUsed = false;
    bool isBandUsed = false;
    bool isDebuffType01 = false; //긁힘 / 출혈
    bool isDebuffType2 = false;
    bool isDebuffType4 = false;

    int tutorialID = 0;

    private void Awake()
    {
        tutorialCrawlZombieGO.GetComponent<CrawlZombieController>();
    }
    private void Update()
    {
        CheckTutorial();

        if (tutorialID == 0 && tutorialBat == null) tutorialID = 1;
        //#2
        if (tutorialID == 1)
        {
            for (int a = 0; a < 4; a++)
            {
                if (handSlots[a].item != null)
                {
                    if (handSlots[a].item.itemName == "Bat") tutorialID = 2;
                }

            }
        }
        //#3
        if (tutorialID == 2 && tutorialCrawlZombieGO.GetComponent<CrawlZombieController>().isDead) tutorialID = 3;
        //#4
        if (tutorialID == 3 && tutorialCrawlZombieGO == null) tutorialID = 4;



        // Not Start Tutorial
        if (!isBandUsed && CharacterManager.instance.characterHp <= 80.0f) tutorialID = 10;
        if (!isWaterUsed && CharacterManager.instance.characterWater <= 50.0f) tutorialID = 12;
        if (!isFoodUsed && CharacterManager.instance.characterHungry <= 50.0f) tutorialID = 13;

        if (!isDebuffType01)
        {
            if (CharacterManager.instance.debuffType[0] || CharacterManager.instance.debuffType[1]) tutorialID = 20;
        }
        if (!isDebuffType2)
        {
            if (CharacterManager.instance.debuffType[2]) tutorialID = 21;
        }
        if (!isDebuffType4)
        {
            if (CharacterManager.instance.debuffType[4]) tutorialID = 22;
        }

    }
    void CheckTutorial()
    {
        if (tutorialID == -1)
        {
            tutorialText.text = null;
            tutorialSubText.text = null;
        }
        else if (tutorialID == 0)
        {
            tutorialText.text = "몽둥이에 습득하시오";
            tutorialSubText.text = "E키를 누르시오";
        }
        else if (tutorialID == 1)
        {
            tutorialText.text = "몽둥이 슬롯에 넣어 장착하시오";
            tutorialSubText.text = "인벤토리에서 드래그하여 장착";
        }
        else if (tutorialID == 2)
        {
            tutorialText.text = "좌클릭으로 좀비를 죽이시오";
            tutorialSubText.text = null;
        }
        else if (tutorialID == 3)
        {
            tutorialText.text = "좀비를 수색하시오";
            tutorialSubText.text = "E키로 수색";
        }
        else if (tutorialID == 4)
        {
            if (!isDoorOpend) StartCoroutine(OpenDoor());
        }
        else if (tutorialID == 10)
        {
            tutorialText.text = "붕대를 제작하시오";
            tutorialSubText.text = "제작 탭에서 제작";
        }
        else if (tutorialID == 11)
        {
            tutorialText.text = "붕대를 사용하시오";
            tutorialSubText.text = "우클릭으로 사용";
            isBandUsed = true;
            tutorialID = -1;
        }
        else if (tutorialID == 12)
        {
            tutorialText.text = "물을 마시시오";
            tutorialSubText.text = "연못 또는 생수를 파밍";
            if (CharacterManager.instance.characterWater >= 70.0f)
            {
                isWaterUsed = true;
                tutorialID = -1;
            }
        }
        else if (tutorialID == 13)
        {
            tutorialText.text = "음식을 드시오";
            tutorialSubText.text = null;
            if (CharacterManager.instance.characterHungry >= 70.0f)
            {
                isFoodUsed = true;
                tutorialID = -1;
            }
        }
        else if (tutorialID == 20)
        {
            tutorialText.text = "붕대를 사용하시오";
            tutorialSubText.text = null;
            if (!CharacterManager.instance.debuffType[0] && !CharacterManager.instance.debuffType[1])
            {
                isDebuffType01 = true;
                tutorialID = -1;
            }
        }
        else if (tutorialID == 21)
        {
            tutorialText.text = "해독제를 사용하시오";
            tutorialSubText.text = "필드 파밍";
            if (!CharacterManager.instance.debuffType[2])
            {
                isDebuffType2 = true;
                tutorialID = -1;
            }
        }
        else if (tutorialID == 22)
        {
            tutorialText.text = "해독제를 사용하시오";
            tutorialSubText.text = "필드 파밍";
            if (!CharacterManager.instance.debuffType[4])
            {
                isDebuffType2 = true;
                tutorialID = -1;
            }
        }
    }
    IEnumerator OpenDoor()
    {
        isDoorOpend = true;
        yield return new WaitForSeconds(1.0f);
        tutorialText.text = "재료를 파밍하고 베이스 캠프를 만드시오";
        tutorialSubText.text = null;

        tutorialDoors[0].transform.rotation = Quaternion.Euler(0, 90, 0);
        tutorialDoors[1].transform.rotation = Quaternion.Euler(0, 90, 0);
        tutorialDoors[2].transform.rotation = Quaternion.Euler(0, 90, 0);
        tutorialDoors[3].transform.rotation = Quaternion.Euler(0, 90, 0);
    }

}