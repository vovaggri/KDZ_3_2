using System;
namespace ClassLibrary
{
    // Событие, которое помогает отслеживать время.
    public class ObjectUpdatedEventArgs : EventArgs
    {
        public DateTime UpdateDateTime { get; }

        public ObjectUpdatedEventArgs()
        {
            UpdateDateTime = DateTime.Now;
        }
    }
}

