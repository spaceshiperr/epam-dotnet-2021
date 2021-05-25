using System;
using System.Threading;

namespace DelegateApp
{
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

    public class Countdown
    {
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;

        public void DoSomething()
        {
            OnRaiseCustomEvent(new CustomEventArgs("Event triggered"));
        }

        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> raiseEvent = RaiseCustomEvent;

            if (raiseEvent != null)
            {
                e.Message += $" at {DateTime.Now}";

                raiseEvent(this, e);
            }
        }
    }

    public class Subscriber
    {
        private readonly string _id;

        public Subscriber(string id, Countdown countdown, TimeSpan ts)
        {
            _id = id;

            countdown.RaiseCustomEvent += HandleCustomEvent;

            Thread.Sleep(ts);
        }

        void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine($"{_id} received this message: {e.Message}");
        }
    }
}
