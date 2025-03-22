using UnityEngine;

public class CreateFireSpark : MonoBehaviour
{
    // 生成するパーティクル
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject redSparkPrefab;
    [SerializeField] GameObject greenSparkPrefab;
    [SerializeField] GameObject blueSparkPrefab;

    // 生成する位置
    [SerializeField] Transform[] createPositions;

    // 生成時のSE
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip sparkSound;
    AudioSource audioSource;

    void Start()
    {
        // 音を鳴らす用の AudioSource を追加
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    // 爆発パーティクル生成メソッド
    public void CreateExplosion()
    {
        // 各生成ポジションを取得し、紙吹雪のパーティクルを生成
        foreach (Transform pos in createPositions)
        {
            Instantiate(explosionPrefab, pos.transform.position, pos.rotation);
        }

        // SEが設定されていたら鳴らす
        if (explosionSound != null)
        {
            audioSource.PlayOneShot(explosionSound);
        }
    }

    // 赤色スパークパーティクル生成メソッド
    public void CreateRedSpark()
    {
        // 各生成ポジションを取得し、紙吹雪のパーティクルを生成
        foreach (Transform pos in createPositions)
        {
            Instantiate(redSparkPrefab, pos.transform.position, pos.rotation);
        }

        // SEが設定されていたら鳴らす
        if (sparkSound != null)
        {
            audioSource.PlayOneShot(sparkSound);
        }
    }

    // 緑色スパークパーティクル生成メソッド
    public void CreateGreenSpark()
    {
        // 各生成ポジションを取得し、紙吹雪のパーティクルを生成
        foreach (Transform pos in createPositions)
        {
            Instantiate(greenSparkPrefab, pos.transform.position, pos.rotation);
        }

        // SEが設定されていたら鳴らす
        if (sparkSound != null)
        {
            audioSource.PlayOneShot(sparkSound);
        }
    }

    // 青色スパークパーティクル生成メソッド
    public void CreateBlueSpark()
    {
        // 各生成ポジションを取得し、紙吹雪のパーティクルを生成
        foreach (Transform pos in createPositions)
        {
            Instantiate(blueSparkPrefab, pos.transform.position, pos.rotation);
        }

        // SEが設定されていたら鳴らす
        if (sparkSound != null)
        {
            audioSource.PlayOneShot(sparkSound);
        }
    }
}
