A. Instruction to run application

  1. EmpPayslipWebApp and EmployeeSalaryWebAPI both must be set as startup app.

    1.1. To set multiple startup projects:

    1.2. In the Solution Explorer, select the solution (the very top node). Right-click the node to get the context menu.

    1.3. Select Properties. The Solution Property Pages dialog box opens.

    1.4. Expand the Common Properties node, and click Startup Project.

    1.5. Click Multiple Startup Projects and set the appropriatet actions.

  2. Restore Nuget packages.
  
    2.1. Right click solution, Click Restore Nuget packages.

    2.2. Start the project

  3. Run application.

  4. At Home page, click on Go button.

  5. Fill all details and click on ‘Generate Payslip’ button to see payslip.

B. Assumptions: 

  1. Application assumption

    1.1. Project is developed using VS2017, Framework version 4.6.1. 

    1.2. User can enter any date of month in start date field. Output will show start and end date of that month . Eg: If user entered 
    21/June/2018 as start date then Pay period in output will show date as- 1 Jun 2018- 30 Jun 2018.
 
  2. Code Assumptions

    2.1. Used Abstract Factory pattern that is based country or location, I used enum to store all posibilities.

    2.2. So based on the location, Method to generate Payslip might change, that is handled using PayslipFactory.

    2.3. I have not used any database as It generates payslip dynamically according to entered employee details.

    2.4. JQuery and JQueryUI controls(datepicker) etc. are used.
  
C. Link to source code : https://github.com/uvikakhatri/EmployeeSalaryWebApp

D. Test Inputs and outputs

    1.Test Inputs and outputs are stated in Unit Test Project
