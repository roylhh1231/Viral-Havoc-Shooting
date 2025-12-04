using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeathState : MonoBehaviour
{
    // 场景名称
    public string nextSceneName;

    // 当死亡动画完成时调用此函数
    public void OnDeathAnimationComplete()
    {
        // 加载指定的场景
        SceneManager.LoadScene(nextSceneName);
    }
}
