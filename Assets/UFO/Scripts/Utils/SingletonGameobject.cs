using UnityEngine;

public class SingletonGameobject<T> : MonoBehaviour where T : Object
{
    [SerializeField] protected bool isDontDestroyOnLoad = false;
    protected static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                if (FindObjectOfType<T>() != null)
                {
                    instance = FindObjectOfType<T>();
                }
                else
                {
                    var fromResource = Resources.Load<T>(typeof(T).Name);
                    instance = Instantiate(fromResource);
                    instance.name = typeof(T).Name;
                }  
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        if (isDontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
