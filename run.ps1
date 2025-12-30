
$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 2.0

$project = Join-Path $PSScriptRoot "Nemonuri.UnsafeUnboxTest/Nemonuri.UnsafeUnboxTest.csproj" -Resolve

function Invoke-Test ([string] $Tfm) {
    Write-Host "----- TargetFramework = $Tfm -----"
    & dotnet run --project $project -p:TargetFramework=$Tfm
}

Invoke-Test net10.0

Invoke-Test net462
