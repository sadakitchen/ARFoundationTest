using UnityEngine;

public class SpawnTrace : MonoBehaviour
{
    [SerializeField] private GameObject m_Tracer;
    [SerializeField] private string m_TagName;
    [SerializeField] private float speed = 0.1f;

    private GameObject _targetObject;

    void Update()
    {
        _targetObject = GetTargetObject(m_TagName);
        if (_targetObject == null) return;

        Vector3 relativePos = _targetObject.transform.position - m_Tracer.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        m_Tracer.transform.rotation = Quaternion.Slerp(m_Tracer.transform.rotation, rotation, speed);

        m_Tracer.transform.position = Vector3.MoveTowards(m_Tracer.transform.position, _targetObject.transform.position,
            speed * Time.deltaTime);
    }

    private GameObject GetTargetObject(string tagName)
    {
        float nearDis = 0;
        GameObject targetObj = null;

        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            var tmpDis = Vector3.Distance(obs.transform.position, m_Tracer.transform.position);

            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }
        }

        return targetObj;
    }
}