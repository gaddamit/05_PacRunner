using UnityEngine;
using Dreamteck.Forever;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    LaneRunner runner;
    public static Player instance;
    private Rigidbody _rigidBody;
    private bool _isJumping = false;
    
    private bool _isDead = false;
    private Animator _animator;
    
    float speed = 0f;
    float startSpeed = 0f;
    [Header("Speed Settings")]
    [SerializeField]
    private float _speedCap = 50;
    [SerializeField]
    private float _speedIncrement = 0.5f;

    [Header("Events")]
    public UnityEvent onDeath;
    public UnityEvent onGameOver;

    [SerializeField]
    private AudioClip _deathSound;

    private void Awake()
    {
        runner = GetComponent<LaneRunner>();
        startSpeed = speed = runner.followSpeed;
        instance = this;

        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void OnRestart()
    {
        LevelGenerator.instance.Restart();
        runner.followSpeed = speed = startSpeed;
    }

    private void Update()
    {
        if(_isDead)
        {
            return;
        }

        // Lane switching logic
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) runner.lane--;
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) runner.lane++;
    }

    private void FixedUpdate()
    {
        if (_isJumping)
        {
            _rigidBody.AddForce(Vector3.up * 10, ForceMode.Impulse);
            _isJumping = false;
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
        runner.followSpeed = speed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    // Increase the player speed, called by the GameManager when scores hits a mark
    public void IncreaseSpeed()
    {
        if(speed < _speedCap)
        {
            SetSpeed(speed + _speedIncrement);
        }
    }

    // Called when the player dies
    public void OnDeath()
    {
        if(_isDead)
        {
            return;
        }

        _isDead = true;
        SetSpeed(0f);
        PlayDeathSequence();

        onDeath?.Invoke();
        Invoke("GameOver", 3.0f);
    }

    // Call the GameOver method in the GameManager
    public void GameOver()
    {
        GameManager.Instance.GameOver();
    }

    // Play the death animation and sound
    private void PlayDeathSequence()
    {
        if(_animator != null)
        {
            _animator.SetTrigger("Death");
        }

        if(_deathSound != null)
        {
            AudioManager.Instance.PlaySoundEffect(_deathSound);
        }
    }
}