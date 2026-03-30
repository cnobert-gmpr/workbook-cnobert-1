using UnityEngine;
using UnityEngine.UIElements;

namespace GMPR2512.Lesson08ScenesAndUI
{
    public class Scene02_UI : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        private Label _scoreLevel01;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            _scoreLevel01 = root.Q<Label>("label-score");
            _scoreLevel01.text = _gameState.ScoreLevel01.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            _scoreLevel01.text = _gameState.ScoreLevel01.ToString();
        }
    }
}
