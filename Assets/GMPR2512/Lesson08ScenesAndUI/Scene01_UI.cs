using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace GMPR2512.Lesson08ScenesAndUI
{
    public class Scene01_UI : MonoBehaviour
    {
        private Button _buttonChangeToScene02;
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            _buttonChangeToScene02 = root.Q<Button>("buttonOpenScene02");
            if(_buttonChangeToScene02 != null)
            {
                _buttonChangeToScene02.clicked += ChangeToScene02;
            }
        }

        private void OnDisable()
        {
            if(_buttonChangeToScene02 != null)
            {
                _buttonChangeToScene02.clicked -= ChangeToScene02;
            }
        }

        private void ChangeToScene02()
        {
            // NOTE: this scene will only successfully open if it is in the scene list,
            // which can be set up in the Unity Editor like:
            // File -> Build Profiles
            SceneManager.LoadScene(2); //SceneManager.LoadScene("Scene01");
        }
    }
}
