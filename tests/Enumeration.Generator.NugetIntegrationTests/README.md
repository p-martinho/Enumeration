# Integration tests for the PMart.Enumeration.Generator Nuget package
The idea of this project is to test the Nuget package before it is published.
It is not added to the solution.
It should use the normal integration tests (in PMart.Enumeration.Generator.IntegrationTests), referring a Nuget package in a local, temporary folder (`./artifacts`) and cache the dependencies in a temporary folder (`./packages`), to not pollute the normal Nuget caches.

## Notes
- The custom nuget config file `nuget.integration-tests.config` adds the local folder `.\artifacts` to the sources.
- After updating a "draft" version of the Nuget package, remember to delete the local cache:
    - Remove the folder `./packages/pmart.enumeration.generator`.

## Steps
1. Pack the package `PMart.Enumeration.Generator` to the folder `.\artifacts`:
    ```
    dotnet pack ../../src/Enumeration.Generator -c Release -o ./artifacts
    ```
2. To make sure we don't pollute our NuGet caches with the test package, we restore NuGet packages to a local folder, `./packages`. Restore the project using the custom config file, restoring packages to the local folder:
    ```
    dotnet restore --packages ./packages --configfile "nuget.integration-tests.config"
    ```
3. Build the project (no restore), using the packages restored to the local folder:
    ```
    dotnet build -c Release --packages ./packages --no-restore
    ```
4. Test the project (no build or restore):
    ```
    dotnet test -c Release --no-build --no-restore
    ```