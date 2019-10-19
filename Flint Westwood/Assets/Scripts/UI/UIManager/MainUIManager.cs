using TMPro;
using UnityEngine;

namespace UI.UIManager
{
    public class MainUIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthText;

        public Player player;
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(player);
            Debug.Log(player.CurrentHealth);
            healthText.SetText("Health: " + player.CurrentHealth);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
