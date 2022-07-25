# Backend Coding Exercise

## How to run
### Running through Developer Command prompt for VS 2022
- Start Visual Studio 2022 and select <em>Open a project or solution</em>
- Navigate to the solution file <em>datacom_20220725\BackendCodingExercise\BackendCodingExercise.sln</em>
- Build the solution
- Place the desired csv file into <em>datacom_20220725\BackendCodingExercise</em> 
    - There is an example file there named <em>examplefile.csv</em>
- The csv should follow the format <em>(first name, last name, annual salary, super rate (%), pay period)</em>
- Open Developer Command prompt for VS 2022
- Change directory to <em>../datacom_20220725/BackendCodingExercise</em> 
- Enter command to run the program
```
dotnet run program.cs 
```
- Enter the filename of the csv 
- The csv should be processed and an output should be shown in console as well as an ouput file named <em>results.csv</em> will be generated

### Running through Visual Studio Debug
- Start Visual Studio 2022 and select <em>Open a project or solution</em>
- Navigate to the solution file <em>datacom_20220725\BackendCodingExercise\BackendCodingExercise.sln</em>
- Build the solution
- Place the desired csv file into <em>datacom_20220725\BackendCodingExercise\bin\Debug\net6.0</em> 
    - There is an example file there named <em>examplefile.csv</em>
- The csv should follow the format <em>(first name, last name, annual salary, super rate (%), pay period)</em>

- Press F5 or the play button to start debugging in Visual Studio
- Enter the filename of the csv 
- The csv should be processed and an output should be shown in console as well as an ouput file named <em>results.csv</em> will be generated

---
## Assumptions made
- The months would always be entered by their whole name and always be correct 
    - (January, February, March , April, May, June, July, August, September, October, November, December)
- An output csv file would also be wanted
- The output file named results.csv would not exist and would not be open 
- The output file would need column names because it may be read by human eyes, making it more readable and user friendly
- The formatting of the csv file would be consistent
    - Always have no spaces before and after a comma
- The super rate would always be an integer
- That the input csv file would not have a header for column names
- The input csv file's format would be static
- The super rate would always have a % symbol and would always be between 0-50
- The input for annual salary will not have a comma
