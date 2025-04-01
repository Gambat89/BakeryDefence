public class ChoiceBtnPower : ChoiceBtn
{
    protected override void Ability()
    {
        AbilityManager.instance.power += 10;
        base.Ability();
    }
}
