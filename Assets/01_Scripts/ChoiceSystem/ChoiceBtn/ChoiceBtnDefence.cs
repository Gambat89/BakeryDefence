public class ChoiceBtnDefence : ChoiceBtn
{
    protected override void Ability()
    {
        AbilityManager.instance.defence += 10;
        base.Ability();
    }
}