using Code;
using UnityEngine;

public class TongueSection : MonoBehaviour
{
    [SerializeField] private TongueParams m_params;

    public void SetParam(TongueParams param)
    {
        m_params = param;
        RefreshParams();
    }

    private void RefreshParams()
    {
        // TODO
    }

    private void Update()
    {
        RefreshParams();
    }
}