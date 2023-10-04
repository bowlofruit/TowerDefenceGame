using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip towerBuildSound;
    [SerializeField] private AudioClip towerShootSound;
    [SerializeField] private AudioClip towerUpgradeSound;

    [SerializeField] private AudioClip enemyDeathSound;

    public static AudioController Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        audioSource.enabled = PlayerPrefs.GetInt("SoundOn", 1) == 1;
    }

    public void PlaySound(AudioClip audioClip)
    {
        if (audioSource.enabled && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

    public void PlayTowerBuildSound()
    {
        PlaySound(towerBuildSound);
    }

    public void PlayTowerShootSound()
    {
        PlaySound(towerShootSound);
    }

    public void PlayTowerUpgradeSound()
    {
        PlaySound(towerUpgradeSound);
    }

    public void PlayEnemyDeathSound()
    {
        PlaySound(enemyDeathSound);
    }
}