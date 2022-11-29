using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Cat cat))
        {
            cat.TakeDamage(_damage);
        }
        
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
