public class ChoiceBtnProjectile : ChoiceBtn
{
    protected override void Ability()
    {
        AbilityManager.instance.projectile += 10;
        base.Ability();
    }
}
