using System.Collections;
using UnityEngine;

public interface IMeleeAttack
{
    IEnumerator DealDamage(Collision other);
}