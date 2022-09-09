using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : Consumable
{

    public override string GetConsumableName()
    {
        return "Crown";
    }

    public override ConsumableType GetConsumableType()
    {
        return ConsumableType.CROWN;
    }

    public override int GetPrice()
    {
        return 9999;
    }

    public override int GetPremiumCost()
    {
        return 9999;
    }

    public override IEnumerator Started(CharacterInputController c)
    {
        yield return base.Started(c);

        m_SinceStart = 0;

        c.trackManager.modifyMultiply += MultiplyModify;

        c.characterCollider.SetInvincibleExplicit(true);

        c.jumpHeight = 4f;
    }

    public override void Ended(CharacterInputController c)
    {
        base.Ended(c);

        c.trackManager.modifyMultiply -= MultiplyModify;

        c.characterCollider.SetInvincibleExplicit(false);

        c.jumpHeight = 1.2f;
    }

    protected int MultiplyModify(int multi)
    {
        return multi * 9;  
    }
}
