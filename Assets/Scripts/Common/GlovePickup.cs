using UnityEngine;

public class GlovePickup : MonoBehaviour
{
    public enum HandType { Left, Right }
    public HandType handType;

    public GameObject glovePrefab;         // Eldiven prefabý
    public Transform handAttachPoint;      // Eldivenin takýlacaðý yer (el boþluðu)

    public Vector3 rotationOffset;         // Dýþarýdan girilecek rotasyon deðeri (Euler)

    private static bool leftHandUsed = false;
    private static bool rightHandUsed = false;

    void OnTriggerEnter(Collider other)
    {
        if (handType == HandType.Left && !leftHandUsed && other.CompareTag("sol"))
        {
            EquipGlove(other.transform);
            Debug.Log("Sol eldiven alýndý ve takýldý.");
            leftHandUsed = true;
        }
        else if (handType == HandType.Right && !rightHandUsed && other.CompareTag("sag"))
        {
            EquipGlove(other.transform);
            Debug.Log("Sað eldiven alýndý ve takýldý.");
            rightHandUsed = true;
        }
    }

    void EquipGlove(Transform playerHand)
    {
        foreach (Transform child in playerHand)
        {
            child.gameObject.SetActive(false);
        }

        // Eðer handAttachPoint atanmýþsa, onun yerine tak
        Transform attachPoint = handAttachPoint != null ? handAttachPoint : playerHand;

        GameObject newGlove = Instantiate(glovePrefab, attachPoint);
        newGlove.transform.localPosition = Vector3.zero;
        newGlove.transform.localRotation = Quaternion.Euler(rotationOffset);

        gameObject.SetActive(false);
    }

}
