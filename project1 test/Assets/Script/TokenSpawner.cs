using System.Collections;
using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    
    public GameObject tokenPrefab;
    public Transform spawnPoint;
    public KeyCode interactKey = KeyCode.E;
    private Animator anim;
    private bool done = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            
            done = true;
            StartCoroutine(WaitAndSpawnToken());
        }

        anim.SetBool("Done", done);
    }

    IEnumerator WaitAndSpawnToken()
    {
        // Wait for 2 seconds before spawning the token
        yield return new WaitForSeconds(1.5f);
        SpawnToken();
    }

    void SpawnToken()
    {
        if (tokenPrefab != null && spawnPoint != null)
        {
            // Instantiate the token at the spawn point's position and rotation
            Instantiate(tokenPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("TokenPrefab or SpawnPoint is not assigned in the inspector.");
        }
    }
}