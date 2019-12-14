using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private string m_TagName;
    [SerializeField] private Text m_ScoreText;
    private int _score = 0;
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(m_TagName))
        {
            Destroy(collision.gameObject);
            _score++;
            m_ScoreText.text = _score.ToString();
        }
    }
}
