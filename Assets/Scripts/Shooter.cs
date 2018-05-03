using Assets;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject[] projectileAssets;
    public static float bulletSpeed = 10;

    public AudioSource LaunchAudio;


    public void Shoot()
    {
      //  Debug.Log("shoot!");
        Vector3 target = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.LookAt(target);
        GameObject go = Instantiate(projectileAssets[getRandomIndex()], gameObject.transform.position, gameObject.transform.rotation);
        LaunchAudio.Play();
        go.GetComponent<Rigidbody>().velocity = ((target - new Vector3(0, 0.3f, 0)) - gameObject.transform.position).normalized * bulletSpeed;

    }

    private int getRandomIndex()
    {
        return Random.Range(0, projectileAssets.Length);
    }
}