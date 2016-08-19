# DNNWordCount

A DNN module that queries URLs specified by the user to determine word counts and also maintains a history of their past searches.

Open the solution in VS2015 to build - this will generate the extension package DNNWordCount\DNNWordCount\install as DNNWordCount_00.00.01_Install.

Deployment Steps:

1.  Use the Install Extension Wizard to install the package.
2.  Add a Search connection string in the DNN Site's web.config like:
        <add name="Search" connectionString="data source=.\SQLEXPRESS;initial catalog=Search;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
3. Ensure the following dlls are in the GAC(if not, extract from the DNNWordCount_00.00.01_Install package bin folder)
    EntityFramework.dll
    EntityFramework.SqlServer.dll
    HtmlAgilityPack.dll