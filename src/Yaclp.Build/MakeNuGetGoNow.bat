REM @echo off

SET SolutionDir=%1
SET BaseDir=%SolutionDir%
SET OutputDir=%BaseDir%..\NuGet
SET NuGet=%BaseDir%.nuget\NuGet.exe

cd %BaseDir%

if not exist %OutputDir%\NUL mkdir %OutputDir%

pushd %SolutionDir%Yaclp
set cmd=%NuGet% pack -Build -Prop Configuration=Release;OutputPath=bin\Release -OutputDirectory %OutputDir%
echo %cmd%
%cmd%
popd
