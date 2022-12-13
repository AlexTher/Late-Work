using System.Collections;
using System.Collections.Generic;
using SpriteGlow;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public string towerName;
    public long cost;
    public float range;
    public float damage;
    public float projectileSpeed;
    
    public float initFireRate;
    private float fireRate;

    //yeah
    public float maxHealth;
    private float health;

    public Projectile projectile;
    public MasterEnemy target; //current target

    private List<MasterEnemy> targets; //all targets in range

    private bool isFiring;

    public static List<Tower> towers = new List<Tower>();
    public CircleCollider2D boundingCollider; //kind of a shitty name for what this does but if renamed will undo all assignments \._./
    private SpriteRenderer towerSprite;
    public AudioSource ShootingAudio;
    

    public GameObject glowObject;

    private SpriteGlowEffect spriteGlow;

    private void Awake()
    {
        towers.Add(this);
        towerSprite = boundingCollider.GetComponent<SpriteRenderer>();
    }

    private void OnDestroy()
    {
        towers.Remove(this);
        Destroy(this.gameObject);
    }

    void Start()
    {
        isFiring = false;
        health = maxHealth;
        fireRate = initFireRate;
        spriteGlow = glowObject.GetComponent<SpriteGlowEffect>();
        spriteGlow.GlowColor = new Color32(0, 255, 0, 255);
    }
    void Update()
    {
        Decay();
    }



    //add willdie to enemy. tower won't target that enemy anymore

    public void OnTriggerEnter2D(Collider2D enemy) {
        print(enemy.tag);
        if (enemy.tag == "Enemy") {
            target = enemy.GetComponent<MasterEnemy>();
        }
    }

    public void OnTriggerStay2D(Collider2D enemy) {
        if (target != null && !isFiring && isActiveAndEnabled) {
            StartCoroutine(Shoot());
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower") && !isActiveAndEnabled)
            towerSprite.color = Color.grey;
        else
            towerSprite.color = Color.white;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        towerSprite.color = Color.white;
    }

    //private bool ValidTarget(DummyEnemy enemy) {}
    private IEnumerator Shoot() {
        //Projectile projectile = projectile.SpawnProjectile(this);
        isFiring = true;
        projectile.SpawnProjectile(this, target.gameObject);
        ShootingAudio = GameObject.Find("ShootAudio").GetComponent<AudioSource>();
        ShootingAudio.Play();
        health --;
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }

    private void Decay() {
        if (health > 0 ) {
            float curG = (health/maxHealth);
            float curR = 1 - (curG);
            Debug.Log(curR);
            spriteGlow.GlowColor = new Color(curR,curG, 0f, 1f);
            fireRate = initFireRate * (curR + 1f);
        }
        else { OnDestroy(); }
    }
}
