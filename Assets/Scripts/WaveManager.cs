using System.Collections;
using UnityEngine;

namespace Assets
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private FireManager fireManager;
        private int waveNumber = 1;
        private int bulletsToFire = 5;
        private float timeBetweenProjectilesFired = 1.5f;
        [SerializeField] private TextMesh wave;

        private void Start()
        {
            Time.timeScale = 1;
            StartCoroutine(NextWave());
        }

        private IEnumerator NextWave()
        {
            wave.text = "Wave: " + waveNumber;
            yield return StartCoroutine(fireManager.StartFire(bulletsToFire, timeBetweenProjectilesFired));
            waveNumber++;
            timeBetweenProjectilesFired *= 0.98f;
            if (waveNumber % 3 == 0)
            {
                // Increase bullet speed every 3rd wave
                Shooter.bulletSpeed = Shooter.bulletSpeed * 1.05f;
                Debug.Log("Bullet speed increased, Speed is now: " + Shooter.bulletSpeed);
            }
            bulletsToFire += 5;
            yield return StartCoroutine(NextWave());
        }
    }
}
