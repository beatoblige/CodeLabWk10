using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{


	private void Awake() //theory: if more than one music player in scene, destroy 
	{
		int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length; //shows you total amount of music players 
		print("Number of music player in this scene " + numMusicPlayers);

		if (numMusicPlayers > 1) //using singletons??
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
		
		
	} 

	// Start is called before the first frame update
	void Start()
    {
        Invoke("LoadFirstScene", 2f);
    }



    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
