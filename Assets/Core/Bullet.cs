using Lib;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private Vector2 direction = Vector2.left;

    public void ChangeDirectionByAngle(float angle) => direction = direction.RotateBy(angle);

    private void Update()
    {
        transform.Translate(direction * (_speed * Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out Enemy enemy)) 
            return;
        
        enemy.TakeDamage(_damage);
        Destroy(gameObject);
    }
}