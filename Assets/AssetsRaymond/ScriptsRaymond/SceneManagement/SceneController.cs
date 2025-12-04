using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;



/*public class SceneController : MonoBehaviour
{
    public PlayableDirector timelineDirector; // Reference to the PlayableDirector that controls the Timeline
    public string nextScene; // Name of the next scene to load, set this in the Unity Inspector

    void Start()
    {
        // Ensure that the OnTimelineFinished function is called when the Timeline completes its playback
        timelineDirector.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        // Load Scene 2 when the Timeline has finished playing
        PlayerPrefs.SetInt("IsNewGame", 1); // Ensure that the next scene treats the start as a new game
        SceneManager.LoadScene("EnvironmentLevel2Original");
    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene("Level3SceneName"); // Replace "Level3SceneName" with the actual scene name
    }
}*/

public class SceneController : MonoBehaviour
{
    public PlayableDirector timelineDirector; // Reference to the PlayableDirector that controls the Timeline
    public string nextScene; // Name of the next scene to load, set this in the Unity Inspector

    void Start()
    {
        // Ensure that the OnTimelineFinished function is called when the Timeline completes its playback
        timelineDirector.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        Debug.Log("Timeline finished. Loading scene: " + nextScene); // Debugging line
        // Load next scene when the Timeline has finished playing
        PlayerPrefs.SetInt("IsNewGame", 1);
        SceneManager.LoadScene(nextScene);
    }
}