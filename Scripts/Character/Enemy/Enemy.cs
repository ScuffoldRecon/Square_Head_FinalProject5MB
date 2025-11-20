using UnityEngine;

public class Enemy
{
    private int HP;
    private float _attackPower;

    public WaveController waveManager;


    public virtual bool Hit()
    {
        return HP > 0;
    }
    public virtual void TakeDamage(int amount)
    {
        HP -= amount;
        Debug.Log($"{gameObject.name} {HP}");

        if (HP <= 0)
        {
            Die();
        }
    }

    public void RandomMove()
    {

        Vector3 randomDir = new Vector3(
            Random.Range(-1f, 1f),
            0,
            Random.Range(-1f, 1f)
        ).normalized;


        transform.Translate(randomDir * MovementSpeed * Time.deltaTime);

        Debug.Log($"{gameObject.name} {randomDir}");
    }

    public virtual void Attack(Player player)
    {
        if (player == null) return;

        Debug.Log($"{gameObject.name} {AttackDamage}");
        player.TakeDamage(AttackDamage);
    }

    protected void Die()
    {
        Debug.Log($"{gameObject.name}");


        if (waveManager != null)
        {
            waveManager.OnEnemyDead(this);
        }

        Destroy(gameObject);
    }
}
