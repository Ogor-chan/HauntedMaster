using UnityEngine;
public class Booster : Attack
{
    public Booster()
    {
        Name = "Booster";
        Damage = 0;
        AttackElement = Element.neutral;
        ChanceToUse = 45;
        AttackTarget = Target.Team;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {

        //PóŸniej zrobi siê randomowy efekt
        foreach (Character target in targets)
        {
            Utilities.ApplyEffect(target, StatusE.strength, 1);
        }
    }

}
