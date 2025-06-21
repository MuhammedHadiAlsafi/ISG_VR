using UnityEngine;

public class DENEME : MonoBehaviour
{
    public bool n1, n2, n3, n4;

    public enum Kontroller
    {
        n1,
        n2,
        n3,
        n4
    }

    public void On(string kontrolStr)
    {
        if (System.Enum.TryParse(kontrolStr, out Kontroller kontrol))
        {
            switch (kontrol)
            {
                case Kontroller.n1:
                    n1 = true;
                    Debug.Log("n1 kontrolü yapýldý.");
                    break;
                case Kontroller.n2:
                    n2 = true;
                    Debug.Log("n2 kontrolü yapýldý.");
                    break;
                case Kontroller.n3:
                    n3 = true;
                    Debug.Log("n3 kontrolü yapýldý.");
                    break;
                case Kontroller.n4:
                    n4 = true;
                    Debug.Log("n4 kontrolü yapýldý.");
                    break;
            }
        }
        else
        {
            Debug.LogWarning("Geçersiz kontrol adý: " + kontrolStr);
        }
    }

    public void Exit(string kontrolStr)
    {
        if (System.Enum.TryParse(kontrolStr, out Kontroller kontrol))
        {
            switch (kontrol)
            {
                case Kontroller.n1:
                    n1 = false;
                    Debug.Log("n1 kontrolü kapatýldý.");
                    break;
                case Kontroller.n2:
                    n2 = false;
                    Debug.Log("n2 kontrolü kapatýldý.");
                    break;
                case Kontroller.n3:
                    n3 = false;
                    Debug.Log("n3 kontrolü kapatýldý.");
                    break;
                case Kontroller.n4:
                    n4 = false;
                    Debug.Log("n4 kontrolü kapatýldý.");
                    break;
            }
        }
        else
        {
            Debug.LogWarning("Geçersiz kontrol adý: " + kontrolStr);
        }
    }
}
