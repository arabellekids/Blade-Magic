using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class Rogue : Character{

    public bool invisible = false;
    bool attack = false;
    Coroutine attackRoutine;

    public override void Initialize(string name, int maxHP, Animator anim)
    {
        base.Initialize(name, maxHP, anim);
    }

    public  override IEnumerator AttackTargetAsync()
    {
        float timer = attackSpeed;
        while (true)
        {
            while (timer <= attackSpeed)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            Debug.Log("attacked");
            var targets = (
                        from enemy in Physics.OverlapSphere(transform.position, attackRange)
                        let angle = Vector3.Angle(this.transform.forward, enemy.transform.position - this.transform.position)
                        where Math.Abs(angle) <= attackFOV
                        let health = enemy.GetComponent<Character>()
                        where health != null
                        select health
                    ).ToList();
            foreach (Character enemy in targets)
            {
                enemy.TakeDamage(attackDamage);
            }
            SetInvisible(false);
            anim.SetTrigger("attack");
            timer = 0;
            yield return null;
        }
    }

    void SetInvisible(bool value)
    {
        invisible = value;
        anim.SetBool("invisible", value);
    }
 
    private void Update()
    {
        attack = Input.GetMouseButtonDown(0);
        var attackUp = Input.GetMouseButtonUp(0);
        if (attack == false && Input.GetKeyUp(KeyCode.I))
        {
            SetInvisible(!invisible);
        }
        if (attack && attackRoutine == null && attackUp != true)
        {
            attackRoutine = StartCoroutine(AttackTargetAsync());
        }
        else if(attackUp && attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            attackRoutine = null;
        }
    }

}
