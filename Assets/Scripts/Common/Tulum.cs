using UnityEngine;

public class Tulum : MonoBehaviour
{
    public GameObject tulumPrefab;
    public GameObject[] model;
    public Transform handAttachPoint;
    public Vector3 rotationOffset;
    public string takildiktanSonrakiLayerAdi = "esya";

    private static bool tulumTakildi = false; // Tüm sahne için geçerli kontrol

    void OnTriggerEnter(Collider other)
    {
        if (tulumTakildi) return;

        if (other.CompareTag("sol") || other.CompareTag("sag"))
        {
            EquipTulum();
            tulumTakildi = true;
            Debug.Log("Tulum takýldý.");
        }
    }

    void EquipTulum()
    {
        if (handAttachPoint == null)
        {
            Debug.LogWarning("El takýlma noktasý atanmadý!");
            return;
        }

        GameObject yeniTulum = Instantiate(tulumPrefab, handAttachPoint);
        yeniTulum.transform.localPosition = Vector3.zero;
        yeniTulum.transform.localRotation = Quaternion.Euler(rotationOffset);

        gameObject.SetActive(false); // Bu obje artýk dokunulamaz

        int yeniLayer = LayerMask.NameToLayer(takildiktanSonrakiLayerAdi);
        if (yeniLayer == -1)
        {
            Debug.LogWarning("Layer adý bulunamadý: " + takildiktanSonrakiLayerAdi);
        }
        else
        {
            SetLayerRecursive(yeniTulum, yeniLayer);
        }

        foreach (var item in model)
        {
            item.SetActive(false);
        }

        gameObject.SetActive(false);
    }
    void SetLayerRecursive(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;
        foreach (Transform child in obj.transform)
        {
            SetLayerRecursive(child.gameObject, newLayer);
        }
    }
}
