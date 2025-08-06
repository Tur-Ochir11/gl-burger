using UnityEngine;

public class Utilities : MonoBehaviour
{
    public static bool AreSameBurgers(Burger a, Burger b)
    {
        if (a.resources.Count != b.resources.Count) return false;
        
        for (int i = 0; i < a.resources.Count; i++)
        {
            if (a.resources[i].type != b.resources[i].type)
                return false;
        }
        return true;
    }
}