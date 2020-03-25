using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneManage : MonoBehaviour {

    public GameObject loadingScreen;
    public GameObject loadingIcon;
    public float loadingIconSpeed;

    // Start is called before the first frame update
    void Start() {

        if (SceneManager.GetActiveScene().name.Equals("MainMenu")) {
            loadingScreen.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update() {

    }

    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void PlayGame() {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadYourAsyncScene());
        
    }

    IEnumerator LoadYourAsyncScene() {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainGame");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) {
            loadingIcon.transform.Translate(Vector2.right * loadingIconSpeed);
            yield return null;
        }
    }

    public void OnPointerDown(Button btnPressed) {
        btnPressed.GetComponent<Animator>().SetTrigger("Pressed");
        btnPressed.GetComponent<AudioSource>().Play();
    }

    public void changeToPreviousScene() {
        SceneManager.LoadScene(GameObject.Find("GameControl").GetComponent<Score>().previousScene);
    }

    public void ResetData() {
        PlayerData playerData = new PlayerData(0, 30, 0, "Player2", 5f);
        SaveSystem.SavePlayerData(playerData);
        SceneManager.LoadScene("MainMenu");
    }
}
