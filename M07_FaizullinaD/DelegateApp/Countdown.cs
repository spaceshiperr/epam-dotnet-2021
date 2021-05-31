using System;
using System.Threading;

namespace DelegateApp
{
    public class CountdownEventArgs : EventArgs
    {
        public CountdownEventArgs(string message, TimeSpan timeout)
        {
            Message = message;
            Timeout = timeout;
        }

        public string Message { get; set; }

        public TimeSpan Timeout { get; set; }
    }

    public class Countdown
    {
        public event EventHandler<CountdownEventArgs> RaiseCountdownEvent;

        public void DoSomething(string message, TimeSpan timeout)
        {
            OnRaiseCountdownEvent(new CountdownEventArgs(message, timeout));
        }

        protected virtual void OnRaiseCountdownEvent(CountdownEventArgs e)
        {
            EventHandler<CountdownEventArgs> raiseEvent = RaiseCountdownEvent;

            if (raiseEvent != null)
            {
                Thread.Sleep(e.Timeout);
                raiseEvent(this, e);
            }
        }
    }

    public class Subscriber
    {
        private readonly string id;

        public Subscriber(string id, Countdown countdown)
        {
            this.id = id;
            countdown.RaiseCountdownEvent += HandleCountdownEvent;
        }

        void HandleCountdownEvent(object sender, CountdownEventArgs e)
        {
            Console.WriteLine($"{id} received this message \"{e.Message}\" after timeout of {e.Timeout}");
        }
    }
}
