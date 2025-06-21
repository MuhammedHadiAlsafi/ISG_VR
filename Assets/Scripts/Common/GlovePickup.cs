using UnityEngine;

public class GlovePickup : MonoBehaviour
{
    public enum HandType { Left, Right }
    public HandType handType;

    public GameObject glovePrefab;         // Eldiven prefab�
    public Transform handAttachPoint;      // Eldivenin tak�laca�� yer (el bo�lu�u)

    public Vector3 rotationOffset;         // D��ar�dan girilecek rotasyon de�eri (Euler)

    private static bool leftHandUsed = false;
    private static bool rightHandUsed = false;

    void OnTriggerEnter(Collider other)
    {
        if (handType == HandType.Left && !leftHandUsed && other.CompareTag("sol"))
        {
            EquipGlove(other.transform);
            Debug.Log("Sol eldiven al�nd� ve tak�ld�.");
            leftHandUsed = true;
        }
        else if (handType == HandType.Right && !rightHandUsed && other.CompareTag("sag"))
        {
            EquipGlove(other.transform);
            Debug.Log("Sa� eldiven al�nd� ve tak�ld�.");
            rightHandUsed = true;
        }
    }

    void EquipGlove(Transform playerHand)
    {
        foreach (Transform child in playerHand)
        {
            child.gameObject.SetActive(false);
        }

        // E�er handAttachPoint atanm��sa, onun yerine tak
        Transform attachPoint = handAttachPoint != null ? handAttachPoint : playerHand;

        GameObject newGlove = Instantiate(glovePrefab, attachPoint);
        newGlove.transform.localPosition = Vector3.zero;
        newGlove.transform.localRotation = Quaternion.Euler(rotationOffset);

        gameObject.SetActive(false);
    }

}
