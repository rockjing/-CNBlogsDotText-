@echo off

echo - Copying Web Files ...
xcopy *.gif ..\builds\release\web\ /s /y /q
xcopy *.txt ..\builds\release\web\ /s /y /q
xcopy *.aspx ..\builds\release\web\ /s /y /q
xcopy *.ascx ..\builds\release\web\ /s /y /q
xcopy *.htm* ..\builds\release\web\ /s /y /q
xcopy *.xml ..\builds\release\web\ /s /y /q
xcopy *.css ..\builds\release\web\ /s /y /q
xcopy *.js ..\builds\release\web\ /s /y /q
xcopy bin\*.dll ..\builds\release\web\bin\ /s /y /q
xcopy *.config ..\builds\release\web\ /s /y /q

