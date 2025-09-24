using UnityEngine;

public class SliceableFruit : MonoBehaviour
{
    [SerializeField] [Min(0)] private int nbSlicemin = 2;
    [SerializeField] [Min(0)] private int nbSlicemax = 4;
    [SerializeField] private GameObject[] prefabsSlices;
    [SerializeField] [Range(0, 10)] private float timeSliceForDestroy = 5;
    [SerializeField] private int pointmin;
    [SerializeField] private int pointmax;

    public void Slice()
    {
        for (var i = 0; i < Random.Range(nbSlicemin, nbSlicemax+1); i++)
        {
            var prefabSlice = prefabsSlices[i % prefabsSlices.Length];
            GameObject sliceObj = Instantiate(prefabSlice, transform.position + Random.insideUnitSphere*0.5f, Random.rotation, transform.parent);
            sliceObj.GetComponent<Rigidbody>().AddForce(transform.position + Random.insideUnitSphere*0.8f, ForceMode.Impulse);
            Destroy(sliceObj, timeSliceForDestroy);
        }
        GameObject.FindWithTag("GameController").GetComponent<Manager>().AddPoint(Random.Range(pointmin, pointmax+1));
        Destroy(gameObject);
    }
}
