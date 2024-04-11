using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Joystick _joystick;

    private Rigidbody _rb;
    private Transform _transform;
    private Vector3 _vecDirection;

    private GameController _gameController;

    [Inject]
    private void Construct(GameController gameController)
    {
        _gameController = gameController;
        Init();
    }

    public void Init()
    {
        _vecDirection = Vector3.zero;

        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.zero;

        _transform = transform;
        _transform.position = Vector3.zero;
        _transform.rotation = Quaternion.identity;
    }

    private void Update()
    {
        if (!_gameController.IsGame)
            return;

        Look();
    }

    private void FixedUpdate()
    {
        if (!_gameController.IsGame)
            return;

        Move();
    }

    private void Move()
    {
        _rb.velocity = _vecDirection * _speed * Time.fixedDeltaTime;
    }

    private void Look()
    {
        _vecDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        if (_vecDirection != Vector3.zero)
            _transform.rotation = Quaternion.LookRotation(_vecDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.TAG_WIN))
            _gameController.Win();

        if (other.CompareTag(Constants.TAG_DEFEAT))
            _gameController.Defeat();
    }
}
