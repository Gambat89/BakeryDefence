using UnityEngine;
using UnityEngine.UI;

public class ChoiceBtn : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => Ability());
        GetComponent<Button>().onClick.AddListener(() => AbilityManager.instance.AbilityUpdate());
        GetComponent<Button>().onClick.AddListener(() => Deactive());
    }

    private void OnDisable()
    {
        gameObject.SetActive(false);
    }

    void Deactive()
    {
        AbilityManager.instance.abilityImage.gameObject.SetActive(false);
    }

    protected virtual void Ability()
    {

    }
}
