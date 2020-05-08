using UnityEngine;

public interface IEnemy
{
    void MoveTowardPlayer();
    void DealDamage(Collision other);
}