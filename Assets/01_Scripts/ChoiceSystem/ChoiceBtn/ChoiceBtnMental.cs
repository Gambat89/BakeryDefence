public class ChoiceBtnMental : ChoiceBtn
{
    protected override void Ability()
    {
        AbilityManager.instance.mental += 10;
        base.Ability();
    }
}
