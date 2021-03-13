using UnityEngine;

namespace Player
{
    public class CooldownCounter
    {
        private readonly float _coolDownTime;
        private float _coolDownTimer;
        private bool _isCooldown = false;

        public bool IsCooldown => _isCooldown;

        public CooldownCounter(float timer)
        {
            _coolDownTime = timer;
        }

        public void CooldownTrigger()
        {
            _coolDownTimer = _coolDownTime;
            _isCooldown = true;
        }
        
        public void CooldownCount()
        {
            if (_isCooldown)
            {
                _coolDownTimer -= Time.deltaTime;
                if (_coolDownTimer <= 0)
                {
                    _isCooldown = false;
                }
            }
        }
    }
}