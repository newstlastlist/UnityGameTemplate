using System;
using Logic.Animations;
using UnityEngine;

namespace Game.Characters.Hero
{
    public class HeroAnimator : MonoBehaviour, IAnimationStateReader
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] public Animator _animator;

        private static readonly int MoveHash = Animator.StringToHash("Walking");
        private static readonly int CargroHash = Animator.StringToHash("Cargo");

        private readonly int _idleStateHash = Animator.StringToHash("Idle");
        private readonly int _walkingStateHash = Animator.StringToHash("Run");
        private readonly int _carryStateHash = Animator.StringToHash("HandCarry");

        public event Action<AnimatorState> StateEntered;
        public event Action<AnimatorState> StateExited;

        public AnimatorState State { get; private set; }

        private void Update()
        {
            _animator.SetFloat(MoveHash, _characterController.velocity.magnitude, 0.1f, 10 * Time.deltaTime);
        }

        public void ResetToIdle()
        {
            _animator.Play(_idleStateHash, -1);
        }

        public void EnteredState(int stateHash)
        {
            State = StateFor(stateHash);
            StateEntered?.Invoke(State);
        }

        public void ExitedState(int stateHash)
        {
            StateExited?.Invoke(StateFor(stateHash));
        }
        
        private void OnCargoCountChanged(int newCargoCount)
        {
            _animator.SetInteger(CargroHash, newCargoCount);
        }

        private AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;
            if (stateHash == _idleStateHash)
            {
                state = AnimatorState.Idle;
            }
            else if (stateHash == _walkingStateHash)
            {
                state = AnimatorState.Walk;
            }
            else if (stateHash == _carryStateHash)
            {
                state = AnimatorState.HandCarry;
            }
            else
            {
                state = AnimatorState.Unknown;
            }

            return state;
        }
    }
}