using UnityEngine;

public class Enemy : MonoBehaviour
{
    Health playerHp;

    EnemyManager enemyManager;

    public string enemyName;

    public float enemyHealth;

    public float enemyFireWeakness;

    public float enemyPoisonWeakness;

    public float enemyHolyWeakness;

    public string weakness;

    public int lookRot;

    public bool isSkeleton;

    string[] weaknesses = { "holy", "fire", "poison" };
    void Start()
    {
        if (isSkeleton)
        {
            weakness = weaknesses[Random.Range(0, weaknesses.Length)];
            switch (weakness)
            {
                case "holy":
                    enemyHolyWeakness = 1.5f;
                    enemyPoisonWeakness = Random.Range(0.2f, 0.5f);
                    enemyFireWeakness = Random.Range(0.2f, 0.5f);
                    break;
                case "fire":
                    enemyFireWeakness = 1.5f;
                    enemyPoisonWeakness = Random.Range(0.2f, 0.5f);
                    enemyHolyWeakness = Random.Range(0.2f, 0.5f);
                    break;
                case "poison":
                    enemyPoisonWeakness = 1.5f;
                    enemyFireWeakness = Random.Range(0.2f, 0.5f);
                    enemyHolyWeakness = Random.Range(0.2f, 0.5f);
                    break;
                default:
                    break;
            }
        }
        transform.rotation = new Quaternion(0, lookRot, 0, 0);
        enemyManager = GameObject.FindGameObjectWithTag("Scene").GetComponent<EnemyManager>();
        playerHp = GameObject.FindGameObjectWithTag("Scene").GetComponent<Health>();
        enemyManager.enemy = this;
        enemyManager.Setup();
        enemyManager.inFight = true;
        InvokeRepeating("Damage", 1.55f, 1.5f);
    }

    private void Update()
    {
        if(enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Damage()
    {
        if(playerHp.HP > 0)
        {
            playerHp.HurtPlayer(1);
        }
    }
}