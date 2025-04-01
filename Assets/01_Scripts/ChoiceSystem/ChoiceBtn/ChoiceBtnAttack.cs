public class ChoiceBtnAttack : ChoiceBtn
{
    protected override void Ability()
    {
        AbilityManager.instance.attack += 10;
        base.Ability();
    }
}
