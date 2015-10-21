using UnityEngine;
using System.Collections;

public interface IDamageAble {
    int health { get; set; }
    void DamageCollision(int damage);
    void DamageNearby(int defaultDamage, float distance, float distanceMultiplier); //Vector3 damagePosition, Vector3 objectPosition
}
