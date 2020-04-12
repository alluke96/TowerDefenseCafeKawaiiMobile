using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------
    // Singleton
    //----------------------------------------------------------------------------------------------------------------
    public static GameController Instance { get; private set; }
    
    //----------------------------------------------------------------------------------------------------------------
    // Serialized fields
    //----------------------------------------------------------------------------------------------------------------
    [SerializeField] private int _maxFails = 5;
    [SerializeField] private Text _failsText;
    [SerializeField] private Text _scoreText;
    
    //----------------------------------------------------------------------------------------------------------------
    // Non-serialized fields
    //----------------------------------------------------------------------------------------------------------------
    private int _fails;
    private int _score;
    
    //----------------------------------------------------------------------------------------------------------------
    // Unity events
    //----------------------------------------------------------------------------------------------------------------
    private void Start()
    {
        Instance = this;
    }
    
    private void Update()
    {
        _scoreText.text = $"Pontos: {_score}"; 
        _failsText.text = $"Fails: {_fails} de {_maxFails}";
    }

    //----------------------------------------------------------------------------------------------------------------
    // Public methods
    //----------------------------------------------------------------------------------------------------------------
    public void AddFails()
    {
        if (_fails < _maxFails)
        {
            Debug.Log("Fail");
            _fails++;
            return; 
        }
        
        SceneManager.LoadScene("EndScene");
    }
    public void Score()
    {
        Debug.Log("Score");
        _score++;
    }
}
