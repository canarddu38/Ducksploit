@echo off
setlocal EnableExtensions DisableDelayedExpansion 
mode con:cols=20 lines=10

REM set x_y = caracter

:: init the canva
:: ex: x_y
:: -4_3 |-3_3 |-2_3 |-1_3 |0_3 |1_3 |2_3 |3_3 |4_3
:: -4_2 |-3_2 |-2_2 |-1_2 |0_2 |1_2 |2_2 |3_2 |4_2
:: -4_1 |-3_1 |-2_1 |-1_1 |0_1 |1_1 |2_1 |3_1 |4_1
:: -4_0 |-3_0 |-2_0 |-1_0 |0_0 |1_0 |2_0 |3_0 |4_0
:: -4_-1|-3_-1|-2_-1|-1_-1|0_-1|1_-1|2_-1|3_-1|4_-1
:: -4_-2|-3_-2|-2_-2|-1_-2|0_-2|1_-2|2_-2|3_-2|4_-2
:: -4_-3|-3_-3|-2_-3|-1_-3|0_-3|1_-3|2_-3|3_-3|4_-3



set /A int=0
set /A num=0
set /A x=-5
set /A y=4

goto getfilewdbywd

:getfilewdbywd
set /A int=int+1
for /f "usebackq tokens=%int% delims=." %%y in (world.txt) do (
if int %int% => "70" (echo end&&pause) else (

if "%y%" <= "-3" (set /A x=%x%+1) else (
set /A y=%y%-1
set %x%_%y%=%%y

)
)
)
echo.
goto getfilewdbywd

endlocal




:next

REM ::line1
REM set 4_3=
REM set 3_3=
REM set 2_3=
REM set 1_3=
REM set 0_3=
REM set -1_3=
REM set -2_3=
REM set -3_3=
REM set -4_3=

REM set 1_1=
REM set 1_1=
REM set 1_1=
REM set 1_1=
REM set 1_1=







:move
cls
choice /c wasd /m ""



if "%errorlevel%"=="1" (goto up) else (
if "%errorlevel%"=="2" (goto left) else (
if "%errorlevel%"=="3" (goto down) else (
if "%errorlevel%"=="4" (goto right) else (
echo nope
)
)
)
)


:left
echo left
goto move

:right
echo right
goto move

:up
echo up
goto move

:down
echo down
goto move





REM ex: "call :newline 1 2 3 4 5 6 7 8 9 10"
call :newline 1 2 3 4 5 6 7 8 9
call :newline 1 2 3 4 5 6 7 8 9
call :newline 1 2 3 4 5 6 7 8 9
call :newline 1 2 3 4 5 6 7 8 9
call :newline 1 2 3 4 5 6 7 8 9
call :newline 1 2 3 4 5 6 7 8 9
call :newline 1 2 3 4 5 6 7 8 9
:newline
set line="%1 %1 %2 %2 %3 %3 %4 %4 %5 %5 %6 %6 %7 %7 %8 %8 %9 %9"
set line=%line: =%
echo %line%


REM title Game Engine
REM pause
REM :menu
REM cls
REM echo Game Engineaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
REM echo.
REM echo   1)compile
REM echo   2)help
REM echo   3)exit
REM echo.
REM set /p menu="Choose [1, 2, 3]: " 
REM if "%menu%"=="1" (goto start) else (
REM if "%menu%"=="2" (goto help) else (
REM if "%menu%"=="3" (goto exit) else (

REM echo [x] Bad awnser!
REM pause
REM goto menu
REM )
REM )
REM )
REM :start

REM goto:eof

REM :help

REM goto:eof

REM :exit
REM echo [x] Exit
REM exit
REM goto:eof


endlocal