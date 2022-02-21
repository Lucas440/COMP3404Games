using System;

namespace Engine.Command
{
    public class CommandOneParam<T> : ICommandOneParam<T>
    {
        //The data of the Action
        private T _parameter;
        //the action that will be invoked
        private Action<T> _action;
        /// <summary>
        /// A parameter that sets a data type
        /// </summary>
        public T SetData { set { _parameter = value; } }
        /// <summary>
        /// A parameter that sets a Action
        /// </summary>
        public Action<T> SetAction { set { _action = value; } }

        public void Execute()
        {
            _action.Invoke(_parameter);
        }
    }
}
