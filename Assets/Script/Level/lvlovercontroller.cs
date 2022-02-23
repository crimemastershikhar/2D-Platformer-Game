using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlovercontroller : MonoBehaviour
{
    public string levelupdate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
//        if(collision.gameObject.CompareTag("Player"))
        if(collision.gameObject.GetComponent<playercontrolnew>() != null)
        {
            SceneManager.LoadScene(levelupdate);
            Debug.Log("Level Finished");
            levelmanager.Instance.MarkCurrentLevelComplete();   
        }
    }

}
