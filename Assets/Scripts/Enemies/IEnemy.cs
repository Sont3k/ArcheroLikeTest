using UnityEngine;

public interface IEnemy
{
    void Move();
    void DealDamage(Collision other);
}