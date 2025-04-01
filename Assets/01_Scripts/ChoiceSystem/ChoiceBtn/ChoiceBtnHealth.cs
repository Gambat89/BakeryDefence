public class ChoiceBtnHealth : ChoiceBtn
{
    protected override void Ability()
    {
        AbilityManager.instance.health += 10;
        base.Ability();
    }
}
