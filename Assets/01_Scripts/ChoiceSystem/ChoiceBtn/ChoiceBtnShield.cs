public class ChoiceBtnShield : ChoiceBtn
{
    protected override void Ability()
    {
        AbilityManager.instance.shield += 10;
        base.Ability();
    }
}
