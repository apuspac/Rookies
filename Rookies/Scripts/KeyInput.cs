using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

using Rookies.Inputs;

namespace Rookies.Players
{
    /// <summary>
    /// keyinput 関連を担当
    /// InputProvider のインターフェースを継承
    /// </summary>
    public class KeyInput : MonoBehaviour, IInputProvider
    {
        //Reactivepropertyってのは、 値が変化した時に イベント発行してくれる。
        //なんかのinputがあったら その変更値と一緒に変化したぞっていうのを送ってくれる。
        private readonly ReactiveProperty<Vector3> _moveDirection = new ReactiveProperty<Vector3>();

        // interfaceを privateのreactiveを購読して 実装
        public IReadOnlyReactiveProperty<Vector3> MoveDirection => _moveDirection;
        // Start is called before the first frame update
        void Start()
        {
            //updateの代わりのようなもの
            this.UpdateAsObservable()
                .Select(_ =>
                    new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0))
                .Subscribe(move => _moveDirection.SetValueAndForceNotify(move));
                //SetValueAndForceNotifyで通知をとばせるっぽい

        }

    }
}
