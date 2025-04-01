public class ChoiceBtnMoney : ChoiceBtn
{
    protected override void Ability()
    {
        AbilityManager.instance.money += 10;
        base.Ability();
    }
}
