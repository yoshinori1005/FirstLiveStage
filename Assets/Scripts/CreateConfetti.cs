using UnityEngine;

public class CreateConfetti : MonoBehaviour
{
    // 生成するパーティクル
    [SerializeField] GameObject goldConfettiPrefab;
    [SerializeField] GameObject silverConfettiPrefab;

    // 生成位置
    [SerializeField] Transform[] createPositions;

    // 生成時のSE
    [SerializeField] AudioClip confettiSound;
    AudioSource audioSource;

    void Start()
    {
        // 音を鳴らす用の AudioSource を追加
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    // 紙吹雪生成メソッド
    public void CreateParticle()
    {
        // 各生成ポジションを取得し、紙吹雪のパーティクルを生成
        foreach (Transform pos in createPositions)
        {
            Instantiate(goldConfettiPrefab, pos.transform.position, pos.rotation);
            Instantiate(silverConfettiPrefab, pos.transform.position, pos.rotation);
        }

        // SEが設定されていたら鳴らす
        if (confettiSound != null)
        {
            audioSource.PlayOneShot(confettiSound);
        }
    }
}
