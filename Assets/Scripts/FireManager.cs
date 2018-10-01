using System.Collections;
using UnityEngine;

public class FireManager : MonoBehaviour {
    [SerializeField] private Shooter[] shooters;
// Stuff here !:P
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator StartFire(int bulletsToFire, float timeBetweenProjectilesFired)
    {
     //   Debug.Log("Bullets to fire" + bulletsToFire);
        if (bulletsToFire == 0)
        {
            yield return new WaitForSeconds(5);
        }

        if (bulletsToFire > 0)
        {
            yield return FireRandom(timeBetweenProjectilesFired);
            yield return StartCoroutine(StartFire(bulletsToFire - 1, timeBetweenProjectilesFired));
            
        }
        
    }
    private IEnumerator FireRandom(float timeBetweenProjectilesFired)
    {
        var length = shooters.Length;
        if (length < 0) {
            Debug.Log("Empty shooters array");
            yield return null;
        }
        var randomIndex = Random.Range(0, length);
        shooters[randomIndex].Shoot();
        yield return new WaitForSeconds(timeBetweenProjectilesFired);
    }
}
