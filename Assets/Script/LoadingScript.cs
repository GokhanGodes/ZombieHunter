using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

    public Image LoadingImage;
    public Text LoadingText;
	void Start () {
        LoadingImage.fillAmount = 0;

        StartCoroutine(LoadAsynchronously());
    }

    void Update () {

        //LoadingImage.fillAmount += Time.deltaTime;
        //LoadingText.text = (LoadingImage.fillAmount * 100).ToString();
        //if(LoadingImage.fillAmount==1)
        //{
        //    SceneManager.LoadScene("SampleScene");
        //}

	}
    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("SampleScene");

        while (!operation.isDone)
        {
            LoadingImage.fillAmount = operation.progress;
            LoadingText.text =((int) (operation.progress * 100)).ToString() + " %";
            yield return null;
        }
    }
}
