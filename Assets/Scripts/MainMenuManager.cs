using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _start;
    [SerializeField] private Button _rules;
    [SerializeField] private Button _close;
    [SerializeField] private GameObject _ruleScreen;


    public void StartGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void CloseRules() {
        _ruleScreen.SetActive(false);
    }

    public void ShowRules() {
        _ruleScreen.SetActive(true);
    }


}
