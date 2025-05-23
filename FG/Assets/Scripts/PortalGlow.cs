using UnityEngine;

public class PortalGlow : MonoBehaviour
{
    public Color emissionColor = Color.cyan;
    public float emissionIntensity = 5f;

    void Start()
    {
        Transform entry = transform.Find("portal.entry");
        if (entry == null)
        {
            Debug.LogWarning("Не найден объект 'portal.entry'");
            return;
        }

        Renderer rend = entry.GetComponent<Renderer>();
        if (rend == null)
        {
            Debug.LogWarning("У 'portal.entry' отсутствует Renderer");
            return;
        }

        Material mat = rend.material;
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", emissionColor * emissionIntensity);
        Debug.Log("Свечение включено для 'portal.entry'");
    }
}