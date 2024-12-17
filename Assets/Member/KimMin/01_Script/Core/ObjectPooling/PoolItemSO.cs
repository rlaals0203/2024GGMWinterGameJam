using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Pool/Item")]
public class PoolItemSO : ScriptableObject
{
    public string poolName;
    public GameObject prefab;
    public int count;

    private void OnValidate()
    {
        if (prefab != null)
        {
            IPoolable item = prefab.GetComponent<IPoolable>();

            if (item == null)
            {
                Debug.LogWarning($"Can't find IPoolable script on prefab : check! {prefab.name}");
                prefab = null;
            }
            else
            {
                return;
            }
        }
    }
}
