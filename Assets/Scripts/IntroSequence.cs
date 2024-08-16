using Dreamteck.Forever;
using UnityEngine;
using DG.Tweening;

// This script is used to animate the camera at the start of the game
public class IntroSequence : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private LaneRunner _runner;
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _runningMusic;

    // Start is called before the first frame update
    private void Start()
    {
        // Disable the camera follow script first
        // Animate the camera to the starting position
        Vector3 targetPosition = new Vector3(0, _cameraFollow.cameraHeight, _cameraFollow.cameraDistance);
        _camera.transform.DOMove(targetPosition, 2).SetEase(Ease.OutCirc).OnComplete(() =>
        {
            _audioSource.Play();
            Invoke("StartRunning", _audioSource.clip.length);
        });
    }

    // Start the runner and enable the camera follow script
    // Play the running music
    // Set the player's speed to the starting speed
    // Start the player's running animation
    private void StartRunning()
    {
        _cameraFollow.enabled = true;
        _runner.followSpeed = _player.StartSpeed;
        _audioSource.clip = _runningMusic;
        _audioSource.loop = true;
        _audioSource.Play();

        _player.StartRunning();
    }
}
