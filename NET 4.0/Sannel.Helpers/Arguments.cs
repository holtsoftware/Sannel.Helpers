using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if NET_4_5
using System.Threading.Tasks;
#endif

namespace Sannel
{
	/// <summary>
	/// This class parses command line arguments into Arguments, Values and NonArgumentValues. It expects arguments to be in the format --[name]=[value] or /[name]=[value]. Name can be a-z,A-Z,0-9,-,_. 
	/// </summary>
	public class Arguments
	{
		/// <summary>
		/// Creates a new Arguments class but does not parse anything until the parse method is called
		/// </summary>
		public Arguments()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates a new Arguments class and parses the provided array
		/// </summary>
		/// <param name="args">The array to parse</param>
		public Arguments(String[] args)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns true if the specified name was passed as an argument false otherwise
		/// </summary>
		/// <param name="name">The name of the argument to look for</param>
		/// <returns>True if the argument was found false if not</returns>
		public bool HasArgument(String name)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns a String representing the value passed to the argument name or null if none was passed or name does not exist
		/// </summary>
		/// <param name="name">The name of the argument to get the value for</param>
		/// <returns>The value passed to the argument or null</returns>
		public String ArgumentValue(String name)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns an array of strings representing arguments that were not in the form --[name]=[value] or /[name]=[value]
		/// </summary>
		/// <returns></returns>
		public String[] GetNonArgumentValues()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Parses the provided <paramref name="args"/> array into Arguments, Values and NonArgumentValues
		/// </summary>
		/// <param name="args">The arguments to parse</param>
		public void Parse(String[] args)
		{
			throw new NotImplementedException();
		}

#if NET_4_5
		/// <summary>
		/// Parses the provided <paramref name="args"/> array into Arguments, Values and NonArgumentValues
		/// </summary>
		/// <param name="args">The arguments to parse</param>
		public Task ParseAsync(String[] args)
		{
			throw new NotImplementedException();
		}
#endif
	}
}
