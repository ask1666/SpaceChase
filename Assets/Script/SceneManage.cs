using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
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
