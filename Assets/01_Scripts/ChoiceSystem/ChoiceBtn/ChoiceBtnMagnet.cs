public class ChoiceBtnMagnet : ChoiceBtn
{
    protected override void Ability()
    {
        AbilityManager.instance.magnet += 10;
        base.Ability();
    }
}
