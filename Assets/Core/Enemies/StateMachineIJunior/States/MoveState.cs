using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;
    
    private Player _target;
    
    private void Start() => _target = GetComponent<Enemy>().Target;

    private void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }
}