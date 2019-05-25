using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour{

    public enum CharacterStates
    {
        Alive,
        Falling,
        Dead,
        Stunned
    }

    public int maxHealth = 10;
    internal int health;
    public CharacterStates currentState = CharacterStates.Alive;
    public Animator anim;
    public string characterName = "";
    public int attackDamage = 1;
    public int attackRange = 2;
    public float attackSpeed = 0.5f;
    public int attackFOV = 40;
    internal float attackTimer = 0;

    public virtual void SpecialAction() { }
    public abstract IEnumerator AttackTargetAsync();

    public virtual void Initialize(string name, int maxHP, Animator anim)
    {
        maxHealth = maxHP;
        characterName = name;
        this.anim = anim;
    }
    public virtual void TakeDamage(int amount)
    {
        health -= amount;
        if(amount <= 0)
        {
            currentState = CharacterStates.Dead;
            Debug.Log(characterName + "died!");
        }
    }


}
