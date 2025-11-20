using UnityEngine;

public class Dragon : Enemy
{
   
    public float BreathAttackRange = 10f;   
    public float MeleeAttackRange = 2f;     

   
    public override void Attack(Player player)
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        
        if (distance <= MeleeAttackRange)
        {
            Debug.Log("MeleeAttackRange!");
            player.TakeDamage(AttackDamage);
        }

        
        else if (distance <= BreathAttackRange)
        {
            FireBreath(player);
        }

       
        else
        {
            Debug.Log();
        }
    }

   
    public void FireBreath(Player player)
    {
        float fireDamage = AttackDamage * 2f;

        Debug.Log($"BreathAttackRange{fireDamage}");
        player.TakeDamage(fireDamage);
    }
}
