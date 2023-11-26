using UnityEngine;

public class Shooter : MonoBehaviour
{
    private Projectile _projectile;

   public void LaunchProjectile(GameObject projectilePrefab, float damage, float speed)
    {
        try
        {
            // ToDo rewrite to ObjectPool
            GameObject projectile = Instantiate(projectilePrefab, transform);
            GetProjectileReference(projectile);

            ConstructAndLaunch(damage, speed);

            ResetScale(projectile);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void GetProjectileReference(GameObject projectile) =>
       _projectile = projectile.GetComponent<Projectile>();
    private void ConstructAndLaunch(float damage, float speed)
    {
        _projectile.Construct(damage, speed);
        _projectile.Launch();
    }

    private void ResetScale(GameObject projectile)
    {
        projectile.transform.parent = null;
        projectile.transform.localScale = Vector3.one;
    }
}
