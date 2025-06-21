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
                    Debug.Log("n1 kontrol� yap�ld�.");
                    break;
                case Kontroller.n2:
                    n2 = true;
                    Debug.Log("n2 kontrol� yap�ld�.");
                    break;
                case Kontroller.n3:
                    n3 = true;
                    Debug.Log("n3 kontrol� yap�ld�.");
                    break;
                case Kontroller.n4:
                    n4 = true;
                    Debug.Log("n4 kontrol� yap�ld�.");
                    break;
            }
        }
        else
        {
            Debug.LogWarning("Ge�ersiz kontrol ad�: " + kontrolStr);
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
                    Debug.Log("n1 kontrol� kapat�ld�.");
                    break;
                case Kontroller.n2:
                    n2 = false;
                    Debug.Log("n2 kontrol� kapat�ld�.");
                    break;
                case Kontroller.n3:
                    n3 = false;
                    Debug.Log("n3 kontrol� kapat�ld�.");
                    break;
                case Kontroller.n4:
                    n4 = false;
                    Debug.Log("n4 kontrol� kapat�ld�.");
                    break;
            }
        }
        else
        {
            Debug.LogWarning("Ge�ersiz kontrol ad�: " + kontrolStr);
        }
    }
}
