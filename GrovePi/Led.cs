﻿using System;

namespace GrovePi
{
    public interface ILed
    {
        LedStatus CurrentState { get; }
        void ChangeState(LedStatus newState);
    }

    public enum LedStatus
    {
        Off = 0,
        On = 1
    }

    internal class Led : ILed
    {
        private readonly IGrovePi _device;
        private readonly Pin _pin;

        internal Led(IGrovePi device, Pin pin)
        {
            if (device == null) throw new ArgumentNullException(nameof(device));
            device.PinMode(_pin, PinMode.Output);
            _device = device;
            _pin = pin;
        }

        public void ChangeState(LedStatus newState)
        {
            _device.DigitalWrite(_pin, (byte) newState);
        }

        public LedStatus CurrentState => (LedStatus) _device.DigitalRead(_pin);
    }
}