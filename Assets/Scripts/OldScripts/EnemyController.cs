using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------
    // Constants
    //----------------------------------------------------------------------------------------------------------------
    private const string TrashTag = "Lixo";
    
    //----------------------------------------------------------------------------------------------------------------
    // Serialized fields
    //----------------------------------------------------------------------------------------------------------------
    [Header("Dependencies")] 
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private AudioClip _fail;
    
    //----------------------------------------------------------------------------------------------------------------
    // Non-serialized fields
    //----------------------------------------------------------------------------------------------------------------
    private GameController _gameController;
    private AudioSource _miss;

    //----------------------------------------------------------------------------------------------------------------
    // Unity events
    //----------------------------------------------------------------------------------------------------------------
    void Start()
    {
        _miss = GetComponent<AudioSource>();
        _gameController = GameController.Instance;
    }
    //----------------------------------------------------------------------------------------------------------------
    // Private methods
    //----------------------------------------------------------------------------------------------------------------
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(TrashTag))
        {
            _gameController.AddFails();
            _miss.PlayOneShot(_fail);
            Destroy(gameObject);
        }
    }
    // 0,1 Vector2 1 de comprimento
    // 0,-1 Vector2 1 de comprimento
    // Velocity(velocidade) possui direção e grandeza, enquanto speed(rapidez) é só grandeza.
    public void Initialize(float speed)
    {
        _rigidbody2D.velocity = Vector2.left*speed;
    }
}
