using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isInitialized;
    [SerializeField] private Transform[] points;
    [SerializeField] private float speed;

    private int currentIndex;

    public void Initialize()
    {
        isInitialized = true;
    }


    private void Update()
    {
        if (!isInitialized) return;

        Vector3 dest = new Vector3(points[currentIndex].position.x, transform.position.y, 0);
        transform.position =
            Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, dest) < 0.1f)
        {
            currentIndex = currentIndex == 1 ? 0 : 1;
        }
    }
}