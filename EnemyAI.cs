using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public float detectionRange = 10f;
    public float health = 100f;
    private bool isAlerted = false;
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < detectionRange || isAlerted)
            agent.SetDestination(player.position);
    }
    public void HearNoise(Vector3 noisePosition)
    {
        isAlerted = true;
        agent.SetDestination(noisePosition);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }
}