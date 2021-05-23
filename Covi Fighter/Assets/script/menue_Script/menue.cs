using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menue : MonoBehaviour
{
    public void PlayGame(){
        StartCoroutine(loadlevel(SceneManager.GetActiveScene().buildIndex+1));
    }
    public void QuitGame(){
        Application.Quit();
    }
    IEnumerator loadlevel(int loadindex){
        SceneManager.LoadScene(loadindex);
        yield return new WaitForSeconds(1f);
    }   
}
