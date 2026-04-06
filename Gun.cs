using UnityEngine;
public class Gun : MonoBehaviour
{
    public float damage = 25f;
    public float range = 100f;
    public Camera fpsCam;
    void Update(){ if (Input.GetButtonDown("Fire1")) Shoot(); }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
            if (enemy != null) enemy.TakeDamage(damage);
        }
        Collider[] enemies = Physics.OverlapSphere(transform.position, 20f);
        foreach (Collider col in enemies)
        {
            EnemyAI enemy = col.GetComponent<EnemyAI>();
            if (enemy != null) enemy.HearNoise(transform.position);
        }
    }
}