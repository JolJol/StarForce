//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        public static BuiltinDataComponent BuiltinData
        {
            get;
            private set;
        }

        public static HPBarComponent HpBar
        {
            get;
            private set;
        }

        public static EnemyComponent EnemyManager
        {
            get;
            private set;
        }
        private static void InitCustomComponents()
        {
            BuiltinData = UnityGameFramework.Runtime.GameEntry.GetComponent<BuiltinDataComponent>();
            HpBar = UnityGameFramework.Runtime.GameEntry.GetComponent<HPBarComponent>();
            EnemyManager = UnityGameFramework.Runtime.GameEntry.GetComponent<EnemyComponent>();
        }
    }
}
