public class ChoiceBtnSpeed : ChoiceBtn
{
    protected override void Ability()
    {
        AbilityManager.instance.speed += 10;
        base.Ability();
    }
}
