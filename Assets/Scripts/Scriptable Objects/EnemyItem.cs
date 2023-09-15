using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Create Enemy")]
public class EnemyItem : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField][Range(0f, 3f)] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private int _reward;
    [SerializeField] private bool _canStun;

    public int Health { get => _health; set => _health = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public int Damage { get => _damage; set => _damage = value; }
    public int Reward { get => _reward; set => _reward = value; }
    public bool CanStun { get => _canStun; set => _canStun = value; }
}
