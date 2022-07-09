using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Rookies.Inputs;

namespace Rookies.Players
{
    public class PlayerMover : MonoBehaviour
    {
        // RigidBody使う。
        [SerializeField]private Rigidbody _rigidbody;
        [SerializeField]private float _speed = 3;


        // [SerializeField]private Vector3 moveDirection;

        /// <summary>
        /// _move 移動ベクトル保管用のvector3
        /// </summary>
        private Vector3 _move;



        void Start()
        {
            // interfaceを取ってくる
            // interfaceを使う理由は キーボードだったりgamepad操作だったりしてもinterface返すと
            // 同じ関数で扱えるため。
            var input = GetComponent<IInputProvider>();

            //input 情報をサブスクライブ
            input.MoveDirection
                .Subscribe(move => _move = move);

            //rigidbodyは fixedUpdateじゃないと 上手く動かないとの情報を得た。
            //fixedUpdate は、1フレーム間のいろんな計算の中で、物理演算の前に呼ばれる処理なので、rigidbodyはここで呼ぶ。
            this.FixedUpdateAsObservable()
                .Subscribe(_ =>
                {
                    _rigidbody.MovePosition(transform.position +  _move * _speed * Time.fixedDeltaTime);
                });
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
