using UnityEngine;
using UnityEngine.UI;

public class AbilityActive : MonoBehaviour
{
    public int btnNum = 4;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => Active());
    }

    void Active()
    {
        AbilityManager.instance.abilityImage.gameObject.SetActive(true);
        ActiveRandomBtn();
    }

    void ActiveRandomBtn()
    {
        for (int i = 0; i < btnNum; i++)
        {
            RandomButton();
        }
    }

    void RandomButton()
    {
        int btnIndex = Random.Range(0, AbilityManager.instance.abilityBtn.Count);

        if (!AbilityManager.instance.abilityBtn[btnIndex].gameObject.activeSelf)
        {
            AbilityManager.instance.abilityBtn[btnIndex].gameObject.SetActive(true);
        }
        else
        {
            RandomButton();
        }
    }
}
