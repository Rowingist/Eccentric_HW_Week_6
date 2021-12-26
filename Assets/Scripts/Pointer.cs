using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Aim _aim;

    private void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);
        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        _aim.transform.position = point;

        Vector3 toAim = _aim.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
    }
}