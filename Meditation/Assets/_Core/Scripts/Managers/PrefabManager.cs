using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TextPopup.Create(Vector3.zero, 3);
        }
    }


    public static PrefabManager Instance;
    public static PrefabManager Inst
    {
        get
        {
            if(Instance == null)
            {
                Instance = Instantiate(Resources.Load<PrefabManager>("PrefabManager"));
            }
                return Instance;
        }
    }

    public Transform damagePopup;



}
