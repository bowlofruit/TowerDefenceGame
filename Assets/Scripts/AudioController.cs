using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip towerBuildSound;
    [SerializeField] private AudioClip towerShootSound;
    [SerializeField] private AudioClip towerUpgradeSound;

    [SerializeField] private AudioClip enemyDeathSound;

    [SerializeField] private AudioSource audioSource;

    public static AudioController Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public void PlayTowerBuildSound()
    {
        audioSource.PlayOneShot(towerBuildSound);
    }

    public void PlayTowerShootSound()
    {
        audioSource.PlayOneShot(towerShootSound);
    }

    public void PlayTowerUpgradeSound()
    {
        audioSource.PlayOneShot(towerUpgradeSound);
    }

    public void PlayEnemyDeathSound()
    {
        audioSource.PlayOneShot(enemyDeathSound);
    }
}