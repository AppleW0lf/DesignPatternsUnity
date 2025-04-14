using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy.Test_2
{
    public class CharacterWithoutStrategy : MonoBehaviour
    {
        public enum MoveType
        { Walk, Run, Fly }

        private MoveType currentMoveType = MoveType.Walk;

        private float walkSpeed = 2f;
        private float runSpeed = 5f;
        private float flySpeed = 3f;

        public void Update()
        {
            switch (currentMoveType)
            {
                case MoveType.Walk:
                    transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
                    break;

                case MoveType.Run:
                    transform.Translate(Vector2.right * runSpeed * Time.deltaTime);
                    break;

                case MoveType.Fly:
                    transform.Translate(Vector2.up * flySpeed * Time.deltaTime);
                    break;
            }
        }

        public void SetMoveType(MoveType moveType)
        {
            currentMoveType = moveType;
        }
    }
}