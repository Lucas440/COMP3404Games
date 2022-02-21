using System.Collections.Generic;
/// <summary>
/// Author Lucas Brennan
/// 
///DATE 22/01/22
/// </summary>
namespace Engine.Command
{
    /// <summary>
    /// A class that schedules commands
    /// </summary>
    public class CommandScheduler : ICommandScheduler
    {
        //DELCARE a new IList called _commandList
        IList<ICommand> _commandList;
        /// <summary>
        /// The defualt constructor
        /// </summary>
        public CommandScheduler()
        {
            //INTIALSE the list
            _commandList = new List<ICommand>();
        }

        /// <summary>
        /// A method used for scheduling commands
        /// </summary>
        /// <param name="pCommand">The command being scheduled</param>
        public void ExecuteCommand(ICommand pCommand)
        {
            //Adds the command to the list
            _commandList.Add(pCommand);
        }
        /// <summary>
        /// A MEthod that updates the commandScheduler
        /// </summary>
        public void Update()
        {
            //loops through each command in the list and Executes it
            foreach (ICommand c in _commandList)
                c.Execute();
        }
    }
}
