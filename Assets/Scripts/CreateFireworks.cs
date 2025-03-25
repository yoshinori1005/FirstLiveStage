using UnityEngine;

public class CreateFireworks : MonoBehaviour
{
    // 生成する花火
    [SerializeField] GameObject heartDancePrefab;
    [SerializeField] GameObject heartRingPrefab;
    [SerializeField] GameObject starDancePrefab;
    [SerializeField] GameObject starRingPrefab;
    [SerializeField] GameObject fireworksPrefab;
    [SerializeField] GameObject fwRingPrefab;
    [SerializeField] GameObject fwYanagiPrefab;
    [SerializeField] GameObject fwBeePrefab;
    [SerializeField] GameObject fwClimaxPrefab;

    // 花火を生成する位置
    [SerializeField] Transform spawnPoint;

    // 現在の花火を記録
    GameObject currentFirework;

    private void CreateFirework(GameObject fireworkPrefab)
    {
        // すでにシーンに花火が存在した場合は削除
        if (currentFirework != null)
        {
            Destroy(currentFirework);
        }

        // 新しい花火を生成し、参照を保持
        currentFirework = Instantiate(
            fireworkPrefab,
            spawnPoint.transform.position,
            spawnPoint.rotation
            );
    }

    // ハートダンス花火を生成するメソッド
    public void CreateHeartDance()
    {
        CreateFirework(heartDancePrefab);
    }

    // ハートリング花火を生成するメソッド
    public void CreateHeartRing()
    {
        CreateFirework(heartRingPrefab);
    }

    // スターダンス花火を生成するメソッド
    public void CreateStarDance()
    {
        CreateFirework(starDancePrefab);
    }

    // スターリング花火を生成するメソッド
    public void CreateStarRing()
    {
        CreateFirework(starRingPrefab);
    }

    // 通常花火を生成するメソッド
    public void CreateNormalFireworks()
    {
        CreateFirework(fireworksPrefab);
    }

    // リング花火を生成するメソッド
    public void CreateRingFireworks()
    {
        CreateFirework(fwRingPrefab);
    }

    // ヤナギ花火を生成するメソッド
    public void CreateYanagiFireworks()
    {
        CreateFirework(fwYanagiPrefab);
    }

    // ハチ花火を生成するメソッド
    public void CreateBeeFireworks()
    {
        CreateFirework(fwBeePrefab);
    }

    // クライマックス花火を生成するメソッド
    public void CreateClimaxFireworks()
    {
        CreateFirework(fwClimaxPrefab);
    }
}
