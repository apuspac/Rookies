using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Rookies.Inputs
{
    /// <summary>
    ///  input の interface部分
    /// 実装は keyInput.csで担当
    /// Moverは Interface 通して使う
    /// </summary>
    public interface IInputProvider
    {
        // MoveDirection 購読で 入力検知
        IReadOnlyReactiveProperty<Vector3> MoveDirection{ get; }

    }
}
