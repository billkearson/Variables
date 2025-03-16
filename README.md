# Environment Variables

A simple example of using variables in c# to store information.  

* Operating System environment variables
* Variables stored in a .env file without additional libraries 

This is useful for moving from different environments such as Dev, QA, and Prod. This can be used to store confidential information but it will be in clear text and available with anyone that has machine or file access. Vaults or password managers are highly recommended for credentials and keys. Keep it secret. Keep it safe.

## Getting Started

Download or pull the repository and open the solution in Visual Studio. The provided form will display the values of the variables stored in the .env file and the operating system environment variables once entered by the user.

Operating System environment variables
Run the program and from the form set or get an environment variable. Targets can be Machine, Process, or User type variables. Experiment with these and see if they will meet your needs. I needed something that was more portable and flexible and thus went with the .env file approach below.  

Variables stored in a .env file
Create a .env file and populate it with the needed information using a Name=Value format, per line. Or copy and rename the .env-sample file to .env. Run the program, enter the variable name, and view the value. The top section of the .env grouping looks for the .env file inside the program file locations. The botton section of the .env grouping allows to user to select the .env file to be used. Example: C:\Secret\prod.env or C:\Secret\dev.env. 

## Built With

* [Microsoft Visual Studio Community 2022 (64-bit)](https://visualstudio.microsoft.com/) 
* [Microsoft .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0) 

## Conclusion

Finding flexible and secure ways to store program information is critical. There are several options available and depending on your needs several might be needed. Here, we looked at two common approaches and hopefully learned something new.  

## References

* [Microsoft's learn site. Always a good reference to start with.](https://learn.microsoft.com/en-us/dotnet/api/system.environment.getenvironmentvariable?view=net-8.0)
* [Asgarov, Kamran (2024). "Understanding Environment Variables and Configuration Files in .NET C#"](https://medium.com/@tivole/understanding-environment-variables-and-configuration-files-in-net-c-88aa8601b332)

## License

This project is licensed under the MIT License - see the LICENSE.txt file for details

* You can freely modify and reuse.
* The original license must be included with copies of this software.
* Please link back to this repo if you use the source code.
