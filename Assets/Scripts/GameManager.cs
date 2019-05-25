using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    public List<GameObject> characterPrefabs = new List<GameObject>();
    public int characterClass = 0;
    GameObject charater;
    [SerializeField]int gameSceneIndex = 1;
    
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void OnChangeClassSelector(int value)
    {
        characterClass = value;
        Debug.Log("Character is now: " + characterPrefabs[characterClass].name);
    }

    public void OnClickPlay()
    {
        var task = SceneManager.LoadSceneAsync(gameSceneIndex, LoadSceneMode.Single);
        task.completed += SpawnPlayer;
    }

    void SpawnPlayer(AsyncOperation _)
    {
            var playerSpawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform.position;
            Debug.Log("SpawnPoint Found! x:" + playerSpawnPoint.x.ToString() + ", y:" + playerSpawnPoint.y.ToString() + ", z:" + playerSpawnPoint.z.ToString());
            charater = Instantiate(characterPrefabs[characterClass], playerSpawnPoint, Quaternion.identity);
            if (charater == null)
            {
                Debug.LogError("Player not assigned!");
            }
    }

}
