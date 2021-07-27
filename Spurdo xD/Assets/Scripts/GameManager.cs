using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tower
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameObject player;
        public bool mobileBuild = false;
        public int frameRate = 60;
        // Start is called before the first frame update
        void Awake()
        {
            //DontDestroyOnLoad(this.gameObject);
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
                Instance = this;

            Time.timeScale = 1f;
            Application.targetFrameRate = frameRate;
        }

        public void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public bool IsMobilebuild()
        {
            return mobileBuild;
        }
    }
}
