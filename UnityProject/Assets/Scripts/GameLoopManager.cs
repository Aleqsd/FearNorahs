using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoopManager : MonoBehaviour {


    enum GameState
    {
        Won,
        Lost,
        Playing
    };

    public GameObject[] playerPrefabs;
    public float startDelay = 5f;             // The delay between the start of phases.
    public float endDelay = 100f;               // The delay between the end of phases.
    public float spawnDelay = 2f;

    private GameState gameState;
    private WaitForSeconds startWait;         // Used to have a delay whilst the game starts.
    private WaitForSeconds endWait;           // Used to have a delay whilst the game ends.
    private WaitForSeconds spawnWait;

    // Use this for initialization
    void Start () {
        // Create the delays so they only have to be made once.
        startWait = new WaitForSeconds(startDelay);
        endWait = new WaitForSeconds(endDelay);
        spawnWait = new WaitForSeconds(spawnDelay);
        gameState = GameState.Playing;

        StartCoroutine(GameLoop());
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    // This is called from start and will run each phase of the game one after another.
    private IEnumerator GameLoop()
    {
        // Start off by running the 'GameStarting' coroutine but don't return until it's finished.
        yield return StartCoroutine(GameStarting());

        // Once the 'GameStarting' coroutine is finished, run the 'GamePlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine(GamePlaying());

        // Once execution has returned here, run the 'GameEnding' coroutine, again don't return until it's finished.
        yield return StartCoroutine(GameEnding());

        // This code is not run until 'GameEnding' has finished.  At which point, check if a game winner has been found.
        switch (gameState)
        {
            case GameState.Won:
                // If there is a game winner, restart the level.
                SceneManager.LoadScene("GUI");
                break;
            case GameState.Lost:
                // If game is lost, restart the level.


                /*
                // TODO : End game camera animation
                gameObject.AddComponent<Camera>();
                Camera endCamera = gameObject.GetComponent<Camera>();
                endCamera.transform.position = Vector3.Lerp(new Vector3(0, 100, 0), new Vector3(0, 100, 0), 0.5f);
                endCamera.transform.rotation = Quaternion.Slerp(new Quaternion(0, 0, 0, 0), new Quaternion(0, 0, 0, 0), 0.5f);
                */
                /*
                if (PlayerPrefs.GetInt("highestScore") < int.Parse(scoreText.text.Substring(6)))
                    PlayerPrefs.SetInt("highestScore", int.Parse(scoreText.text.Substring(6)));
                    */
                SceneManager.LoadScene("GUI");
                break;
            case GameState.Playing:
                // If there isn't a winner yet, restart this coroutine so the loop continues.
                // Note that this coroutine doesn't yield.  This means that the current version of the GameLoop will end.
                StartCoroutine(GameLoop());
                break;
        }
    }


    private IEnumerator GameStarting()
    {
        Debug.Log("char : " + playerPrefabs[PlayerPrefs.GetInt("charSelected")]);
        Instantiate(playerPrefabs[PlayerPrefs.GetInt("charSelected")], new Vector3(36, 1, -12), new Quaternion(0, 0, 0, 0));

        gameState = GameState.Playing;

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return startWait;
    }


    private IEnumerator GamePlaying()
    {

        do
        {
            // ... return on the next frame.
        } while (!GameFinished());
        yield return endWait;
    }


    private IEnumerator GameEnding()
    {
        // Wait for the specified length of time until yielding control back to the game loop.
        yield return endWait;
        
    }

    private bool GameFinished()
    {
        return true; // condition to end game
    }
}
