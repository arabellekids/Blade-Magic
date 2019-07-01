using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Character {

    public GameObject fireballSystemPrefab;
    public int fireballSpeed = 10;
    public float fireballLifetime = 3;
    public Transform fireballSpawnPoint;
    Coroutine fireballRoutine; 
    float timer = 0;
    [HideInInspector] public List<GameObject> currentFireballs = new List<GameObject>();

    public override void Initialize(string name, int maxHP, Animator anim)
    {
        base.Initialize(name, maxHP, anim);
    }
    public override IEnumerator AttackTargetAsync()
    {
        timer = attackSpeed;
        while (true)
        {
            while (timer <= attackSpeed)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            anim.SetTrigger("CastSpell");
            var fireball = Instantiate(fireballSystemPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
            Destroy(fireball, fireballLifetime);
            fireball.GetComponent<Fireball>().Initialize(fireballSpawnPoint.forward.normalized * fireballSpeed);
            fireball.GetComponent<Fireball>().wizard = this;
            currentFireballs.Add(fireball);
            timer = 0;
            yield return null;
        }
        
    }
    public override void SpecialAction()
    {
        
    }
    void Update()
    {
        var castSpell = Input.GetMouseButtonDown(0);
        var castEnd = Input.GetMouseButtonUp(0);
        if (castSpell && fireballRoutine == null)
        {
            fireballRoutine = StartCoroutine(AttackTargetAsync());
        }
        else if (castEnd && fireballRoutine != null)
        {
            StopCoroutine(fireballRoutine);
            fireballRoutine = null;
        }
    }
}
