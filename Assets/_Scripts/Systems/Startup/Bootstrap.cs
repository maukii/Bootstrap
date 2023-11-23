using UnityEngine;

public class Bootstrap : PersistentSingleton<Bootstrap>
{
    [SerializeField] Logger logger;


    private void Start() => logger.Log("Bootstrap singleton created by Bootstrapper", this);
}
