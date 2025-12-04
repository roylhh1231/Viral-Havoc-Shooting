using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeath : StateMachineBehaviour
{
    // 场景名称
    public string nextSceneName;

    // 在动画状态机进入这个状态时调用
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 在此可以初始化一些状态，比如重置变量
    }

    // 在动画状态机更新时调用
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 在此可以处理一些持续的状态更新
    }

    // 在动画状态机退出这个状态时调用
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 当状态退出时加载下一个场景
        SceneManager.LoadScene(nextSceneName);
    }
}
