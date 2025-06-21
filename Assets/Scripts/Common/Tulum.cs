using UnityEngine;

public class Tulum : MonoBehaviour
{
    public GameObject tulumPrefab;
    public GameObject[] model;
    public Transform handAttachPoint;
    public Vector3 rotationOffset;
    public string takildiktanSonrakiLayerAdi = "esya";

    private static bool tulumTakildi = false; // T�m sahne i�in ge�erli kontrol

    void OnTriggerEnter(Collider other)
    {
        if (tulumTakildi) return;

        if (other.CompareTag("sol") || other.CompareTag("sag"))
        {
            EquipTulum();
            tulumTakildi = true;
            Debug.Log("Tulum tak�ld�.");
        }
    }

    void EquipTulum()
    {
        if (handAttachPoint == null)
        {
            Debug.LogWarning("El tak�lma noktas� atanmad�!");
            return;
        }

        GameObject yeniTulum = Instantiate(tulumPrefab, handAttachPoint);
        yeniTulum.transform.localPosition = Vector3.zero;
        yeniTulum.transform.localRotation = Quaternion.Euler(rotationOffset);

        gameObject.SetActive(false); // Bu obje art�k dokunulamaz

        int yeniLayer = LayerMask.NameToLayer(takildiktanSonrakiLayerAdi);
        if (yeniLayer == -1)
        {
            Debug.LogWarning("Layer ad� bulunamad�: " + takildiktanSonrakiLayerAdi);
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
