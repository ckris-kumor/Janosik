using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.ZiomakiStudios.Janosik{
    public class LoadMainGame : MonoBehaviour
    {

        public void LoadingMainScene()
        {
            SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
        }
    }
}

